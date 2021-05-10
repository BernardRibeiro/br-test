Serviço de cálculo de juros ao mês
==========

Neste repositório existem duas APIs: API Taxas e API Calc

Ambas utilizam as seguintes tecnologias/frameworks:

* .NET Core 3.1
* Swagger
* NUnit
* Moq


Inicialização 
-----------
Ambas as APIs, ao inicializar, serão direcionadas para página do Swagger, contendo informações necessárias para utilização das mesmas.


Estrutura dos projetos
----------------------
Criei um projeto para cada contexto que julguei necessário. Basicamente, a estrutura ficou dividida da seguinte forma:

API Taxas
* Api
* Servicos

* TestesUnitarios
* TestesIntegrados

API Calc
* Api
* Servicos
* ServicosIntegrados

* TestesUnitarios

Busquei separar as responsabilidades seguindo um dos conceitos de SOLID.

Testes
------
Para a API de Taxas foi realizado testes unitários e testes integrados.
Já para a API de Calc foi realizado somente testes unitários.

Meu propósito na elaboração dos testes foi demostrar a intensão e conhecimento na implementação dos mesmos. Por isso, existem cenários não cobertos.