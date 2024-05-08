using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

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

        [HttpGet("GetAnnoBisestile")]
        public JsonResult GetAnnoBisestile(int anno)
        {
            string status_result = "OK";
            string message = "";
            if((anno % 400 == 0) || (anno % 4 == 0 && anno % 100 != 0)) 
            {
                message = "anno bistile";
            }
            else
            {
                message = "anno non bisestile";
            }

            return Json(new { anno=anno, status = status_result, message = message });
        }

        [HttpGet("GetIpotenusa")]
        public JsonResult GetIpotenusa (double cateto1, double cateto2)
        {
            string status_result = "OK";
            string message = "";
            double res;

            if((cateto1 == 0) || (cateto2 == 0))
            {
                status_result = "KO";
                message = "Valori non calcolabili";
                res = 0;
            }
            else
            {
                res = Math.Sqrt((cateto1*cateto1) + (cateto2*cateto2));
                message = "Valori calcolabili";
            }
            return Json(new { ipotenusa = res, status = status_result, message = message });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
