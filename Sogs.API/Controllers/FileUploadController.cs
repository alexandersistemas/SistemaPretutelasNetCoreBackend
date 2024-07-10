using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.IO;
using System.Threading.Tasks;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly string _targetFilePath;

        public FileUploadController()
        {
            // Aqui se define el directorio donde se almacenarán los archivos subidos
            _targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

            if (!Directory.Exists(_targetFilePath))
            {
                Directory.CreateDirectory(_targetFilePath);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded");
            }

            DateTime thisDay = DateTime.Now;
            string dia = thisDay.Day.ToString();
            string mes = thisDay.Month.ToString();
            string year = thisDay.Year.ToString();
            string hora = thisDay.Hour.ToString();
            string min = thisDay.Minute.ToString();
            string sec = thisDay.Second.ToString();

            string code = dia + mes + year + hora + min + sec;

            string modifiedFileName = code + "_" + file.FileName.Replace(" ", String.Empty);


            var filePath = Path.Combine(_targetFilePath, modifiedFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { modifiedFileName });
        }

    }
}
