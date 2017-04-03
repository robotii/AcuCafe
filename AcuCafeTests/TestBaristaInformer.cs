using AcuCafe.interfaces;

namespace AcuCafeTests
{
    public class TestBaristaInformer : IBaristaInformer
    {
        public string Message { get; private set; }

        public void Inform(string message)
        {
            Message = message;
        }
    }
}