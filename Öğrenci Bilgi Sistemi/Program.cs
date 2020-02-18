using System;
using System.Collections.Generic;

namespace Öğrenci_Bilgi_Sistemi
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            List<Ders> dersler = new List<Ders>();
            VeriGir(ogrenciler, dersler);
            VeriYazdir(ogrenciler, dersler);
            Console.ReadKey();
        }

        private static void VeriGir(List<Ogrenci> ogrenciler, List<Ders> dersler)
        {
            try
            {
                Console.WriteLine("Öğrenci Bilgisi Girmek İçin 1, Bilgileri Yazdırıp Çıkmak İçin 2'yi Tuşlayın.");
                string girdi = Console.ReadLine();
                while (girdi == "1")
                {
                    int i = 0;
                    Console.WriteLine("Öğrenci Numarası Giriniz:");
                    uint ogrenciNo = Convert.ToUInt32(Console.ReadLine());

                    Console.WriteLine("Öğrenci İsmi Giriniz:");
                    string ogrenciAdi = Console.ReadLine();

                    Console.WriteLine("Öğrenci Bölümü Giriniz:");
                    string ogrenciBolumu = Console.ReadLine();

                    Console.WriteLine("Lisans Öğrencisi Eklemek İçin 1'i, Master Öğrencisi Eklemek için 2'yi, Doktora Öğrencisi Eklemek İçin 3'ü tuşlayın.");
                    girdi = Console.ReadLine();

                    if (girdi == "1")
                    {
                        ogrenciler.Add(new LisansOgrencisi(ogrenciNo, ogrenciAdi, ogrenciBolumu));
                    }
                    else if (girdi == "2")
                    {
                        Console.WriteLine("Master Öğrencisinin Master Yaptığı Üniversiteyi Giriniz.");
                        string masterUniversitesi = Console.ReadLine();

                        Console.WriteLine("Master Öğrencisinin Master Yaptığı Bölümü Giriniz.");
                        string masterBolumu = Console.ReadLine();

                        ogrenciler.Add(new MasterOgrencisi(ogrenciNo, ogrenciAdi, ogrenciBolumu, masterUniversitesi, masterBolumu));
                    }
                    else
                    {
                        Console.WriteLine("Doktora Öğrencisinin Doktora Yaptığı Üniversiteyi Giriniz.");
                        string doktoraUniversitesi = Console.ReadLine();

                        Console.WriteLine("Doktora Öğrencisinin Doktora Yaptığı Bölümü Giriniz.");
                        string doktoraBolumu = Console.ReadLine();

                        Console.WriteLine("Doktora Öğrencisinin Master Yaptığı Üniversiteyi Giriniz.");
                        string lisansUniversitesi = Console.ReadLine();

                        Console.WriteLine("Doktora Öğrencisinin Master Yaptığı Bölümü Giriniz.");
                        string lisansBolumu = Console.ReadLine();

                        ogrenciler.Add(new DoktoraOgrencisi(ogrenciNo, ogrenciAdi, ogrenciBolumu, lisansUniversitesi, lisansBolumu, doktoraUniversitesi, doktoraBolumu));
                    }

                    while (true)
                    {
                        int j = 0;
                        Console.WriteLine("Ders Adı Giriniz:");
                        string dersAdi = Console.ReadLine();

                        Console.WriteLine("Ders Kodu Giriniz:");
                        string dersKodu = Console.ReadLine();

                        Console.WriteLine("Ders Kredisi Giriniz:");
                        uint dersKredisi = Convert.ToUInt32(Console.ReadLine());

                        Console.WriteLine("Ders Notu Giriniz:");
                        uint dersNotu = Convert.ToUInt32(Console.ReadLine());

                        dersler.Add(new Ders(dersKodu, dersAdi, dersKredisi));
                        ogrenciler[i].DersEkle(dersler[j], dersNotu);

                        Console.WriteLine("Çıkmak İçin 0, Devam etmek için 1'e Tuşlayın");
                        string girdi2 = Console.ReadLine();
                        if (girdi2 == "0")
                        {
                            break;
                        }
                        j++;
                    }
                    i++;
                    Console.WriteLine("Öğrenci Bilgisi Girmek İçin 1, Bilgileri Yazdırıp Çıkmak İçin 2'yi Tuşlayın.");
                    girdi = Console.ReadLine();
                }
            }
            catch { }
        }

        public static void VeriYazdir(List<Ogrenci> ogrenciler, List<Ders> dersler)
        {
            for (int i = 0; i < ogrenciler.Count; i++)
            {
                if (ogrenciler[i] is LisansOgrencisi)
                    Console.WriteLine("Lisans Öğrencisi");
                else if (ogrenciler[i] is MasterOgrencisi)
                    Console.WriteLine("Master Öğrencisi");
                else if (ogrenciler[i] is DoktoraOgrencisi)
                    Console.WriteLine("Doktora Öğrencisi");
                Console.WriteLine("Numara: {0} İsim: {1}", ogrenciler[i].OgrenciNo, ogrenciler[i].OgrenciAdi);
                Console.WriteLine("Bölüm: {0}", (ogrenciler[i].Bolum));

                if (ogrenciler[i] is LisansOgrencisi)
                {
                    
                }
                else if (ogrenciler[i] is MasterOgrencisi)
                {
                    Console.WriteLine("Lisans Üniversitesi: {0}", ((MasterOgrencisi)ogrenciler[i]).LisansUniversitesi);
                    Console.WriteLine("Lisans Bölümü: {0}", ((MasterOgrencisi)ogrenciler[i]).LisansBolumu);
                }
                else if (ogrenciler[i] is DoktoraOgrencisi)
                {
                    Console.WriteLine("Lisans Üniversitesi: {0}", ((DoktoraOgrencisi)ogrenciler[i]).LisansUniversitesi);
                    Console.WriteLine("Lisans Bölümü: {0}", ((DoktoraOgrencisi)ogrenciler[i]).LisansBolumu);
                    Console.WriteLine("Master Üniversitesi: {0}", ((DoktoraOgrencisi)ogrenciler[i]).MasterUniversitesi);
                    Console.WriteLine("Master Bölümü: {0}", ((DoktoraOgrencisi)ogrenciler[i]).MasterBolumu);
                }

                for (int j = 0; j < ogrenciler[i].Dersler.Count; j++)
                {
                    Console.WriteLine("{1} {2} Kredi: {3}{0}Not: {4}", Environment.NewLine, ogrenciler[i].Dersler[j].dersKodu,
                        ogrenciler[i].Dersler[j].dersAdi, ogrenciler[i].Dersler[j].dersKredisi, ogrenciler[i].Notlar[j]);
                }
                Console.WriteLine("Öğrenci Not Ortalaması: {0}", ogrenciler[i].NotOrt);
                Console.WriteLine();
            }
        }
    }
}
