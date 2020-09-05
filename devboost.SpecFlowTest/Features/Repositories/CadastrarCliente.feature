Feature: Realizar cadastro de um cliente

Scenario Outline: Cadastrar clientes com dados válidos
	Given Que não existão clientes cadastrados
	When Quando eu cadastrar o cliente Nome:'<Nome>' Email: '<Email>' Telefone:'<Telefone>' Latitude:'<Latitude>' Longitude:'<Longitude>' Usuario:'<Usuario>' Senha:'<Senha>' Perfil:'<Perfil>'
	Then Será retornado um cliente
	Examples: 
	| Nome | Email            | Telefone   | Latitude | Longitude | Usuario | Senha | Perfil |
	| Joao | joao@joao.com.br | 1231313123 | -23.458  | -43.567   | Eric   | 12345 | admin  | 