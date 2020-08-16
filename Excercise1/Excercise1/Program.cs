using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise1 {
    public class Program {
        static void Main(string[] args)
        {
            // Home size between 1 to 3
            int homeSize = getHomeSize();

            // Wood cutter count
            int woodCutterNo = getWoodCutterNo();

            // Memar count
            int memarNo = getMemarNo();

            // Wood number for cunstruct a home by size
            int woodNo = getWoodNo(homeSize);

            // A Dictionary for determine number of memar that 
            // strat cunstruct at wich time.
            //
            // <startHour, personNo>
            Dictionary<int, int> startHours = new Dictionary<int, int>();

            // Number of memars that are cunstructing home and are not free
            int busyMan = 0;

            // Integer for wood number that is exist to memar pick them for cunstruct
            int temp = 0;

            // Hours for finishing home
            int hour = 6;
            while (woodNo > 0)
            {
                hour++;

                // Wood cutters add wood to temp after every 7 hour
                if (hour % 7 == 0)
                {
                    temp += woodCutterNo;
                }

                // If every memar finish cunstructing,
                // they are not busy now,
                // adding woods to home
                if (startHours.ContainsKey(hour % 10))
                {
                    woodNo -= startHours[hour % 10];
                    busyMan -= startHours[hour % 10];
                    startHours.Remove(hour % 10);
                }

                // If some woods are available,
                // memars pick up them and add them to home.
                // Memars are busy now
                if (temp > 0 && memarNo > busyMan)
                {

                    if ((memarNo - busyMan) > temp)
                    {
                        busyMan += temp;
                        startHours.Add(hour % 10, temp);
                        temp = 0;
                    }
                    else
                    {
                        temp -= (memarNo - busyMan);
                        startHours.Add(hour % 10, memarNo - busyMan);
                        busyMan += (memarNo - busyMan);
                    }
                }
            }

            Console.WriteLine($"Days : {hour / 14}\nHour : {hour % 14}");
        }

        public static int getHomeSize()
        {
            Console.WriteLine("Please enter home size (int number between 1 to 3) :");
            int homeSize = 0;
            bool flag = true;
            while (flag)
            {
                try
                {
                    homeSize = Convert.ToInt32(Console.ReadLine());
                    flag = false;

                    if (homeSize < 1 || homeSize > 3)
                    {
                        Console.Write("Input must be between 1 and 3 !!!\nenter again : ");
                        flag = true;
                    }
                }
                catch (Exception)
                {
                    Console.Write("Input must be an integer number !!!\nenter again : ");
                }
            }

            return homeSize;
        }

        public static int getWoodCutterNo()
        {
            Console.WriteLine("Enter number of ChoobBar :");
            int woodCutterNo = 0; // چوب بر

            bool flag = true;
            while (flag)
            {
                try
                {
                    woodCutterNo = Convert.ToInt32(Console.ReadLine());
                    flag = false;

                    if (woodCutterNo <= 0)
                    {
                        Console.Write("Input must be a positive number !!!\nenter again : ");
                        flag = true;
                    }
                }
                catch (Exception)
                {
                    Console.Write("Input must be an integer number !!!\nenter again : ");
                }
            }

            return woodCutterNo;
        }

        public static int getMemarNo()
        {
            Console.WriteLine("Enter number of Memar :");
            int memarNo = 0; // معمار

            bool flag = true;
            while (flag)
            {
                try
                {
                    memarNo = Convert.ToInt32(Console.ReadLine());
                    flag = false;

                    if (memarNo <= 0)
                    {
                        Console.Write("Input must be a positive number !!!\nenter again : ");
                        flag = true;
                    }
                }
                catch (Exception)
                {
                    Console.Write("Input must be an integer number !!!\nenter again : ");
                }
            }

            return memarNo;
        }

        /// <summary>
        /// determine the wood number for home by size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static int getWoodNo(int size)
        {
            int woodNo;
            switch (size)
            {
                case 1:
                woodNo = 414; // 414
                break;

                case 2:
                woodNo = 328; // 328
                break;

                case 3:
                woodNo = 248; // 248
                break;

                default:
                woodNo = 0;
                break;
            }

            return woodNo;
        }
    }
}
