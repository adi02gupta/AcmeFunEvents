// Author : Aditya Gupta
using AcmeFunEvents.Controllers;
using AcmeFunEvents.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Testing
{
    public class UserActivityTest
    {
        AcmeFunEventsContext _context = new AcmeFunEventsContext();
        private static Random random = new Random();

        [Fact]
        public async Task ValidateViewDataMessage_Success_Async()
        {
            // Arrange
            UserActivityController controller = new UserActivityController(_context);

            // Act
            ViewResult result = await controller.Index() as ViewResult;

            // Assert
            Assert.Equal("List of all signed up employee's is retreived successfully.", result.ViewData["Message"]);
        }

        [Fact]
        public async Task SignUp_Success_Async()
        {
            // Arrange
            UserActivityController controller = new UserActivityController(_context);

            UserActivity ua = new UserActivity()
            {
                FirstName = RandomString(8),
                LastName = RandomString(8),
                Email = RandomString(8) + "@gmail.com",
                Phone = RandomString(3) + "-" + RandomString(3) + "-" + RandomString(4),
                ActivityId = 1
            };


            // Act
            ViewResult result = await controller.Create(ua) as ViewResult;
            ViewResult indexResult = await controller.Index() as ViewResult;
            List<UserActivity> listSignedUpUsers = (List<UserActivity>)indexResult.Model;

            // Assert
            Assert.Equal(ua.Email, listSignedUpUsers.FirstOrDefault(u => u.Email == ua.Email).Email);
        }

        [Fact]
        public async Task SignUp_Failure_Async()
        {
            // Arrange
            UserActivityController controller = new UserActivityController(_context);

            UserActivity ua = new UserActivity()
            {
                FirstName = RandomString(8),
                ActivityId = 1
            };

            // Act
            ViewResult result = await controller.Create(ua) as ViewResult;
            ViewResult indexResult = await controller.Index() as ViewResult;
            List<UserActivity> listSignedUpUsers = (List<UserActivity>)indexResult.Model;

            // Assert
            Assert.Null(listSignedUpUsers.FirstOrDefault(u => u.FirstName == ua.FirstName));
        }

        // Method to generate a random alphanumberic character.
        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
