using System.Net;

namespace App.Exceptions
{

  public class HttpRequestException : Exception
  {
    public HttpStatusCode StatusCode { get; }

    public HttpRequestException(string message, Exception inner, HttpStatusCode statusCode) : base(message, inner)
    {
      StatusCode = statusCode;
    }

    public HttpRequestException(string message, HttpStatusCode statusCode) : base(message)
    {
      StatusCode = statusCode;
    }
  }
  public class NotFoundException : HttpRequestException
  {
    public NotFoundException(string message, Exception inner) : base(message, inner, HttpStatusCode.NotFound) { }
    public NotFoundException(string message) : base(message, HttpStatusCode.NotFound) { }

  }

  public class BadRequestException : HttpRequestException
  {
    public BadRequestException(string message, Exception inner) : base(message, inner, HttpStatusCode.BadRequest) { }
    public BadRequestException(string message) : base(message, HttpStatusCode.BadRequest) { }

  }

  public class UnauthorizedException : HttpRequestException
  {
    public UnauthorizedException(string message, Exception inner) : base(message, inner, HttpStatusCode.Unauthorized) { }
    public UnauthorizedException(string message) : base(message, HttpStatusCode.Unauthorized) { }

  }

  public class ForbiddenException : HttpRequestException
  {
    public ForbiddenException(string message, Exception inner) : base(message, inner, HttpStatusCode.Forbidden) { }
    public ForbiddenException(string message) : base(message, HttpStatusCode.Forbidden) { }

  }

  public class ConflictException : HttpRequestException
  {
    public ConflictException(string message, Exception inner) : base(message, inner, HttpStatusCode.Conflict) { }
    public ConflictException(string message) : base(message, HttpStatusCode.Conflict) { }

  }
}