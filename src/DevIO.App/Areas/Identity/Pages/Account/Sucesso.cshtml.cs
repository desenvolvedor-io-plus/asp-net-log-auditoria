using DevIO.App.Extensions.Auditoria;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevIO.App.Areas.Identity.Pages.Account
{
    public class SucessoModel : PageModel
    {
        private readonly IAuditoriaHelper _auditoria;

        public SucessoModel(IAuditoriaHelper auditoria)
        {
            _auditoria = auditoria;
        }

        public IActionResult OnGet(string returnUrl, string email, string tipoRegisto)
        {
            returnUrl ??= Url.Content("~/");

            var mensagem = tipoRegisto == "Login"
                ? "Usuário Logado"
                : "Usuário Registrado";

            _auditoria.RegistrarLog(HttpContext, $"{mensagem} - {email}");

            return LocalRedirect(returnUrl);
        }
    }

}
