using Api.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository.Configurations
{
    public class CarDealershipContext : DbContext
    {
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public CarDealershipContext(DbContextOptions<CarDealershipContext> options) : base(options)
        {

        }
    }
}
