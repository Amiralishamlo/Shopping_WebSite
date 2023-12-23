namespace Shop.Application.Dtos
{
    public class BaseDto<T> 
    {
        public BaseDto(T data, List<string> message, bool isSuccess)
        {
            Data = data;
            Message = message;
            IsSuccess = isSuccess;
        }

        public T Data { get; private set; }
        public List<string>? Message { get; private set; }
        public bool IsSuccess { get; set; }
    }
    public class BaseDto
    {
        public BaseDto( List<string> message, bool isSuccess)
        {
            Message = message;
            IsSuccess = isSuccess;
        }
        public List<string>? Message { get; private set; }
        public bool IsSuccess { get; set; }
    }
}
