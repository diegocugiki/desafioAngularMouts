# Solução Desafio

## Descrição do projeto

Neste repositório há uma API RESTfull e um projeto do Angular criados com o intuito de responder a um desafio de gerenciamento de Unidades Federativas e Municípios . A API foi desenvolvida com a linguagem de programação C#, utilizando o editor de código-fonte Visual Studio Code. Para a disponibilização dos dados foi utilizado o Framework ASP.NET Core. Para criar as requisições foi utilizada a ferramenta Postman, que tem como objetivo testar serviços de WEB APIs por meio do envio de requisições HTTP, sendo possível avaliar as respostas das requisições.

## Sumário

* [Critérios](#criterios)
* [Como rodar a aplicação](#rodar-aplicacao)
* [Pacotes utilizados](#pacotes-utilizados)



## Critérios

<div id="criterios">

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

<div id="rodar-aplicacao">
## Como rodar a aplicação

Antes de tudo, é preciso ter o SQL Server, o .NET Framework e o .NET Core instalados em seu computador. A API utiliza esses serviços para funcionar e para gerenciar um banco de dados.

Depois de baixar os programas necessários, é preciso configurar a conexão com o banco de dados SQL no diretório `BackEnd/appsettings.json` e na chave `"ConexaoBase"`, cujo valor será a string de conexão. Para isso, crie um bloco de notas na área de trabalho e o salve como um arquivo .udl. Ao abrir esse arquivo udl, você conseguirá configurar a conexão. Depois de configurada, basta abrir o mesmo arquivo com o bloco de notas e terás a string de conexão.

Para executar a API através do Visual Studio Code, deve-se abrir o Terminal com a combinação de teclas `Ctrl + Shift + ` ou `Ctrl + `, selecionar a pasta "BackEnd" com o comando cd e a tecla TAB e digitar os seguintes comandos:
```
dotnet tool install --global dotnet-ef
dotnet ef database update
dotnet run
```

Antes de iniciar o projeto do Angular, deve-se instalar o Node.js

Após isso, no Visual Studio Code, necessita-se abrir outro Terminal, navegue até o diretório "FrontEnd" e digitar os seguintes comandos:
```
npm install -g @angular/cli
npm update
npm start
```

Caso dê erro ao executar 'npm' no terminal, adicione o diretório do Node às Variáveis de Ambiente de seu computador e reinicie-o.

Após essas etapas, a API e o Angular estarão rodando ao mesmo tempo, e você poderá acessar o programa através do link `http://localhost:4200` em seu navegador.

<div id="pacotes-utilizados">
## Pacotes utilizados
BackEnd:

 - Microsoft.EntityFrameworkCore
 - Microsoft.EntityFrameworkCore.SqlServer
 - Microsoft.EntityFrameworkCore.Design
 - Microsoft.EntityFrameworkCore.Tools
 - Microsoft.EntityFrameworkCore.Analyzers
 - Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 3.1.7
 - NUnit --version 3.12.0

FrontEnd:

 - Bootstrap
 - NGX-Bootstrap

Os pacotes do EntityFrameworkCore foram usados para desenvolver a API;
O pacote NewtonsoftJson foi empregado para impedir ciclos incessantes ao receber respostas da API;
O pacote NUnit foi utilizado para realizar testes unitários na classe de verificação de listas na API; Os pacotes do FrontEnd foram recorridos com o intuito de estilizar as páginas HTML.
