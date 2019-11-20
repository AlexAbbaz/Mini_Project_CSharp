using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] year = new bool[12, 31];
            int month, day, duration;
            string choice = "";

            for(int i = 0; i < 12; ++i)
            {
                for(int j = 0; j < 31; ++j)
                {
                    year[i, j] = false;
                }
            }
            
            do
            {
                Console.Write("You can: \r\n1)Take a reservation. \r\n2)Check reserved periods. \r\n3)Print the number of reserved days. \r\n4)Exit \r\n");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter the month from 1 to 12: \r\n");
                        month = int.Parse(Console.ReadLine());
                        Console.Write("Enter the day from 1 to 31: \r\n");
                        day = int.Parse(Console.ReadLine());
                        Console.Write("Enter the duration: \r\n");
                        duration = int.Parse(Console.ReadLine());

                        if ((month - 1) * 31 + duration + day > 372)
                        {
                            Console.Write("Request rejected. \r\n");
                            break;
                        }
                        else
                        {
                            if (checkIfAlreadyReserved(year, month, day, duration))
                            {
                                Console.Write("Request rejected. \r\n");
                            }
                            else
                            {
                                disponibilityTableUpdate(year, month, day, duration);

                                Console.WriteLine("Request accepted. \r\n");
                            }
                        }
                        break;
                    case "2":
                        string periods = "";

                        periods = checkDisponibility(year, periods);

                        if(periods != "")
                        {
                            Console.WriteLine(periods);
                        }
                        else
                        {
                            Console.WriteLine("There is no reservation \r\n");
                        }
                        break;
                    case "3":
                        int count = 0;
                        for (int i = 0; i < 12; ++i)
                        {
                            for (int j = 0; j < 31; ++j)
                            {
                                if(year[i, j])
                                {
                                    ++count;
                                }
                            }
                        }
                        Console.WriteLine("The number of reserved day is: {0} \r\nThis year the percentage of reserved day is {1} \r\n", count, (count * 100) / (12 * 31));
                        break;
                    case "4":

                        break;
                    default:
                        break;
                }
            } while (choice != "4");
        }

        private static bool checkIfAlreadyReserved(bool[,] year, int month, int day, int duration)
        {
            int durCount = duration, pastMonth = 0, dayCount = day - 1;

            for (int i = month - 1; i < month + (day + duration) / 31; ++i)
            {
                for (int j = 1; j < durCount; ++j)
                {
                    if (j + dayCount > 31)
                    {
                        break;
                    }
                    if (year[i, j + dayCount - 1])
                    {
                        return true;
                    }
                    ++pastMonth;
                }
                durCount -= pastMonth;
                dayCount = 0;
            }
            return false;
        }

        private static void disponibilityTableUpdate(bool[,] year, int month, int day, int duration)
        {
            int durCount = duration, pastMonth = 0, dayCount = day - 1;

            for (int i = month - 1; i < month + (day + duration) / 31; ++i)
            {
                for (int j = 1; j < durCount + 1; ++j)
                {
                    if (j + dayCount > 31)
                    {
                        break;
                    }
                    year[i, j + dayCount - 1] = true;
                    ++pastMonth;
                }
                durCount -= pastMonth;
                dayCount = 0;
            }
        }

        private static string checkDisponibility(bool[,] year, string periods)
        {
            bool today = false, yesterday = false;
            for (int i = 0; i < 12; ++i)
            {
                for (int j = 0; j < 31; ++j)
                {
                    today = year[i, j];

                    if (today != yesterday)
                    {
                        if (today)
                        {
                            periods += "from " + (j + 1).ToString() + "/" + (i + 1).ToString() + " ";
                        }

                        else
                        {
                            if(j == 0)
                            {
                                j = 31;
                                --i;
                            }
                            periods += "to " + j.ToString() + "/" + (i + 1).ToString() + "\r\n";
                        }
                    }

                    yesterday = today;
                }
            }

            return periods;
        }
    }
}
