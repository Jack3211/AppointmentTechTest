using Microsoft.AspNetCore.Components;
using SixBeeTechTest.Mappers;
using SixBeeTechTest.ViewModels;
using SixBeeTechTestData.Repositories;

namespace SixBeeTechTest.Components.Pages
{
    public partial class Appointments
    {
        [Inject]
        private IAppointmentRepository _appointmentsRepository {  get; set; }

        public IEnumerable<AppointmentFormViewModel> AppointmentDetails { get; private set; } = Enumerable.Empty<AppointmentFormViewModel>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            AppointmentDetails = (await _appointmentsRepository.GetAllAppointmentsAsync()).Select(AppointmentMapper.ModelToFormViewModel);
        }
    }
}
