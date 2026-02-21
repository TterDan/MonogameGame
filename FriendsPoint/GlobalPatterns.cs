using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FriendsPoint
{
    public class GlobalPatterns
    {
        static double noSpray(double shot) => Math.Sin(shot * 0.2) * Math.Cos(shot * 0.20) * 0.25;
        static Random rnd = new Random();
        static double SinCos(double shot) => Math.Asin(Math.Sin(shot)) * 0.05; //Паттерн для MP5
        static double Sine(double shot) => Math.Sin(shot) * 0.1; //Паттерн для Glock'a
        static double Sin(double shot) => Math.Sin(shot * 1.75) * Math.Sin(shot) * 0.15; // Паттерн для Minigun'a
        static double ShotgunPallets(double shot) => rnd.Next(-5, 5) * 0.01;
        Func<double, double>[] functions = { noSpray, SinCos, Sine, Sin, ShotgunPallets };
        public Vector2 getPattern(float index, float x, Vector2 playerSpeed)
        {
            float multipiler = 0;
            int speed = (int)playerSpeed.Length();
            Console.Log(speed);
            if (speed > 1)
                multipiler = rnd.Next(-speed, speed) * 0.028f;
            if (index == 0 && speed <= 1)
            {
                return Vector2.Zero;
            }
            if (x <= 1 && speed <= 1)
            {
                return Vector2.Zero;
            }
            float X = (float)functions[(int)index](x) + multipiler; 
            float Y = (float)functions[(int)index](x) + multipiler;
            return new Vector2(X, Y);
        }
    }
}
