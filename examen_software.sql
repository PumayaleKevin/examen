CREATE DATABASE examen_software

USE examen_software;

CREATE TABLE tclientes (
    ID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Genero NVARCHAR(50)
);

CREATE TABLE tlibros (
    ID INT PRIMARY KEY IDENTITY,
    Titulo NVARCHAR(100),
    Tipo INT,
    Precio DECIMAL(5, 2)
);

CREATE TABLE tventas (
    ID INT PRIMARY KEY IDENTITY,
    ClienteID INT FOREIGN KEY REFERENCES tclientes(ID),
    LibroID INT FOREIGN KEY REFERENCES tlibros(ID),
    Cantidad INT,
    ImportBruto DECIMAL(5, 2),
    Descuento DECIMAL(5, 2),
    ImporteNeto AS (ImportBruto - Descuento)
);

CREATE TABLE Tdescuentos (
    CantidadMinima INT,
    CantidadMaxima INT,
    TipoLibro INT,
    PorcentajeDescuento DECIMAL(5, 2)
);
