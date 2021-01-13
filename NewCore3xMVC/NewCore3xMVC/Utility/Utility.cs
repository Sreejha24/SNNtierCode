using Alachisoft.NCache.Tools.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCore3xMVC.Utility
{
    public class Utility
    {

        public static int Sum(params int[] prms)
        {
            var sum = 0;
            foreach(var i in prms)
            {
                sum = sum + i;
            }
            return sum;
        }

        public int Multiply(params int[] prms)
        {
            var mul = 1;
            foreach (var i in prms)
            {
                mul = mul * i;
            }
            return mul;
        }


    }

}
