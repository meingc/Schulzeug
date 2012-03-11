using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringReverser
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = "zwei boxkaempfer jagen eva quer durch sylt";
            Liste l = new Liste();
            for (int i = 0; i < text.Length; i++)
            {
                String zeichen = text[i].ToString();
                l.anfügenVorn(zeichen);
            }
            for (int i = 0; i < text.Length; i++)
            {
                String zeichen = l.holAnfang();
                Console.Write(zeichen);
            }
        }
    }

    class Liste
    {
        Knoten anfang = null;
        Knoten ende = null;

        public String holAnfang()
        {
            Knoten ergebnis = anfang;
            if (anfang == ende)
            {
                anfang = null;
                ende = null;
            }
            else
            {
                anfang.nachfolger.vorgänger = null;
                anfang = anfang.nachfolger;
                ergebnis.nachfolger = null;
            }
            return ergebnis.inhalt;
        }

        public String holEnde()
        {
            Knoten ergebnis = ende;
            if (anfang == ende)
            {
                anfang = null;
                ende = null;
            }
            else
            {
                ende = ende.vorgänger;
                ende.nachfolger = null;
                ergebnis.vorgänger = null;
            }
            return ergebnis.inhalt;
        }

        public void anfügenVorn(String s)
        {
            Knoten k = new Knoten(s);
            anfügenVorn(k);
        }

        public void anfügenVorn(Knoten k)
        {
            if (anfang == null)
            {
                anfang = k;
                ende = k;
            }
            else
            {
                anfang.vorgänger = k;
                k.nachfolger = anfang;
                anfang = k;
            }
        }

        public void anfügenHinten(String s)
        {
            Knoten k = new Knoten(s);
            anfügenHinten(k);
        }

        public void anfügenHinten(Knoten k)
        {
            if (ende == null)
            {
                ende = k;
                anfang = k;
            }
            else
            {
                ende.nachfolger = k;
                k.vorgänger = ende;
                ende = k;
            }
        }
    }

    class Knoten
    {
        public String inhalt = "";
        public Knoten nachfolger = null;
        public Knoten vorgänger = null;

        public Knoten(String s)
        {
            this.inhalt = s;
        }
    }
}
