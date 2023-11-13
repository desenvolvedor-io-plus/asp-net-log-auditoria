using DevIO.App.Extensions.Auditoria.UserAgentHelper;
using DevIO.Business.Models.Base;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.App.Extensions.Auditoria
{

    public partial class AuditoriaHelper : IAuditoriaHelper
    {
        private readonly IAppIdentityUser _user;
        private readonly ILogger<AuditoriaHelper> _logger;
        private readonly IServiceProvider _services;
        private UserAgent _userAgent;

        public AuditoriaHelper(IAppIdentityUser user, ILogger<AuditoriaHelper> logger, IServiceProvider services)
        {
            _user = user;
            _logger = logger;
            _services = services;
        }

        private static List<Item> Form(HttpContext context)
        {
            return context.Request.Form.Keys.OfType<string>().Select(k => new Item(k, context.Request.Form[k])).ToList();
        }

        private static string ObterValor(Item item)
        {
            return $"'{item.Key}':" + $"'{item.Value}',";
        }

        private static string GetIp(HttpContext context)
        {
            return context.Connection.RemoteIpAddress?.ToString();
        }

        public void RegistrarLog(HttpContext context, string descricao = null, string model = null)
        {
            try
            {
                var userName = _user.IsAuthenticated()
                    ? _user.GetUsername()
                    : "Anonimo";

                var userId = _user.IsAuthenticated()
                    ? _user.GetUserId().ToString()
                    : "Anonimo";

                if (descricao is null)
                {
                    var routeData = context.GetRouteData();

                    var controllerName = routeData.Values["controller"]?.ToString();
                    var actionName = routeData.Values["action"]?.ToString();

                    descricao = $"{controllerName}/{actionName}";
                }

                _userAgent = new UserAgent(context.Request.Headers["User-Agent"]);

                var modelJson = model;
                if (context.Request.Method.ToLower() == "post")
                {
                    var form = Form(context);
                    form.Remove(form.First(c => c.Key == "__RequestVerificationToken"));
                    modelJson = form.Aggregate("{", (current, item) => current + ObterValor(item)) + "}";
                }

                var log = new AuditoriaViewModel()
                {
                    DataOcorrencia = DateTime.Now,
                    UserName = userName,
                    UserId = userId,
                    Sistema = "Sistema desenvolvedor.io",
                    Ip = GetIp(context),
                    SistemaOperacional = _userAgent.OS.Name + " " + _userAgent.OS.Version,
                    Browser = _userAgent.Browser.Name + " " + _userAgent.Browser.Version,
                    Mobile = MobileDetectorUtils.fBrowserIsMobile(context),
                    Acao = context.Request.Path,
                    Descricao = descricao,
                    Model = modelJson ?? string.Empty
                };

                var auditoria = AuditoriaViewModel.ViewModelToAuditoria(log);
                var dbContext = new MeuDbContext(_services.GetRequiredService<DbContextOptions<MeuDbContext>>());

                dbContext.Auditoria.Add(auditoria);
                dbContext.SaveChanges();

                _logger.LogInformation("Auditoria", log);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
