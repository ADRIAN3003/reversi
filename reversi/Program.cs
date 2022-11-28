using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversi
{
    class Program
    {
        static Tabla tabla;
        static void Main(string[] args)
        {
            NegyedikFeladat();
            OtodikFeladat();
            HatodikFeladat();
            NyolcadikFeladat();
            KilencedikFeladat();

            Console.ReadKey();
        }

        private static void KilencedikFeladat()
        {
            Console.Write("\n9. feladat: [jatekos;sor;oszlop] = ");
            string[] bekeres = Console.ReadLine().Split(';');
            if (tabla.Lepes(
                    Convert.ToChar(bekeres[0]),
                    Convert.ToInt32(bekeres[1]),
                    Convert.ToInt32(bekeres[2])))
            {
                Console.WriteLine("\tSzabályos lépés!");
            }
            else
            {
                Console.WriteLine("\tSzabálytalan lépés!");
            }
        }

        private static void NyolcadikFeladat()
        {
            Console.Write("\n8. feladat: [jatekos;sor;oszlop;iranySor;iranyOszlop] = ");
            string[] bekeres = Console.ReadLine().Split(';');
            if (tabla.VanForditas(
                    Convert.ToChar(bekeres[0]),
                    Convert.ToInt32(bekeres[1]),
                    Convert.ToInt32(bekeres[2]),
                    Convert.ToInt32(bekeres[3]), 
                    Convert.ToInt32(bekeres[4])))
            {
                Console.WriteLine("\tVan fordítás!");
            } 
            else
            {
                Console.WriteLine("\tNincs fordítás!");
            }
        }

        private static void HatodikFeladat()
        {
            Console.WriteLine("6. feladat: Összegzés");
            Console.WriteLine("\tKék korongok száma: " + tabla.Osszegzes('K'));
            Console.WriteLine("\tFehér korongok száma: " + tabla.Osszegzes('F'));
            Console.WriteLine("\tÜres mezők száma: " + tabla.Osszegzes('#'));
        }

        private static void OtodikFeladat()
        {
            Console.WriteLine("5. feladat: A betöltött tábla");
            Console.WriteLine(tabla.Megjelenit());
        }

        private static void NegyedikFeladat()
        {
            tabla = new Tabla("allas.txt");
        }
    }
}
