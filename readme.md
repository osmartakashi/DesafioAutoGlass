Este desafio consistiu nos seguintes requisitos:

Voc� ir� criar API para a gest�o de produtos, com os seguintes recursos:
�	Recuperar um registro por c�digo;
�	Listar registros 
 	Filtrando a partir de par�metros e paginando a resposta
�	Inserir 
Criar valida��o para o campo data de fabrica��o que n�o poder� ser maior ou igual a data de validade.
�	Editar
Criar valida��o para o campo data de fabrica��o que n�o poder� ser maior ou igual a data de validade.
�	Excluir 
A exclus�o dever� ser l�gica, atualizando o campo situa��o com o valor Inativo.
Campos no escopo de produtos s�o
�	C�digo do produto (sequencial e n�o nulo)
�	Descri��o do produto (n�o nulo)
�	Situa��o do produto (Ativo ou Inativo)
�	Data de fabrica��o
�	Data de validade
�	C�digo do fornecedor
�	Descri��o do fornecedor
�	CNPJ do fornecedor
Requisitos
Obrigat�rio
�	Construir a Web-api em dotnet core ou dotnet 5.
�	Construir a estrutura em camadas e em DDD.
Diferenciais
�	Utilizar ORM
�	Utilizar a biblioteca Automapper para fazer o mapeamento entity-DTO.
�	Fazer teste unit�rios

===================================================================================================================
Explicando sobre a arquitetura penso que a solu��o mais interessante para um in�cio de projeto seria:

----------------------|---|
|API                  | M |
|---------------------| O |
|Application          | D |
|---------------------| E |
|Infra                | L |
|---------------------|---|

A responsabilidade da API � simplesmente receber uma requisi��o e encaminh�-la para a camada Application (ou aplica��o). 
Tem como responsabilidade tamb�m de validar o ModelState de entrada. 

A responsabilidade da camada Application � referente �s regras de neg�cio quando houver. Um exemplo � utilizar-se do padr�o
Specification para validar regras de neg�cio ou mesmo fazer valida��es. Para esse exerc�cio esta camada simplesmente
faz o mapeamento utilizando o AutoMapper dos modelos de entrada para o modelo conhecido do nosso DataContext.

A camada de Infra � basicamente comportar todos os tipos de servi�os de infra-estrutura. Costumo utilizar essa camada 
para armazenar os reposit�rios de dados j� que de fato, h� uma comunica��o com o banco de dados, o que considero um componente de infra.

Por fim a camada de dom�nio (Model) est�o as classes de dom�nio do sistema. Nessa camada coloquei tanto os DTO�s quanto as
classe de dom�nio e que s�o utilizadas pelo DataContext. Criei tamb�m um validador customizado para validar 
se a data de fabrica��o � maior do que a data de validade. 
Nesse validador verifico qual o tipo que est� sendo passado tornando-o gen�rico o suficiente para atender essa demanda.

====================================================================================================================

Testes unit�rios:

- Testes unit�rios s�o excelentes para se testar rapidamente se um determinado compomente est� funcionando de acordo.
Existem duas abordagens quando o tema � testes: O primeiro seria a cobertura do c�digo com testes e a segunda seria o
desenvolvimendo usando TDD ou mesmo BDD.
Para este exerc�cio fiz um teste de reposit�rio utilizando-se um banco em mem�ria apenas para fins de testes. 
Pode-se expandir os testes para outras camadas mas acredito que isso vai de acordo com a necessidade.

=====================================================================================================================

Para rodar a aplica��o:
 - Pegar a collection do postman que est� junto do projeto e importar no Postman.
 - Rodar a migration para inicializar o banco de dados. O banco � o SQL Server express (.\sqlexpress)
   Abrir o console do Package-Manager e rodar: Add-Migration SeedDatabase, se der tudo certo rode: update-database

=====================================================================================================================
Documenta��o:

- A documenta��o foi feita utilizando-se o swagger e adicionando as descri��es do que cada endpoint faz. Acredito que
essa � a melhor solu��o para documentar API`s de uma maneira geral.

Obrigado!