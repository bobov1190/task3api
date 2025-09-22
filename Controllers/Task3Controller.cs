using Microsoft.AspNetCore.Mvc;

namespace Task3Api.Controllers
{
    [ApiController]
    [Route("bobov1190_gmail_com")] // 👈 твой email с _ вместо @ и .
    public class Task3Controller : ControllerBase
    {
        [HttpGet]
        public string Get([FromQuery] string x, [FromQuery] string y)
        {
            if (!long.TryParse(x, out long a) || !long.TryParse(y, out long b) || a < 0 || b < 0)
            {
                return "NaN";
            }

            if (a == 0) return b.ToString();
            if (b == 0) return a.ToString();

            long gcd = GCD(a, b);
            long lcm = a / gcd * b; // важно: делим перед умножением, чтобы избежать переполнения

            return lcm.ToString();
        }

        private long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
