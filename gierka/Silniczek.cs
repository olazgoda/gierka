using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gierka
{
    class Silniczek
    {
        Mapa NowaMapa = new Mapa();
        Postac Ja = new Postac();
        private static Random R = new Random();
        private int _random15 = R.Next(1, 6);
        private int random12 = R.Next(1, 3);
        private string imie;
        private int MojLVL;
        private int MojExp;
        private int MojExpLimit;
        private int MojHP;
        private int X;
        private int Y;
        private int LVL_P;
        private int HP_P;
        private int trolle;
        private int Zaklecie;
        private int proba;


        Przeciwnik P = new Przeciwnik();


        Przedmiot Papuga = new Przedmiot(); //moze wywalac
        Przedmiot KarteczkaZZakleciem = new Przedmiot(); //moze wywalac
        List<Przedmiot> Przedmioty = new List<Przedmiot>();

        public void Poczatek()
        {
            X = 0;
            Y = 0;
            MojLVL = Ja.PobierzLvl();
            MojExp = Ja.PobierzExp();
            MojExpLimit = Ja.PobierzExpLimit();
            MojHP = Ja.PobierzHP();
            Console.Clear();
            Console.WriteLine("Podaj imię dla swojego bohatera:");
            try
            {
                imie = Console.ReadLine();
                Ja.UstawImie(imie);

                Przedmiot Miecz = new Przedmiot();
                Miecz.NazwaPrzedmiotu = "Miecz";
                Miecz.Moc = 1;
                Przedmioty.Add(Miecz);
                Console.Clear();

                
               string wstep = "Ciemność i warczenie...budzisz się przerażony i obolały na wilgotnej trawie.\nJak się tu znalazłeś? Po co Ci miecz?\n\n\nPomału odzyskujesz pamięć. Zostałeś skatowany i wygnany ze swojej wioski przez Wielkiego Kapłana.";           
               for (int i = 0; i < wstep.Length; i++)
               {
                   System.Threading.Thread.Sleep(40);
                   Console.Write(wstep[i]);
               }
               string cd = "\nJesteś potencjalnym zagrożeniem- w końcu ośmieliłeś się zaprotestować, kiedy cyklop pobił malutką dziewczynkę.\nBiedne maleństwo, ukryła wróbelka w swoim domu, aby ocalić zwierzę przed śmiercią.\n";
               for (int i = 0; i < cd.Length; i++)
               {
                   System.Threading.Thread.Sleep(40);
                   Console.Write(cd[i]);
               }
               string cdd = "\n\nJesteś wściekły. Pragniesz zemsty!\nA nade wszystko chcesz zabić Wielkiego Kapłana i obalić jego krwawe rządy!\n\n\n";
               for (int i = 0; i < cdd.Length; i++)
               {
                   System.Threading.Thread.Sleep(40);
                   Console.Write(cdd[i]);
               }
               string cddd = "W blasku księżyca dostrzegasz ścieżkę, po mchu na drzewie orientujesz się, że prowadzi ona na południe.\n\n";
               for (int i = 0; i < cddd.Length; i++)
               {
                   System.Threading.Thread.Sleep(40);
                   Console.Write(cddd[i]);
               }
               string rozgrywka = "Naciśnij dowolny klawisz, aby rozpocząć rozgrywkę...";
               for (int i = 0; i < rozgrywka.Length; i++)
               {
                   System.Threading.Thread.Sleep(40);
                   Console.Write(rozgrywka[i]);
               }               
               Console.ReadKey();
               Console.Clear();   
               
                MenuP();
                WstepDoMenu();
            }
            catch
            {
                Console.Clear();
                Poczatek();
            }
        }

        private void TwojaPostac()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("<  Postać: " + imie + "  LVL:" + MojLVL + "  HP:" + MojHP + "  EXP:" + MojExp + "  " + (MojExpLimit - MojExp) + " EXP do " + (MojLVL + 1) + "lvla  >");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void PostacPrzeciwnika()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("<  Twój przeciwnik to:  " + P.PobierzImie() + "  LVL:" + P.PobierzLvl() + "  HP:" + P.PobierzHP() + "  >");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void MenuP()
        {
            NowaMapa.Koordynaty();
            Console.WriteLine();
            TwojaPostac();
            Console.WriteLine();
        }

        private void Ekwipunek()
        {
            Console.Clear();
            MenuP();
            Console.WriteLine("______________________________________");
            Console.WriteLine("W Twoim ekwipunku znajdują się:");
            Console.WriteLine();
            foreach (Przedmiot aPart in Przedmioty)
            {
                Console.WriteLine(aPart);
            }
            Console.WriteLine("______________________________________");
            Menu();
        }

        private void Poziom()
        {
            if (Ja.PobierzExp() >= Ja.PobierzExpLimit())
            {
                MojLVL += 1;
                Ja.UstawLvl(MojLVL);
                MojExp = (MojExp - MojExpLimit);
                Ja.UstawExp(MojExp);
                MojExpLimit += 1;
                Ja.UstawExpLimit(MojExpLimit);
            }
            if (Ja.PobierzLvl() == 10)
            {
                
                Console.WriteLine("\nAby zagrać ponownie, naciśnij p.\nAby zakończyć, naciśnij dowolny inny klawisz.");
                string p = Console.ReadLine();
                if (p == "p" || p == "P")
                {
                    Poczatek();
                }
                else
                {
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
            }
        }

        private bool Atak()
        {
            Console.WriteLine("Aby zadać cios, wybierz przycisk f");
            string cios = (Console.ReadLine());
            if (cios == "f") return true;
            else return false;
        }

        public void WstepDoMenu()
        {
            NowaMapa.UstawY(Y);
            NowaMapa.UstawX(X);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nOpis lokacji, w której obecnie się znajdujesz:");
            Console.ForegroundColor = ConsoleColor.Gray;
            NowaMapa.OpisLokacji();
            Menu();
        }
        //************************************************************************************************************************************************
        //tu zaczynają się tak długie metody, że aż się chce płakać ;(
        //************************************************************************************************************************************************
        public void Menu()
        {
            int wersjaMenu = NowaMapa.WersjaMenu();
            if (wersjaMenu == 1)
            {
                trolle = (NowaMapa.IleTrolli);
                while (trolle > 1)
                {
                    Console.WriteLine("Naciśnij: \n1, aby rozpocząć walkę\n2, aby zerwać owoc\n3, aby sprawdzić ekwipunek. ");
                    try
                    {
                        int wybor = int.Parse(Console.ReadLine());
                        if (wybor == 1)
                        {
                            trolle = 1;
                            NowaMapa.IleTrolli = trolle;
                            WalkaTroll();
                        }
                        else if (wybor == 2)
                        {
                            MojHP = 0;
                            Ja.UstawHP(0);
                            Console.Clear();
                            MenuP();
                            Console.WriteLine("I po co Ci to było? Troll Cię dorwał i sprał, nomen omen, na kwaśne jabłko!" +
                                         "\nNastępnym razem przemyśl kolejność swoich czynów.");

                            Ja.Smierc();
                        }
                        else if (wybor == 3)
                        {
                            Ekwipunek();
                        }
                        else
                        {
                            TwojaPostac();
                            Console.WriteLine("\n\nCo Ty do licha wyprawiasz?! Tańczysz gangnam style?\n\n" +
                                     "A mogłeś zerwać jabłko albo powalczyć, a postanowiłeś się powygłupiać." +
                                     "\n" +
                                     "\n" +
                                      "\nTroll Cię zauważył i aresztował. Przegrywasz.");
                            MojHP = 0;
                            Ja.UstawHP(MojHP);
                            Ja.Smierc();
                        }
                    }
                    catch
                    {
                        Console.Clear();
                        MenuP();
                        WstepDoMenu();
                    }
                }
                if (trolle == 1)
                {
                    trolle = 0;
                    NowaMapa.IleTrolli = trolle;
                    Console.WriteLine("\n\nUWAŻAJ!\nZza ogromnej skały wybiega w Twoim kierunku drugi troll, najwyraźniej dobry kumpel tego, którego właśnie pozbawiłeś łba.\nNaciśnij dowolny przycisk, aby przybrać pozycję bojową!");
                    Console.ReadKey();
                    WalkaTroll();
                }
                if (trolle == 0)
                {
                    Console.WriteLine("Super! Pokonałeś dwóch niezłych bandziorów.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\nNaciśnij:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("1, aby zmienić lokację\n2, aby sprawdzić ekwipunek.");
                    int wybor;
                    try
                    {
                        wybor = int.Parse(Console.ReadLine());
                        if (wybor == 1)
                        {
                            Chodzenie();
                        }
                        else if (wybor == 2)
                        {
                            Ekwipunek();
                        }
                        else
                        {
                            Console.Clear();
                            MenuP();
                            Menu();
                        }
                    }
                    catch
                    {
                        Console.Clear();
                        MenuP();
                        Menu();
                    }

                }
            }
            else if (wersjaMenu == 2)
            {
                //pusta lokacja //mag i zaklecie


                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\nNaciśnij:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1, aby zmienić lokację\n2, aby sprawdzić ekwipunek.");
                int wybor;
                Zaklecie = NowaMapa.PobierzZaklecie();
                if (proba == 0 & Zaklecie == 1)
                {
                    
                    KarteczkaZZakleciem.NazwaPrzedmiotu = "Zaklęcie";
                    KarteczkaZZakleciem.Moc = 99;
                    Przedmioty.Add(KarteczkaZZakleciem);
                    proba += 1;
                }

                try
                {
                    wybor = int.Parse(Console.ReadLine());
                    if (wybor == 1)
                    {
                        Chodzenie();
                    }
                    else if (wybor == 2)
                    {
                        Ekwipunek();
                    }
                    else
                    {
                        Console.Clear();
                        MenuP();
                        Menu();
                    }
                }
                catch
                {
                    Console.Clear();
                    MenuP();
                    Menu();
                }
            }
            else if (wersjaMenu == 3)
            {
                trolle = (NowaMapa.IleTrolli);
                while (trolle > 1)
                {
                    Console.WriteLine("Naciśnij: \n1, aby przejść do innej lokacji\n2, aby rozpocząć walkę");
                    try
                    {
                        int wybor = int.Parse(Console.ReadLine());
                        if (wybor == 2)
                        {
                            trolle = 1;
                            NowaMapa.IleTrolli = trolle;
                            WalkaTroll();
                        }
                        else if (wybor == 1)
                        {
                            Chodzenie();
                        }
                        else
                        {
                            TwojaPostac();
                            Console.WriteLine("\n\nCo Ty do licha wyprawiasz?! Tańczysz gangnam style?\n\n" +
                                     "A mogłeś zerwać jabłko albo powalczyć, a postanowiłeś się powygłupiać." +
                                     "\n" +
                                     "\n" +
                                      "\nTroll Cię zauważył i aresztował. Przegrywasz.");
                            MojHP = 0;
                            Ja.UstawHP(MojHP);
                            Ja.Smierc();
                        }
                    }
                    catch
                    {
                        Console.Clear();
                        MenuP();
                        WstepDoMenu();
                    }
                }
                if (trolle == 1)
                {
                    trolle = 0;
                    NowaMapa.IleTrolli = trolle;
                    Console.WriteLine("Postaraj się, aby pokonać tego trolla, dzięki temu ocalisz papugę!\n");
                    
                    Papuga.NazwaPrzedmiotu = "Papuga";
                    Papuga.Moc = 0;
                    Przedmioty.Add(Papuga);
                    Console.ReadKey();
                    WalkaTroll();

                }
                if (trolle == 0)
                {
                    Console.WriteLine("Super! Pokonałeś dwóch niezłych bandziorów i ocaliłeś papugę. Od teraz znajduje się ona w Twoim ekwipunku.\nWypuść ją, kiedy pokonasz Wielkiego Kapłana.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n\nNaciśnij:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("1, aby zmienić lokację\n2, aby sprawdzić ekwipunek.");
                    int wybor;
                    try
                    {
                        wybor = int.Parse(Console.ReadLine());
                        if (wybor == 1)
                        {
                            Chodzenie();
                        }
                        else if (wybor == 2)
                        {
                            Ekwipunek();
                        }
                        else
                        {
                            Console.Clear();
                            MenuP();
                            Menu();
                        }
                    }
                    catch
                    {
                        Console.Clear();
                        MenuP();
                        Menu();
                    }
                }
            }
            else if (wersjaMenu == 4)
            {
                WalkaBoss();
            }
            else if (wersjaMenu == 5)
            {
                
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\nNaciśnij:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("1, aby szybko czmychnąć\n2, aby zmierzyć się z cyklopem.");
                int wybor;
                try
                {
                    wybor = int.Parse(Console.ReadLine());
                    if (wybor == 1)
                    {
                        Chodzenie();
                    }
                    else if (wybor == 2)
                    {
                        WalkaCyklop();
                    }
                    else
                    {
                        Console.Clear();
                        MenuP();
                        Menu();
                    }
                }
                catch
                {
                    Console.Clear();
                    MenuP();
                    Menu();
                }
            }
            else if (wersjaMenu == 6)
            {
                int jablko = (NowaMapa.IleJablek);
                while (jablko > 0)
                {
                    Console.WriteLine("Wciśnij:\n1, aby przejść do innej lokacji\n2, aby zerwać i zjeść jabłko.");
                    try
                    {
                        int o = int.Parse(Console.ReadLine());                  
                        if (o == 2)
                        {
                            MojHP += 2;
                            Ja.UstawHP(MojHP);
                            jablko = 0;
                            NowaMapa.IleJablek = jablko;                                                      
                        }
                        else if (o == 1)
                        {
                            Chodzenie();
                        }
                        else
                        {
                            Console.WriteLine("Myślisz, że to powtórka z Królewny śnieżki? Możliwe, w tym szalonym świecie wszystko wydaje się prawdopodobne.");
                            Menu();
                        }
                    }
                    catch
                    {
                        Console.Clear();
                        MenuP();
                        Menu();
                    }
                }
                if (jablko == 0)
                {
                    Console.Clear();
                    MenuP();
                    Console.WriteLine("Przepyszne. Teraz czas odkrywać nowe miejsca w tym dziwnym świecie...");
                    Console.WriteLine("\n\nNaciśnij:");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("1, aby zmienić lokację\n2, aby sprawdzić ekwipunek.");
                    int wybor;
                    try
                    {
                        wybor = int.Parse(Console.ReadLine());
                        if (wybor == 1)
                        {
                            Chodzenie();
                        }
                        else if (wybor == 2)
                        {
                            Ekwipunek();
                        }
                        else
                        {
                            Console.Clear();
                            MenuP();
                            Menu();
                        }
                    }
                    catch
                    {
                        Console.Clear();
                        MenuP();
                        Menu();
                    }

                }

            }
        }





        private void WalkaBoss()
        {
            HP_P = 101;
            P.UstawHP(HP_P);
            P.UstawImie("Wielki Kapłan");
            P.UstawLvl(100);

            while (HP_P > 0)
            {
                if (Przedmioty.Contains(KarteczkaZZakleciem))
                {
                    PostacPrzeciwnika();
                    Console.WriteLine("\nAby użyć:\n-miecza: naciśnij 'f'\n-zaklęcia: naciśnij 'z'\n");
                    string bron;
                    try
                    {
                        bron = Console.ReadLine();
                        if (bron == "f")
                        {
                            MojHP -= 10;
                            Ja.UstawHP(MojHP);
                            HP_P -= 1;
                            P.UstawHP(HP_P);
                            TwojaPostac();
                            PostacPrzeciwnika();
                            Console.WriteLine("\nLedwie zdołałeś ugodzić Kapłana, tymczasem on zadał Ci bardzo poważne obrażenia.\n");
                            Ja.Smierc();
                            Console.WriteLine("Może inny rodzaj ataku okaże się bardziej skuteczny?\n");
                           
                        }
                        else if (bron == "z")
                        {
                            Przedmioty.Remove(KarteczkaZZakleciem);
                            MojHP -= 2;
                            Ja.UstawHP(MojHP);
                            HP_P -= 99;
                            P.UstawHP(HP_P);
                            TwojaPostac();
                            PostacPrzeciwnika();
                            Zaklecie = 0;
                            Console.WriteLine("\nKapłan upadł na ziemię. Zaklęcie dosłownie zwaliło go z nóg!\n" +
                                "Dobij go mieczem.");
                        }
                        else
                        {
                            MojHP = 0;
                            Ja.UstawHP(MojHP);
                            HP_P -= 1;
                            P.UstawHP(HP_P);
                            TwojaPostac();
                            PostacPrzeciwnika();
                            Console.WriteLine("\nNiestety chybiłeś, a Kapłan korzystając z tej okazji chwycił za katanę.\nTwoja głowa turla się po dziedzińcu zamku, a Kapłan zanosi się śmiechem.\n");
                            Ja.Smierc();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Przez Twoje błędy Kapłan zdążył sie zregenerować.");
                        WalkaBoss();
                    }
                }
                if ( HP_P > 50)
                {
                    Console.WriteLine("\nAby użyć:\n-miecza: naciśnij 'f'\n");
                    string b;
                    try
                    {
                        b = Console.ReadLine();
                        if (b == "f")
                        {
                            MojHP -= 30;
                            Ja.UstawHP(MojHP);
                            HP_P -= 1;
                            P.UstawHP(HP_P);
                            TwojaPostac();
                            PostacPrzeciwnika();
                            Console.WriteLine("\nLedwie zdołałeś ugodzić Kapłana, tymczasem on zadał Ci bardzo poważne obrażenia.\n");
                            Ja.Smierc();
                        }
                        else
                        {
                            MojHP = 0;
                            Ja.UstawHP(MojHP);
                            TwojaPostac();
                            Console.WriteLine("\nNiestety chybiłeś, a Kapłan korzystając z tej okazji chwycił za katanę.\nTwoja głowa turla się po dziedzińcu zamku, a Kapłan zanosi się śmiechem.\n");
                            Ja.Smierc();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Przez Twoje błędy Kapłan zdążył sie zregenerować.");
                        WalkaBoss();
                    }
                }
                if (HP_P < 50 & HP_P > 0)
                {
                    Console.WriteLine("\nAby użyć:\n-miecza: naciśnij 'f'\n");
                    string c;
                    try
                    {
                        c = Console.ReadLine();
                        if (c == "f")
                        {
                            MojHP -= 1;
                            Ja.UstawHP(MojHP);
                            HP_P -= 1;
                            P.UstawHP(HP_P);
                            TwojaPostac();
                            PostacPrzeciwnika();
                            Console.WriteLine("\nKapłan jest bardzo słaby.\n");
                            Ja.Smierc();
                        }
                        else
                        {
                            MojHP -= 1;
                            Ja.UstawHP(MojHP);
                            TwojaPostac();
                            PostacPrzeciwnika();
                            Console.WriteLine("\nNiestety chybiłeś, szczęśliwie Kapłan jest już słaby i tylko lekko ugodził Cię nożem.\n");
                            Ja.Smierc();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Przez Twoje błędy Kapłan zdążył sie zregenerować.");
                        WalkaBoss();
                    }
                }
            }
            if (HP_P <= 0)
            {
                P.UstawHP(HP_P);
                MojLVL = 10;
                Ja.UstawLvl(MojLVL);
                TwojaPostac();
                PostacPrzeciwnika();
                Console.WriteLine("\nGratulacje! Pokonałeś Kapłana.\n");
                if (Przedmioty.Contains(Papuga))
                {
                    Console.WriteLine("\nWypuściłeś papugi. Świat nabrał kolorów; teraz będzie już tylko lepiej!\n");
                }
                Poziom();
            }
        }


        private void WalkaCyklop()
        {
            //walka z cyklopem(lvl albo 5 albo 8) 
            Console.Clear();
            Random R = new Random();
            int _randomLVL = R.Next(5, 9);
            P.UstawImie("Cyklop");
            P.UstawLvl(_randomLVL);
            LVL_P = P.PobierzLvl();
            HP_P = 2;
            P.UstawHP(HP_P);
            MenuP();
            PostacPrzeciwnika();
            if (P.PobierzLvl() > MojLVL)
            {
                MojHP -= 1;
                Ja.UstawHP(MojHP);
                Ja.Smierc();
                Console.Clear();
                MenuP();
                PostacPrzeciwnika();
                Console.WriteLine("Przeciwnik Cię odpycha- tracisz 1 punkt życia.\n");
                Console.WriteLine("'Nie będę się z Tobą bić, żałosna kreaturo, zdobądź więcej doświadczenia to podyskutujemy'.\n");
                Menu();
            }
            else if (P.PobierzLvl() < MojLVL)
            {
                Console.WriteLine("Przeciwnik kuli się ze strachu. Jesteś od niego wyraźnie silniejszy.");
                while (P.PobierzHP() > 0)
                {
                    if (Atak() == true)
                    {
                        HP_P -= 1;
                        P.UstawHP(HP_P);
                        MojExp += 1;
                        Ja.UstawExp(MojExp);
                        Poziom();
                        Console.Clear();
                        MenuP();
                        PostacPrzeciwnika();
                        Console.WriteLine("Niezły z Ciebie wojkownik! Gnida padła szybciej, niż zdążyła cokolwiek pomyśleć. \nDostajesz 1 punkt doświadczenia.\n");
                        Menu();
                    }
                    else
                    {
                        MojHP -= 1;
                        Ja.UstawHP(MojHP);
                        Ja.Smierc();
                        Console.Clear();
                        MenuP();
                        PostacPrzeciwnika();
                        Console.WriteLine("Miecz chyba wyślizgnął Ci się z ręki...Cyklop zdążył zaatakować wcześniej od Ciebie.\nTracisz punkt życia.\n");
                    }
                }
            }
            else
            {
                while (P.PobierzHP() > 0)
                {
                    if (Atak() == false)
                    {
                        MojHP -= 1;
                        Ja.UstawHP(MojHP);
                        Ja.Smierc();
                        Console.Clear();
                        MenuP();
                        PostacPrzeciwnika();
                        Console.WriteLine("Miecz chyba wyślizgnął Ci się z ręki...Cyklop zdążył zaatakować wcześniej od Ciebie. Tracisz punkt życia.");
                    }
                    else
                    {
                        HP_P -= 1;
                        P.UstawHP(HP_P);

                        if (P.PobierzHP() == 0)
                        {
                            MojExp += 3;
                            Ja.UstawExp(MojExp);
                            Poziom();
                            Console.Clear();
                            MenuP();
                            PostacPrzeciwnika();
                            Console.WriteLine("Super! Pokonałeś tę dziką bestię. Zyskujesz 3 punkty doświadczenia");
                            Console.WriteLine();
                            Console.WriteLine("Zauważasz, że z kieszeni wroga wystaje fiolka z eliksirem.\nNaciśnij 'j', by go wypić, może akurat dzięki niemu polepszy się Twoje zdrowie?");
                            string j;
                            try
                            {
                                j = Console.ReadLine();

                                if (j == "j")
                                {
                                    MojHP += _randomLVL;
                                    Ja.UstawHP(MojHP);
                                    Console.Clear();
                                    MenuP();
                                    Console.WriteLine("Nawet niezły w smaku, ale podobno to gorzki lek najlepiej leczy...");
                                    Menu();
                                }
                                else
                                {
                                    Console.Clear();
                                    MenuP();
                                    Console.WriteLine("Cóż, nie dziwię Ci się, że niechętnie pijesz pierwszą lepszą ciecz znalezioną w lesie. Może rzeczywiście niewarto ryzykować swoim zdrowiem?");
                                    Menu();
                                }
                            }
                            catch
                            {
                                WalkaCyklop();
                            }
                        }
                        MojHP -= 1;
                        Ja.UstawHP(MojHP);
                        Ja.Smierc();
                        Console.Clear();
                        MenuP();
                        PostacPrzeciwnika();
                        Console.WriteLine("Ekstra! Udało Ci się zranić przeciwnika.\n");
                        Console.WriteLine("Cyklop nie pozostaje Ci jednak dłużny i również godzi Cię bronią.\n");
                    }
                }
            }

        }

        private void WalkaTroll()
        {
            Console.Clear();
            Random R = new Random();
            int _randomLVL = R.Next(1, (MojLVL + 1));           
            P.UstawImie("Troll");         
            P.UstawLvl(_randomLVL);
            LVL_P = P.PobierzLvl();
            HP_P = 2;
            P.UstawHP(HP_P);
            MenuP();
            PostacPrzeciwnika();
            if (P.PobierzLvl() > MojLVL)
            {
                MojHP -= 1;
                Ja.UstawHP(MojHP);
                Ja.Smierc();
                Console.Clear();
                MenuP();
                PostacPrzeciwnika();
                Console.WriteLine("Przeciwnik Cię odpycha.\n");
                Console.WriteLine("'Nie będę się z Tobą bić, żałosna kreaturo, zdobądź więcej doświadczenia to podyskutujemy'.\n");
                Console.WriteLine("Tracisz 1 punkt życia.");
                WstepDoMenu();
            }
            else if (P.PobierzLvl() < MojLVL)
            {
                Console.WriteLine("Przeciwnik kuli się ze strachu. Jesteś od niego wyraźnie silniejszy.");
                while (P.PobierzHP() > 0)
                {
                    if (Atak() == true)
                    {
                        HP_P -= 1;
                        P.UstawHP(HP_P);
                        MojExp += 1;
                        Ja.UstawExp(MojExp);
                        Poziom();
                        Console.Clear();
                        MenuP();
                        PostacPrzeciwnika();
                        Console.WriteLine("Niezły z Ciebie wojkownik! Gnida padła szybciej, niż zdążyła cokolwiek pomyśleć. \nDostajesz 1 punkt doświadczenia.\n");
                        Menu();
                    }
                    else
                    {
                        MojHP -= 1;
                        Ja.UstawHP(MojHP);
                        Ja.Smierc();
                        Console.Clear();
                        MenuP();
                        PostacPrzeciwnika();
                        Console.WriteLine("Miecz chyba wyślizgnął Ci się z ręki...Wróg zdążył zaatakować wcześniej od Ciebie.\nTracisz punkt życia.\n");
                    }
                }
            }
            else
            {
                while (P.PobierzHP() > 0)
                {
                    if (Atak() == false)
                    {
                        MojHP -= 1;
                        Ja.UstawHP(MojHP);
                        Ja.Smierc();
                        Console.Clear();
                        MenuP();
                        PostacPrzeciwnika();
                        Console.WriteLine("Miecz chyba wyślizgnął Ci się z ręki...Wróg zdążył zaatakować wcześniej od Ciebie. Tracisz punkt życia.");
                    }
                    else
                    {
                        HP_P -= 1;
                        P.UstawHP(HP_P);

                        if (P.PobierzHP() == 0)
                        {
                            MojExp += 2;
                            Ja.UstawExp(MojExp);
                            Poziom();
                            Console.Clear();
                            MenuP();
                            PostacPrzeciwnika();
                            Console.WriteLine("Super! Pokonałeś tę dziką bestię. Zyskujesz 2 punkty doświadczenia");
                            Console.WriteLine();
                            Console.WriteLine("Zauważasz, że z kieszeni wroga wystaje fiolka z eliksirem.\nNaciśnij 'j', by go wypić, może akurat dzięki niemu polepszy się Twoje zdrowie?");
                            string j;
                            try
                            {
                                j = Console.ReadLine();

                                if (j == "j")
                                {
                                    MojHP += _randomLVL;
                                    Ja.UstawHP(MojHP);
                                    Console.Clear();
                                    MenuP();
                                    Console.WriteLine("Nawet niezły w smaku, ale podobno to gorzki lek najlepiej leczy...");
                                    Menu();
                                }
                                else
                                {
                                    Console.Clear();
                                    MenuP();
                                    Console.WriteLine("Cóż, nie dziwię Ci się, że niechętnie pijesz pierwszą lepszą ciecz znalezioną w lesie. Może rzeczywiście niewarto ryzykować swoim zdrowiem?");
                                    Menu();
                                }
                            }
                            catch
                            {
                                WalkaTroll();
                            }
                        }
                        MojHP -= 1;
                        Ja.UstawHP(MojHP);
                        Ja.Smierc();
                        Console.Clear();
                        MenuP();
                        PostacPrzeciwnika();
                        Console.WriteLine("Ekstra! Udało Ci się zranić przeciwnika.\n");
                        Console.WriteLine("Przeciwnik nie pozostaje Ci jednak dłużny i również godzi Cię bronią.\n");
                    }
                }
            }
        }

        

        private void Chodzenie()
        {

            Console.Clear();
            MenuP();
            Console.WriteLine("Wpisz wybraną literę, aby iść w określonym kierunku: \nd- wschód\na- zachód\nw- północ\ns- południe");
            string ruch;
            try
            {
                ruch = (Console.ReadLine());
                if (ruch == "a")
                {
                    if ((X - 1) < 0)
                    {
                        Console.Clear();
                        MenuP();
                        Console.WriteLine("Nie można wyjść poza mapę\n");
                        WstepDoMenu();
                    }
                    else if (((X - 1) == 2) & Y == 1 & MojLVL < 9)
                    {
                        Console.Clear();
                        MenuP();
                        Console.WriteLine("W lokacji, do której chcesz się dostać, znajduje się zamek Wielkiego Kapłana. Nie możesz do niego wejść, dopóki nie osiągniesz 9 poziomu.");
                        WstepDoMenu();

                    }
                    else if (NowaMapa.SprLewo() == true)
                    {
                        X -= 1;
                        NowaMapa.UstawX(X);
                        Console.Clear();
                        MenuP();
                        WstepDoMenu();
                    }
                    else
                    {
                        Console.Clear();
                        MenuP();
                        Console.WriteLine("W lokacji, do której chcesz się dostać, znajduje się wielki, ceglany mur, którego nie możesz przeniknąć- musisz znaleźć drogę dookoła." +
                            "\nCiekawe co znajduje się po jego drugiej stronie...\n");
                        WstepDoMenu();
                    }
                }
                else if (ruch == "d")
                {
                    if ((X + 1) > 3)
                    {
                        Console.Clear();
                        MenuP();
                        Console.WriteLine("Nie można wyjść poza mapę\n");
                        WstepDoMenu();
                    }
                    else if (((X + 1) == 2) & Y == 1 & MojLVL < 9)
                    {
                        Console.Clear();
                        MenuP();
                        Console.WriteLine("W lokacji, do której chcesz się dostać, znajduje się zamek Wielkiego Kapłana. Nie możesz do niego wejść, dopóki nie osiągniesz 9 poziomu.");
                        WstepDoMenu();
                    }
                    else if (NowaMapa.SprPrawo() == true)
                    {
                        X += 1;
                        NowaMapa.UstawX(X);
                        Console.Clear();
                        MenuP();
                        WstepDoMenu();
                    }
                    else
                    {
                        Console.Clear();
                        MenuP();
                        Console.WriteLine("W lokacji, do której chcesz się dostać, znajduje się wielki, ceglany mur, którego nie możesz przeniknąć- musisz znaleźć drogę dookoła." +
                            "\nCiekawe co znajduje się po jego drugiej stronie...\n");
                        WstepDoMenu();
                    }
                }
                else if (ruch == "w")
                {
                    if ((Y - 1) < 0)
                    {
                        Console.Clear();
                        MenuP();
                        Console.WriteLine("Nie można wyjść poza mapę\n");
                        WstepDoMenu();
                    }
                    else if ((X == 2) & (Y - 1) == 1 & MojLVL < 9)
                    {
                        Console.Clear();
                        MenuP();
                        Console.WriteLine("W lokacji, do której chcesz się dostać, znajduje się zamek Wielkiego Kapłana. Nie możesz do niego wejść, dopóki nie osiągniesz 9 poziomu.");
                        WstepDoMenu();
                    }
                    else if (NowaMapa.SprGora() == true)
                    {
                        Y -= 1;
                        NowaMapa.UstawY(Y);
                        Console.Clear();
                        MenuP();
                        WstepDoMenu();
                    }
                    else
                    {
                        Console.Clear();
                        MenuP();
                        Console.WriteLine("W lokacji, do której chcesz się dostać, znajduje się wielki, ceglany mur, którego nie możesz przeniknąć- musisz znaleźć drogę dookoła." +
                         "\nCiekawe co znajduje się po jego drugiej stronie...\n");
                        WstepDoMenu();
                    }
                }
                else if (ruch == "s")
                {
                    if ((Y + 1) > 3)
                    {
                        Console.Clear();
                        MenuP();
                        Console.WriteLine("Nie można wyjść poza mapę\n");
                        WstepDoMenu();
                    }
                    else if ((X == 2) & (Y + 1) == 1 & MojLVL < 9)
                    {
                        Console.Clear();
                        MenuP();
                        Console.WriteLine("W lokacji, do której chcesz się dostać, znajduje się zamek Wielkiego Kapłana. Nie możesz do niego wejść, dopóki nie osiągniesz 9 poziomu.");
                        WstepDoMenu();
                    }
                    else if (NowaMapa.SprDol() == true)
                    {
                        Y += 1;
                        NowaMapa.UstawY(Y);
                        Console.Clear();
                        MenuP();
                        WstepDoMenu();
                    }
                    else
                    {
                        Console.Clear();
                        MenuP();
                        Console.WriteLine("W lokacji, do której chcesz się dostać, znajduje się wielki, ceglany mur, którego nie możesz przeniknąć- musisz znaleźć drogę dookoła." +
                            "\nCiekawe co znajduje się po jego drugiej stronie...\n");
                        WstepDoMenu();
                    }
                }
                else
                {
                    Chodzenie();
                }
            }
            catch
            {
                Chodzenie();
            }
        }
    }
}
               
