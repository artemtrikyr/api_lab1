namespace AttendanceJournalApi.Middlewares;

public class ServerErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ServerErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync("Сталася помилка на сервері");
        }
    }
}
