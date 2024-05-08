using Microsoft.AspNetCore.Mvc;

namespace AS2324_5G_INF_BuonoFilippo_WebAPI.Controllers
{
    public class MathController : Controller
    {
        [HttpGet("GetMultiplo")]
        public JsonResult GetMultiplo(int num, int factor)
        {
            string status_result = "OK";
            string message = "Problema";
            if(num == 0)
            {
                status_result = "KO";
            }
            else
            {
                if(num % factor != 0)
                {
                    message = "non è un multiplo";
                }
                else
                {
                    message = "è un multiplo";
                }
            }
            return Json(new { output = message, status = status_result });
        }

        [HttpGet("GetPotenza")]
        public JsonResult GetPotenza(int b, int esponente)
        {
            string status_result = "OK";
            string message = "Calcolata la potenza";
            int res = b; 

            for(int i = esponente; i > 1; i--) 
            {
                res = res * b;
            }

            return Json(new { output = res, status = status_result, message = message });

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
