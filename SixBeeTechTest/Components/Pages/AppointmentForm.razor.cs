using SixBeeTechTest.ViewModels;
using SixBeeTechTestData.Repositories;
using SixBeeTechTest.Mappers;
using Microsoft.AspNetCore.Components;

namespace SixBeeTechTest.Components.Pages
{
    public partial class AppointmentForm
    {
        [Inject]
        private IAppointmentRepository _appointmentRepository { get; set; }
        public AppointmentFormViewModel AppointmentDetails { get; set; } = new AppointmentFormViewModel { AppointmentDate = DateTime.Today };

        public async Task SubmitAsync()
        {
            await _appointmentRepository.AddAppointmentAsync(AppointmentMapper.ViewModelToModel(AppointmentDetails));
        }
    }
}
