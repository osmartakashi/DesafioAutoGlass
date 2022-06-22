

### Explicando sobre a arquitetura penso que a solução mais interessante para um início de projeto seria:


A responsabilidade da API é simplesmente receber uma requisição e encaminhá-la para a camada Application (ou aplicação). 
Tem como responsabilidade também de validar o ModelState de entrada. 

A responsabilidade da camada Application é referente às regras de negócio quando houver. Um exemplo é utilizar-se do padrão
Specification para validar regras de negócio ou mesmo fazer validações. Para esse exercício esta camada simplesmente
faz o mapeamento utilizando o AutoMapper dos modelos de entrada para o modelo conhecido do nosso DataContext.

A camada de Infra é basicamente comportar todos os tipos de serviços de infra-estrutura. Costumo utilizar essa camada 
para armazenar os repositórios de dados já que de fato, há uma comunicação com o banco de dados, o que considero um componente de infra.

Por fim a camada de domínio (Model) estão as classes de domínio do sistema. Nessa camada coloquei tanto os DTO´s quanto as
classe de domínio e que são utilizadas pelo DataContext. Criei também um validador customizado para validar 
se a data de fabricação é maior do que a data de validade. 
Nesse validador verifico qual o tipo que está sendo passado tornando-o genérico o suficiente para atender essa demanda.



Testes unitários:

- Testes unitários são excelentes para se testar rapidamente se um determinado compomente está funcionando de acordo.
Existem duas abordagens quando o tema é testes: O primeiro seria a cobertura do código com testes e a segunda seria o
desenvolvimendo usando TDD ou mesmo BDD.
Para este exercício fiz um teste de repositório utilizando-se um banco em memória apenas para fins de testes. 
Pode-se expandir os testes para outras camadas mas acredito que isso vai de acordo com a necessidade.



Para rodar a aplicação:
 - Pegar a collection do postman que está junto do projeto e importar no Postman.
 - Rodar a migration para inicializar o banco de dados. O banco é o SQL Server express (.\sqlexpress)
   Abrir o console do Package-Manager e rodar: Add-Migration SeedDatabase, se der tudo certo rode: update-database


Documentação:

- A documentação foi feita utilizando-se o swagger e adicionando as descrições do que cada endpoint faz. Acredito que
essa é a melhor solução para documentar API`s de uma maneira geral.

Obrigado!
