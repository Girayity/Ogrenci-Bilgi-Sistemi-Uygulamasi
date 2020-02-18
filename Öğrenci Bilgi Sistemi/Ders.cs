
namespace Öğrenci_Bilgi_Sistemi
{
    class Ders
    {
        public string dersAdi;
        public string DersAdi
        {
            get
            {
                return dersAdi;
            }
            set
            {
                 dersAdi = value;
            }
        }

        public string dersKodu;
        public string DersKodu
        {
            get
            {
                return dersKodu;
            }
            set
            {
                dersKodu = value; 
            }
        }

        public uint dersKredisi;
        public uint DersKredisi
        {
            get
            {
                return dersKredisi;
            }
            set
            {
                dersKredisi = value;
            }
        }

        public Ders(string dersKodu, string dersAdi, uint dersKredisi)
        {
            DersAdi = dersAdi;
            DersKodu = dersKodu;
            DersKredisi = dersKredisi;
        }

    }
}
