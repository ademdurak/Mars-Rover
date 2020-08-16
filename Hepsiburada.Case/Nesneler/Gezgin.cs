using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Case
{
    public class Gezgin
    {
        private readonly Plato _platoSiniri;
        private readonly Nokta _nokta;
        private char yon;


        public Gezgin(Plato plato, Nokta nokta, char yon)
        {
            _platoSiniri = plato;
            _nokta = nokta;
            this.yon = yon;
        }

        /// <summary>
        /// Kullanıcı tarafından girilen hareket dizisine göre geziciyi ilerletir.
        /// </summary>
        /// <param name="hareketDizisi"></param>
        public void Ilerle(string hareketDizisi)
        {
            foreach (var hareket in hareketDizisi)
            {
                if (hareket.ToString() == "M")
                {
                    HareketEt();
                }
                else
                {
                    YonBelirle(hareket);
                }
            }
        }

        /// <summary>
        /// Gezicinin yapacağı harekete göre yeni yön belirlenir.
        /// </summary>
        /// <param name="hareket"></param>
        private void YonBelirle(char hareket)
        {
            switch (yon)
            {
                case 'N':
                    yon = hareket == 'L' ? 'W' : 'E';
                    break;
                case 'S':
                    yon = hareket == 'L' ? 'E' : 'W';
                    break;
                case 'W':
                    yon = hareket == 'L' ? 'S' : 'N';
                    break;
                case 'E':
                    yon = hareket == 'L' ? 'N' : 'S';
                    break;
                default:
                    break;
            }

        }


        /// <summary>
        /// Geziciyi bir sonraki konumuna hareket ettirir.
        /// </summary>
        private void HareketEt()
        {
            switch (yon)
            {
                case 'N':
                    _nokta.y = _platoSiniri.Boy > _nokta.y ? ++_nokta.y : _nokta.y;
                    break;
                case 'S':
                    _nokta.y = 0 < _nokta.y ? --_nokta.y : _nokta.y;
                    break;
                case 'W':
                    _nokta.x = 0 < _nokta.x ? --_nokta.x : _nokta.x;
                    break;
                case 'E':
                    _nokta.x = _platoSiniri.En > _nokta.x ? ++_nokta.x : _nokta.x;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gezicinin aktif konumunu yazdırır.
        /// </summary>
        public void GezgininKonumunuYazdir()
        {
            Console.WriteLine($" Gezicinin yeni konumu {_nokta.x} {_nokta.y} {yon}");
        }
    }
}
