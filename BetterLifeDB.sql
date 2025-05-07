create database BetterLifeDB;

CREATE LOGIN [IIS APPPOOL\WebBetterLife] FROM WINDOWS;

USE BetterLifeDB;

CREATE USER [IIS APPPOOL\WebBetterLife] FOR LOGIN [IIS APPPOOL\WebBetterLife];
EXEC sp_addrolemember N'db_owner', N'IIS APPPOOL\WebBetterLife';

create table Usuario(
id_Usuario int primary key identity,
Nombre_Usuario nvarchar(50) not null,
Apellidos_Usuario nvarchar(50) not null,
Edad_Usuario tinyint not null,
Genero_Usuario varchar(6) not null check(Genero_Usuario in ('Hombre','Mujer')),
Estatura char(5),
Peso_Usuario tinyint not null,
BrazoRelajado char(4),
BrazoContraido char(4),
Cintura char(5),
Pierna char(4)
);

create table Profesionales(
id_Profesional int primary key identity,
Nombre_Profesional nvarchar(50),
Apellido_Profesional nvarchar(50),
Genero_Profesional varchar not null check(Genero_Profesional in ('Hombre','Mujer')),
NivelEstudio nvarchar(30),
Titulo nvarchar(50),
TipoProfesional VARCHAR(20) CHECK (TipoProfesional IN ('Entrenador', 'Nutriologo', 'Medico')),
email nvarchar(60) not null,
email2 nvarchar(60),
telefono char(12),
telefono2 char(12)
);

create table Rutinas(
id_Rutina int primary key identity,
Rutina nvarchar(max) not null,
id_Usuario int,
id_Profesional int,
foreign key (id_Profesional) references Profesionales(id_Profesional),
foreign key (id_Usuario) references Usuario(id_Usuario)
);

insert into Usuario values ('Luis Manuel', 'Cardenas Ibarra', 20, 'Hombre','171cm',81,'30cm', '33cm','86cm','56cm');

insert into Usuario values ('Alejandro', 'Lezama Torres', 20, 'Hombre','177cm',85,'28cm', '36cm','80cm','55cm');

select * from Usuario where id_Usuario=2;

select id_Usuario, Nombre_Usuario, Apellidos_Usuario, Edad_Usuario, Genero_Usuario from Usuario;

select * from Rutinas;