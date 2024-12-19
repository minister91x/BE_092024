using BE_09_2024.Media.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_09_2024.Media.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private IConfiguration _configuration;
        public MediaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost("Upload")]
        public async Task<ActionResult> Upload(UploadRequestData requestData)
        {
            //1 .Kiểm tra chữ ký
            // 2. convert từ base64 sang ảnh -> lưu vào folder 


            var returnData = new ReturnData();
            var ReqeuestId = DateTime.Now.Ticks;
            try
            {

                if (requestData == null ||
                    string.IsNullOrEmpty(requestData.Base64Image)
                    || string.IsNullOrEmpty(requestData.Sign))
                {
                    returnData.ResponseCode = -1;
                    returnData.Description = "Dữ liệu đầu vào không hợp lệ";
                    return Ok(returnData);

                }


                // kiểm tra xem chữ ký có hợp lệ không ?
                var SecretKey = _configuration["Sercurity:SecretKey"] ?? "";

                var plantext = requestData.Base64Image + SecretKey;

                var Sign = BE_092024.Common.Sercurity.MD5Hash(plantext);

                if (Sign != requestData.Sign)
                {

                    returnData.ResponseCode = -3;
                    returnData.Description = "Chữ ký không hợp lệ không hợp lệ";


                    return Ok(returnData);
                }

                // Vẽ lại ảnh và lưu vào thư mục

                var path = "Upload"; //Path

                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                string imageName = Guid.NewGuid().ToString() + ".png";
                //set the image path
                var imgPath = Path.Combine(path, imageName);

                if (requestData.Base64Image.Contains("data:image"))
                {
                    requestData.Base64Image = requestData.Base64Image.Substring(requestData.Base64Image.LastIndexOf(',') + 1);
                }

                byte[] imageBytes = Convert.FromBase64String(requestData.Base64Image);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                image.Save(imgPath, System.Drawing.Imaging.ImageFormat.Png);

                returnData.ResponseCode = 1;
                returnData.Description = imageName;
                return Ok(returnData);
            }
            catch (Exception ex)
            {

                returnData.ResponseCode = 1;
                returnData.Description = ex.StackTrace;
                return Ok(returnData);
            }
        }
    }
}
