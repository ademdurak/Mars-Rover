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
            bool newRoverTransaction = true;
            var plateau = GetInformationPlateau();

            while (newRoverTransaction)
            {
                var rover = GetRoverInformation(plateau);

                rover.PrintLocationRover();

                if (!NewRover())
                {
                    newRoverTransaction = false;
                }

            }

        }

        /// <summary>
        /// Yeni gezgin yerleştirmek istenip istenmediği kullanıcıya sorulur. Gelen cevaba göre true yada false döner geriye.
        /// </summary>
        /// <returns>Geriye true yada false döner</returns>
        private static bool NewRover()
        {
            Console.WriteLine("Yeni gezgin yerleştirmek istiyormusunuz ? Evet(E)");
            return Console.ReadLine().ToUpper() == "E";
        }


        /// <summary>
        /// Plato sınırları kullanıcıdan alınıyor ve yeni bir plato oluşturulur.
        /// </summary>
        /// <returns>Geriye plato nesnesi döner</returns>
        private static Plateau GetInformationPlateau()
        {
            string plateauInformation;
            string[] plateauInformationArr;

            Console.WriteLine("Platoyu boyutunu giriniz.");
            do
            {
                plateauInformation = Console.ReadLine();
                plateauInformationArr = plateauInformation.Split(' ');
                if (plateauInformationArr.Length != 2)
                {
                    Console.WriteLine("Platoyu boyutunu hatalı girdiniz lütfen tekrar deneyiniz.");
                }

            } while (plateauInformationArr.Length != 2);


            return new Plateau(Convert.ToInt32(plateauInformationArr[0]), Convert.ToInt32(plateauInformationArr[1]));

        }


        /// <summary>
        /// Kullanıcıdan talimatlarla geziciler hakkında gerekli bilgiler alınıyor.
        /// </summary>
        /// <param name="plateau">Plato nesnesi.</param>
        /// <returns>Geriye gezgin nesnesi döner</returns>
        private static Rover GetRoverInformation(Plateau plateau)
        {
            string roverLocation, movements = "";
            string[] roverLocationArr;

            int transactionInformation;
            do
            {
                Console.WriteLine("Geziciyi nereye konuşlandıracaksınız ?");

                roverLocation = Console.ReadLine();
                roverLocationArr = roverLocation.Split(' ');

                if (!ValidationTool.IsLocationEntryCorrect(plateau, roverLocationArr))
                {
                    Console.WriteLine("Hatalı giriş yapıldı tekrar kontrol ederek giriş yapınız.");
                    transactionInformation = (int)(Command.Continue);
                    continue;
                }

                Console.WriteLine("Gezicinin izleyeceği adımları giriniz ? ");
                movements = Console.ReadLine();
                if (!ValidationTool.IsMovementEntryCorrect(movements.ToCharArray()))
                {
                    Console.WriteLine("Hatalı giriş yapıldı tekrar kontrol ederek giriş yapınız.");
                    transactionInformation = (int)(Command.Continue);
                    continue;
                }

                transactionInformation = 0;

            } while ((int)(Command.Continue) == transactionInformation);

            Point point = new Point();
            point.x = Convert.ToInt32(roverLocationArr[0]);
            point.y = Convert.ToInt32(roverLocationArr[1]);

            var rover = new Rover(plateau, point, Convert.ToChar(roverLocationArr[2]));
            rover.Go(movements);

            return rover;
        }

    }
}
