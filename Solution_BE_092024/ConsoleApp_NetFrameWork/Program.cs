using BE_092024.DataAcess.NetFrameWork.Enum;
using BE_092024.DataAcess.NetFrameWork.STRUCT;
using System;
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


        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            // var tong = BE_092024.DataAcess.NetFrameWork.Funtion.FunctionTong_Demo(1, 2);

            //  int x_phay = 0;
            //Console.Write("x_phay truoc:{0}", x_phay + "\n");

            //Function_ThamChieu(ref x_phay);
            //// ref x_phay -> biến x_phay là tham chiếu của của biến x_phay
            //Console.Write("x_phay sau :{0}", x_phay);


            //int gia_tri2;
            //int gia_tri1 = BE_092024.DataAcess.NetFrameWork.Funtion
            //    .FunctionTong_Demo_Tra_ve_2_giatri_OUT(10, 20, out gia_tri2);

            //Console.Write("gia_tri1 = :{0}", gia_tri1 + "\n");
            //Console.Write("gia_tri2 = :{0}", gia_tri2);


            //try
            //{
            //    var ketquachia = BE_092024.DataAcess.NetFrameWork.Funtion.ChiaHaiSo(10, 0);
            //    Console.Write("ketquachia = :{0}", ketquachia);

            //    BE_092024.DataAcess.NetFrameWork.Funtion.UserInput("BA KÝ TỰ");
            //}
            //catch (Exception ex)
            //{

            //    Console.Write("ex = :{0}", ex.Message);
            //}


            // int a, b;
            //Console.Write("nhap he so a: ");
            //a = int.Parse(Console.ReadLine());
            //Console.Write("nhap he so b: ");
            //b = int.Parse(Console.ReadLine());
            //// Console.WriteLine(" ket qua: " + GPTrinhBac1(a, b));
            //Console.ReadKey();

            //int myValiable = 1245;
            //string myName = "My Name Is QUAN";

            //Console.WriteLine("Xin chào các bạn đến với lớp BE_092024");
            //Console.WriteLine("giá trị của biến myValiable= {0}", myValiable);

            //var myVarValiable = 100;

            //string myVarValiable2 = null;

            //string myVarValiable3 = "";

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

            //  Console.WriteLine("y= {0}", y);
            //  Console.WriteLine("x={0}", x);
            //int Month = 12;
            //var totaldays = Month == 12 ? "ĐÚNG " : "SAI";

            //var totaldays2 = Month == 12 ? "ĐÚNG " : Month == 2 ? "ĐÚNG" : "SAI";


            //for (int i = 0; i < 10; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        // nếu là sổ chẵn thì bỏ qua
            //        continue;
            //    }

            //    // nếu là số lẻ thì in ra 
            //    Console.WriteLine("i={0}", i);
            //}

            //// không có break vòng for này chạy 10000 lần 
            //// có break vòng for này chạy 12 lần 
            //// có điểm bắt đầu , có điểm kết thúc 
            //// break và contiue;
            //var list = new List<int> { 1, 2, 3 };

            //foreach (var item in list)
            //{
            //    Console.WriteLine("item={0}", item);
            //}


            /// break nhảy xuống đây




            // var product2 = new Product("SP001", "Iphone 16", "sản phẩm mới");

            //Console.WriteLine("id={0} \n", product2.ID);
            //Console.WriteLine("name={0} \n", product2.Name);
            //Console.WriteLine("desc={0} \n", product2.Description);

            //Console.WriteLine("product infor = {0} \n", product2.ProductInfor());


            //Console.WriteLine("nhập id :");
            //var id = Console.ReadLine();

            //Console.WriteLine("nhập tên  :");
            //var name = Console.ReadLine();


            //Console.WriteLine("nhập giá  :");
            //var price = Console.ReadLine();

            //Console.WriteLine("nhập mô tả :");
            //var description = Console.ReadLine();

            //var product = new BE_092024.DataAcess.NetFrameWork.Bussiness.ProductManagerment();
            //var rs = product.Product_Insert(id, name, price, description);

            //Console.WriteLine("product infor = {0} \n", rs);


            int paymentStatus = 1;

            if (paymentStatus == (int)PaymentStatus.Initial)
            {
                /// 
            }

            if (paymentStatus == (int)PaymentStatus.Success) // 2 tương ứng là gì ????
            {
                /// 
            }

            if (paymentStatus == 3)
            {
                /// 
            }

            int[] arr = { 1, 2, 3, 4, 5 };

           
            arr[4] = 100;

            var value_index_4 = arr[4];
            Console.WriteLine("value_index_5 = {0} \n", value_index_4);

            Console.ReadKey();
        }



    }
}
