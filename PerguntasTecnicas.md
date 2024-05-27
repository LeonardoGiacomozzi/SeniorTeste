1- Quanto tempo você usou para completar a solução apresentada? O que você faria se 
tivesse mais tempo? 
Demorei em torno de 30 horas, isso porque iniciei utilizando docker na aplicação, mas o docker da aplicação não se comunicava com o docker do banco de dados e tentar achar uma solução para isso me custou a maior parte do tempo, como não encontrei solução, resolvi deixar somente o banco no docker. Se eu tivesse mais tempo eu  investiria em aprimorar os testes, adicionaria autenticação e iria procurar outras formas para resolver o problema de comunicação dos containers. 

2- Se usou algum framework, qual foi o motivo de ter usado este? Caso contrário, por 
que não utilizou nenhum? 
Utilizei o EntityFrameworkCore para poder criar as estruturas de banco e acessar as entidades de forma mais simples. 

3- Descreva você mesmo utilizando json.
{
   "nome":"Leonardo Gabriel",
   "sobrenome":"Giacomozzi",
   "data_nascimento":"1998-01-26",
   "Cidade":"Blumenau",
   "estado-civil":"União estável",
   "hobby":[
      "Assistir Series",
      "Assistir Animes",
      "Jogos Eletrônicos",
      "Voleibol"
   ],
   "pets":[
      {
         "tipo":"Cachorro",
         "nome":"Zoe"
      },
      {
         "tipo":"Cachorro",
         "nome":"Zara"
      }
   ]
   
}