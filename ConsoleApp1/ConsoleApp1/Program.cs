using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Library libray = new Library("Kitabxana");
            while (true)
            {
                Console.WriteLine("1.Kitabxanaya isci elave et 2.Muellif elave et 3.Kitabxanaya kitab elave et 4.Kitabxanadan isci sil 5.Kitabxanadan kitab sil 6.Muellifin kitablarin gor!");

                string numm = Console.ReadLine();
                bool isInt = int.TryParse(numm, out int menu);
                switch (menu)
                {
                    case 1:
                        #region addemploye
                        Console.WriteLine("iscinin adi");
                        string ename = Console.ReadLine();
                        Console.WriteLine("Iscin soyadi");
                        string esname = Console.ReadLine();
                        AGE:
                        Console.WriteLine("Iscinin yasi");
                        string eage = Console.ReadLine();
                        bool isAge = int.TryParse(eage, out int age);
                        if (!isAge)
                        {
                            Console.WriteLine("Yanlis daxil edildi,zehmet olmasa Duzgun daxil edin");
                            goto AGE;
                        }
                        Employe employe = new Employe(ename, esname, age);
                        libray.employes.Add(employe);
                        Console.WriteLine($"{ename} adli isci elave olundu ");
                        break;
                    #endregion
                    case 2:
                        #region addauthor
                        Console.WriteLine("Muellifin adi");
                        string mname = Console.ReadLine();
                        Console.WriteLine("Muellifin soyadi");
                        string msname = Console.ReadLine();
                        AGEE:
                        Console.WriteLine("Muellifin yasi");
                        string mage = Console.ReadLine();
                        bool ismAge = int.TryParse(mage, out int _mage);
                        if (!ismAge)
                        {
                            Console.WriteLine("Yanlis daxil edildi,zehmet olmasa Duzgun daxil edin");
                            goto AGEE;
                        }
                        Author author = new Author(mname, msname, _mage);
                        libray.authors.Add(author);
                        Console.WriteLine($"{mname} adli muellif elave olundu ");
                        break;
                    #endregion
                    case 3:
                        #region addbook
                        Console.WriteLine("Kitabin adi");
                        string kname = Console.ReadLine();
                        year:
                        Console.WriteLine("Kitabin ili");
                        string kyear = Console.ReadLine();

                        bool isYear = int.TryParse(kyear, out int year);
                        if (!isYear)
                        {
                            Console.WriteLine("Yanlis daxil edildi,zehmet olmasa Duzgun daxil edin");
                            goto year;

                        }
                        Book book = new Book(kname, year);
                        foreach (var item in libray.authors)
                        {
                            Console.WriteLine($"Id--{item.Id}  Ad--{item.Name}");
                        }
                        
                        Iddd:
                        Console.WriteLine("Muellifi ve ya muellifleri secmek ucun ID daxil edin");
                        string mid = Console.ReadLine();
                        string[] mid2 = mid.Split(",");
                        foreach (var item in mid2)
                        {
                            bool isMid = int.TryParse(item, out int midd2);
                            if (!isMid)
                            {
                                Console.WriteLine("Yanlis daxil edildi,zehmet olmasa Duzgun daxil edin");
                                goto Iddd;
                            }
                            foreach (var item1 in libray.authors)
                            {
                                if (item1.Id==midd2)
                                {
                                    book.authors.Add(item1);
                                    
                                    item1.books.Add(book);
                                    
                                }
                            }
                            
                        }
                        libray.books.Add(book);
                        Console.WriteLine($"{kname} adli kitab yaradildi");

                        break;
                    #endregion
                    case 4:
                        #region deletemploye
                        foreach (var item in libray.employes)
                        {
                            Console.WriteLine($"ID--{item.Id}  AD--{item.Name}");
                        }
                        idd:
                        Console.WriteLine("Silmek istediyiniz iscinin ID qeyd edin");
                        string did = Console.ReadLine();
                        bool isid = int.TryParse(did, out int _id);
                        if (!isid)
                        {
                            Console.WriteLine("Yanlis daxil edildi,zehmet olmasa Duzgun daxil edin");
                            goto idd;
                        }
                        foreach (var item in libray.employes)
                        {
                            if (item.Id == _id)
                            {
                                libray.employes.Remove(item);
                                Console.WriteLine($"{item.Name} adli isci silindi");
                                break;
                            }
                        }
                        break;
                    #endregion
                    case 5:
                        #region deletebook
                        foreach (var item in libray.books)
                        {
                            Console.WriteLine($"id --{item.Id}  AD--{item.Name}");
                        }
                        iddd:
                        Console.WriteLine("Silmek istediyiniz kitabin ID qeyd edin");
                        string kid = Console.ReadLine();
                        bool isidk = int.TryParse(kid, out int __id);
                        if (!isidk)
                        {
                            Console.WriteLine("Yanlis daxil edildi,zehmet olmasa Duzgun daxil edin");
                            goto iddd;
                        }
                        foreach (var item in libray.books)
                        {
                           
                            if (item.Id == __id)
                            {
                                foreach (var item1 in libray.authors)
                                {
                                    item1.books.Remove(item);
                        }
                                libray.books.Remove(item);
                                
                                Console.WriteLine($"{item.Name} adli kitab silindi");
                                break;
                            }
                        }
                       
                        break;
                    #endregion
                    case 6:
                        #region seebooks
                        foreach (var item in libray.authors)
                        {
                            Console.WriteLine($"{item.Id}  {item.Name}");
                        }
                        Console.WriteLine("Kitablarini gormek istediyiniz muellif id qeyd edin");
                        string middd = Console.ReadLine();
                        int _mid = int.Parse(middd);
                        foreach (var item in libray.authors)
                        {
                            if (item.Id==_mid)
                            {
                                foreach (var item1 in item.books)
                                {
                                    Console.WriteLine(item1.Name);
                                }
                            }
                        }
                        break;
                    #endregion
                    default:
                        break;
                }
            }
        }
    }
}
