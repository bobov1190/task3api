using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Task3Api.Controllers
{
    [ApiController]
    [Route("bobov1190_gmail_com")] // твой email с _ вместо @ и .
    public class Task3Controller : ControllerBase
    {
        [HttpGet]
        public string Get([FromQuery] string x, [FromQuery] string y)
        {
            if (!BigInteger.TryParse(x, out BigInteger a) || !BigInteger.TryParse(y, out BigInteger b) || a < 0 || b < 0)
            {
                return "NaN";
            }

            if (a == 0) return b.ToString();
            if (b == 0) return a.ToString();

            BigInteger gcd = GCD(a, b);
            BigInteger lcm = a / gcd * b;

            return lcm.ToString();
        }

        private BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
