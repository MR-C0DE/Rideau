#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rideau.Models;

namespace Rideau.Data
{
    public class RideauContext : DbContext
    {
        public RideauContext (DbContextOptions<RideauContext> options)
            : base(options)
        {
        }

        public DbSet<Rideau.Models.ClientVO> ClientVO { get; set; }

        public DbSet<Rideau.Models.LivreVO> LivreVO { get; set; }
    }
}
