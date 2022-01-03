using CarRentalManagementv2.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalManagementv2.Server.Configuration.Entities
{
  public class MakeSeedConfiguration : IEntityTypeConfiguration<Make>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Make> builder)
    {
      builder.HasData(
       new Make
       {
         Id = 1,
         Name = "BMW",
         DateCreated = DateTime.Now,
         DateUpdated = DateTime.Now,
         CreatedBy = "System",
         UpdatedBy = "System"
       },
       new Make
       {
         Id = 2,
         Name = "Toyota",
         DateCreated = DateTime.Now,
         DateUpdated = DateTime.Now,
         CreatedBy = "System",
         UpdatedBy = "System"
       }
      );


      throw new NotImplementedException();
    }
  }
}

