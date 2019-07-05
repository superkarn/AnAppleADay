using A3D.Library.Models;
using A3D.Library.Services.Interfaces;
using A3D.Library.Services.LookUp;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace A3D.Tests.Library.Services.LookUp
{
    public class LookUpServiceTests
    {
        private readonly ILookUpService _lookUpService;

        public LookUpServiceTests()
        {
            this._lookUpService = new LookUpService();
        }

        [Fact]
        public void GetAll_ShouldReturnAllLookUpValues()
        {
            // Arrange
            ApplicationContext fakeContext = null;
            string ACTIVITY_PRIVACIES = "ActivityPrivacies";
            string ACTIVITY_INSTANCE_STATUSES = "ActivityInstanceStatuses";
            string NOTIFICATION_TYPES = "NotificationTypes";

            // Act
            var result = this._lookUpService.GetAll(fakeContext);

            // Assert
            Assert.NotNull(result[ACTIVITY_PRIVACIES]);
            Assert.NotNull(result[ACTIVITY_INSTANCE_STATUSES]);
            Assert.NotNull(result[NOTIFICATION_TYPES]);
        }
    }
}
