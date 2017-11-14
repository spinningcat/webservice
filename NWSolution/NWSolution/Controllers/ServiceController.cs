using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using NWSolution.Models;
using NWSolution.DTO;
using Microsoft.Extensions.Options;
using NWSolution.Business;
using NWSolution.DAL;

namespace NWSolution.Controllers
{
    [Produces("application/json")]
    public class ServicesController : Controller
    {
        private readonly NWSolutionContext _context;

        public ServicesController(NWSolutionContext context)
        {
            _context = context;
        }

        // GET: vector
        [HttpGet]
        [Route("vector")]
        public IActionResult GetToken()
        {
            // Register cookie
            Guid sessionId = Guid.Empty;
            Guid cookieResult = Guid.Empty;

            Guid.TryParse(Request.Cookies["session-id"], out cookieResult);

            if (cookieResult != Guid.Empty)
            {
                sessionId = cookieResult;
            }
            else
            {
                sessionId = Guid.NewGuid();

                // Set Cookie
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Append("session-id", sessionId.ToString(), options);
            }

            string token = PasswordGeneratorHelper.GetRandomAlphanumericString(16);

            SessionToken sessionToken = new SessionToken() { SessionID = sessionId, Token = token, CreatedAt = DateTime.Now };

            var session = _context.SessionToken.Where(x => x.SessionID == sessionToken.SessionID).SingleOrDefault();
            if (session != null)
            {
                session.Token = token;
            }
            else
            {
                _context.SessionToken.Add(sessionToken);
            }
            _context.SaveChanges();

            // Return token.
            return Content(sessionToken.Token);
        }

        // POST: nw
        [HttpPost]
        [Route("nw")]
        public async Task<IActionResult> PostNWSolutionDTO([FromBody] NWSolutionDTO dto)
        {
            string authHeader = Request.Headers["Authorization"].FirstOrDefault();
            Guid cookieResult = Guid.Empty;
            Guid.TryParse(Request.Cookies["session-id"], out cookieResult);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Extra...
            if (cookieResult == Guid.Empty)
            {
                //Cookie olmalı.
                return Unauthorized();
            }


            if (String.IsNullOrEmpty(authHeader))
            {
                // Auth header olmalı.
                return Unauthorized();
            }


            var tokenOnDB = _context.SessionToken.Where(x => x.SessionID == cookieResult)
                                    .Select(y => y.Token).FirstOrDefault();

            if (String.IsNullOrEmpty(tokenOnDB))
            {
                // Token not found on DB.
                return NotFound();
            }
            //Encrypt phone number.
            var decryptedValue = CryptorHelper.aes_decrypt(authHeader, tokenOnDB);


            // If client encryption is different than server encryption...
            if (dto.USERPHONENUMBER != decryptedValue)
            {
                // Auth header userphonenumber ile aes_encrypt'lenerek gelmeli.
                return Unauthorized();
            }

           
            NW nw;
          

            MapDtoToModels(dto,  out nw );

            var userToUpdate = await _context
                .nw.SingleOrDefaultAsync(s => s.id == nw.id);

            if (userToUpdate != null && await TryUpdateModelAsync<NW>(nw))
            {
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.nw.Add(nw);
                
            }

            
            await _context.SaveChangesAsync();


            return Content("Operation succesful");
            //return CreatedAtRoute("nw", new { id = solution.ID});
        }




        private void MapDtoToModels(NWSolutionDTO dto, out NW nw)
        {

            nw = new Models.NW()
            {
                //id = dto.NWID,
                user_name = dto.USERNAME,
                Longtitude = dto.LONGITUDE,
                Latitude = dto.LATITUDE,
                user_devicetype = dto.USERDEVICETYPE,
                user_email = dto.USEREMAIL,
                user_phonenumber = dto.USERPHONENUMBER,
                user_deviceversion = dto.DEVICEOSVERSION,
                deviceosversion = dto.DEVICEOSVERSION,
                problem_date = dto.PROBLEMDATE,
                problem_note = dto.PROBLEMNOTE,
                problem_type = dto.PROBLEMTYPE,
                report_date = dto.REPORTDATE,
                network = dto.NETWORKTYPE

            };
        }


        [HttpGet]
        [Route("encrypt/{phoneNumber}/with/{vector}")]
        public IActionResult EncryptPhoneNumber(string phoneNumber, string vector)
        {
            return Content(CryptorHelper.aes_encrypt(vector, phoneNumber));
        }
    }
}