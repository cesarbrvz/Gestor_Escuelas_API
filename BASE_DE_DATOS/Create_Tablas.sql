-- Crear base de datos
CREATE DATABASE GestorEscuelasMusicaDb;
GO

-- Usarla para crear las tablas ahí
USE GestorEscuelasMusicaDb;
GO

-- Tabla: EscuelasDeMusica
CREATE TABLE EscuelasDeMusica (
    IdEscuela INT PRIMARY KEY IDENTITY(1,1),
    CodigoEscuela NCHAR(10) NOT NULL UNIQUE,
    NombreEscuela NVARCHAR(100),
    DescripcionEscuela NVARCHAR(255)
);

-- Tabla: Profesores
CREATE TABLE Profesores (
    IdProfesor INT PRIMARY KEY IDENTITY(1,1),
    NombreProfesor NVARCHAR(100),
    ApellidoProfesor NVARCHAR(100),
    IdentificacionProfesor NCHAR(10) NOT NULL UNIQUE,
    EscuelaId INT NOT NULL,
    FOREIGN KEY (EscuelaId) REFERENCES EscuelasDeMusica(IdEscuela)
);

-- Tabla: Alumnos
CREATE TABLE Alumnos (
    IdAlumno INT PRIMARY KEY IDENTITY(1,1),
    NombreAlumno NVARCHAR(100),
    ApellidoAlumno NVARCHAR(100),
    FechaNac DATE,
    IdentificacionAlumno NCHAR(10) NOT NULL UNIQUE,
    EscuelaId INT NOT NULL,
    FOREIGN KEY (EscuelaId) REFERENCES EscuelasDeMusica(IdEscuela)
);

-- Tabla intermedia: AlumnoProfesor
CREATE TABLE AlumnoProfesor (
    IdAlumno INT NOT NULL,
    IdProfesor INT NOT NULL,
    PRIMARY KEY (IdAlumno, IdProfesor),
    FOREIGN KEY (IdAlumno) REFERENCES Alumnos(IdAlumno),
    FOREIGN KEY (IdProfesor) REFERENCES Profesores(IdProfesor)
);
