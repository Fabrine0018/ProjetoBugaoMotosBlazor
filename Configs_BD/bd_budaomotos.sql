create database bd_bugaomotos_ofici;
use bd_bugaomotos_ofici;


create table cliente(
id_cli int primary key auto_increment,
nome_cli varchar (300),
telefone_cli varchar (200),
estado_cli varchar (100),
cpf_cli varchar (100),
cidade_cli varchar (100),
complemento_cli text,
bairro_cli varchar (100),
rua_cli varchar (100)
);
create table fornecedor(
id_for int primary key auto_increment,
nome_empre_for varchar (300),
nome_funcio_for  varchar (300),
telefone_for varchar (200),
complemento_for  text,
cnpj_for varchar (200),
rua_for varchar (100),
estado_for varchar (100),
cidade_for varchar (100),
bairro_for varchar (100)
);

create table produto(
id_pro int primary key auto_increment,
nome_pro varchar (300),
codigo_pro varchar (300),
quantidade_pro int,
valor_pro int
);

create table servico(
id_ser int primary key auto_increment,
nome_ser varchar (300),
codigo_ser varchar (300),
prestador_ser varchar (300),
valor_ser double
);

create table Venda(
id_ven int primary key auto_increment,
data_ven varchar (300),
valor_total_ven varchar (300)
);

create table caixa (
id_cai int primary key auto_increment not null,
data_cai date,
hora_aberto_cai time,
funcionario_cai varchar(300),
hora_fechado_cai time,
saldo_aberto_cai float,
saldo_fechado_cai float
);