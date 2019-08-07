using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Assignment
{
    class BookManager
    {
        static List<Book> listBooks = new List<Book>();
        public void DisplayMenuManegerBook()
        {
            while (true)
            {
                Menu Menu = new Menu();
                Console.Clear();
                Console.WriteLine("=======================================\n");
                Console.WriteLine("Quan ly sach\n");
                Console.WriteLine("1. Xem danh sach sach");
                Console.WriteLine("2. Cap nhat thong tin sach");
                Console.WriteLine("3. Them moi mot quyen sach");
                Console.WriteLine("0. Tro ve MENU chinh\n");
                Console.Write("#Chon : ");
                int number;
                while (true)
                {
                    bool isINT = Int32.TryParse(Console.ReadLine(), out number);
                    if (!isINT)
                    {
                        Console.WriteLine("Nhap lai !");
                        Console.Write("#Chon : ");
                    }
                    else if (number < 0 || number > 3)
                    {
                        Console.WriteLine("Nhap lai !");
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
                        DisplayListBook();
                        break;
                    case 2:
                        UpdateBook();
                        break;
                    case 3:
                        AddBook();
                        break;
                    case 0:
                        Menu.MENU();
                        break;
                }
            }
        }
        public void DisplayListBook()
        {
            Console.Clear();
            Console.WriteLine("=======================================\n");
            Console.WriteLine("Danh sach sach\n");
            Console.WriteLine("=======================================\n");
            var table = new ConsoleTable("Ma sach", "Ten sach", "Ten tac gia", "So luong", "Danh muc");
            foreach (var item in listBooks)
            {
                table.AddRow(item.BookId, item.BookName, item.Author, item.Count, item.Category);
            }
            table.Write(Format.Alternative);
            Console.Write("Nhan phim bat ki de quay lai !");
            Console.ReadKey();
        }
        public void AddBook()
        {
            Console.Clear();
            Console.Write("- Nhap ma sach: ");
            Book book = new Book();
            while (true)
            {
                string id = Console.ReadLine();
                Regex regex = new Regex(@"^[a-zA-Z0-9 ]+$");
                if (listBooks.FindIndex(x => x.BookId == id) == -1)
                {
                    if (regex.IsMatch(id))
                    {
                        book.BookId = id;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nhap sai !");
                        Console.Write("- Nhap ma sach: ");
                    }
                }
                else
                {
                    Console.WriteLine("Ma sach da ton tai !");
                    Console.Write("- Nhap ma sach: ");
                }
            }
            Console.Write("- Nhap ten sach: ");
            while (true)
            {
                string name = Console.ReadLine();
                Regex regex = new Regex(@"^[a-zA-Z0-9 ]+$");
                if (listBooks.FindIndex(x => x.BookName == name) == -1)
                {
                    if (regex.IsMatch(name))
                    {
                        book.BookName = name;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nhap sai !");
                        Console.Write("- Nhap ten sach: ");
                    }
                }
                else
                {
                    Console.WriteLine("Ten sach da ton tai !");
                    Console.Write("- Nhap ten sach: ");
                }
            }
            Console.Write("- Nhap ten tac gia: ");
            while (true)
            {
                string tg = Console.ReadLine();
                Regex regex = new Regex(@"^[a-zA-Z ]+$");
                if (regex.IsMatch(tg))
                {
                    book.Author = tg;
                    break;
                }
                else
                {
                    Console.WriteLine("Nhap sai !");
                    Console.Write("- Nhap ten tac gia: ");
                }
            }
            Console.Write("- Nhap so luong: ");
            while (true)
            {
                int number;
                bool check = Int32.TryParse(Console.ReadLine(), out number);
                if (check == true)
                {
                    if (number > 0)
                    {
                        book.Count = number;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nhap sai !");
                        Console.Write("- Nhap so luong: ");
                    }
                }
                else
                {
                    Console.WriteLine("Nhap sai !");
                    Console.Write("- Nhap so luong: ");
                }
            }
            Console.Write("- Nhap danh muc: ");
            while (true)
            {
                string danhmuc = Console.ReadLine();
                Regex regex = new Regex(@"^[a-zA-Z0-9 ]+$");
                if (regex.IsMatch(danhmuc))
                {
                    book.Category = danhmuc;
                    break;
                }
                else
                {
                    Console.WriteLine("Nhap sai !");
                    Console.Write("- Nhap danh muc: ");
                }
            }
            Console.WriteLine(" ");
            Console.Write("Ban muon them sach?(Y/N): ");
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
                    Console.Write("Ban muon them sach?(Y/N): ");
                }
            }
            switch (Question)
            {
                case "Y":
                    Console.WriteLine("Da them sach !");
                    listBooks.Add(book);
                    Console.ReadKey();
                    break;
                case "y":
                    Console.WriteLine("Da them sach !");
                    listBooks.Add(book);
                    Console.ReadKey();
                    break;
                case "N":
                    break;
                case "n":
                    break;
            }
        }

        public void UpdateBook()
        {
            Console.Clear();
            Book book = new Book();
            if (listBooks.Count == 0)
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
                        AddBook();
                        break;
                    case "y":
                        AddBook();
                        break;
                    case "N":
                        break;
                    case "n":
                        break;
                }
            }
            else
            {
                Console.Clear();
                int item;
                Console.Write("- Nhap ma sach: ");
                while (true)
                {
                    book.BookId = Console.ReadLine();
                    if (listBooks.FindIndex(x => x.BookId == book.BookId) != -1)
                    {
                        item = listBooks.FindIndex(x => x.BookId == book.BookId);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ma sach khong ton tai!");
                        Console.Write("- Nhap ma sach: ");
                    }
                }
                Console.Write("- Sua ten sach: ");
                while (true)
                {
                    string name = Console.ReadLine();
                    Regex regex = new Regex(@"^[a-zA-Z0-9 ]+$");
                    if (listBooks.FindIndex(x => x.BookName == name) == -1)
                    {
                        if (regex.IsMatch(name))
                        {
                            book.BookName = name;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nhap sai !");
                            Console.Write("- Sua ten sach: ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ten sach da ton tai!");
                        Console.Write("- Nhap ten sach khac: ");
                    }
                }
                Console.Write("- Sua ten tac gia: ");
                while (true)
                {
                    string tg = Console.ReadLine();
                    Regex regex = new Regex(@"^[a-zA-Z ]+$");
                    if (regex.IsMatch(tg))
                    {
                        book.Author = tg;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nhap sai !");
                        Console.Write("- Sua ten tac gia: ");
                    }
                }
                Console.Write("- Sua so luong: ");
                while (true)
                {
                    int number;
                    bool check = Int32.TryParse(Console.ReadLine(), out number);
                    if (check == true)
                    {
                        if (number > 0)
                        {
                            book.Count = number;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nhap sai !");
                            Console.Write("- Nhap so luong: ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nhap sai !");
                        Console.Write("- Nhap so luong: ");
                    }
                }
                Console.Write("- Sua danh muc: ");
                while (true)
                {
                    string danhmuc = Console.ReadLine();
                    Regex regex = new Regex(@"^[a-zA-Z ]+$");
                    if (regex.IsMatch(danhmuc))
                    {
                        book.Category = danhmuc;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nhap sai !");
                        Console.Write("- Sua danh muc: ");
                    }
                }
                Console.Write("Ban co muon sua thong tin sach ? (Y/N): ");
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
                        Console.Write("Ban co muon sua thong tin sach ? (Y/N): ");
                    }
                }
                switch (Question)
                {
                    case "Y":
                        Console.WriteLine("Da sua thong tin sach! ");
                        listBooks[item].BookName = String.Copy(book.BookName);
                        listBooks[item].Author = String.Copy(book.Author);
                        listBooks[item].Category = String.Copy(book.Category);
                        listBooks[item].Count = book.Count;
                        break;
                    case "y":
                        Console.WriteLine("Da sua thong tin sach! ");
                        listBooks[item].BookName = String.Copy(book.BookName);
                        listBooks[item].Author = String.Copy(book.Author);
                        listBooks[item].Category = String.Copy(book.Category);
                        listBooks[item].Count = book.Count;
                        break;
                    case "n":
                        break;
                    case "N":
                        break;
                }
            }
        }
        public List<Book> getListBook()
        {
            return listBooks;
        }

        static public void _addBook(Book book)
        {
            listBooks.Add(book);
        }
    }
}