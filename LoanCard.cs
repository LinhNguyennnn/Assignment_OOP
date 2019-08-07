using System;
namespace Assignment
{
    class LoanCard : Book
    {
        private string idLoanCard;
        private LibraryCards cards;
        private DateTime Thoigian;
        private DateTime? ThoigianNull;

        public LoanCard() { }

        public LoanCard(string idLoanCard, LibraryCards cards, DateTime thoigian, DateTime? thoigianNull)
        {
            this.IdLoanCard = idLoanCard;
            this.Cards = cards;
            Thoigian1 = thoigian;
            ThoigianNull1 = thoigianNull;
        }

        public string IdLoanCard { get => idLoanCard; set => idLoanCard = value; }
        public DateTime Thoigian1 { get => Thoigian; set => Thoigian = value; }
        public DateTime? ThoigianNull1 { get => ThoigianNull; set => ThoigianNull = value; }
        public LibraryCards Cards { get => cards; set => cards = value; }
    }
}