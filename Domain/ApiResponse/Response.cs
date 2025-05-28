using System.Net;

namespace Domain.ApiResponse;

public class Response<T>
{
    public bool IsSuccess { get; set; }
    public string Messenge { get; set; }
    public T? Data { get; set; }
    public int StatusCode { get; set; }

    public Response(string messenge, T data)
    {
        IsSuccess = true;
        Messenge = messenge;
        Data = data;
        StatusCode = (int)HttpStatusCode.OK;
    }
    public Response(string messenge, HttpStatusCode statusCode)
    {
        IsSuccess = false;
        Messenge = messenge;
        Data = default;
        StatusCode = (int)statusCode;
    }
}


