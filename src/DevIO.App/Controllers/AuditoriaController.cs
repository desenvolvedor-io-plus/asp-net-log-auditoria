using AutoMapper;
using DevIO.App.Extensions.Auditoria;
using DevIO.Business.Models.Auditorias;
using DevIO.Business.Models.Base;
using DevIO.Business.Notificacoes;
using DevIO.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevIO.App.Controllers
{
    [Route("auditoria")]
    public class AuditoriaController : BaseController
    {
        private readonly MeuDbContext _context;
        private readonly IMapper _mapper;

        public AuditoriaController(IMapper mapper,
                                  INotificador notificador,
                                  IAuditoriaHelper auditoria,
                                  IAppIdentityUser user,
                                  MeuDbContext context) : base(notificador, auditoria, user)
        {
            _mapper = mapper;
            _context = context;
        }

        [Route("listar")]
        public IActionResult Index()
        {
            var auditoria = _context.Auditoria
                                .Where(a => a.UserId == UserId.ToString())
                                .OrderBy(a=>a.DataOcorrencia)
                                .Select(a => AuditoriaViewModel.AuditoriaToViewModel(a));

            return View(auditoria);
        }
    }
}
