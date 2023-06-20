using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer { Id = 1, Name = "Yunus", Surname = "KAYA" },
                new Customer { Id = 2, Name = "Serkan", Surname = "DEMİR" },
                new Customer { Id = 3, Name = "Demir", Surname = "OLCAY" }
                );
        }
    }
}