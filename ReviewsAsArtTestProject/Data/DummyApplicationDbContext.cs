using ReviewsAsArt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewsAsArtTestProject.Data
{
    public class DummyApplicationDbContext
    {
        public IEnumerable<User> users;
        public IEnumerable<Review> reviews;
        public IEnumerable<Reviewgenre> reviewgenres;
        public IEnumerable<Werk> werken;

        public DummyApplicationDbContext()
        {
            User user1 = new User() { Berichten = { new Bericht() { Titel = "a", Inhoud = "Dit is de letter a." }, new Bericht() { Titel = "b", Inhoud = "Dit is de letter b"} } };
            User user2 = new User() { Berichten = { new Bericht() { Titel = "Iets nieuws", Inhoud = "Dit is iets nieuws." } } };
            user1.Users.Add(user2);
            user1.Subscribers = 0;
            user2.Subscribers = 1;
            users = new[] { user1, user2 };
            Commentaar commentaar1 = new Commentaar() { Beschrijving = "Dit is goed"};
            Commentaar commentaar2 = new Commentaar() { Beschrijving = "Dit is slecht"};
            Commentaar commentaar3 = new Commentaar() { Beschrijving = "Dit is middelmatig"};
            Werk werk = new Werk() { Creatiejaar = 1999, Media = Werk.Medium.Album, Titel="The Last temptation of Muhammad" };
            Werk werk2 = new Werk() { Creatiejaar = 2008, Media = Werk.Medium.Boek, Titel = "De la grammairologie" };
            Reviewgenre rg = new Reviewgenre() { Admin = new Admin() { GebruikersNaam = "nta", Id = "apodk" }, GeblokkeerdeUserIDs = { "cdk", "mdk" }, Regels = { "Wees beleefd. " }, Score = 20, Titel = "Dommerik" };
            Reviewgenre rga = new Reviewgenre() { Admin = new Admin() { GebruikersNaam = "ask", Id = "iron" }, Regels = { "Alles mag. " }, Score = 50, Titel="Tot 50" };
            Review review1 = new Review() { Beschrijving = "Dit is een analyse van X", Commentaars = { commentaar1, commentaar2}, Score = 8, Rg = rg, Titel="Dit was een leuk werk. " };
            Review review2 = new Review() { Beschrijving = "De review", Commentaars = { commentaar3 }, Score = 50, };
            reviews = new[] { review1, review2 };
            reviewgenres = new[] { rg, rga };
            werken = new[] { werk, werk2 };
        }
    }
}
