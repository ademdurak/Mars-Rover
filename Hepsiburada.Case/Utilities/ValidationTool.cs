using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Case.Utilities
{
    public static class ValidationTool
    {
        /// <summary>
        /// Kullanıcı tarafından girilen gezici konumunun plato sınırları içerisinden olup olmadığı ve doğru formattamı girildiği kontrol ediliyor.
        /// </summary>
        /// <param name="plateau">Gezginin indirildiği yer.</param>
        /// <param name="roverLocationArr">Gezginin indiridiği nokta ve yön bilgisinin olduğu string dizi</param>
        /// <returns>Geriye true yada false döner</returns>
        public static bool IsLocationEntryCorrect(Plateau plateau, string[] roverLocationArr)
        {
            return roverLocationArr.Length == 3 && Convert.ToInt32(roverLocationArr[0]) <= plateau.maxHorizantelLineCount && Convert.ToInt32(roverLocationArr[1]) <= plateau.maxVeriticalLineCount;
        }

        /// <summary>
        /// Kullanıcı tarafından girilen komutların uygunluğu kontrol ediliyor
        /// </summary>
        /// <param name="movementsArr">Kullanıcı tarafından girilen hareket komutlari.</param>
        /// <returns>Geriye true yada false döner</returns>
        public static bool IsMovementEntryCorrect(char[] movementsArr)
        {
            return movementsArr.Any(e => e.Equals('L') || e.Equals('R') || e.Equals('M'));
        }
    }
}
