using DevIO.Business.Models.Base;
using System.Text.Json;

namespace DevIO.Business.Models.Auditorias
{
    public class Auditoria : Entity
    {
        public Auditoria(string userId, string userName, string sistema, string ip, string sistemaOperacional, string browser, bool mobile, string acao, string descricao, string model = null)
        {
            UserId = userId;
            UserName = userName;
            Sistema = sistema;
            Ip = ip;
            SistemaOperacional = sistemaOperacional;
            Browser = browser;
            Mobile = mobile;
            Acao = acao;
            Descricao = descricao;
            Model = model;
            DataOcorrencia = DateTime.Now;
        }

        public DateTime DataOcorrencia { get; private set; }
        public string Sistema { get; private set; }
        public string UserId { get; private set; }
        public string UserName { get; private set; }
        public string Ip { get; private set; }
        public string SistemaOperacional { get; private set; }
        public string Browser { get; private set; }
        public bool Mobile { get; private set; }
        public string Acao { get; private set; }
        public string Descricao { get; private set; }
        public string Model { get; private set; }

        public string ModelToJson(object model)
        {
            return JsonSerializer.Serialize(model);
        }
    }
}