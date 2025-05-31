/**************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2022 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI 1:
**				ÖĞRENCİ ADI ÖMER KILINÇOĞLU:
**				ÖĞRENCİ NUMARASI G211210571:
**              DERSİN ALINDIĞI GRUP 2B:
**************************/



using System;

namespace CSharpExercises
{
    internal class CSprojeOdev
    {

        private static string _sifre;

        private static int _kucukHarf;

        private static int _buyukHarf;

        private static int _sayi;

        private static int _toplam;


        public static void Main()
        {
            Console.Write("Lütfen şifreyi giriniz: ");

            _sifre = Console.ReadLine();

            Console.WriteLine(Check());
        }

        private static string Check()
        {
            bool kucuckHarfVarMi = false, buyukHarfVarMi = false, sayiVarMi = false, sembolVarMi = false;
            string sonuc = "";

            foreach (var c in _sifre)
            {
                if (!gecerliSembolMu(c)) return "Şifre geçersiz karakterler içeriyor";

                if (kucukHarfMi(c) && _kucukHarf < 2)
                {
                    _kucukHarf++;
                    _toplam += 10;
                    kucuckHarfVarMi = true;
                }

                if (buyukHarfMi(c) && _buyukHarf < 2)
                {
                    _buyukHarf++;
                    _toplam += 10;
                    buyukHarfVarMi = true;
                }

                if (sayiMi(c) && _sayi < 2)
                {
                    _sayi++;
                    _toplam += 10;
                    sayiVarMi = true;
                }

                if (sembolMu(c))
                {
                    _toplam += 10;
                    sembolVarMi = true;
                }
            }
            if (_sifre.Length >= 9) _toplam += 10;

            sonucYazdir(kucuckHarfVarMi, buyukHarfVarMi, sayiVarMi, sembolVarMi);

            if (kucuckHarfVarMi && buyukHarfVarMi && sayiVarMi && sembolVarMi && _sifre.Length >= 9)
            {
                if (_toplam > 70 && _toplam < 90) return "\nzayıf şifre";
                else if (_toplam >= 90) return "\ngüçlü şifre";
            }


            if (!kucuckHarfVarMi && !buyukHarfVarMi && !sayiVarMi && !sembolVarMi)
            {
                sonuc += "\nşifre en az ";
                if (!sayiVarMi) sonuc += "bir sayı, ";
                if (!sembolVarMi) sonuc += "bir özel karakter, ";
                if (!buyukHarfVarMi) sonuc += "bir büyük harf, ";
                if (!kucuckHarfVarMi) sonuc += "bir küçük harf ";
                sonuc += "içermelidir";
            }

            if (_sifre.Length < 9) sonuc += "\n9 karakterden uzun olmalıdır ";
            if (_toplam < 70) sonuc += "\ntoplam puan 70'den büyük olmamalıdır";

            return sonuc;
        }

        private static bool kucukHarfMi(char c)
        {
            return c >= 97 && c <= 122;
        }

        private static bool buyukHarfMi(char c)
        {
            return c >= 65 && c <= 90;
        }

        private static bool sayiMi(char c)
        {
            return c >= 48 && c <= 57;
        }

        private static bool sembolMu(char c)
        {
            return gecerliSembolMu(c) && !kucukHarfMi(c) && !buyukHarfMi(c) && !sayiMi(c);
        }

        private static bool gecerliSembolMu(char c)
        {
            return c > 33 && c < 126;
        }

        private static void sonucYazdir(bool kucuckHarfVarMi, bool buyukHarfVarMi, bool sayiVarMi, bool sembolVarMi)
        {

            if (kucuckHarfVarMi) Console.WriteLine((char)10004 + " Küçük harf");
            else Console.WriteLine('x' + " Küçük harf");

            if (buyukHarfVarMi) Console.WriteLine((char)10004 + " Büyük harf");
            else Console.WriteLine('x' + " Büyük harf");

            if (sembolVarMi) Console.WriteLine((char)10004 + " Özel karakter");
            else Console.WriteLine('x' + " Özel karakter");

            if (sayiVarMi) Console.WriteLine((char)10004 + " Sayı");
            else Console.WriteLine('x' + " Sayı");

            if (_sifre.Length >= 9) Console.WriteLine((char)10004 + " 9 karakter ve daha fazlası");
            else Console.WriteLine('x' + " 9 karakter ve daha fazlası");

            if (_toplam >= 70) Console.WriteLine((char)10004 + " toplam puan 70'den büyük (şimdilik: " + _toplam + ")");
            else Console.WriteLine('x' + " toplam puan 70'den büyük (şimdilik: " + _toplam + ")");
        }
    }
}