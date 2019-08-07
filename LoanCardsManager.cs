using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment
{
    class LoanCardManager
    {
        static List<LoanCard> ListLoanCard = new List<LoanCard>();
        public void DisplayLoanCard()
        {
            while (true)
            {
                Menu Menu = new Menu();
                Console.Clear();
                Console.WriteLine("=======================================\n");
                Console.WriteLine("Quan ly the muon sach\n");
                Console.WriteLine("1. Tao moi the muon sach");
                Console.WriteLine("2. Tra sach");
                Console.WriteLine("3. Hien thi the muon sach theo ngay muon");
                Console.WriteLine("4. Hien thi the theo nguoi muon");
                Console.WriteLine("0. Tro ve Menu chinh\n");
                Console.Write("#Chon : ");
                int number;
                while (true)
                {
                    bool isINT = Int32.TryParse(Console.ReadLine(), out number);
                    if (!isINT)
                    {
                        Console.WriteLine("Nhap sai !");
                        Console.Write("#Chon : ");
                    }
                    else if (number < 0 || number > 4)
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
                        addLoanCard();
                        break;
                    case 2:
                        GiveBookBack();
                        break;
                    case 3:
                        BorrowBookinDay();
                        break;
                    case 4:
                        BorrowBookinPeople();
                        break;
                    case 0:
                        Menu.MENU();
                        break;
                }
            }
        }
        public void addLoanCard()
        {
            Console.Clear();
            LoanCard LoanCardmng = new LoanCard();
            LibraryCardsManager library = new LibraryCardsManager();
            BookManager book = new BookManager();
            List<LibraryCards> listCard = library.getListCard();
            List<Book> listBook = book.getListBook();
            Console.WriteLine("========== Tao moi the muon sach trong ngay ========\n");
            if (listCard.Count == 0)
            {
                Console.WriteLine("Danh sach the thu vien trong !");
                Console.Write("Ban co muon them moi mot the thu vien ? (Y/N): ");
                string Question;
                while (true)
                {
                    Question = Console.ReadLine();
                    if (Question == "Y" || Question == "N" || Question == "y" || Question == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Ban co muon them moi mot the thu vien ? (Y/N): ");
                    }
                }
                switch (Question)
                {
                    case "Y":
                        library.AddCard();
                        break;
                    case "y":
                        library.AddCard();
                        break;
                    case "N":
                        break;
                    case "n":
                        break;
                }
            }
            else if (listBook.Count == 0)
            {
                Console.WriteLine("Danh sach trong !");
                Console.Write("Ban co muon them moi mot quyen sach ? (Y/N): ");
                string Question;
                while (true)
                {
                    Question = Console.ReadLine();
                    if (Question == "Y" || Question == "N" || Question == "y" || Question == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Ban co muon them moi mot quyen sach ? (Y/N): ");
                    }
                }
                switch (Question)
                {
                    case "Y":
                        book.AddBook();
                        break;
                    case "y":
                        book.AddBook();
                        break;
                    case "N":
                        break;
                    case "n":
                        break;
                }
            }
            else
            {
                Console.Write("- Nhap ma the: ");
                while (true)
                {
                    string name = Console.ReadLine();
                    Regex regex = new Regex(@"^[a-zA-Z0-9 ]+$");
                    if (ListLoanCard.FindIndex(x => x.IdLoanCard == name) == -1)
                    {
                        if (regex.IsMatch(name))
                        {
                            LoanCardmng.IdLoanCard = name;
                            break;
                        }
                    }
                    else
                    {
                        Console.Write("Ma the da ton tai, nhap lai: ");
                    }
                }
                Console.Write("- Nhap ma the thu vien: ");
                while (true)
                {
                    string name = Console.ReadLine();
                    Regex regex = new Regex(@"^[a-zA-Z0-9 ]+$");
                    int index1 = listCard.FindIndex(x => x.IdCards == name);
                    if (index1 != -1)
                    {
                        if (regex.IsMatch(name))
                        {
                            LoanCardmng.Cards = listCard[index1];
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nhap sai!");
                            Console.Write("Nhap lai: ");
                        }
                    }
                    else
                    {
                        Console.Write("Ma the thu vien khong ton tai, nhap lai: ");
                    }
                }
                Console.Write("- Nhap ten sach muon: ");
                int index;
                while (true)
                {
                    string name = Console.ReadLine();
                    Regex regex = new Regex(@"^[a-zA-Z0-9 ]+$");
                    index = listBook.FindIndex(x => x.BookName == name);
                    if (index != -1)
                    {
                        if (listBook[index].Count < 1)
                        {
                            Console.WriteLine("Da het sach!");
                            Console.Write("Ban muon nhap lai ten sach khong?(Y/N):");
                            string Question;
                            while (true)
                            {
                                Question = Console.ReadLine();
                                if (Question == "Y" || Question == "N" || Question == "y" || Question == "n")
                                {
                                    break;
                                }
                            }
                            switch (Question)
                            {
                                case "Y":
                                    Console.Write("- Nhap ten sach muon: ");
                                    continue;
                                case "y":
                                    Console.Write("- Nhap ten sach muon: ");
                                    continue;
                                case "N":
                                    DisplayLoanCard();
                                    break;
                                case "n":
                                    DisplayLoanCard();
                                    break;
                            }
                        }
                        else
                        {
                            if (regex.IsMatch(name))
                            {
                                LoanCardmng.BookName = name;
                                LoanCardmng.BookId = listBook[index].BookId;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Nhap sai ten sach!");
                                Console.Write("- Nhap ten sach muon: ");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ten sach khong ton tai!");
                        Console.Write("- Nhap ten sach muon: ");
                    }
                }
                Console.Write($"- Ma sach: {listBook[index].BookId}");
                Console.WriteLine(" ");
                Console.Write("Ban muon them the muon sach?(Y/N): ");
                string Question1;
                while (true)
                {
                    Question1 = Console.ReadLine();
                    if (Question1 == "Y" || Question1 == "N" || Question1 == "y" || Question1 == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Ban muon them the muon sach?(Y/N): ");
                    }
                }
                switch (Question1)
                {
                    case "Y":
                        Console.WriteLine("Da them the muon sach!");
                        LoanCardmng.Thoigian1 = DateTime.Now;
                        listBook[index].Count = listBook[index].Count - 1;
                        ListLoanCard.Add(LoanCardmng);
                        Console.ReadKey();
                        break;
                    case "y":
                        Console.WriteLine("Da them the muon sach!");
                        LoanCardmng.Thoigian1 = DateTime.Now;
                        listBook[index].Count = listBook[index].Count - 1;
                        ListLoanCard.Add(LoanCardmng);
                        Console.ReadKey();
                        break;
                    case "N":
                        break;
                    case "n":
                        break;
                }
            }
        }
        public void GiveBookBack()
        {
            Console.Clear();
            LoanCard LoanCardmng = new LoanCard();
            LibraryCardsManager library = new LibraryCardsManager();
            BookManager book = new BookManager();
            List<LibraryCards> listCard = library.getListCard();
            List<Book> listBook = book.getListBook();
            Console.WriteLine("============== Tra sach ===============\n");
            Console.Write("- Nhap ma the muon: ");
            int index;
            while (true)
            {
                string id = Console.ReadLine();
                index = ListLoanCard.FindIndex(x => x.IdLoanCard == id);
                Regex regex = new Regex(@"^[a-zA-Z0-9 ]+$");
                if (index != -1)
                {
                    if (regex.IsMatch(id))
                    {
                        ListLoanCard[index].IdLoanCard = id;
                        break;
                    }
                }
                else
                {
                    Console.Write("Ma the khong ton tai, nhap lai: ");
                }
            }
            Console.WriteLine("=======================================\n");
            Console.WriteLine("- Ma the thu vien: " + ListLoanCard[index].Cards.IdCards);
            Console.WriteLine("- Ten chu the: " + ListLoanCard[index].Cards.CardsName);
            Console.WriteLine("- Ten sach muon: " + ListLoanCard[index].BookName);
            Console.Write("Ban muon tra sach?(Y/N): ");
            string Question;
            while (true)
            {
                Question = Console.ReadLine();
                if (Question == "Y" || Question == "N" || Question == "y" || Question == "n")
                {
                    break;
                }
                else
                {
                    Console.Write("Ban muon tra sach?(Y/N): ");
                }
            }
            switch (Question.ToLower())
            {
                case "y":
                    Console.WriteLine("Tra sach thanh cong!");
                    listBook[index].Count = listBook[index].Count + 1;
                    ListLoanCard[index].ThoigianNull1 = DateTime.Now;
                    Console.ReadKey();
                    break;
                case "n":
                    break;
            }
        }
        public void BorrowBookinDay()
        {
            Console.Clear();
            LoanCard LoanCardmng = new LoanCard();
            LibraryCardsManager library = new LibraryCardsManager();
            BookManager book = new BookManager();
            List<LibraryCards> listCard = library.getListCard();
            List<Book> listBook = book.getListBook();
            Console.WriteLine("======= The muon sach trong ngay ========\n");
            Console.Write("- Nhap ngay: ");
            string Date;
            while (true)
            {
                Date = Console.ReadLine();
                string regexEmail = @"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$";
                if (Regex.IsMatch(Date, regexEmail) != true)
                {
                    Console.WriteLine("Nhap sai, nhap theo dinh dang dd/MM/yyyy !");
                    Console.Write("- Nhap ngay: ");
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("=======================================\n");
            var table = new ConsoleTable("Ma the", "Ma the thu vien", "Gio tao", "Gio tra", "Ten sach");
            foreach (var item in ListLoanCard)
            {
                string time = $"{item.Thoigian1.Day.ToString("00")}/{item.Thoigian1.Month.ToString("00")}/{item.Thoigian1.Year.ToString("0000")}";
                if (Date == time)
                {
                    table.AddRow(item.IdLoanCard, item.Cards.IdCards, item.Thoigian1.ToString("hh:mm tt"), item.ThoigianNull1?.ToString("hh:mm tt"), item.BookName);
                }
            }
            table.Write(Format.Alternative);
            Console.Write("Nhan phim bat ki de quay lai !");
            Console.ReadKey();
        }
        public void BorrowBookinPeople()
        {
            Console.Clear();
            LoanCard LoanCardmng = new LoanCard();
            LibraryCardsManager library = new LibraryCardsManager();
            BookManager book = new BookManager();
            List<LibraryCards> listCard = library.getListCard();
            List<Book> listBook = book.getListBook();
            Console.WriteLine("========== The muon sach cua ban doc ==========\n");
            Console.Write("- Nhap ma the thu vien: ");
            int index1;
            while (true)
            {
                string name = Console.ReadLine();
                index1 = listCard.FindIndex(x => x.IdCards == name);
                Regex regex = new Regex(@"^[a-zA-Z0-9 ]+$");
                if (index1 != -1)
                {
                    if (regex.IsMatch(name))
                    {
                        LoanCardmng.Cards = listCard[index1];
                        LoanCardmng.BookName = listBook[index1].BookName;
                        LoanCardmng.Cards.CardsName = listCard[index1].CardsName;
                        LoanCardmng.Thoigian1 = ListLoanCard[index1].Thoigian1;
                        LoanCardmng.ThoigianNull1 = ListLoanCard[index1].ThoigianNull1;
                        break;
                    }
                }
                else
                {
                    Console.Write("Ma the khong ton tai, nhap lai: ");
                }
            }
            Console.WriteLine($"- Ten nguoi muon: {listCard[index1].CardsName}");
            Console.WriteLine(" ");
            Console.WriteLine("===============================================\n");
            var table = new ConsoleTable("Gio muon", "Gio tra", "Ten sach");
            foreach (var item in ListLoanCard)
            {
                table.AddRow(item.Thoigian1.ToString("hh:mm tt"), item.ThoigianNull1?.ToString("hh:mm tt"), item.BookName);
            }
            table.Write(Format.Alternative);
            Console.Write("Nhan phim bat ki de quay lai !");
            Console.ReadKey();
        }
        static public void _addLoanCard(LoanCard card)
        {
            ListLoanCard.Add(card);
        }
    }
}