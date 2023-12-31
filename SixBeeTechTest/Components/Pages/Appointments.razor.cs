﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SixBeeTechTest.Mappers;
using SixBeeTechTest.ViewModels;
using SixBeeTechTestData.Models;
using SixBeeTechTestData.Repositories;
using System.Security.Claims;

namespace SixBeeTechTest.Components.Pages
{
    public partial class Appointments
    {
        [Inject]
        private IAppointmentRepository _appointmentsRepository { get; set; } // Access to the database

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        public IEnumerable<AppointmentFormViewModel> AppointmentDetails { get; private set; } = Enumerable.Empty<AppointmentFormViewModel>();
        private ClaimsPrincipal User;
        private string ErrorMessage = string.Empty;

        // The initial page load to ensure the table is populated and set a user if there is one logged in
        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            User = authState.User;

            await base.OnInitializedAsync();

            AppointmentDetails = (await _appointmentsRepository.GetAllAppointmentsAsync()).Select(AppointmentMapper.ModelToViewModel).OrderBy(x => x.AppointmentDate);
        }

        // Takes the id of an appointment to approve and check that there is a valid user and the appointment exists
        private async Task ApproveAppointmentAsync(int id)
        {
            var appointment = await _appointmentsRepository.GetAppointmentByIdAsync(id);
            if (appointment != null && string.IsNullOrEmpty(User?.Identity?.Name))
            {
                ErrorMessage = "Invalid Approval, cancelling operation";
                return;
            }
            ErrorMessage = string.Empty;
            appointment.ApprovedBy = User?.Identity?.Name;
            await _appointmentsRepository.UpdateAppointmentAsync(appointment);
        }

        private void EditAppointment(int id)
        {
            NavigationManager.NavigateTo($"/edit-appointment/{id}");
        }
    }
}
