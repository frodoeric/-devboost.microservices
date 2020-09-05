Feature: Realizar Cadastro Drone

Scenario Outline: Cadastrar Drones com dados válidos
	Given Que não existão drones cadastrados
	When Quando eu cadastrar o drone Id:'<Id>' Capacidade: '<Capacidade>' Velocidade:'<Velocidade>' Autonomia:'<Autonomia>' Carga:'<Carga>' StatusDrone:'<StatusDrone>'
	Then Será retornado um drone
	Examples: 
	| Id | Capacidade | Velocidade | Autonomia | Carga | StatusDrone |
	| 21 | 12         | 35         | 15        | 100   | 1  |