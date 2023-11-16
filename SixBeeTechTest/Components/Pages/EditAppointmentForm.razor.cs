using SixBeeTechTest.ViewModels;
using SixBeeTechTestData.Repositories;
using SixBeeTechTest.Mappers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace SixBeeTechTest.Components.Pages
{
    public partial class EditAppointmentForm
    {
        [Inject]
        private IAppointmentRepository _appointmentRepository { get; set; }

        public AppointmentFormViewModel AppointmentDetails { get; private set; } = new AppointmentFormViewModel { AppointmentDate = DateTime.Today };

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        private ClaimsPrincipal User;

        [Parameter]
        public string AppointmentIdFromUrl { get; set; }

        protected override async Task OnInitializedAsync() // The initial page load to ensure the form is populated and set a user if there is one logged in
        {
            int.TryParse(AppointmentIdFromUrl, out var AppointmentId);
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            User = authState.User;

            await base.OnInitializedAsync();

            AppointmentDetails = AppointmentMapper.ModelToViewModel(await _appointmentRepository.GetAppointmentByIdAsync(AppointmentId));
        }


        // Updates the AppointmentCreated property so that the user gets a different display screen of their appointment details
        public async Task SubmitAsync()
        {
            await _appointmentRepository.UpdateAppointmentAsync(AppointmentMapper.ViewModelToModel(AppointmentDetails));
        }
    }
}
