namespace ManualDI
{
    public class ServiceConsumer
    {
        private HelloService _hello;

        public ServiceConsumer(HelloService hello)
        {
            _hello = hello;
        }

        public void Print()
        {
            _hello.Print();
        }
    }
}