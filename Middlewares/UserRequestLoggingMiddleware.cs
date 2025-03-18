namespace AttendanceJournalApi.Middlewares;

public class UserRequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public UserRequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"Запит від користувача до {context.Request.Method} {context.Request.Path}");

        await _next(context);
    }
}
