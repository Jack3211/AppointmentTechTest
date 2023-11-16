using SixBeeTechTest.ViewModels;
using SixBeeTechTestData.Repositories;
using SixBeeTechTest.Mappers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace SixBeeTechTest.Components.Pages
{
    public partial class AppointmentForm
    {
        [Inject]
        private IAppointmentRepository _appointmentRepository { get; set; }

        public AppointmentFormViewModel AppointmentDetails { get; private set; } = new AppointmentFormViewModel { AppointmentDate = DateTime.Today };

        private bool AppointmentCreated = false;

        public async Task SubmitAsync()
        {
            AppointmentCreated = true;
            await _appointmentRepository.AddAppointmentAsync(AppointmentMapper.ViewModelToModel(AppointmentDetails));
        }
    }
}
