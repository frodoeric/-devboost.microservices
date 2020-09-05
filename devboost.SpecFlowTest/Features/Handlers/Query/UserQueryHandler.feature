Feature: Consultar Usuarios no sistema

Scenario Outline: consultar usuario
	Given Que exista usuarios cadastrados
	When Quando consultar
	Then Será retornado uma lista de clientes cadastrados