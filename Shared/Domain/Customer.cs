using System;

namespace CarRentalManagementv2.Shared.Domain
{
  public class Customer
  {
    public string DrivingLicense { get; set; }
    public string Address { get; set; }
    public string ContactNumber { get; set; }
    public string EmailAddress { get; set; }
    public List<Booking> Bookings { get; set; }
  }
}