using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Autok
{
    class Auto
    {
        int sorszam;
        string marka;
        string model;
        int gyartasi_ev;
        string szin;
        int eladott_darabszam;
        double atlagos_eladasi_ar;

        public Auto(string sor)
        {
            string[] splitelve = sor.Split(";");
            this.Sorszam = int.Parse(splitelve[0]);
            this.Marka = splitelve[1];
            this.Model = splitelve[2];
            this.Gyartasi_ev = int.Parse(splitelve[3]);
            this.Szin = splitelve[4];
            this.Eladott_darabszam = int.Parse(splitelve[5]);
            this.Atlagos_eladasi_ar = double.Parse(splitelve[6]);
        }

        public int Sorszam { get => sorszam; set => sorszam = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public int Gyartasi_ev { get => gyartasi_ev; set => gyartasi_ev = value; }
        public string Szin { get => szin; set => szin = value; }
        public int Eladott_darabszam { get => eladott_darabszam; set => eladott_darabszam = value; }
        public double Atlagos_eladasi_ar { get => atlagos_eladasi_ar; set => atlagos_eladasi_ar = value; }
        public static List<Auto> Beolvasas(string eleresi_ut)
        {
            List<Auto> autoklistaba = new List<Auto>();
            StreamReader sr = new StreamReader(eleresi_ut);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                autoklistaba.Add(new Auto(sr.ReadLine()));
            }
            return autoklistaba;
        }
    }
}
