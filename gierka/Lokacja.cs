using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gierka
{
    class Lokacja
    {
        
        public Lokacja(int _Opcja)
        {
            Opcja = _Opcja;
        }

        private static Random R = new Random();
        private int Menu;
        private int Opcja;

        private int Trolle;

        public int IloscTrolli
        {
            get
            {
                return Trolle;
            }
            set
            {
                Trolle=value;
            }
        }


        private int Zaklecie;
        private int Nauka;
        private int Boss;
        private int Jablko;
        private int Cyklop;
        private int Proba;

        
        public int IloscBoss()
        {
            return Boss;
        }
        public int IloscCyklop()
        {
            return Cyklop;
        }
        public int IloscJablko()
        {
            return Jablko;
        }



        public int WersjaMenu()
        {
            return Menu;
        }
        public int ZwrocOpcjeLokacji()
        {
            return Opcja;
        }
        public int zaklecie()
        {
            return Zaklecie;
        }




        public void UstawOpcje(int OpcjazMapy)
        {
            Opcja = OpcjazMapy;
        }


        public void OpisLokacji_MetodaZaleznaOdOpcji(int o)
        {
            if (Opcja == 1) //poczatek
            {
                Menu = 1;
                Trolle = 2;
                Boss = 0;
                Cyklop = 0;
                Jablko = 1;
                Console.WriteLine("\nDostrzegasz, że za pobliskim drzewkiem siedzi nabuzowany troll." +
                                "\nNa gałązce dostrzegasz jabłko, może uda Ci się je zerwać i zjeść tak, żeby stwór Cię nie dorwał?\n");
            }
            else if (Opcja == 2) //pusta lokacja
            {
                Menu = 2;//możesz tylko wyjść albo sprawdzić ekwipunek
                Trolle = 0;
                Boss = 0;
                Cyklop = 0;
                Jablko = 0;
                Console.WriteLine("\nW tej lokacji jest niepokojąco pusto...i cicho.\nOd kiedy Wielki Kapłan kazał strzelać do wszystkich ptaków, cisza w lesie jest naprawdę przejmująca.\nLepiej stąd zmykać, bo może czekać tu na Ciebie jakaś pułapka!\n");
            }

            else if (Opcja == 3) //mag i zaklecie
            {
                Menu = 2; //możesz tylko wyjść albo sprawdzić ekwipunek

                if (Zaklecie == 1)
                {
                    Console.WriteLine("\nO borze liściasty! Mag leży na ziemi, na wskroś przebity włócznią.\nLepiej szybko stąd uciekaj, bo jeszcze spotka Cię to samo!");
                }
                else if (Proba == 0 & Zaklecie == 0)
                {
                    Console.WriteLine("\nCo u licha! Człowiek unosi się nad ziemią! jak to możliwe?" +
                        "\n'Witaj Wędrowcze'- odzywa się lewitująca postać -'jestem lokalnym magiem.\nOpracowuję właśnie zaklęcie, które będzie w stanie pokonać Wielkiego Kapłana.'");
                }
                if (Zaklecie == 0)
                {
                    Console.WriteLine("\nAby poprosić maga, żeby nauczył Cię tego zaklęcia naciśnij 'j'.");
                    try
                    {

                        string s = Console.ReadLine();
                        if (s == "j" || s == "J")
                        {
                            Console.WriteLine("\nChętnie Cię pouczę.");
                            while (Nauka == 0)
                            {
                                Console.WriteLine("\n'Powtarzaj za mną: 'Lorem ipsum dolor sit amet'.'");
                                string k = Console.ReadLine();
                                if (k == "Lorem ipsum dolor sit amet" || k == "lorem ipsum dolor sit amet" || k == "LOREM IPSUM DOLOR SIT AMET")
                                {
                                    Nauka = 1;
                                    Zaklecie = 1;
                                    Console.WriteLine("\n'Gratuluję! Oto karteczka z zaklęciem. Życzę powodzenia w walce z Kapłanem!'");
                                }
                                else
                                {
                                    Console.WriteLine("\n'Oj, trochę słabo Ci poszło, spróbuj jeszcze raz.'");
                                }
                            }
                        }
                        else
                        {
                            Proba = 1;
                            Console.WriteLine("\n'Chyba nie w głowie Ci nauka. Wróć, kiedy będziesz gotowy.'");
                        }
                    }
                    catch
                    {
                        OpisLokacji_MetodaZaleznaOdOpcji(3);
                    }
                }
                
            }
            else if (Opcja == 4) //tylko walka z dwoma trollami, potem info o tym ze uwolnil papuge puscil ją wolno, aby świat nabral dzieki niej troche kolorow
            {
                Menu = 3;
                Boss = 0;
                Cyklop = 0;
                Jablko = 0;
                Trolle = 2;
                Console.WriteLine("\nSłyszysz chichot- to trolle!\nJeden z nich niesie ze sobą klatkę z ptakiem- piękną, kolorową papugą.\nSkop im tyłki i uwolnij zwierzaka!");             
            }
            else if (Opcja == 5)
            {
                Menu = 4; //menu walki z bossem(mozesz tylko zaatakowac ale jak odpowiednio szybko nie uzyjesz zaklecia to kapa bo jego cios odbiera 5 HP, a twoj cios odbiera mu tylko 1 ze 100 hp a zaklecie odejmuje 99hp i zostawia go wykonczonego i trzeba go dobic)
                Trolle = 0;
                Boss = 1;
                Cyklop = 0;
                Jablko = 0;

                Console.WriteLine("\nOto i on...potwór i szalony dyktator...tyle czasu go szukałeś!\nTylu łotrów musiałeś zabić po drodze do tego miejsca.\nDaj z siebie wszystko w tej finałowej walce i nie zapomnij o prezencie od Maga!");               
            }
            else if (Opcja == 6)
            {
                Menu = 5;
                Trolle = 0;
                Boss = 0;
                Cyklop = 1;
                Jablko = 0;
                //walka z cyklopem(lvl albo 5 albo 8)(albo mozesz uciec szybko albo sie z nim zmierzyc
                Console.WriteLine("\nIdąc ścieżką dostrzegasz, że zza drzewa przygląda Ci się...no właśnie, co to? Jedno oko? A co z drugim?\n\n" +
                    "Nagle postać wybiega. W ręku trzyma ogromną kolczugę.\nOrientujesz się, że to cyklop, najgorszy rodzaj wroga jakiego mogłeś spotkać w lesie.\n" +
                    "\nJeśli wykażesz się odpowiednim refleksem, może zdołasz mu uciec-\nnie wiadomo czy nie jest on nabuzowany po wypiciu eliksiru mocy, wtedy w sekundę rozniesie Cię na strzępy!");
            }
            else if (Opcja == 7)
            {
                Menu = 6;
                Trolle = 0;
                Boss = 0;
                Cyklop = 0;
                Jablko = 1;
                Console.WriteLine("\nCo za piękne miejsce! Malutka sadzawka, a tuż nad jej brzegiem jabłoń." +
                "\n\nDostrzegasz jedyny dojrzały owoc. Zjedzenie go na pewno doda Ci siły.");
                /*menu7"\n\n Wciśnij 'o', aby zerwać i zejść jabłko.");
                string o = Console.ReadLine();
                try
                {
                    if (o == o)
                    {
                        MojHP += 2;
                        Ja.UstawHP(MojHP);
                        Console.WriteLine();
                        TwojaPostac();
                        Console.WriteLine("Przepyszne. Teraz czas odkrywać nowe miejsca w tym dziwnym świecie...");
                        Menu();
                    }
                    else
                    {
                        Console.Clear();
                        MenuP();
                        Console.WriteLine("Myślisz, że to powtórka z Królewny śnieżki? Możliwe, w tym szalonym świecie wszystko wydaje się prawdopodobne.");
                        Menu();
                    }
                }
                catch
                {
                   Menu();
                   
                }*/
            }
        }
    }
}
/*

        

    }
}
*/
