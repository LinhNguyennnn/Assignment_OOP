using System;
using System.Collections;
namespace Assignment
{
    class Menu
    {
        public void MENU()
        {
            Console.Clear();
            Console.WriteLine("---- Chao mung den voi thu vien VTCA ----\n");
            Console.WriteLine("=======================================\n");
            Console.WriteLine("1. Quan ly sach");
            Console.WriteLine("2. Quan ly the thu vien");
            Console.WriteLine("3. Quan ly the muon sach");
            Console.WriteLine("0. Thoat\n");
            Console.Write("#Chon : ");
            int number;
            while (true)
            {
                bool check = Int32.TryParse(Console.ReadLine(), out number);
                if (check == false)
                {
                    Console.WriteLine("Nhap sai !");
                    Console.Write("#Chon : ");
                }
                else if (number < 0 || number > 3)
                {
                    Console.WriteLine("Nhap sai !");
                    Console.Write("#Chon : ");
                }
                else
                {
                    break;
                }
            }
            switch (number)
            {
                case 1:
                    BookManager books = new BookManager();
                    books.DisplayMenuManegerBook();
                    break;
                case 2:
                    LibraryCardsManager Cards = new LibraryCardsManager();
                    Cards.DisplayLibraryCards();
                    break;
                case 3:
                    LoanCardManager Borrow = new LoanCardManager();
                    Borrow.DisplayLoanCard();
                    break;
                case 0:
                    break;
            }
        }
    }
}