using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace gierka
{
    class Przedmiot
    {
        public Przedmiot() ////zrobic rozdzke i klucz, lista ich- to ekwipunek postac 
        {
        }       
        public string NazwaPrzedmiotu { get; set; }
        public int Moc { get; set; }

        public override string ToString()
        {
            return NazwaPrzedmiotu + ", moc: " + Moc;
        }         
    }
     
}
      

