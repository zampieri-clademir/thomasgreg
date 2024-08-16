
# Desafio

<hr>

<p align="center">
   <img src="http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=RED&style=for-the-badge" />
</p>

### Tópicos

- [Descrição do Projeto](#descrição-do-projeto)
- [Funcionalidades](#funcionalidades)
- [Aplicação](#aplicação)
- [Ferramentas Utilizadas](#ferramentas-utilizadas)
- [Acesso ao Projeto](#acesso-ao-projeto)
- [Como Abrir e Rodar o Projeto](#como-abrir-e-rodar-o-projeto)
- [Desenvolvedores](#desenvolvedores)

## Descrição do Projeto

<p align="justify">
 Projeto em desenvolvimento para a empresa Thomas Greg. Este projeto visa implementar um sistema de cadastro de clientes.
 
 O sistema permitirá criar, editar, remover e visualizar clientes em um portal web. Além da implementação do portal, também faz parte deste projeto a criação de uma API REST que suportará um grande número de requisições.
</p>

## Funcionalidades

### Cadastro de Clientes
- Criar um novo cliente com os campos: Nome, E-mail, Logotipo e Logradouro.
- Atualizar as informações de um cliente existente.
- Visualizar os detalhes de um cliente, incluindo todos os seus logradouros.
- Remover um cliente do sistema.

### Cadastro de Logradouros
- Criar novos logradouros associados a um cliente.
- Atualizar as informações de um logradouro.
- Visualizar os detalhes de um logradouro.
- Remover um logradouro.

### Validação de Dados
- Garantir que um cliente não possa ser registrado duas vezes com o mesmo endereço de e-mail.
- O logotipo deve ser uma imagem e deve ser possível fazer o upload e armazená-la no banco de dados.

### Autenticação e Autorização
- O acesso à API deve ser autenticado. Apenas usuários autorizados devem ser capazes de criar, atualizar, visualizar ou remover clientes e logradouros.
- A API deve suportar diferentes níveis de permissão, por exemplo, usuários que podem visualizar mas não alterar dados.

## Requisitos Não Funcionais

### Performance
- A API deve ser capaz de lidar com um grande volume de requisições simultâneas sem degradação significativa de desempenho.
- O tempo de resposta da API deve ser mínimo, garantindo que as operações de cadastro, atualização, visualização e remoção sejam executadas rapidamente.

### Escalabilidade
- A solução deve ser escalável, permitindo que o sistema suporte um aumento significativo no número de clientes e logradouros sem perda de performance.
- O sistema deve estar preparado para escalar horizontalmente, adicionando mais instâncias de servidores conforme necessário.

### Segurança
- A API deve implementar autenticação e autorização robustas para proteger os dados dos clientes.
- Dados sensíveis, como informações de login e senhas, devem ser protegidos através de criptografia.
- Deve haver mecanismos para prevenir ataques como SQL Injection, Cross-Site Scripting (XSS), e Cross-Site Request Forgery (CSRF).

### Disponibilidade
- A API deve ter alta disponibilidade, com uma meta de uptime de 99.9% ou superior.
- Deve haver planos de contingência e recuperação de desastres para garantir a continuidade do serviço em caso de falhas.

### Manutenibilidade
- O código da API deve ser modular, bem documentado e fácil de manter e atualizar.
- Deve ser possível adicionar novos campos ou funcionalidades no futuro sem necessidade de reescrever grandes partes do código.

### Armazenamento de Imagens
- O armazenamento de logotipos (imagens) deve ser eficiente em termos de espaço e deve permitir uma recuperação rápida.
- Devem ser utilizados métodos de compressão de imagens no tráfego e no armazenamento.

### Conformidade com Padrões
- Para a implementação da API, deve ser adotado o padrão RESTful.
- É imprescindível a participação do time de UX para montar a proposta do design do portal.

## Pré-requisitos

### Para Início da Implementação
- Definição do layout do portal pelo time de UX Design.

### Para Início dos Testes em Ambiente de Desenvolvimento
- Definição, com base em estimativas e orçamentos, da infraestrutura a ser utilizada, seja em nuvem pública ou privada. Considerar também a necessidade de treinamento do time na tecnologia escolhida.
- Definição, com base em estimativas, do local de armazenamento dos arquivos de logotipo, preferencialmente em um storage na nuvem (como Amazon S3 ou Azure Blob Storage), mantendo apenas a URL do arquivo no banco de dados.

### Para a Entrega
- Definição do hardware dos servidores de aplicação e banco de dados com base em números.

## Ferramentas Utilizadas

- .NET 8.0
- Entity Framework 8
- FluentMigrator
- SQL Server
- ASP.NET MVC
- Razor
- JavaScript
- GitHub Actions
- NUnit

## Orientações aos Desenvolvedores

### Arquitetural Decisions Records

- **Decisão 1**: Utilização do Application Insights para monitoramento da API.
- **Decisão 2**: Criação da API no padrão REST para receber e disponibilizar os dados dos clientes.
- **Decisão 3**: Devido ao fato de o serviço trabalhar com dados que não são de natureza pessoal, segundo a LGPD, existe a possibilidade de termos a infraestrutura fora do Brasil, impactando assim positivamente nos custos.
- **Decisão 4**: Utilização do Entity Framework como ORM para a aplicação.
- **Decisão 5**: Utilização de um gateway para a API com rate limiter para evitar consumo indevido e indisponibilidade e gastos não previstos. Necessário devido à API ser aberta.
- **Decisão 6**: Utilização do SonarQube para análise de código.
- **Decisão 7**: Utilização dos pacotes NUnit e Moq para a criação de testes unitários e testes integrados.
- **Decisão 8**: Utilização do Selenium para automatização dos testes de tela e de sistema.
- **Decisão 9**: Utilizar o componente Serilog para a criação de logs da API.
- **Decisão 10**: Caso seja decidido utilizar o SQL Server para armazenar os logotipos criar um filegroup separado com seu próprio FileDisk.


### Design de Código
- A POC proposta pode e deve ser utilizada como template e estrutura base para a implementação do serviço e também do portal. A estrutura proposta leva em consideração a estratégia de implementação em camadas e possui a estrutura bem definida, o que vai proporcionar a evolução saudável do projeto.

### Testes Automatizados
- Utilizar o padrão de testes proposto na POC fornecida.
- Manter a cobertura de código acima de 80% para toda a solução.

### Repositório, Políticas de Pull Requests e Estratégia de Branch
- O repositório a ser utilizado é o mesmo utilizado na POC fornecida.
- Pull Requests somente serão aprovados mediante a aprovação do líder técnico.
- Utilizar a estratégia de branch Git Flow.

### DevOps
- Implementar pipelines de CI/CD através do GitHub Actions para atualização automática de ambientes de homologação e produção.
- Considerar a execução dos testes unitários na pipeline de CI.

### Documentação
- Envolver o time responsável para a criação de uma documentação detalhada sobre as funcionalidades da aplicação.

### API REST

- A documentação da API está disponível em [API Documentation](https://zampiericlademir.docs.apiary.io/#).
- Implementar um bloqueio de 5 minutos após 3 tentativas de autenticação inválidas.
- Os endpoints serão protegidos através de autenticação com JWT Token.
- Seguir as recomendações de performance mencionadas no link acima.

### Portal Web
- O portal deve ser implementado com ASP.NET Core MVC e Razor.
- O protótipo do portal apresenta apenas a forma de autenticação na API e armazenamento do token para acesso posterior às chamadas da API. Utilizar este exemplo para desenvolver o portal.

### Como Abrir e Rodar a POC
- No repositório do GitHub, você encontrará o código da POC deste projeto. Ao abrir a solução no Visual Studio, você encontrará na camada Distribution Layer o projeto da API e o Projeto Web. O banco de dados para teste está hospedado no Azure, então ao executar a API, ela deve ser executada normalmente.
- Para executar o portal, é necessário informar a URL da API no `appsettings.json`, apenas esse ajuste é necessário.
