using System.Collections.Generic;

namespace Öğrenci_Bilgi_Sistemi
{
    abstract class Ogrenci
    {
        private uint ogrenciNo;
        public uint OgrenciNo
        {
            get
            {
                return ogrenciNo;
            }
            set
            {
                ogrenciNo = value;
            }
        }

        private string ogrenciAdi;
        public string OgrenciAdi
        {
            get
            {
                return ogrenciAdi;
            }
            set
            {
                ogrenciAdi = value;
            }
        }

        private string bolum;
        public string Bolum
        {
            get
            {
                return bolum;
            }
            set
            {
                bolum = value;
            }
        }

        private List<Ders> dersler = new List<Ders>();
        public List<Ders> Dersler
        {
            get
            {
                return dersler;
            }
            set
            {
                dersler = value;
            }
        }

        private List<uint> notlar = new List<uint>();
        public List<uint> Notlar
        {
            get
            {
                return notlar;
            }
            set
            {
                notlar = value;
            }
        }

        private double notOrt;
        public double NotOrt
        {
            get
            {
                return NotHesapla();
            }
        }

        public double NotHesapla()
        {
            uint toplamKredi = 0;
            uint notKrediCarpimi = 0; // formülün pay kısmı için

            for (int i = 0; i < Dersler.Count; i++)
            {
                toplamKredi += dersler[i].dersKredisi;
                notKrediCarpimi += dersler[i].dersKredisi * Notlar[i];
            }
            double NotOrtalamasi = (double)notKrediCarpimi / toplamKredi;
            return NotOrtalamasi;
        }

        public int DersEkle(Ders ders, uint not)
        {
            if (not < 0 && not > 100)
            {
                return -1;
            }
            Dersler.Add(ders);
            Notlar.Add(not);
            return 0;
        }

        public Ogrenci(uint ogrenciNo, string ogrenciAdi, string bolumAdi)
        {
            OgrenciAdi = ogrenciAdi;
            OgrenciNo = ogrenciNo;
            Bolum = bolumAdi;
        }
    }

    class LisansOgrencisi : Ogrenci
    {
        public LisansOgrencisi(uint ogrenciNo, string ogrenciAdi, string bolumAdi) 
            : base(ogrenciNo, ogrenciAdi, bolumAdi)
        {
        }
    }

    class MasterOgrencisi : Ogrenci
    {
        private string lisansUniversitesi;
        public string LisansUniversitesi
        {
            get
            {
                return lisansUniversitesi;
            }
            set
            {
                lisansUniversitesi = value;
            }
        }

        private string lisansBolumu;
        public string LisansBolumu
        {
            get
            {
                return lisansBolumu;
            }
            set
            {
                lisansBolumu = value;
            }
        }

        public MasterOgrencisi(uint ogrenciNo, string ogrenciAdi, string bolumAdi, string lisansUniversitesi, string lisansBolumu)
            : base(ogrenciNo, ogrenciAdi, bolumAdi)
        {
            Bolum = bolumAdi;
            LisansUniversitesi = lisansUniversitesi;
            LisansBolumu = lisansBolumu;
        }
    }

    class DoktoraOgrencisi : Ogrenci
    {
        private string lisansUniversitesi;
        public string LisansUniversitesi
        {
            get
            {
                return lisansUniversitesi;
            }
            set
            {
                lisansUniversitesi = value;
            }
        }

        private string lisansBolumu;
        public string LisansBolumu
        {
            get
            {
                return lisansBolumu;
            }
            set
            {
                lisansBolumu = value;
            }
        }

        private string masterUniversitesi;
        public string MasterUniversitesi
        {
            get
            {
                return masterUniversitesi;
            }
            set
            {
                masterUniversitesi = value;
            }           
        }

        private string masterBolumu;
        public string MasterBolumu
        {
            get
            {
                return masterBolumu;
            }
            set
            {
                masterBolumu = value;
            }             
        }

        public DoktoraOgrencisi(uint ogrenciNo, string ogrenciAdi, string bolumAdi, string lisansUniversitesi, string lisansBolumu, string masterUniversitesi, string masterBolumu)
            : base(ogrenciNo, ogrenciAdi, bolumAdi)
        {
            Bolum = bolumAdi;
            LisansBolumu = lisansBolumu;
            LisansUniversitesi = lisansUniversitesi;
            MasterUniversitesi = masterUniversitesi;
            MasterBolumu = masterBolumu;
        }
    }
}