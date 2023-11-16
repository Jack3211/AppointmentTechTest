using System.ComponentModel.DataAnnotations;

namespace SixBeeTechTestData.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Issue { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ApprovedBy { get; set; }

    }
}
