using DevIO.Business.Models.Auditorias;

namespace DevIO.App.Extensions.Auditoria
{
    public static class AuditoriaExtensions
    {
        public static WebApplication UseLogAuditoria(this WebApplication app)
        {
            app.UseMiddleware<AuditoriaMiddleware>();

            return app;
        }
    }

    public class AuditoriaMiddleware
    {
        private readonly RequestDelegate _next;

        public AuditoriaMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAuditoriaHelper auditoriaService)
        {
            var temErro = false;

            try
            {
                await _next(context);
            }
            catch (Exception)
            {
                temErro = true;
                throw;
            }
            finally
            {
                if (!temErro)
                {
                    auditoriaService.RegistrarLog(context);
                }
            }
        }
    }

}
