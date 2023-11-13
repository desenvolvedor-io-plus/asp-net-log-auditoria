using DevIO.App.Extensions.Auditoria;
using DevIO.Business.Models.Base;
using DevIO.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.App.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;
        private readonly IAuditoriaHelper _auditoria;

        protected Guid UserId { get; set; }
        protected string UserName { get; set; }

        protected BaseController(INotificador notificador,
                                 IAuditoriaHelper auditoria,
                                 IAppIdentityUser user)
        {
            _notificador = notificador;
            _auditoria = auditoria;

            if (user.IsAuthenticated())
            {
                UserId = user.GetUserId();
                UserName = user.GetUsername();
            }
        }

        protected void LogAuditoria(string descricao)
        {
            //_auditoria.RegistrarLog(HttpContext, descricao);
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
    }
}