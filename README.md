BasicArchitecture

📌 Sobre o Projeto
O BasicArchitecture é uma solução baseada em .NET que segue o princípio do DDD (Domain-Driven Design). Ele é projetado para ser modular e escalável, facilitando a manutenção e evolução do código.

⚙️ Tecnologias Utilizadas
O projeto foi desenvolvido utilizando as seguintes tecnologias:
- .NET (versão recomendada: 7.0 ou superior)
- ASP.NET Core Web API
- MongoDB (para persistência de dados)
- Apache Kafka (para processamento de mensagens)
- xUnit (para testes unitários e de integração)

🚀 Como Executar o Projeto
Pré-requisitos
Antes de rodar o projeto, certifique-se de ter instalado:
- SDK do .NET
- Docker (opcional, para rodar MongoDB e Kafka)
- Visual Studio ou VS Code

Passos para execução
1 - Clone o repositório
git clone https://github.com/seu-usuario/BasicArchitecture.git
cd BasicArchitecture

2 - Configure as variáveis de ambiente
Defina as configurações de conexão no appsettings.json dentro do projeto WebApi, como:
{
  "ConnectionStrings": {
    "MongoDB": "mongodb://localhost:27017",
    "Kafka": "localhost:9092"
  }
}

3 - Execute os containers do MongoDB e Kafka (opcional) Se quiser rodar o MongoDB e Kafka localmente, utilize o Docker:
docker-compose up -d

4 - Execute a aplicação
dotnet run --project src/WebApi/WebApi.csproj

5 - Acesse a API Após a execução, a API estará disponível em:
http://localhost:5000/swagger

✅ Testes
Para rodar os testes, utilize o comando:
dotnet test

Os testes estão organizados em:
- UnitTests → Testes unitários de componentes individuais.
- IntegratedTests → Testes de integração com serviços externos.
- FunctionalTests → Testes funcionais para validar fluxos completos.