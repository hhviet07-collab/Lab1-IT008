using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2_Lab1
{
    internal class Program
    {
            // Hàm kiểm tra số nguyên tố.
            static bool IsPrime(int n)
            {
                if (n < 2) return false;
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0) return false;
                }
                return true;
            }
            static void Main(string[] args)
            {
                int n;
                // Kiểm tra tính hợp lệ của số nguyên dương n
                while (true) 
                {
                    Console.Write("Nhap so nguyen duong n: ");
                    if (int.TryParse(Console.ReadLine(), out n) && n >= 0)
                        break;
                    Console.WriteLine("Khong hop le, vui long nhap lai: ");
                }
                
                // Tính tổng các số nguyên tố < n
                int sum = 0;
                for (int i = 2; i < n; i++)
                {
                    if (IsPrime(i)) sum += i;
                }
                Console.Write("Tong cac so nguyen to <n la: ");
                Console.WriteLine(sum);
            
        }
    }
}
