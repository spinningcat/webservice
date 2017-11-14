using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
namespace WebApplication2.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            inserTotheDB();
           return View();
        }
      
        public DataTable ViewTheTable()
        {
             DataTable  dTable = new DataTable();
            using (SqlConnection sConnection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NWSolution;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False "))
            {
                sConnection.Open();
                using (SqlCommand sCommand = new SqlCommand("select * from nw", sConnection))
                {
                    
                    using (SqlDataReader sDataReader = sCommand.ExecuteReader())
                    {
                        if (sDataReader.Read())
                        {
                           dTable.Load(sDataReader);                                                                                                                                               
                        }
                        
                    }
                }
                return dTable;
                

            }
        }
        public void inserTotheDB()
        {
            
           DataTable dTable = ViewTheTable();
            var view = dTable.DefaultView;
            using (SqlConnection sConnection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebApplication2Context-daa9136d-534b-4dd3-8b1f-877e022291eb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                sConnection.Open();
                using (SqlCommand sCommand = new SqlCommand("insert into Dashboard(user_name, Latitude, Longtitude, user_devicetype, user_email, user_phonenumber, user_deviceversion, deviceosversion,problem_note, problem_date, problem_type, network, report_date) values (@user_name, @Latitude, @Longtitude, @user_devicetype, @user_email, @user_phonenumber, @user_deviceversion, @deviceosversion,@problem_note, @problem_date, @problem_type, @network, @report_date)", sConnection))
                {
                    var columns = dTable.Columns;
                    sCommand.Parameters.Add(new SqlParameter("@user_name", ""));
                    sCommand.Parameters.Add(new SqlParameter("@Latitude", ""));
                    sCommand.Parameters.Add(new SqlParameter("@Longtitude", ""));
                    sCommand.Parameters.Add(new SqlParameter("@user_devicetype", ""));
                    sCommand.Parameters.Add(new SqlParameter("@user_email", ""));
                    sCommand.Parameters.Add(new SqlParameter("@user_phonenumber", ""));
                    sCommand.Parameters.Add(new SqlParameter("@user_deviceversion", ""));
                    sCommand.Parameters.Add(new SqlParameter("@deviceosversion", ""));
                    sCommand.Parameters.Add(new SqlParameter("@problem_note", ""));
                    sCommand.Parameters.Add(new SqlParameter("@problem_date", ""));
                    sCommand.Parameters.Add(new SqlParameter("@problem_type", ""));
                    sCommand.Parameters.Add(new SqlParameter("@network", ""));
                    sCommand.Parameters.Add(new SqlParameter("@report_date", ""));


                    //  sCommand.Parameters["LATITUDE"].Value = "@LATITUDE";
                    foreach (DataColumn col in dTable.Columns)
                    {
                        
                       

                        foreach (DataRow row in dTable.Rows)
                        {
                            
                            sCommand.Parameters["@user_name"].Value = row["user_name"].ToString();
                            sCommand.Parameters["@Latitude"].Value =  row["Latitude"].ToString();
                            sCommand.Parameters["@Longtitude"].Value = row["Longtitude"].ToString();
                            sCommand.Parameters["@user_devicetype"].Value = row["user_devicetype"].ToString();
                            sCommand.Parameters["@user_email"].Value = row["user_email"].ToString();
                            sCommand.Parameters["@user_phonenumber"].Value = row["user_phonenumber"].ToString();
                            sCommand.Parameters["@user_deviceversion"].Value = row["user_deviceversion"].ToString();
                            sCommand.Parameters["@deviceosversion"].Value = row["deviceosversion"].ToString();
                            sCommand.Parameters["@problem_note"].Value = row["problem_date"].ToString();
                            sCommand.Parameters["@problem_date"].Value = row["problem_note"].ToString();
                            sCommand.Parameters["@problem_type"].Value = row["problem_type"].ToString();
                            sCommand.Parameters["@network"].Value = row["network"].ToString();
                            sCommand.Parameters["@report_date"].Value = row["report_date"].ToString();
                            sCommand.ExecuteNonQuery();    
                            
                        }
                       }
                   



                }
            }
           
        }
        [HttpGet]
        [Route("Dashboard/ConstructATable")]
        public string ConstructATable(/*JsonResult jsonTable*/)
        {
            DataTable dTable = new DataTable();
            using (SqlConnection sConnection = new SqlConnection(@"
                    Data Source=(localdb)\MSSQLLocalDB;
                    Initial Catalog=WebApplication2Context-daa9136d-534b-4dd3-8b1f-877e022291eb;
                    Integrated Security=True;Connect Timeout=30;
                    Encrypt=False;TrustServerCertificate=True;
                    ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                sConnection.Open();
                var column = dTable.Columns;
                using (SqlCommand sCommand = new SqlCommand("select * from [dbo].[Dashboard]",sConnection))
                {
                    using (SqlDataReader sDataReader = sCommand.ExecuteReader())
                    {
                        if (sDataReader.Read())
                        {
                            dTable.Load(sDataReader);
                        }

                    }
                }
                var jsonTable = JsonConvert.SerializeObject(dTable);
                return jsonTable;

            }
        }
    }
}