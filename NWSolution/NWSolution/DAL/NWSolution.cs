using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NWSolution.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NWSolution.DAL
{
    public class NWSolutionContext : DbContext
    {
        

        public NWSolutionContext(DbContextOptions<NWSolutionContext>options)
            : base(options)
        {
        }

        public DbSet<NW> nw { get; set; }
        public DbSet<SessionToken> SessionToken { get; set; }
       
        
    }
}
