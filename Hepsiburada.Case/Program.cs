using Hepsiburada.Case.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Case
{
    class Program
    {

        static void Main(string[] args)
        {
            bool yeniGezginIslemi = true;
            var plato = PlatoBilgileriniAl();

            while (yeniGezginIslemi)
            {
                var gezici = GeziciBilgileriniAl(plato);

                gezici.GezgininKonumunuYazdir();

                if (!YeniGezgin())
                {
                    yeniGezginIslemi = false;
                }

            }

            Console.ReadLine();
        }

        private static bool YeniGezgin()
        {
            Console.WriteLine("Yeni gezgin yerleştirmek istiyormusunuz ? Evet(E)");
            return Console.ReadLine().ToUpper() == "E";
        }


        /// <summary>
        /// Plato sınırları kullanıcıdan alınıyor.
        /// </summary>
        private static Plato PlatoBilgileriniAl()
        {
            string platoBoyutu;
            string[] platoBoyutuArr;

            Console.WriteLine("Platoyu boyutunu giriniz.");
            do
            {
                platoBoyutu = Console.ReadLine();
                if (platoBoyutu.Split(' ').Length != 2)
                {
                    Console.WriteLine("Platoyu boyutunu hatalı girdiniz lütfen tekrar deneyiniz.");
                }

            } while (platoBoyutu.Split(' ').Length != 2);

            platoBoyutuArr = platoBoyutu.Split(' ');

            return new Plato(Convert.ToInt32(platoBoyutuArr[0]), Convert.ToInt32(platoBoyutuArr[1]));

        }


        /// <summary>
        /// Kullanıcıdan talimatlarla geziciler hakkında gerekli bilgiler alınıyor.
        /// </summary>
        private static Gezgin GeziciBilgileriniAl(Plato plato)
        {
            string geziciYeri, geziciHareketi = "";
            string[] geziciYeriArr;

            int islemBilgisi;
            do
            {
                Console.WriteLine("Geziciyi nereye konuşlandıracaksınız ?");

                geziciYeri = Console.ReadLine();
                geziciYeriArr = geziciYeri.Split(' ');

                if (DogrulamaAraclari.KonumGirdisiDogruMu(plato, geziciYeriArr))
                {
                    Console.WriteLine("Hatalı giriş yapıldı tekrar kontrol ederek giriş yapınız.");
                    islemBilgisi = (int)(KomutDizini.Devam);
                    continue;
                }

                Console.WriteLine("Gezicinin izleyeceği adımları giriniz ? ");
                geziciHareketi = Console.ReadLine();
                islemBilgisi = 0;

            } while ((int)(KomutDizini.Devam) == islemBilgisi);

            Nokta nokta = new Nokta();
            nokta.x = Convert.ToInt32(geziciYeriArr[0]);
            nokta.y = Convert.ToInt32(geziciYeriArr[1]);

            var gezgin = new Gezgin(plato, nokta, Convert.ToChar(geziciYeriArr[2]));
            gezgin.Ilerle(geziciHareketi);

            return gezgin;
        }

    }
}
