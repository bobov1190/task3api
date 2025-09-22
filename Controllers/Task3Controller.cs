using Microsoft.AspNetCore.Mvc;

namespace Task3Api.Controllers
{
    [ApiController]
    [Route("bobov_gmail_com")] // 👈 тут именно твой email с _ вместо @ и .
    public class Task3Controller : ControllerBase
    {
        [HttpGet]
        public string Get([FromQuery] string x, [FromQuery] string y)
        {
            if (!int.TryParse(x, out int a) || !int.TryParse(y, out int b) || a <= 0 || b <= 0)
            {
                return "NaN";
            }

            int gcd = GCD(a, b);
            long lcm = (long)a * b / gcd;

            return lcm.ToString();
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
