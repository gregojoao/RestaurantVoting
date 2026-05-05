# Sistema de Votação de Restaurantes 🍽️

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

> Sistema de votação para escolha democrática de restaurantes para almoço, desenvolvido com .NET 10 e arquitetura DDD/CQRS.

## 📋 Índice

- [Sobre o Projeto](#sobre-o-projeto)
- [Problema e Solução](#problema-e-solução)
- [Tecnologias](#tecnologias)
- [Requisitos](#requisitos)
- [Instalação](#instalação)
- [Como Usar](#como-usar)
- [Arquitetura](#arquitetura)
- [Testes](#testes)
- [Regras de Negócio](#regras-de-negócio)
- [Melhorias Futuras](#melhorias-futuras)

## 🎯 Sobre o Projeto

Sistema desenvolvido para resolver o problema comum de escolher onde almoçar em equipe, através de um processo de votação democrático e automatizado.

## ⚡ Problema e Solução

### O Problema
Perder tempo escolhindo onde almoçar é um problema recorrente em ambientes corporativos. Discussões longas, colegas insatisfeitos e indecisão são comuns no dia a dia.

### A Solução
Sistema de votação onde cada profissional pode votar em seu restaurante favorito diariamente, com as seguintes características:

- ✅ **Um voto por pessoa por dia**
- ✅ **Restaurantes vencedores ficam bloqueados por uma semana**
- ✅ **Votação automática**: Abre às 07:00 e fecha às 11:30
- ✅ **Desempate automático**: Sistema sorteia entre os mais votados
- ✅ **Cadastro dinâmico**: Novos restaurantes podem ser adicionados a qualquer momento

## 🚀 Tecnologias

- **.NET 10.0** - Framework principal
- **ASP.NET Core** - API REST
- **NUnit 4.2** - Framework de testes
- **Flunt 2.0** - Validações e notificações
- **CQRS** - Separação de comandos e consultas
- **DDD** - Domain-Driven Design
- **In-Memory Database** - Persistência em memória

## 📦 Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Editor de código (Visual Studio 2022, VS Code ou Rider)

## 🔧 Instalação

1. Clone o repositório:
```bash
git clone <url-do-repositorio>
cd <nome-do-repositorio>
```

2. Restaure as dependências:
```bash
dotnet restore
```

3. Compile o projeto:
```bash
dotnet build
```

4. Execute a API:
```bash
cd Voting.Domain.Api
dotnet run
```

A API estará disponível em `https://localhost:5001` ou `http://localhost:5000`.

## 💻 Como Usar

### Endpoints Principais

#### Profissionais Famintos (Hungry Professionals)
- `POST /api/hungryprofessional` - Cadastrar novo profissional
- `GET /api/hungryprofessional` - Listar profissionais

#### Restaurantes Favoritos
- `POST /api/favoriterestaurant` - Cadastrar restaurante favorito
- `GET /api/favoriterestaurant` - Listar restaurantes

#### Votação
- `POST /api/restaurantvoting` - Registrar voto
- `GET /api/restaurantvoting/winner` - Consultar restaurante vencedor do dia

### Exemplo de Uso

1. **Cadastrar um profissional:**
```json
POST /api/hungryprofessional
{
  "name": "João Silva",
  "email": "joao@example.com"
}
```

2. **Cadastrar um restaurante:**
```json
POST /api/favoriterestaurant
{
  "name": "Restaurante Italiano",
  "hungryProfessionalId": "guid-do-profissional"
}
```

3. **Votar em um restaurante:**
```json
POST /api/restaurantvoting
{
  "hungryProfessionalId": "guid-do-profissional",
  "favoriteRestaurantId": "guid-do-restaurante"
}
```

4. **Consultar vencedor:**
```
GET /api/restaurantvoting/winner
```

## 🏗️ Arquitetura

O projeto segue os princípios de **Domain-Driven Design (DDD)** e **CQRS**:

### Estrutura de Pastas

```
├── Voting.Domain/              # Camada de domínio
│   ├── Commands/               # Comandos (escrita)
│   ├── Queries/                # Consultas (leitura)
│   ├── Entities/               # Entidades de domínio
│   ├── Handlers/               # Manipuladores de comandos
│   └── Services/               # Serviços de domínio
├── Voting.Domain.Infra/        # Camada de infraestrutura
│   ├── Data/                   # Contexto de dados
│   └── Repositories/           # Implementação de repositórios
├── Voting.Domain.Api/          # Camada de apresentação (API)
│   └── Controllers/            # Controladores REST
└── Voting.Domain.Tests/        # Testes unitários
    ├── Commands/
    ├── Handlers/
    └── Queries/
```

### Benefícios da Arquitetura

- **Separação de responsabilidades**: Cada camada tem sua responsabilidade bem definida
- **Testabilidade**: Facilita a criação de testes unitários
- **Manutenibilidade**: Código organizado e fácil de manter
- **Escalabilidade**: Preparado para crescimento
- **Reutilização**: Domínio pode ser consumido por diferentes aplicações

## 🧪 Testes

Execute os testes unitários:

```bash
dotnet test
```

Execute com cobertura de código:

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

O projeto possui testes para:
- ✅ Comandos (Commands)
- ✅ Manipuladores (Handlers)
- ✅ Consultas (Queries)
- ✅ Entidades de domínio
- ✅ Objetos de valor (Value Objects)

## 📜 Regras de Negócio

1. **Votação Diária**
   - Horário: 07:00 às 11:30 (segunda a sexta)
   - Um voto por profissional por dia
   - Resultado disponível após às 11:30

2. **Restaurantes**
   - Cada profissional pode cadastrar múltiplos restaurantes
   - Restaurante vencedor fica bloqueado por 7 dias
   - Novos restaurantes podem ser adicionados durante votação ativa

3. **Desempate**
   - Em caso de empate, o sistema realiza sorteio aleatório
   - Todos os restaurantes empatados participam do sorteio

4. **Período de Votação**
   - Ciclo semanal (5 dias úteis)
   - Reinicia automaticamente a cada semana

## 🔮 Melhorias Futuras

- [ ] **Autenticação e Autorização**: Implementar JWT para segurança
- [ ] **Banco de Dados Persistente**: Migrar para SQL Server ou PostgreSQL
- [ ] **Notificações**: Enviar e-mail/push com resultado da votação
- [ ] **Dashboard**: Interface web para visualização de estatísticas
- [ ] **Histórico**: Relatórios de votações anteriores
- [ ] **Critérios de Desempate**: Implementar critérios alternativos ao sorteio
- [ ] **API de Geolocalização**: Sugerir restaurantes próximos
- [ ] **Avaliações**: Sistema de rating dos restaurantes
- [ ] **Containerização**: Docker e Docker Compose
- [ ] **CI/CD**: Pipeline automatizado de deploy

## 👥 Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para:

1. Fazer fork do projeto
2. Criar uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abrir um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 📞 Contato

Dúvidas, sugestões e melhorias são sempre bem-vindas! 👊 🚀

---

**Desenvolvido com ❤️ usando .NET 10**
