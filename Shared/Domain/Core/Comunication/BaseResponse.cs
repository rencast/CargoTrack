namespace Shared.Domain.Core.Comunication;

public abstract class BaseResponse <T>
{
    protected BaseResponse(T resource)
    {
        Success = true;
        Resource = resource;
        Message = string.Empty;
        
    }


    protected BaseResponse(string message)
    {
        Success = false;
        Resource = default;
        Message = message;
    }

    public bool Success { get; private set; }
    public string Message { get; private set; }
    public T Resource { get; private set; }
}