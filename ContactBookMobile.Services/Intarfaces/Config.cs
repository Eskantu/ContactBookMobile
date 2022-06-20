using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookMobile.Services.Intarfaces
{
    public static class Config
    {
        private static readonly string ServerClientIp = "http://bookvue.somee.com";
        private static readonly string ServerClientPort = "80";
        private static readonly string ServerAPIPrefix = "api";
        private static readonly string ServerClientAddress = $"{ServerClientIp}:{ServerClientPort}";
        public static readonly string ServerAPIAddress = $"{ServerClientAddress}/{ServerAPIPrefix}/";
    }
}
