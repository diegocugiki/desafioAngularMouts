# Solução Desafio

## Descrição do projeto

Neste repositório há uma API RESTfull e um projeto do Angular criados com o intuito de responder a um desafio de gerenciamento de Unidades Federativas e Municípios . A API foi desenvolvida com a linguagem de programação C#, utilizando o editor de código-fonte Visual Studio Code. Para a disponibilização dos dados foi utilizado o Framework ASP.NET Core. Para criar as requisições foi utilizada a ferramenta Postman, que tem como objetivo testar serviços de WEB APIs por meio do envio de requisições HTTP, sendo possível avaliar as respostas das requisições.

## Sumário

* [Critérios](#criterios)
* [Como rodar a aplicação](#rodar-aplicacao)
* [Pacotes utilizados](#pacotes-utilizados)
* [Explicação dos modelos](#modelos)
* [Efetuação das restrições](#restricoes)
* [Endpoints](#endpoints)

## Critérios

### Problema

Nesse desafio você deverá criar um sistema de cadastro (CRUD) permitindo o gerenciamento 
de Unidades Federativas e Municípios.

### O sistema deve permitir

<ul><li>Deverá ser criado as tabelas do banco de dados:</li></ul>

<ol><li>Tabela estados, campos: id, nome, sigla</li><li>Tabela municipios, campos: id, nome, prefeito, populacao. (Prefeito e 
população poderão ser preenchidos em branco)</li><li>Deverá ser criado uma relação entre a tabela municipios e estados, atrelando 
o municipio a um estado e um estado a varios municipios</li><li>itemd</li></ol>

<ul><li>Um cabeçalho e um rodapé deverão ser compartilhados entre as páginas.</li></ul>
<ol><li>O cabeçalho deverá conter um menu que chamará a listagem de estados e de 
Municípios.</li><li>itemb</li><li>No rodapé deverá conter o texto “Todos os direitos reservado” com ano atual 
e o símbolo de copyright “©”, o mesmo deverá sempre na parte inferior do 
site centralizado. </li></ol>
<ul><li>Criar o CRUD de estados e municípios.</li></ul>
<ol><li>Deve-se utilizar os campos criados partir das tabelas do banco de dados.</li><li>Na tela de listagem deverá apresentar as operações que usuário poderá 
realizar (Criar, visualizar, editar e remover).</li><li>Ao finalizar o cadastro e edição deverá apresentar uma mensagem de 
confirmação e usuário deverá ser redirecionado a página de listagem.</li><li> Ao tentar remover um item o mesmo deverá solicitar uma confirmação.</li></ol>
