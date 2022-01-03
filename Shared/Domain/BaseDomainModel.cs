using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagementv2.Shared.Domain
{
  public abstract class BaseDomainModel
  {
    public int Id { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateUpdated { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }
  }
  public class Make: BaseDomainModel
  {
    public string Name { get; set; }
  }
  public class Model : BaseDomainModel{
    public string Name { get; set; }
  }
  public class Colour: BaseDomainModel
  {
    public string Name { get; set; }
  }
  public class Vehicle : BaseDomainModel { 
    public int Year { get; set; }
    public string LiscensePlateNumber { get; set; }
    public int MakeID { get; set; }
    public virtual Make Make { get; set; }
    public int ModelID { get; set; }
    public virtual Model Model { get; set; }
    public int ColourID { get; set; }
    public virtual Colour Colour { get; set; }
    public virtual List<Booking> Bookings { get; set; }

  }
}
