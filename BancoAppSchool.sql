USE "appSchool"

CREATE TABLE usuario(
cpf int primary key not null,
senha varchar(20) not null,
nome varchar(50) not null,
sexo varchar(10) not null,
rg int not null,
nascimento date not null,
celular int not null,
email varchar(50),
foto varbinary,
cidade varchar(50) not null,
endereco varchar(100) not null,
cep int not null,
numero int not null 



)


Create table forum(

idPost int identity primary key not null,
comentario varchar(max),
cpf_usuario int not null,

foreign key (cpf_usuario)
references  usuario(cpf)
)


INSERT INTO forum values('Pedro', 4)
select*from forum

select cpf_usuario, comentario, idpost FROM forum, usuario WHERE cpf_usuario = cpf AND idpost = 1

CREATE TABLE instituicao(
cnpj int PRIMARY KEY not null,
nomeInst varchar(30) not null,
telefone int not null,
cep int not null,
endereco varchar(50) not null,
numero int not null
)

CREATE TABLE  aluno(
frequencia int not null,
almoco varchar(20) not null,
turma varchar(10) not null,
rm int primary key not null,
cpf_usuario int not null,
cnpj_instituicao int not null,

CONSTRAINT chave_instituicao 
FOREIGN KEY (cnpj_instituicao)
REFERENCES instituicao(cnpj),

CONSTRAINT chave_usuario
FOREIGN KEY(cpf_usuario)
REFERENCES usuario(cpf)
)

select cpf, rm, senha from aluno, usuario
	where cpf = cpf_usuario and rm = 3333;

	select * from usuario

CREATE TABLE professor(
materia varchar(30) primary key, 
cpf_usuario int  not null,

CONSTRAINT chave_usuario2 
FOREIGN KEY(cpf_usuario)
REFERENCES usuario(cpf)

)

CREATE TABLE nutricionista(


)

CREATE TABLE administrador(
id VARCHAR(20) PRIMARY KEY NOT NULL,
senha VARCHAR(20) NOT NULL
)

CREATE TABLE cardapio(

 

)

 -- APAGAR TODOS AS TABELAS COM REFERENCIA AO USUARIO 

SELECT * FROM usuario
select * from aluno
drop table  aluno, instituicao

-- SELECT NO ALUNO, USUARIO E ETC PARA SABER OS DADOS DENTRO DO MESMO
Select * from aluno
select * from instituicao
select * from usuario

update aluno set turma = '6º ano B' where turma = 'B'  


-- COMO ALUNO PRECISA DE UMA CHAVE ESTRANGEIRA DE INSTITUICAO É PRECISO CADASTRÁ-LA PRIMEIRO, ANTES DE USAR DO ALUNO
Insert into instituicao Values (5, 'Sesi amoreiras', 32732828, 13031390, 'Parque italia', 403)

-- INSERINDO EM ALUNO COM O CNPJ IGUAL AO DO INSTITUICAO, NO CASO '5'
INSERT INTO aluno VALUES (7, 'Sim', 'B', 3333, 4, 5)

-- INSERT EM USUARIO, PRECISA SER FEITO ANTES DE ALUNO TBM
INSERT INTO usuario VALUES (4, '1234', 'Pedro', 'Feminino', 5, '13/12/2000', 9, 'Gu@gmail.com', 5, 'Campinas', 'Rua asneira', 6, 257)

INSERT INTO administrador VALUES ('1234','1234')




