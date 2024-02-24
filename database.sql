create database if not exists sistema;
use sistema;

create table if not exists usuario(
id int auto_increment primary key,
username varchar(32) unique not null, -- name to login
password varchar(64) not null, -- md5 enc
expiration DATETIME default null
);


create table if not exists licencas(
id int auto_increment primary key,
activation varchar(20) not null, -- make to generate random letters like: TEST1-TEST2-TEST3-TEST4
duration datetime not null -- duration of access on the system, like 1 day if i activate this code
);