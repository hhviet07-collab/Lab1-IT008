using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp45
{
    internal class Program
    {
        // Kiểm tra năm nhuận
        static bool NamNhuan(int n)
        {
            return (((n % 4 == 0) && (n % 100 != 0)) || (n % 400 == 0));
        }


        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());

            // Kiểm tra năm
            if (year < 0 )
            {
                Console.WriteLine("Ngay thang nam khong hop le");
                return;
            }

            // Kiểm tra tháng
            if (month < 0 || month > 12 )
            {
                Console.WriteLine("Ngay thang nam khong hop le");
                return;
            }

            int MaxDay;

            if (month == 2)
            {
                MaxDay = (NamNhuan(year)) ? 29 : 28;
            }  
            else if (month == 4 || month == 6 || month ==9 || month == 11 )
            {
                MaxDay = 30;
            }
            else
            {
                MaxDay = 31;
            }

            // Kiểm tra ngày
            if (day > MaxDay || day < 0)
            {
                Console.WriteLine("Ngay thang nam khong hop le");
            }
            else
            {
                Console.WriteLine("Ngay thang nam hop le");
            }
        }
    }
}
