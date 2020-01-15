using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Repository
{
    public class PaymentsStorageContext: DbContext
    {
        public DbSet<PaymentResponse> Payments { get; set; }
        public DbSet<PaymentRecord> PaymentRecords { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQL2017DEV;Database=PaymentsDB;Trusted_Connection=True;");
        }

    }
}
