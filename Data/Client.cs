using System;
namespace TaskManagement_WebClient.Data
{
    public static class ClientHttp
    {
        public static HttpClient client = new HttpClient();

        public static bool isConnected = false;
    }
}

