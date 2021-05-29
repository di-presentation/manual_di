using System;

namespace ManualDI
{
    public class HelloService
    {
        private MessageService _messageService;
        
        public HelloService(MessageService messageService)
        {
            _messageService = messageService;
        }
        public void Print()
        {
            Console.WriteLine(_messageService.Message());
        }
    }
}
