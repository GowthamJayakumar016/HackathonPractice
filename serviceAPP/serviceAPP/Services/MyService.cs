using System;

namespace serviceAPP.Services
{
    public class MyService:IMyService
    {
        public string GetMessage()
        {
            return "Hello from Service";
        }
    }
}
