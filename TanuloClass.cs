using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanulok_konzolos
{
    class TanuloClass
    {
        private int ev;
        private string osztaly;
        private string nev;

        //konstruktor
        public TanuloClass(string sor)
        {
            string[] d = sor.Split(';');
            ev = Convert.ToInt32(d[0]);
            osztaly = d[1];
            nev = d[2];
        }

        //get és set
        public int Ev { get => ev; set => ev = value; }
        public string Osztaly { get => osztaly; set => osztaly = value; }
        public string Nev { get => nev; set => nev = value; }

        public int nevHossz()
        {
            //szóközök megszámolás
            int szokozDB = 0;
            for (int i = 0; i < nev.Length; i++)
            {
                if (nev[i] == ' ')
                {
                    szokozDB++;
                }
            }
            return (nev.Length - szokozDB);
        }

        public string azonosito()
        {
            char elso = ev.ToString()[3];
            string vnev = nev.Split(' ')[0].Substring(0, 3).ToLower();
            string knev = nev.Split(' ')[1].Substring(0, 3).ToLower();
            return (elso+osztaly+vnev+knev);
        }
    }
}
