namespace DevIO.App.Extensions.Auditoria
{
    public interface IAuditoriaHelper
    {
        void RegistrarLog(HttpContext context, string descricao = null, string model = null);
    }
}
