using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace task3
{
    public class HmacComputation
    { 
        public byte[] ComputeHmac(string move, byte[] key)
        {
            byte[] byteMove = Encoding.UTF8.GetBytes(move);
            using (var hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(byteMove);
            }
        }

    }
}
