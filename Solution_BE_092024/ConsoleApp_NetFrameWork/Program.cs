﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_NetFrameWork
{
    public class Program
    {
        public int abc = 100;

        public int Tong(int x, int y)
        {



            return x + y;
        }


        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;


            int myValiable = 1245;
            string myName = "My Name Is QUAN";

            Console.WriteLine("Xin chào các bạn đến với lớp BE_092024");
            Console.WriteLine("giá trị của biến myValiable= {0}", myValiable);

            var myVarValiable = 100;

            string myVarValiable2 = null;

            string myVarValiable3 = "";

            //object variable = new object();
            //GCHandle handle = GCHandle.Alloc(myValiable, GCHandleType.Pinned);
            //IntPtr address = handle.AddrOfPinnedObject();
            //Console.WriteLine(address);

            //myVarValiable = 2000;

            //if (myVarValiable < 100000)
            //{

            //}

            //handle.Free();

            // CTRL + K +C -- comment
            // CTRL + K+ D -- fomat code

            int x = 5;
            int y = x--;

            // ++x
            // Bước 1: tăng biến x lên 1 = 6 ( x= 5+1)
            // bước 2: gán giá trị sau khi tăng ở bước 1 vào giá trị x = x ( ở bưỡc 1)


            // x++
            // Bước 1: tạo ra 1 biến là bản sao chép của x ( x' = 5)
            // bước 2: x = 6 ( x= x+1)
            // bước 3: gán giá trị của bản sao ( bước 1 ) x= x' ( x=5)
            // bước 4: biễn x' sẽ bị loại bỏ => 5

            Console.WriteLine("y= {0}", y);
            Console.WriteLine("x={0}", x);
            Console.ReadKey();
        }



    }
}