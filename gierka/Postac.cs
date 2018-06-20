using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace gierka
{
    class Postac
    {
        private string _imie;
        private int _lvl;
        private int _hp;
        private int _exp;
        private int _exp_limit;

        public Postac()
        {            
            _lvl = 1;
            _hp = 10;           
            _exp = 0;
            _exp_limit = 2;
        }

        public void Smierc()
        {
            if (_hp <= 0)
            {
                Console.WriteLine("Upsss...najwyraźniej umarłeś. Aby rozpocząć grę od początku, naciśnij dowolny klawisz:");
                Silniczek S = new Silniczek();
                Console.ReadKey();
                S.Poczatek();
            }
        }

        public string PobierzImie()
        {
            return _imie;
        }
        public void UstawImie(string imie)
        {
            _imie = imie;
        }

        public int PobierzLvl()
        {
            return _lvl;
        }
        public void UstawLvl(int lvl)
        {
            _lvl = lvl;
        }
        
        public int PobierzHP()
        {
            return _hp;
        }
        public void UstawHP(int hp)
        {
            _hp = hp;
            
        }

        public int PobierzExp()
        {
            return _exp;
        }
        public void UstawExp(int exp)
        {
            _exp = exp;
        }

        public int PobierzExpLimit()
        {
            return _exp_limit;
        }
        public void UstawExpLimit(int exp_limit)
        {
            _exp_limit = exp_limit;
        }

        /*class SlabyPrzeciwnik : Postac
        {
                //w konstruktorze muszą być wartosci jakie obecnie ma nasza postać
        }
           
        class MocnyPrzeciwnik : Postac
        {
                //w konstruktorze muszą być większe wartosci niz ma obecnie nasza postać
        }

        class Boss : Postac
        {
            //w konstruktorze muszą być większe wartosci niz ma obecnie nasza postać
        }
        */
    }
}