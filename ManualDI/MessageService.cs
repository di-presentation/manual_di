using System;

namespace ManualDI
{
    public class MessageService
    {
        private int _random;

        public MessageService()
        {
            _random = new Random().Next();
        }
        public string Message()
        {
            return $"Test message. Random number: {_random}";
        }
    }
}