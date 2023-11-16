using System.ComponentModel.DataAnnotations;

namespace SixBeeTechTest.ViewModels
{
    public class AppointmentFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public string Issue { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsApproved() => !string.IsNullOrWhiteSpace(ApprovedBy);
    }
}
