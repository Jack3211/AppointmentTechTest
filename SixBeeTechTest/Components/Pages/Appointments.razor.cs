using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SixBeeTechTest.Mappers;
using SixBeeTechTest.ViewModels;
using SixBeeTechTestData.Repositories;
using System.Security.Claims;

namespace SixBeeTechTest.Components.Pages
{
    public partial class Appointments
    {
        [Inject]
        private IAppointmentRepository _appointmentsRepository {  get; set; }

        public IEnumerable<AppointmentFormViewModel> AppointmentDetails { get; private set; } = Enumerable.Empty<AppointmentFormViewModel>();

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        private ClaimsPrincipal User;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            User = authState.User;

            await base.OnInitializedAsync();

            AppointmentDetails = (await _appointmentsRepository.GetAllAppointmentsAsync()).Select(AppointmentMapper.ModelToViewModel);
        }

        private async Task ApproveAppointmentAsync(int id)
        {
            var appointment = AppointmentDetails.FirstOrDefault(x => x.Id == id);
            if (appointment == null && string.IsNullOrEmpty(User?.Identity?.Name))
            {
                throw new Exception("Appointment Not Found");
            }
            appointment.ApprovedBy = User?.Identity?.Name;
            await _appointmentsRepository.UpdateAppointmentAsync(AppointmentMapper.ViewModelToModel(appointment));
        }
    }
}
