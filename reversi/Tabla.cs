using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace reversi
{
    class Tabla
    {
        private char[,] t { get; set; }

        public Tabla(string fajl)
        {
            t = new char[8, 8];
            using (StreamReader sr = new StreamReader(fajl))
            {
                for (int sor = 0; sor < 8; sor++)
                {
                    string srSor = sr.ReadLine();
                    for (int oszlop = 0; oszlop < 8; oszlop++)
                    {
                        t[sor, oszlop] = srSor[oszlop];
                    }
                }
            }
        }

        public string Megjelenit()
        {
            string sorok = "";
            for (int sor = 0; sor < 8; sor++)
            {
                sorok += "\t";
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    sorok += t[sor, oszlop];
                }
                sorok += "\n";
            }
            return sorok;
        }

        public int Osszegzes(char karakter)
        {
            int db = 0;
            for (int sor = 0; sor < 8; sor++)
            {
                for (int oszlop = 0; oszlop < 8; oszlop++)
                {
                    if (t[oszlop, sor] == karakter)
                    {
                        db++;
                    }
                }
            }
            return db;
        }

        public bool VanForditas(char jatekos, int sor, int oszlop, int iranySor, int iranyOszlop)
        {
            int aktSor, aktOszlop;
            char ellenfel;
            bool nincsEllenfel;
            aktSor = sor + iranySor;
            aktOszlop = oszlop + iranyOszlop;
            ellenfel = 'K';

            if (jatekos == 'K')
            {
                ellenfel = 'F';
            }
            nincsEllenfel = true;

            while (aktSor > 0 && aktSor < 8 && aktOszlop > 0 && aktOszlop < 8 && t[aktSor, aktOszlop] == ellenfel)
            {
                aktSor = aktSor + iranySor;
                aktOszlop = aktOszlop + iranyOszlop;
                nincsEllenfel = false;
            }

            if (nincsEllenfel || aktSor < 0 || aktSor > 7 || aktOszlop < 0 || aktOszlop > 7 || t[aktSor, aktOszlop] != jatekos)
            {
                return false;
            }

            return true;
        }

        public bool Lepes(char jatekos, int sor, int oszlop)
        {
            bool vanForditas = Ellenorzes(jatekos, sor, oszlop);

            if (t[sor, oszlop] == '#' && vanForditas)
            {
                return true;
            }

            return false;
        }

        private bool Ellenorzes(char jatekos, int sor, int oszlop)
        {
            for (int sorSzam = -1; sorSzam < 2; sorSzam++)
            {
                for (int oszlopSzam = -1; oszlopSzam < 2; oszlopSzam++)
                {
                    if (sorSzam != 0 && oszlopSzam != 0)
                    {
                        if (VanForditas(jatekos, sor, oszlop, sorSzam, oszlopSzam))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
