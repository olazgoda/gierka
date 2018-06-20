using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gierka
{
    class Mapa
    {
        private int Zaklecie;
        int X;
        int Y;
        int Opcja;
        Lokacja[,] TablicaLokacji = new Lokacja[4, 4];
        public Mapa()
        {
            TablicaLokacji[0, 1] = null;                 //                               null
            TablicaLokacji[2, 2] = null;                 //                               null
            TablicaLokacji[1, 1] = null;                 //                               null
            TablicaLokacji[2, 1] = null;                //                                null

            TablicaLokacji[0, 0] = new Lokacja(1);   // początek- 1-2 słabe trolle     -1

            TablicaLokacji[3, 1] = new Lokacja(1);   // 1-2 slabe trolle               -1

            TablicaLokacji[0, 2] = new Lokacja(2);   //puste ale można tam wejść       -2
            TablicaLokacji[3, 2] = new Lokacja(2);   //puste ale można tam wejść       -2
            TablicaLokacji[2, 3] = new Lokacja(2);   //puste ale można tam wejść       -2
            TablicaLokacji[3, 0] = new Lokacja(2);   //puste ale można tam wejść       -2

            TablicaLokacji[0, 3] = new Lokacja(3);   //mag i zaklecie                  -3

            TablicaLokacji[1, 0] = new Lokacja(4);   // 2 trolle i jabłko              -4

            TablicaLokacji[1, 2] = new Lokacja(5);   // boss                           -5 

            TablicaLokacji[3, 3] = new Lokacja(6);   // 1 mocny cyklop lvl 5           -6
            TablicaLokacji[2, 0] = new Lokacja(6);   // 1 mocny cyklop lvl 8           -6

            TablicaLokacji[1, 3] = new Lokacja(7);   //  1 jablko                      -7
        }

        public int RodzajLokacji()
        {
            Opcja = TablicaLokacji[Y, X].ZwrocOpcjeLokacji();
            return Opcja;
        }

        public int WersjaMenu()
        {
            int menu = TablicaLokacji[Y, X].WersjaMenu();
            return menu;
        }


        private int troll;
        public int IleTrolli
        {
            get
            {
                troll = (TablicaLokacji[Y, X].IloscTrolli);
                return troll;
            }
            set
            {
                troll = value;
                TablicaLokacji[Y, X].IloscTrolli = troll;
            }
        }

        private int Jablko;
        public int IleJablek
        {
            get
            {
                Jablko = TablicaLokacji[Y, X].IloscJablko();
                return Jablko;
            }
            set
            {
                if (value>=0 & value<2)
                {
                    Jablko = value;
                }
            }
        }

        public void OpisLokacji()
        {
            
            Opcja = TablicaLokacji[Y, X].ZwrocOpcjeLokacji();
            TablicaLokacji[Y, X].OpisLokacji_MetodaZaleznaOdOpcji(Opcja);
            Zaklecie = TablicaLokacji[Y, X].zaklecie();
        }


        public int PobierzZaklecie()
        {
            return Zaklecie;
        }
        public void UstawZaklecie()
        {
            Zaklecie = TablicaLokacji[X, Y].zaklecie();
        }


        public int PobierzX()
        {
            return X;
        }
        public void UstawX(int _X)
        {
            X = _X;
        }

        public int PobierzY()
        {
            return Y;
        }
        public void UstawY(int _Y)
        {
            Y = _Y;
        }

        public bool SprGora()
        {
            if (TablicaLokacji[(Y - 1), X] is null)
                return false;
            else return true;
        }
        public bool SprDol()
        {
            if (TablicaLokacji[(Y + 1), X] is null)
                return false;
            else return true;
        }
        public bool SprLewo()
        {
            if (TablicaLokacji[Y, (X - 1)] is null)
                return false;
            else return true;
        }
        public bool SprPrawo()
        {
            if (TablicaLokacji[Y, (X + 1)] is null)
                return false;
            else return true;
        }

        public void Koordynaty()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Obecnie znajdujesz się w lokacji zaznaczonej literką X:");
            Console.WriteLine();
            RysujMape();
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void RysujMape()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            string[,] MapaSwiata = new string[4,4];
            for (int k = 0; k <= 3; k++)
            {
                for (int l = 0; l <= 3; l++)
                {
                    if (TablicaLokacji[k, l] == null)
                    {
                        MapaSwiata[k, l] = "[█]";
                    }
                    else
                    {
                        MapaSwiata[k, l] = "[ ]";
                    }
                }
            }           
            MapaSwiata[Y, X] = "[X]";
            for (int k = 0; k <= 3; k++)
            {
                for (int l = 0; l <= 3; l++)

                    Console.Write(MapaSwiata[k, l]);
                    Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}

