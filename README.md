# Adicionando Log de Auditoria em uma Aplicação ASP.NET

## Introdução
Este repositório aborda a implementação de um log de auditoria em uma aplicação ASP.NET. A auditoria de logs é crucial para rastrear ações importantes do usuário que alteram o estado da aplicação, fornecendo informações detalhadas sobre quem realizou determinadas ações e quando foram realizadas.

## Diferença entre Log de Auditoria e Log de Aplicação
Enquanto um log de aplicação se concentra em informações sobre o funcionamento da aplicação (como erros e status de operações), o log de auditoria registra ações específicas do usuário, como mudanças no estado da aplicação, tornando-se um recurso valioso para auditoria e conformidade.

## Entidade Modelo para Log de Auditoria
Criamos uma entidade modelo que representa o log de auditoria, capturando informações relevantes como IP do usuário, versão do sistema operacional e do navegador, dados trafegados no formulário, rotas acessadas, entre outros.

## Implementação de Log de Auditoria
Oferecemos duas abordagens para implementar o log de auditoria:

1. **Serviço de Log sob Demanda:**
   - Invocação do serviço de log em actions específicas da controller.
   - Permite focar no registro de ações que são críticas e merecem ser auditadas.
   - Exemplo de como integrar o serviço de log nas controllers para capturar ações específicas.

2. **Log Automático via Middleware:**
   - Implementação de um middleware que registra automaticamente todas as requests.
   - Produz um log mais detalhado, capturando todos os aspectos da navegação do usuário.
   - Demonstra como integrar o middleware na aplicação para uma auditoria abrangente e automatizada.

## Vantagens
- **Rastreabilidade:** Fornece um histórico detalhado das ações do usuário, crucial para auditorias e análise forense.
- **Flexibilidade:** Oferece diferentes métodos de implementação, adequados para diversos cenários de uso.
- **Segurança Reforçada:** Ajuda na identificação de atividades suspeitas ou não autorizadas.

## Como Utilizar Este Repositório
1. **Configuração do Ambiente:** Certifique-se de ter o .NET Core SDK e o EF Core instalados.
2. **Clonar o Repositório:** Clone este repositório para sua máquina local.
3. **Explorar o Código:** Abra o projeto no seu IDE favorito e explore a estrutura e implementação.
4. **Executar o Projeto:** Execute o Build e observe o comportamento do projeto conforme o vídeo do conteúdo PLUS.

