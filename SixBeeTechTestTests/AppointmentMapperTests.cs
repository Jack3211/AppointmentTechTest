using SixBeeTechTest.Mappers;
using SixBeeTechTestData.Models;

namespace SixBeeTechTestTests
{
    [TestClass]
    public class AppointmentMapperTests
    {
        [TestMethod]
        public void WhenModelIsConvertedToViewModel_IsApprovedShouldBeTrueWhenApprovedByIsNotEmpty()
        {
            //Arrange
            var model = new Appointment()
            {
                ApprovedBy = "test",
            };

            //Act
            var viewModel = AppointmentMapper.ModelToViewModel(model);

            //Assert
            Assert.IsTrue(viewModel.IsApproved());
        }

        [TestMethod]
        public void WhenModelIsConvertedToViewModel_IsApprovedShouldBeFalseWhenApprovedByIsEmpty()
        {
            //Arrange
            var model = new Appointment()
            {
                ApprovedBy = string.Empty,
            };

            //Act
            var viewModel = AppointmentMapper.ModelToViewModel(model);

            //Assert
            Assert.IsFalse(viewModel.IsApproved());
        }
    }
}