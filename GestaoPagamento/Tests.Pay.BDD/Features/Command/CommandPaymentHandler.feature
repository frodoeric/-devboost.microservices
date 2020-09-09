Feature: CommandPaymentHandler

Scenario Outline: 
	Given Exista Payments cadastrados	
	When Consultar Pagamentos
	Then Cadastrar pagamentos