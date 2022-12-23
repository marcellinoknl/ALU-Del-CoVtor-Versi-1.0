using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelCoVtor
{
    /// <summary>
    /// Membuat class untuk menampung algoritma pembuatan struktur daerah--
    /// </summary>
    public class DaerahInfected
    {
        private readonly int jumlahOrang; // jumlah manusia di daerah yang ditujukan
        public int hariAwal; // Hari awal terjadinya infeksi virus
        private readonly string namaDaerah;

        //Membuat Constructor dengan parameter jumlahOrang dan namaDaerah
        public DaerahInfected(string namaDaerah, int jumlahOrang)
        {
            this.namaDaerah = namaDaerah;
            this.jumlahOrang = jumlahOrang;
        }

        public DaerahInfected(DaerahInfected daerahinfected) : this(daerahinfected.namaDaerah, daerahinfected.jumlahOrang)
        {
            //inisialisasi cosntructor kosong
        }
        public void Reset()
        {
            hariAwal = int.MaxValue; 
        }
        //inisialisasi method untuk Nama Daerah terinfeksi
        public string GetNamaDaerah()
        {
            return this.namaDaerah;
        }
        //inisialisasi method untuk jumlah orang
        public int DataCountMasayarakat()
        {
            return this.jumlahOrang;
        }

        //Awal daerah terinfeksi virus (Hari ke- ...)
        public int DayInfected()
        {
            return this.hariAwal;
        }

        //Kalkulasi infeksi virus mewabah
        public double InfectedByTheDuration(int DayMax)
        {
            double data = (double)DataCountMasayarakat();
            //Kalkulasi exponensial penyebaran virus
            double calculationSet1 = Math.Exp(-0.25 * DurationByInfected(DayMax));
            //set variable tampung hasil perhitungan daerah terinfeksi
            double result = data / (1 + (data - 1) * calculationSet1);
            return result;
        }

        //Durasi wabah virus menginfeksi Daerah X
        public int DurationByInfected(int DayMax)
        {
            int data = DayMax - hariAwal;
            return data;
        }



    }
}
