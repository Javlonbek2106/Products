using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Buffers.Text;
using System.Net.NetworkInformation;

namespace Base64rontTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GetBase64Controller : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            var filePath = @"C:\Users\j_usmonov\Downloads\121557.jpg";

           var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
       
        var basString = "data:image/jpg;base64,";

           var fileBase64 =  Convert.ToBase64String(bytes);
 
            return basString + fileBase64;
        }
    }
}
