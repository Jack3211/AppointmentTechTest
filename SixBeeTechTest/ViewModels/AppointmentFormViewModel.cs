using System.ComponentModel.DataAnnotations;

namespace SixBeeTechTest.ViewModels
{
    public class AppointmentFormViewModel
    {
        public int Id { get; set; }
        [Required] // Data annotations provide validation and error messages in the event of an incorrect input
        public string Name { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public string Issue { get; set; }
        [Required]
        [Phone]
        public string ContactNumber { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string ApprovedBy { get; set; } = string.Empty;
        public bool IsApproved() => !string.IsNullOrWhiteSpace(ApprovedBy);
    }
}
