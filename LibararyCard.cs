using System;
using System.Collections;
namespace Assignment
{
    class LibraryCards
    {
        private string idCards;
        private string cardsName;
        private string peopleId;
        private DateTime Ngaytao;

        public LibraryCards() { }

        public LibraryCards(string idCards, string cardsName, string peopleId)
        {
            this.IdCards = idCards;
            this.CardsName = cardsName;
            this.PeopleId = peopleId;
        }

        public string IdCards { get => idCards; set => idCards = value; }
        public string CardsName { get => cardsName; set => cardsName = value; }
        public string PeopleId { get => peopleId; set => peopleId = value; }
        public DateTime Ngaytao1 { get => Ngaytao; set => Ngaytao = value; }
    }
}