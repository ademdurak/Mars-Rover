using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Case
{
    public class Rover
    {
        private readonly Plateau _plateau;
        private readonly Point _point;
        private char direction;


        public Rover(Plateau plateau, Point point, char direction)
        {
            _plateau = plateau;
            _point = point;
            this.direction = direction;
        }

        /// <summary>
        /// Kullanıcı tarafından girilen adımlara göre gezgini ilerletir.
        /// </summary>
        /// <param name="movements"></param>
        public void Go(string movements)
        {
            foreach (var movement in movements)
            {
                if (movement == 'M')
                {
                    Move();
                }
                else
                {
                    SetDirection(movement);
                }
            }
        }

        /// <summary>
        /// Gezginin yapacağı harekete göre yeni yön belirlenir.
        /// </summary>
        /// <param name="move"></param>
        private void SetDirection(char move)
        {
            switch (direction)
            {
                case 'N':
                    direction = move == 'L' ? 'W' : 'E';
                    break;
                case 'S':
                    direction = move == 'L' ? 'E' : 'W';
                    break;
                case 'W':
                    direction = move == 'L' ? 'S' : 'N';
                    break;
                case 'E':
                    direction = move == 'L' ? 'N' : 'S';
                    break;
                default:
                    break;
            }

        }


        /// <summary>
        /// Gezginin bir sonraki konumuna hareket ettirir.
        /// </summary>
        private void Move()
        {
            switch (direction)
            {
                case 'N':
                    _point.y = _plateau.maxVeriticalLineCount > _point.y ? ++_point.y : _point.y;
                    break;
                case 'S':
                    _point.y = 0 < _point.y ? --_point.y : _point.y;
                    break;
                case 'W':
                    _point.x = 0 < _point.x ? --_point.x : _point.x;
                    break;
                case 'E':
                    _point.x = _plateau.maxHorizantelLineCount > _point.x ? ++_point.x : _point.x;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gezginin aktif konumunu yazdırır.
        /// </summary>
        public void PrintLocationRover()
        {
            Console.WriteLine($"Gezicinin yeni konumu {_point.x} {_point.y} {direction}");
        }
    }
}
