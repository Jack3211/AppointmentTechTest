using SixBeeTechTest.ViewModels;

namespace SixBeeTechTest.Components.Pages
{
    public partial class AppointmentForm
    {
        public AppointmentFormViewModel AppointmentDetails { get; set; } = new AppointmentFormViewModel { AppointmentDate = DateTime.Today };

        public async Task SubmitAsync()
        {
            //await Repository.AddAppointmentAsync(AppointmentDetails);
        }
    }
}
