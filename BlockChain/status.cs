﻿using System;
namespace BlockChain
{
    public class status
    {
        public string[] add(string txt)
        {
            string[] x = { txt, getTime() };
            return x;
        }
        private string getTime()
        {
            long x = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            return x.ToString();
        }
    }
}
