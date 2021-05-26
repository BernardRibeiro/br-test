# Projeto de estudos - Juros compostos

## Projeto Web

Projeto web (BR.Site) foi construído em React JS com objetivo de consumir uma API que realiza o cálculo de juros compostos com base em um valor inicial e o número de meses escolhido.

### Instalando

> `npm install`

### Configurando

É necessário a criação do arquivo .env e a configuração da variável `REACT_APP_BASEURL` indicando a url base onde ficará a API de Cálculo.

#### Exemplo:

> `REACT_APP_BASEURL=https://localhost:5003/`

### Rodando a aplicação localmente

> `npm start`

## APIs

Existem duas APIs: API Taxas (BR.Taxas) e API Calc (BR.Calc)

Ambas utilizam as seguintes tecnologias/frameworks:

- .NET Core 3.1
- Swagger
- NUnit
- Moq

### Inicialização

As APIs, ao inicializarem, serão direcionadas para página do Swagger, contendo informações necessárias para utilização das mesmas.

> De preferência as APIs devem ser executadas diretamente por seus projetos de inicialização, e não pelo IIS Express. Isso facilitará o funcionamento local.

### Estrutura dos projetos

Foram criados dois projetos distintos com a seguintes estruturas:

API Taxas

- Api
- Servicos

- TestesUnitarios
- TestesIntegrados

API Calc

- Api
- Servicos
- ServicosIntegrados

- TestesUnitarios

Foram separadas as responsabilidades seguindo conceitos de SOLID.

### Testes

Para a API de Taxas foram realizados testes unitários e testes integrados.
Já para a API de Calc, somente testes unitários.

O propósito na elaboração dos testes foi demostrar a intensão e conhecimento na implementação dos mesmos. Por isso, existem cenários não cobertos.
