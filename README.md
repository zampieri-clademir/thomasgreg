
# Desafio

<hr>

<p align="center">
   <img src="http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=RED&style=for-the-badge" />
</p>

### Tópicos

- [Descrição do Projeto](#descrição-do-projeto)
- [Funcionalidades](#funcionalidades)
- [Requisitos Não Funcionais](#requisitos-não-funcionais)
- [Pré-Requisitos](#pré-requisitos)
- [Frameworkde e Componentes Utilizados](#frameworkde-e-componentes-utilizados)
- [Orientações aos Desenvolvedores](#orientações-aos-desenvolvedores)

## Descrição do Projeto

<p align="justify">
Este projeto, em desenvolvimento para a empresa Thomas Greg, tem como objetivo a implementação de um robusto sistema de cadastro de clientes.
 
O sistema será capaz de criar, editar, remover e visualizar informações de clientes em um portal web intuitivo e eficiente. Além do portal, o projeto inclui a construção de uma API REST escalável, projetada para suportar um grande volume de requisições, garantindo alta performance e disponibilidade.
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
- A API deve ter alta disponibilidade.

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
- Finalização do layout do portal pelo time de UX Design, garantindo uma interface intuitiva e centrada no usuário.
- Determinação do local de armazenamento dos arquivos de logotipo, com base em análises de desempenho e custo. A recomendação é utilizar um serviço de storage na nuvem, como Amazon S3 ou Azure Blob Storage, armazenando apenas a URL do arquivo no banco de dados para otimização de recursos.

### Para Início dos Testes em Ambiente de Desenvolvimento
- Definição da infraestrutura necessária, levando em consideração estimativas de desempenho e orçamentos. A escolha entre nuvem pública ou privada deve ser feita com base nesses fatores, incluindo a necessidade de capacitação do time na tecnologia selecionada.

### Para a Entrega
- Especificação do hardware para os servidores de aplicação e banco de dados, baseada em análises detalhadas e números projetados, assegurando que os recursos sejam adequados para o ambiente de produção.

## Frameworkde e Componentes Utilizados

- .NET 8.0
- Entity Framework 8
- FluentMigrator
- SQL Server
- ASP.NET MVC
- Razor
- JavaScript
- GitHub Actions
- NUnit
- JSON Web Token
- Mediator
- Arquitetura em Camadas

## Orientações aos Desenvolvedores

### Arquitetural Decisions Records

- **Decisão 1**: Adotar o Application Insights para monitoramento e telemetria da API, proporcionando visibilidade detalhada sobre o desempenho, erros e métricas de uso.

- **Decisão 2**: Desenvolver a API seguindo o padrão RESTful, garantindo a interoperabilidade e a facilidade de integração para a gestão e disponibilização dos dados dos clientes.

- **Decisão 3**: Considerando que o serviço lida com dados não classificados como pessoais segundo a LGPD, optar por uma infraestrutura hospedada fora do Brasil, visando a otimização de custos operacionais.

- **Decisão 4**: Utilizar o Entity Framework como ORM (Object-Relational Mapper) para facilitar a manipulação de dados e acelerar o desenvolvimento com uma abordagem orientada a objetos.

- **Decisão 5**: Implementar um gateway para a API com funcionalidades de rate limiting, assegurando o controle de consumo, evitando abusos e prevenindo indisponibilidades, especialmente por se tratar de uma API pública.

- **Decisão 6**: Adotar o SonarQube para análise contínua da qualidade do código, garantindo a identificação e correção de potenciais bugs, vulnerabilidades e melhorias no código.

- **Decisão 7**: Utilizar os pacotes NUnit e Moq para o desenvolvimento de testes unitários e integrados, assegurando a robustez e a confiabilidade do código através de testes automatizados.

- **Decisão 8**: Empregar o Selenium para a automação dos testes de interface e sistema, garantindo que todas as funcionalidades atendam aos requisitos de usabilidade e comportamento esperados.

- **Decisão 9**: Utilizar o Serilog como ferramenta de logging para a API, permitindo a criação de logs estruturados e eficientes para monitoramento e auditoria.

- **Decisão 10**: Caso o SQL Server seja escolhido para o armazenamento dos logotipos, criar um filegroup separado com um FileDisk dedicado, otimizando o desempenho e a organização dos dados de imagem.

- **Decisão 11**: A entrega final do sistema deverá ser realizada utilizando containers, garantindo portabilidade, consistência nos ambientes de execução e facilitando o processo de deploy.



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
