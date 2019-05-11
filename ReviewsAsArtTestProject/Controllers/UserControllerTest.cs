using Moq;
using ReviewsAsArt.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ReviewsAsArt.Controllers;
using ReviewsAsArtTestProject.Data;
using Xunit;

namespace ReviewsAsArtTestProject.Controllers
{
    public class UserControllerTest
    {
        private DummyApplicationDbContext dadc;
        private Mock<IUserStore<User>> mius;
        private UserManager<User> umu;
        private SignInManager<User> simu;
        private Mock<IUserRepository> miur;
        private Mock<IConfiguration> mic;
        private UserController uc;
        public UserControllerTest()
        {
            dadc = new DummyApplicationDbContext();
            mius = new Mock<IUserStore<User>>();
            umu = new UserManager<User>(mius.Object, null, null, null, null, null, null, null, null);
            simu = new SignInManager<User>(umu, null, null, null, null, null);
            miur = new Mock<IUserRepository>();
            mic = new Mock<IConfiguration>();
            uc = new UserController(simu, umu, miur.Object, mic.Object);
        }

        [Fact]
        public void geefUsersWeer()
        {
            miur.Setup(s => s.GetUsers()).Returns(dadc.users);
            Assert.Equal(uc.GetUsers(), dadc.users);
        }
    }
}
