using System.Text.Json;

namespace DevIO.App.Extensions.Auditoria
{
    public class AuditoriaViewModel
    {
        public AuditoriaViewModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string Sistema { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Ip { get; set; }
        public string SistemaOperacional { get; set; }
        public string Browser { get; set; }
        public bool Mobile { get; set; }
        public string Acao { get; set; }
        public string Descricao { get; set; }
        public string Model { get; set; }

        public string ModelToJson(object model)
        {
            return JsonSerializer.Serialize(model);
        }

        public static AuditoriaViewModel AuditoriaToViewModel(Business.Models.Auditorias.Auditoria auditoria)
        {
            if (auditoria == null) return null;

            return new AuditoriaViewModel
            {
                Id = auditoria.Id,
                DataOcorrencia = auditoria.DataOcorrencia,
                Sistema = auditoria.Sistema,
                UserId = auditoria.UserId,
                UserName = auditoria.UserName,
                Ip = auditoria.Ip,
                SistemaOperacional = auditoria.SistemaOperacional,
                Browser = auditoria.Browser,
                Mobile = auditoria.Mobile,
                Acao = auditoria.Acao,
                Descricao = auditoria.Descricao,
                Model = auditoria.Model,
            };
        }

        public static Business.Models.Auditorias.Auditoria ViewModelToAuditoria(AuditoriaViewModel viewModel)
        {
            if (viewModel == null) return null;

            return new Business.Models.Auditorias.Auditoria(
                userId: viewModel.UserId,
                userName: viewModel.UserName,
                sistema: viewModel.Sistema,
                ip: viewModel.Ip,
                sistemaOperacional: viewModel.SistemaOperacional,
                browser: viewModel.Browser,
                mobile: viewModel.Mobile,
                acao: viewModel.Acao,
                descricao: viewModel.Descricao,
                model: viewModel.Model
            );
        }
    }
}