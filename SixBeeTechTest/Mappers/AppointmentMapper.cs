using SixBeeTechTest.ViewModels;
using SixBeeTechTestData.Models;

namespace SixBeeTechTest.Mappers
{
    public static class AppointmentMapper
    {
        public static AppointmentFormViewModel ModelToFormViewModel(Appointment model)
        {
            return new AppointmentFormViewModel
            {
                Id = model.Id,
                Name = model.Name,
                AppointmentDate = model.AppointmentDate,
                Issue = model.Issue,
                ContactNumber = model.ContactNumber,
                EmailAddress = model.EmailAddress,
                ApprovedBy = model.ApprovedBy
            };
        }

        public static Appointment ViewModelToModel(AppointmentFormViewModel viewModel)
        {
            return new Appointment
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                AppointmentDate = viewModel.AppointmentDate,
                Issue = viewModel.Issue,
                ContactNumber = viewModel.ContactNumber,
                EmailAddress = viewModel.EmailAddress,
                ApprovedBy = viewModel.ApprovedBy
            };
        }
    }
}
