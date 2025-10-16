using System;
using System.Collections.Generic;

class MaTran
{
    static Random rand = new Random();

    // Hàm tạo ma trận ngẫu nhiên
    static int[,] TaoMaTran(int n, int m)
    {
        int[,] mt = new int[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                mt[i, j] = rand.Next(1, 1000); 
        return mt;
    }

    // Hàm in ma trận
    static void XuatMaTran(int[,] mt)
    {
        int n = mt.GetLength(0);
        int m = mt.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write(mt[i, j] + "\t");
            Console.WriteLine();
        }
    }

    // Tìm phần tử lớn nhất và nhỏ nhất
    static void TimMaxMin(int[,] mt, out int max, out int min)
    {
        max = int.MinValue;
        min = int.MaxValue;
        foreach (int val in mt)
        {
            if (val > max) max = val;
            if (val < min) min = val;
        }
    }

    // Tìm dòng có tổng lớn nhất
    static int TimDongCoTongLonNhat(int[,] mt)
    {
        int n = mt.GetLength(0);
        int m = mt.GetLength(1);
        int maxSum = int.MinValue;
        int rowIndex = -1;
        for (int i = 0; i < n; i++)
        {
            int sum = 0;
            for (int j = 0; j < m; j++)
                sum += mt[i, j];

            if (sum > maxSum)
            {
                maxSum = sum;
                rowIndex = i;
            }
        }
        return rowIndex;
    }

    // Kiểm tra số nguyên tố
    static bool LaSoNguyenTo(int x)
    {
        if (x < 2) return false;
        for (int i = 2; i * i <= x; i++)
            if (x % i == 0) return false;
        return true;
    }

    // Tính tổng các số không phải là số nguyên tố
    static int TongKhongNguyenTo(int[,] mt)
    {
        int tong = 0;
        foreach (int val in mt)
        {
            if (!LaSoNguyenTo(val))
                tong += val;
        }
        return tong;
    }

    // Xóa dòng thứ k (0-based)
    static int[,] XoaDong(int[,] mt, int k)
    {
        int n = mt.GetLength(0);
        int m = mt.GetLength(1);

        if (k < 0 || k >= n) return mt;

        int[,] newMt = new int[n - 1, m];
        int row = 0;
        for (int i = 0; i < n; i++)
        {
            if (i == k) continue;
            for (int j = 0; j < m; j++)
                newMt[row, j] = mt[i, j];
            row++;
        }
        return newMt;
    }

    // Xóa cột chứa phần tử lớn nhất
    static int[,] XoaCotMax(int[,] mt)
    {
        int n = mt.GetLength(0);
        int m = mt.GetLength(1);
        int max = int.MinValue;
        int colMax = -1;

        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                if (mt[i, j] > max)
                {
                    max = mt[i, j];
                    colMax = j;
                }

        if (colMax == -1) return mt;

        int[,] newMt = new int[n, m - 1];
        for (int i = 0; i < n; i++)
        {
            int col = 0;
            for (int j = 0; j < m; j++)
            {
                if (j == colMax) continue;
                newMt[i, col++] = mt[i, j];
            }
        }
        return newMt;
    }

    // Chương trình chính
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Nhập số dòng n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Nhập số cột m = ");
        int m = int.Parse(Console.ReadLine());

        int[,] maTran = TaoMaTran(n, m);
        Console.WriteLine("\nMa trận ban đầu:");
        XuatMaTran(maTran);

        // a. Xuất ma trận
        // (đã in ở trên)

        // b. Tìm phần tử lớn nhất/nhỏ nhất
        TimMaxMin(maTran, out int max, out int min);
        Console.WriteLine($"\nPhần tử lớn nhất: {max}");
        Console.WriteLine($"Phần tử nhỏ nhất: {min}");

        // c. Tìm dòng có tổng lớn nhất
        int dongMax = TimDongCoTongLonNhat(maTran);
        Console.WriteLine($"Dòng có tổng lớn nhất: {dongMax} (dòng số {dongMax + 1})");

        // d. Tính tổng các số không phải là số nguyên tố
        int tong = TongKhongNguyenTo(maTran);
        Console.WriteLine($"Tổng các số không phải là số nguyên tố: {tong}");

        // e. Xóa dòng thứ k
        Console.Write("\nNhập dòng cần xóa (bắt đầu từ 0): ");
        int k = int.Parse(Console.ReadLine());
        maTran = XoaDong(maTran, k);
        Console.WriteLine("Ma trận sau khi xóa dòng:");
        XuatMaTran(maTran);

        // f. Xóa cột chứa phần tử lớn nhất
        maTran = XoaCotMax(maTran);
        Console.WriteLine("Ma trận sau khi xóa cột chứa phần tử lớn nhất:");
        XuatMaTran(maTran);
    }
}
