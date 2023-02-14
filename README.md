# SD2023_T5

- Diogo
- Gian
- Marcelo

Linguagens C# (.NET 6.0) e JS (Node)

Broker MQTT

BAAS Firebase

Definição do grupo (até 3 componentes):
-------------------------------------
1 - aplicação de IoT 
2 - broker (mosquitto)
3 - container
4 - SGBD noSQL ou BAAS

Implementações:
-------------------------------------
A- aplicação que simule a leitura de um sensor e envie os dados (pub) para um broker (o broker deve estar rodando em uma VM ou container docker)
B- aplicação que busque os dados (sub) do broker e salve em formato JSON em um BAAS ou em um SGBD noSQL
(o SGBD "pode" estar rodando em uma VM ou container docker)

3 - aplicação que consulte os dados (verbo get de CRUD) do BAAS ou SGBD noSQL

Avaliação do trabalho:
-------------------------------------
10 pontos: broker rodando no container
30 pontos: 2 implementações 
10 pontos: SGBD noSQL rodando no container ou BAAS


Adicionar um arquivo readme.md com as explicação e com os passos para:
     a) instalação 
     b) execução do sistema
