

namespace RealShop.Services.Exceptions;
public class CustomException:Exception
{
    public int StatusCode { get; set; }
    public CustomException(int code,string Message):base(Message)
    {
        StatusCode = code;
    }
}
