create database bd_bugaomotos;
use bd_bugaomotos;


create table Cliente(
id_Clie int primary key auto_increment,
nome_clie varchar (300),
telefone_clie varchar (200),
estado_clie varchar (100),
cpf_clie varchar (100),
cidade_clie varchar (100),
complemento_clie varchar (100),
bairro_clie varchar (100),
rua_clie varchar (100),
cep_clie  varchar (200)
);
create table Fornecedor(
id_forne int primary key auto_increment,
nome_forne varchar (300),
nome_responsa_forne  varchar (300),
telefoner_respon_forne varchar (200),
telefoner_forne varchar (200),
numero_forne varchar (200),
complemento_forne  varchar (100),
cep_forne varchar (200),
cnpj_forne varchar (200),
rua_forne varchar (100),
estado_forne varchar (100),
cidade_forne varchar (100),
bairro_forne varchar (100),
razao_social_forne varchar (100)
);

create table Produto(
id_prod int primary key auto_increment,
nome_prod varchar (300),
codigo_prod varchar (300),
quantidade_prod int,
valor_prod int
);

create table Serviço(
id_ser int primary key auto_increment,
nome_ser varchar (300),
codigo_ser varchar (300),
prestador_ser varchar (300),
valor_ser int
);

create table Venda(
id_ven int primary key auto_increment,
nome_ser varchar (300),
codigo_ser varchar (300),
prestador_ser varchar (300),
valor_ser int
);

ALTER TABLE Produto
ADD id_forne_fk INT;

ALTER TABLE Produto
ADD Foreign key id_forne_fk references Fornecedor (id_for);

---- Inserindo fornecedores
--INSERT INTO

--  fornecedor (nome_forne)
--VALUES
--  ('Fornecedor Alpha'),
--  ('Fornecedor Beta'),
--  ('Fornecedor Gamma'),
--  ('Fornecedor Delta');

---- Inserindo produtos vinculados aos fornecedores
--INSERT INTO
--  produto (
--id_forne_fk,
--nome_prod,
--codigo_prod,
--quantidade_prod,
--valor_prod
-- )
-- VALUES
--  (1, 'Notebook X', 'Notebook de alto desempenho com 16GB RAM e SSD 512GB', 10, 4500.00),
--  (1, 'Mouse Óptico', 'Mouse com fio, 1200 DPI', 50, 45.90),
--  (2, 'Smartphone Y', 'Smartphone 6.5 polegadas, 128GB', 20, 2100.00),
--  (2, 'Carregador Rápido', 'Carregador USB-C 25W', 100, 89.90),
--  (3, 'Cadeira Gamer', 'Cadeira ergonômica ajustável', 15, 1250.00),
--  (3, 'Mesa de Escritório', 'Mesa em L com suporte para monitor', 8, 980.00),
--  (4, 'Monitor 27"', 'Monitor LED Full HD 27 polegadas', 12, 1150.00),
--  (4, 'Teclado Mecânico', 'Teclado RGB switch blue', 30, 350.00);