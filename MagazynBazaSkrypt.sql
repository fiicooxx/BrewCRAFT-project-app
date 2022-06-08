CREATE DATABASE Magazyn

USE Magazyn

CREATE TABLE [dbo].[DaneLogowania](
    [ID] [int] PRIMARY KEY IDENTITY,
    [Login] [nvarchar] (50) NOT NULL,
    [Haslo] [nvarchar] (50) NOT NULL)

CREATE TABLE [dbo].[StanMagazynu](
	[ID] [int] PRIMARY KEY IDENTITY,
	[Nazwa] [nvarchar] (50) NOT NULL,
	[Rodzaj] [nvarchar] (100) NOT NULL,
	[PuszkaButelka] [nvarchar] (20) NULL,
	[Ilosc] [int] NOT NULL)

CREATE TABLE [dbo].[Dostawcy](
	[ID] [int] PRIMARY KEY IDENTITY,
	[Nazwa] [nvarchar] (50) NOT NULL,
	[Miasto] [nvarchar] (250) NULL,
	[Telefon] [nvarchar] (20) NULL,
	[Email] [nvarchar] (250) NULL)

CREATE TABLE [dbo].[StatusDostawy](
    [ID] [int] PRIMARY KEY IDENTITY,
    [Nazwa] [nvarchar] (20))

CREATE TABLE [dbo].[Dostawy](
	[ID] [int] PRIMARY KEY IDENTITY,
	[PiwoID] [int] NOT NULL FOREIGN KEY REFERENCES StanMagazynu(ID),
	[DostawcaID] [int] NOT NULL FOREIGN KEY REFERENCES Dostawcy(ID),
	[DataZamowienia] [datetime] NOT NULL,
	[Ilosc] [int] NOT NULL,
	[StatusID] [int] NOT NULL FOREIGN KEY REFERENCES StatusDostawy(ID))

INSERT INTO DaneLogowania VALUES 
('login', 'haslo')

INSERT INTO StanMagazynu VALUES
('Atak Chmielu', 'American IPA', 'Puszka', 10),
('Pierwsza Pomoc', 'Polski PILS', 'Butelka', 15),
('Bawarka', 'Hefeweizen', 'Butelka', 20),
('Modern Drinking', 'West Coast IPA', 'Puszka', 25),
('Hazy Morning', 'American Pale IPA', 'Butelka', 30)

INSERT INTO Dostawcy VALUES
('FifiHurt', 'Zywiec', '665789763', 'fifihurt@gmail.com'),
('SeBrowar', 'Krakow', '786543123', 'sebrowar@gmail.com'),
('HurTom', 'Warszawa', '589654123', 'hurtom@gmail.com'),
('DobryBrowar', 'Mszana', '678901345', 'dobrybrowar@gmail.com'),
('Chmielski', 'Kraków', '578900112', 'chmielski@gmail.com')

INSERT INTO StatusDostawy VALUES
('Przyjeta'),
('Realizowana')

INSERT INTO Dostawy VALUES
(1, 1, '2022-06-05', 10, 1),
(2, 2, '2022-06-05', 15, 1),
(3, 3, '2022-06-05', 20, 1),
(4, 4, '2022-06-05', 25, 1),
(5, 5, '2022-06-05', 30, 1)



