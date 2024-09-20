using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class KeyGenerator
    {
        public byte[] GenerateSecureRandomKey(int size)
        {

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] randomNumber = new byte[size];
                rng.GetBytes(randomNumber);
                return randomNumber;
            }

        }
        public int GenerateRandomNumber(int min, int max)
        {
            byte[] randomByte = GenerateSecureRandomKey(1);
            return (randomByte[0] % (max - min + 1)) + min;
        }
    }
}
