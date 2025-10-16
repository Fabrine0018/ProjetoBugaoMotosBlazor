﻿create database bd_bugaomotos_ofici;
use bd_bugaomotos_ofici;


create table Cliente(
id_cli int primary key auto_increment,
nome_cli varchar (300),
telefone_cli varchar (200),
estado_cli varchar (100),
cpf_cli varchar (100),
cidade_cli varchar (100),
complemento_cli varchar (100),
bairro_cli varchar (100),
rua_cli varchar (100)
);
create table Fornecedor(
id_for int primary key auto_increment,
nome_empre_for varchar (300),
nome_funcio_for  varchar (300),
telefone_for varchar (200),
complemento_for  varchar (100),
cnpj_for varchar (200),
rua_for varchar (100),
estado_for varchar (100),
cidade_for varchar (100),
bairro_for varchar (100)
);

create table Produto(
id_pro int primary key auto_increment,
nome_pro varchar (300),
codigo_pro varchar (300),
quantidade_pro int,
valor_pro int
);

create table Servico(
id_ser int primary key auto_increment,
nome_ser varchar (300),
codigo_ser varchar (300),
prestador_ser varchar (300),
valor_ser int
);







