using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAcess.NetFrameWork
{
    public static class Funtion
    {
        public static int FunctionTong_Demo(int x, int y)
        {
            return x + y;
        }
        public static int FunctionTong_Demo_Tra_ve_2_giatri(int x, int y, ref int result)
        {
            result = 150;
            return x + y;
        }
        public static int FunctionTong_Demo_Tra_ve_2_giatri_OUT(int x, int y, out int result)
        {
            result = 190;
            return x + y;
        }

        public static void GetDescription()
        {

        }

        public static int Function_ThamChieu(ref int x)
        {
            x = 100;
            return x;
        }

        public static string ChiaHaiSo(int sothunhat, int sothuhai)
        {
            var result = string.Empty;

            try
            {
                var rs = sothunhat / sothuhai;
                result = rs.ToString();
            }
            catch (Exception ex)
            {
                // throw ;
                result = ex.Message + "\n" + ex.StackTrace;
            }
            return result.ToString();
        }

        public static void UserInput(string s)
        {
            if (s.Length > 2)
            {
                Exception e = new DataTooLongExeption();
                throw e;    // lỗi văng ra
            }
            //Other code - no exeption
        }

    }
}
