using BE_092024.DataAcess.NetFrameWork.DataObject;
using BE_092024.DataAcess.NetFrameWork.Enum;
using BE_092024.DataAcess.NetFrameWork.Generic;
using BE_092024.DataAcess.NetFrameWork.Interface;
using BE_092024.DataAcess.NetFrameWork.STRUCT;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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

            var dateNow = DateTime.Now.Hour; // UTC+7
            var dateNowUTC = DateTime.UtcNow.Hour; // UTC+0
            var datofweek = DateTime.Now.DayOfWeek; // UTC+0
            Console.WriteLine("dateNow = {0} \n", dateNow);
            Console.WriteLine("dateNowUTC = {0} \n", dateNowUTC);
            Console.WriteLine("datofweek = {0} \n", datofweek);
            var DaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            Console.WriteLine("DaysInMonth = {0} \n", DaysInMonth);

            var myDate = new DateTime(2024, 10, 21);
            Console.WriteLine("myDate = {0} \n", myDate.ToString("dd-MM-yyyy"));

            var tomorow = DateTime.Now.AddDays(-1).AddHours(5).AddMinutes(10);

            var timeSpan = new TimeSpan(-50, 10, 58);

            tomorow = tomorow.Add(timeSpan);

            Console.WriteLine("tomorow = {0} \n", tomorow.ToString("ss"));

            var date = new DateTime(2024, 10, 21).Subtract(new DateTime(1991, 02, 08));
            Console.WriteLine("TotalDays = {0} \n", date.TotalDays);

            // Các định dạng date-time được hỗ trợ.
            DateTime aDateTime = new DateTime(2024, 10, 21, 21, 30, 00);

            //string[] formattedStrings = aDateTime.GetDateTimeFormats();

            //foreach (string format in formattedStrings)
            //{
            //    Console.WriteLine(format);
            //}


            // d: không kèm số 0 ở đầu đối với ngày <10
            // dd: kèm số 0 ở đầu đối với ngày <10
            // ddd : viết tắt của ngày (Mon)
            // dddd : viết đầy đủ của ngày (Monday)

            // M: không kèm số 0 ở đầu đối với ngày <10
            // MM: kèm số 0 ở đầu đối với ngày <10
            // MMM : viết tắt của ngày (Aug)
            // MMMM : viết đầy đủ của ngày (August)

            // y: không kèm số 0 ở đầu đối với ngày <10
            // yy: kèm số 0 ở đầu đối với ngày <10
            // yyy : viết tắt của ngày (Mon)
            // yyyy : viết đầy đủ của ngày (Monday)


            // h: không kèm số 0 ở đầu đối với giờ <10
            // hh: kèm số 0 ở đầu đối với giờ <10
            // H : định dạng 12H
            // HH : định dạng 24H


            // s: không kèm số 0 ở đầu đối với giây <10
            // ss: kèm số 0 ở đầu đối với giấy <10

            //string date_string = "21/10/2024"; // dd/MM/yyyy
            //var myDateStr = DateTime.ParseExact(date_string, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //Console.WriteLine("tomorow = {0} \n", myDateStr.ToString("dd-MM-yyyy HH:mm:ss"));



            //string date_string2 = "2100/10/2024"; // dd/MM/yyyy
            //DateTime date1;
            //var checkIsDateTime = DateTime.TryParseExact(date_string2, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date1);
            //if (checkIsDateTime)
            //{
            //    Console.WriteLine("là định dạng ngày tháng  \n");
            //}
            //else
            //{
            //    Console.WriteLine("Không phải định dạng ngày tháng  \n");
            //}


            //// string  // kiểu dữ liệu 
            //string abc = "my name is_";
            //var length = abc.Length;
            //Console.WriteLine("length = {0}", length);

            //var str_arr = abc.Split(' ');
            //foreach (var item in str_arr)
            //{
            //    Console.WriteLine("item = {0}", item);
            //}

            //var substr = abc.Substring(0, abc.Length - 1);
            //Console.WriteLine("substr = {0}", substr);

            //var replace = abc.Replace("_","1234");
            //Console.WriteLine("replace = {0}", replace);

            //var str = abc.Concat("test");
            //var str2 = abc + "test";

            //StringBuilder stringBuilder = new StringBuilder("abc");
            //stringBuilder.Append("test");

            /// Buổi 7
            /// 
            //int sothunhat = 10;
            //int sothuhai = 20;
            //MyGeneric.Swap<int>(ref sothunhat, ref sothuhai);

            //Console.WriteLine("sothunhat = {0}", sothunhat);
            //Console.WriteLine("sothuhai = {0}", sothuhai);

            //string sothunhat_str = "Lớp ";
            //string sothuhai_str = "BE092024";
            //MyGeneric.Swap<string>(ref sothunhat_str, ref sothuhai_str);


            //Console.WriteLine("sothunhat_str = {0}", sothunhat_str);
            //Console.WriteLine("sothuhai_str = {0}", sothuhai_str);

            var mystuct = new GenericStruct<int>(10);
            Console.WriteLine("mystuct Value = {0}", mystuct.GetValue());


            var mystuctStr = new GenericStruct<string>("My Name is QUAN");
            Console.WriteLine("mystuctStr Value = {0}", mystuctStr.GetValue());

            float aa = (float)10.5;
            var mystructFloat = new GenericStruct<float>(aa);
            Console.WriteLine("mystructFloat Value = {0}", mystructFloat.GetValue());


            //Dictionary<string, string> _phoneBook = new Dictionary<string, string>()
            //    {
            //    {"Trump", "0123.456.789" },
            //    {"Obama", "0987.654.321" },
            //    {"Putin", "0135.246.789" }
            //    };


            //foreach (KeyValuePair<string, string> entry in _phoneBook)
            //{
            //    Console.WriteLine($" -> {entry.Key} : {entry.Value}");
            //}
            //ArrayList arrayList1 = new ArrayList();
            //arrayList1.Add(1);
            //arrayList1.Add("so hai");
            //arrayList1.Add(1.5);
            //arrayList1.Add(true);

            //for (var i = 0; i < arrayList1.Count; i++)
            //{
            //    Console.WriteLine(arrayList1[i]);

            //}
            //Hashtable hashtable = new Hashtable();
            //hashtable.Add("Key1", "Value1");
            //hashtable.Add("Key2", "Value2");
            //Console.WriteLine(hashtable["Key1"]);
            //foreach (DictionaryEntry item in hashtable)
            //{
            //    Console.WriteLine("Key: {0} - Value: {1}", item.Key, item.Value);
            //}
            //foreach (var key in hashtable.Keys)
            //{
            //    Console.WriteLine("Key: {0} ", key);
            //}

            //SortedList mySL = new SortedList();
            //mySL.Add("Third", "!");
            //mySL.Add("Second", "World");
            //mySL.Add("First", "Hello");
            //// Displays the properties and values of the SortedList.
            //Console.WriteLine("mySL");
            //Console.WriteLine(" Count: {0}", mySL.Count);
            //Console.WriteLine(" Capacity: {0}", mySL.Capacity);
            //Console.WriteLine(" Keys and Values:");
            //Console.WriteLine("\t-KEY-\t-VALUE-");
            //for (int i = 0; i < mySL.Count; i++)
            //{
            //    Console.WriteLine("\t{0}:\t{1}", mySL.GetKey(i), mySL.GetByIndex(i));
            //}

            //Stack myStack = new Stack();
            //myStack.Push("Hello");
            //myStack.Push("World");
            //myStack.Push("!");

            //Console.WriteLine("myStack");
            //Console.WriteLine("\tCount: {0}", myStack.Count);
            //Console.Write("\tValues:");
            //foreach (Object obj in myStack) Console.Write(" {0}", obj);


            //Queue myQ = new Queue();
            //myQ.Enqueue("Hello");
            //myQ.Enqueue("World");
            //myQ.Enqueue("!");
            //Console.WriteLine("myQ");
            //Console.WriteLine("\tCount: {0}", myQ.Count); Console.Write("\tValues:");

            //foreach (Object obj in myQ) Console.Write(" {0}", obj);


            //var mybird = new Cow();
            ////đối tương    // classmyclass
            //var mycat = new Cat();
            //Console.WriteLine("mybird GetSound: {0}", mybird.GetSound());;
            //Console.WriteLine("mycat GetSound: {0}", mycat.GetSound()); ;

            var ps = new ProductManager();

            var result = ps.Product_Insert(new Product { Id = 1, Name = "" });
            Console.WriteLine("Product_Insert result : {0}", result.ReponseCode +" | Des:" +result.ResponseMessenger );


            var width = 100;
            if (width == 100)
            {
                Console.WriteLine("bang");
            }
            else
            {
                Console.WriteLine("Khong bang");
            }

            switch (width)
            {
                case 100: Console.WriteLine("bang"); break;
                default: Console.WriteLine("Khong bang"); break;
            }


            if(width != 100 ) 
            {
                Console.WriteLine("Khong bang"); 
            }

            Console.WriteLine("bang");


            Console.ReadKey();
        }



    }
}
