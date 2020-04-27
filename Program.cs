using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanulok_konzolos
{
    class JelszoGeneralo
    {
        private Random Rnd;

        public JelszoGeneralo(Random r)
        {
            Rnd = r;
        }

        public string Jelszó(int jelszóHossz)
        {
            string jelszó = "";
            while (jelszó.Length < jelszóHossz)
            {
                char c = (char)Rnd.Next(48, 123);
                if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z'))
                {
                    jelszó += c;
                }
            }
            return jelszó;
        }
    }

    class Program
    {
        static List<TanuloClass> tanLista = new List<TanuloClass>();

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("nevek.txt", Encoding.UTF8);
            string sor = "";
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                TanuloClass t = new TanuloClass(sor);
                tanLista.Add(t);
            }
            sr.Close();

            Console.WriteLine("3. feladat");
            Console.WriteLine("Az iskolába járó tanulók: " + tanLista.Count);
            Console.WriteLine($"Ennyien vannak: {tanLista.Count}");


            Console.WriteLine("4. feladat");
            int maxHossz = tanLista[0].nevHossz();
            for (int i = 0; i < tanLista.Count; i++)
            {
                if (tanLista[i].nevHossz() > maxHossz)
                {
                    maxHossz = tanLista[i].nevHossz();
                }
            }
            Console.WriteLine("A leghosszabb név: " + maxHossz);
            for (int i = 0; i < tanLista.Count; i++)
            {
                if (tanLista[i].nevHossz() == maxHossz)
                {
                    Console.WriteLine(tanLista[i].Nev);
                }
            }

            Console.WriteLine("5. feladat");
            Console.WriteLine("Első tanuló: " + tanLista[0].Nev + ", " + tanLista[0].azonosito());
            Console.WriteLine("Utolsó tanuló: " + tanLista[tanLista.Count-1].Nev + ", " 
                + tanLista[tanLista.Count - 1].azonosito());

            Console.WriteLine("6. feladat");
            Console.Write("Kérek egy azonosítót: ");
            string bekertAzon = Console.ReadLine();
            int index = 0;
            bool vanIlyen = false;
            while (vanIlyen == false && index < tanLista.Count)
            {
                if (tanLista[index].azonosito() == bekertAzon)
                {
                    vanIlyen = true;
                    Console.WriteLine(tanLista[index].Nev);
                }
                else
                {
                    index++;
                }
            }
            if (vanIlyen == false)
            {
                Console.WriteLine("Nincs ilyen tanuló!");
            }

            Console.WriteLine("7. feladat");
            //Véletlen tanuló kiválasztása
            Random r = new Random();
            int randomIndex = r.Next(0,tanLista.Count);
            TanuloClass randomTanulo = tanLista[randomIndex];
            JelszoGeneralo j = new JelszoGeneralo(r);
            Console.WriteLine("A tanuló: " + randomTanulo.Nev);
            Console.WriteLine("A jelszó: " + j.Jelszó(8));

            Console.ReadKey();
        }
    }
}
