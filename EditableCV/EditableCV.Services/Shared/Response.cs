using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace EditableCV.Services.Shared;

public class Response
{
    protected Response() {}

    public HttpStatusCode StatusCode { get; init; }
    public string? ErrorMessage { get; init; }

    [MemberNotNullWhen(false, nameof(ErrorMessage))]
    public virtual bool IsSuccess => string.IsNullOrWhiteSpace(ErrorMessage);

    public static Response CreateFailed(HttpStatusCode statusCode, string errorMessage)
    {
        return new Response { StatusCode = statusCode, ErrorMessage = errorMessage };
    }

    public static Response CreateSuccess(HttpStatusCode statusCode)
    {
        return new Response { StatusCode = statusCode };
    }
}

public class Response<TResult>: Response
{
    public TResult? Result { get; init; }

    [MemberNotNullWhen(true, nameof(Result))]
    public override bool IsSuccess => base.IsSuccess;

    public static new Response<TResult> CreateFailed(HttpStatusCode statusCode, string errorMessage)
    {
        var response = Response.CreateFailed(statusCode, errorMessage);
        return new Response<TResult>
        {
            ErrorMessage = response.ErrorMessage,
            StatusCode = response.StatusCode
        };
    }

    public static new Response CreateSuccess(HttpStatusCode statusCode)
    {
        var response = Response.CreateSuccess(statusCode);
        return new Response<TResult>
        {
            StatusCode = response.StatusCode,
        };
    }

    public static Response<TResult> CreateSuccess(TResult result)
    {
        return CreateSuccess(HttpStatusCode.OK, result);
    }

    public static Response<TResult> CreateSuccess(HttpStatusCode statusCode, TResult result)
    {
        return new Response<TResult> { StatusCode = statusCode, Result = result};
    }
}
