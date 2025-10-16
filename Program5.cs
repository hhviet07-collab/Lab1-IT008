using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai5_Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());

            try
            {
                DateTime date = new DateTime(year, month, day);
                Console.WriteLine($"Ngay {date:dd//MM//yyyy} la {GetVietNameseDayOfWeek(date.DayOfWeek)} ");
            }
            catch
            {
                Console.WriteLine("Ngay thang nam khong hop le");
            }
        }

        static string GetVietNameseDayOfWeek(DayOfWeek day)
        { 
            switch(day)
            {
                case DayOfWeek.Monday: return "thu hai";
                case DayOfWeek.Tuesday: return "thu ba";
                case DayOfWeek.Wednesday: return "thu tu";
                case DayOfWeek.Thursday: return "thu nam";
                case DayOfWeek.Friday: return "thu sau";
                case DayOfWeek.Saturday: return "thu bay";
                case DayOfWeek.Sunday: return "chu nhat";
                default: return "";
            }
        }
    }
}
