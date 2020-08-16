using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Case.Utilities
{
    public static class DogrulamaAraclari
    {
        /// <summary>
        /// Kullanıcı tarafından girilen gezici konumunun plato sınırları içerisinden olup olmadığı ve doğru formattamı girildiği kontrol ediliyor.
        /// </summary>
        /// <param name="plato">Gezginin indirildiği yer.</param>
        /// <param name="geziciYeriArr">Gezginin indiridiği nokta ve yön bilgisinin olduğu string dizi</param>
        /// <returns></returns>
        public static bool KonumGirdisiDogruMu(Plato plato, string[] geziciYeriArr)
        {
            return geziciYeriArr.Length != 3 && Convert.ToInt32(geziciYeriArr[0]) >= plato.En && Convert.ToInt32(geziciYeriArr[1]) >= plato.Boy;
        }
    }
}
