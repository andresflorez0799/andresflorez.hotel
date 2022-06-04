
DROP TABLE IF EXISTS Reserva, HotelHabitacion, Hotel, Pais, Usuario
GO

CREATE TABLE Usuario
(
	Id INT IDENTITY(1,1) NOT NULL,
	UsuarioNombre VARCHAR(200) NOT NULL,
	UsuarioApellido  VARCHAR(200) NOT NULL,
	UsuarioEmail  VARCHAR(255) NOT NULL,
	UsuarioDireccion VARCHAR(500),
	CONSTRAINT PK_Usuario_Primary PRIMARY KEY(Id),
	CONSTRAINT UK_Usuario_UniqueEmail UNIQUE(UsuarioEmail)
)
GO
INSERT INTO Usuario(UsuarioNombre, UsuarioApellido, UsuarioEmail, UsuarioDireccion)VALUES
('Nombre Usuario1', 'Apellido Usuario1', 'Usuario1@correo.com', 'Direccion Usuario1'),
('Nombre Usuario2', 'Apellido Usuario2', 'Usuario2@correo.com', 'Direccion Usuario2'),
('Nombre Usuario3', 'Apellido Usuario3', 'Usuario3@correo.com', 'Direccion Usuario3')

CREATE TABLE Pais
(
	Id INT IDENTITY(1,1) NOT NULL,
	PaisNombre VARCHAR(30) NOT NULL,
	PaisEstado BIT NOT NULL DEFAULT(1),
	CONSTRAINT PK_Pais_Primary PRIMARY KEY(Id),
	CONSTRAINT UK_Pais_Unique UNIQUE(PaisNombre)
)
GO
INSERT INTO Pais(PaisNombre)VALUES
('Colombia');

CREATE TABLE Hotel
(
	Id INT IDENTITY(1,1) NOT NULL,
	IdPais INT NOT NULL,
	HotelNombre VARCHAR(200) NOT NULL,	
	HotelLatitud DECIMAL(9,6),
	HotelLongitud DECIMAL(9,6),
	HotelDescripcion VARCHAR(500),
	HotelActivo bit not null default(1),
	HotelNumeroHabitaciones INT NOT NULL DEFAULT(1),
	CONSTRAINT PK_Hotel_Primary PRIMARY KEY(Id),
	CONSTRAINT FK_Hotel_Pais_IdPais FOREIGN KEY (IdPais) REFERENCES Pais(Id),
)
GO
INSERT INTO Hotel(IdPais, HotelNombre, HotelLatitud, HotelLongitud, HotelDescripcion, HotelNumeroHabitaciones)VALUES
(1, 'Resort1', 4.6144912, -74.0721252, 'Hotel tequendama', 7),
(1, 'Resort2', 4.6209183, -74.0714922, 'Hotel City Expo', 4)

CREATE TABLE HotelHabitacion
(
	Id INT IDENTITY(1,1) NOT NULL,
	IdHotel INT NOT NULL,
	HotelHabitacionCodigo VARCHAR(15) NOT NULL,
	HotelHabitacionEstado BIT NOT NULL DEFAULT(1),
	CONSTRAINT PK_HotelHabitacion_Primary PRIMARY KEY(Id),
	CONSTRAINT FK_HotelHabitacion_Hotel_IdHotel FOREIGN KEY (IdHotel) REFERENCES Hotel(Id),
	CONSTRAINT UK_HotelHabitacion_UniqueHotel UNIQUE(IdHotel, HotelHabitacionCodigo)
)
GO
INSERT INTO HotelHabitacion(IdHotel, HotelHabitacionCodigo)VALUES
(1, '101'),(1, '102'),(1, '103'), (1, '201'), (1, '202'), (1, '203'), (1, '777'),
(2, '101'),(2, '102'),(2, '201'),(2, '202')

CREATE TABLE Reserva
(
	Id INT IDENTITY(1,1) NOT NULL,
	IdUsuario INT NOT NULL,
	IdHotel INT NOT NULL,
	IdHotelHabitacion INT,
	ReservaFechaEntrada datetime,
	ReservaFechaSalida datetime,
	ReservaFechaReserva datetime,
	ReservaEstado BIT NOT NULL DEFAULT(1),
	CONSTRAINT PK_Reserva_Primary PRIMARY KEY(Id),
	CONSTRAINT FK_Reserva_Usuario_IdUsuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id),
	CONSTRAINT FK_Reserva_Hotel_IdHotel FOREIGN KEY (IdHotel) REFERENCES Hotel(Id),
	CONSTRAINT FK_Reserva_HotelHaitacion_IdHotelHabitacion FOREIGN KEY (IdHotelHabitacion) REFERENCES HotelHabitacion(Id),
)
GO