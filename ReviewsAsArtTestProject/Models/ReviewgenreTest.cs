
using ReviewsAsArt.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ReviewsAsArtTestProject.Models
{
    public class ReviewgenreTest
    {
        [Fact]
        public void maakCorrectReviewgenreAan()
        {
            Reviewgenre rg = new Reviewgenre() {Admin = new Admin() { GebruikersNaam="spd",Id="dsp"},Score = 10, Titel="Totale Score" };
            Assert.Equal(10,rg.Score);
            Assert.Equal("Totale Score", rg.Titel);
        }
        [Fact]
        public void gooiExceptionBijFouteScore()
        {
            Reviewgenre rg = new Reviewgenre();
            Assert.Throws<ArgumentException>(()=>rg.Score=-5);
        }
    }
}
