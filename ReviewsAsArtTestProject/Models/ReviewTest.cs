using ReviewsAsArt.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ReviewsAsArtTestProject.Models
{
    public class ReviewTest
    {
        private Reviewgenre rg;
        public ReviewTest()
        {
            rg = new Reviewgenre() { Admin= new Admin() { GebruikersNaam="ck", Id="rtl"}, Score=20, Titel = "reviewgenretotaal" };
        }
        [Fact]
        public void maakCorrecteReviewAan()
        {
            Review r = new Review() { Beschrijving = "Economisch nationalisme", Rg = rg, Score = 10, Titel = "Review", Werk = new Werk() { Creatiejaar = 1998, Media = Werk.Medium.Theateruitvoering, Titel = "Hitring" } };
            Assert.Equal("Economisch nationalisme", r.Beschrijving);
            Assert.Equal(rg, r.Rg);
            Assert.Equal(10, r.Score);
            Assert.Equal("Review", r.Titel);
        }
        [Fact]
        public void gooiExceptionBijFouteReview()
        {
            Review r = new Review() { Rg = new Reviewgenre() { Score=20} };
            Assert.Throws<ArgumentException>(()=>r.Score=25);
        }

        [Fact]
        public void gooiAndereExceptionBijFouteReview()
        {
            Review r = new Review();
            Assert.Throws<ArgumentException>(() => r.Score = -5);
        }
    }
}
