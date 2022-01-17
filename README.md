# TARS TEST

- Requirements
    - [x] Criar um projeto de sistema web ou aplicativo utilizando o VSCode.
    - [x] O nome do projeto deverá ser TARSTestSeuNome.
    - [x] Deve ser utilizado qualquer um dos frameworks a seguir: ASP.NET Core, VueJS, KnockoutJS. Caso o projeto de escolha seja aplicativo, utilizar Flutter;
    - [x] A aplicação web ou app deverá ser no mínimo um CRUD de qualquer informação, com as ações Criar, Listar, Atualizar e Deletar.
    - [x] Utilizar bancos de dados PostgreSQL, MongoDB ou MySQL. Utilizar Entity Framework ou modelo de procedures escritas no banco.
    - [x] O projeto deve ser todo escrito em inglês.
    - [x] Enviar o projeto e o script do banco de dados populado anexos por e-mail.

<a href="https://github.com/j-rdel/TARSTestJardel-mobile">Link to Flutter repository</a>

------

## Technologies 💻

- ASP.NET Core
- EntityFrameworkCore

------
### How to use

```bash
# Clone the repository
$ git clone https://github.com/j-rdel/TARSTestJardel-api.git

# Browse to repository
$ cd TARSTestJardel-api

# Install the EntityFrameworkCore dependencie
$ dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.0

# Open your MySQL and run these commands to create database and table
> CREATE DATABASE TARS;
> USE TARS;
> CREATE TABLE persons (
	id Integer auto_increment,
	name varchar(64) not null,
	age Integer not null,
	career varchar(32) not null,
	photoURL varchar(2024) not null,
	primary key (id)
);

# Open Program.cs and configure var ConnectionString with your database configurations
$ vi Program.cs

# Run API
$ dotnet run --urls "http://localhost:5001"

# Open Insomnia or some similiar app and test the routes
# List of persons GET to /person
# Individual person GET to /person/id
# Remove an person DELETE to /person/id
# Create person POST to /person
# Update person PATCH to /person/id

# JSON example to POST/PATCH
{
	"name":"Jardel Urban",
	"age":"20",
	"career":"Front end developer",
	"photourl":"https://avatars.githubusercontent.com/u/57304363?v=4"
}

```