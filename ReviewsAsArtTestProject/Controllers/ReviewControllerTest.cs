using ReviewsAsArtTestProject.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using ReviewsAsArt.Models;
using Xunit;
using ReviewsAsArt.Controllers;

namespace ReviewsAsArtTestProject.Controllers
{
    public class ReviewControllerTest
    {
        private DummyApplicationDbContext dadc;
        private Mock<IReviewRepository> mirr;
        private ReviewController rc;
        private Reviewgenre rg;

        public ReviewControllerTest()
        {
            dadc = new DummyApplicationDbContext();
            mirr = new Mock<IReviewRepository>();
            rc = new ReviewController(mirr.Object);
        }

        [Fact]
        public void returnReviews()
        {
            mirr.Setup(s => s.GetReviews()).Returns(dadc.reviews);
            Assert.Equal(dadc.reviews, rc.GetReviews());
        }
    }
}
