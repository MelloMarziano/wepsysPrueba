USE DBMATRICULAS
GO

IF EXISTS (SELECT * FROM sys.objects WHERE [type]='p' AND name = 'stp_insert')
DROP PROCEDURE stp_insert
GO

CREATE PROCEDURE stp_insert(
    @nombres VARCHAR(100),
    @apellidos VARCHAR(100),
    @matricula VARCHAR(10),
    @fechaNAcimiento DATETIME,
    @ubicacionLatitud DECIMAL(18,6),
    @ubicacionLongitud DECIMAL(18,6),
    @ubicacionAltitud DECIMAL(18,6)
)

AS
BEGIN

INSERT INTO [DBMATRICULAS].[dbo].[PERSONA] (Nombres, Apellidos, Matricula, FechaNacimiento, UbicacionLatitud, UbicacionLongitud, UbicacionAltitud)
VALUES
(
    @nombres,
    @apellidos,
    @matricula,
    @fechaNAcimiento,
    @ubicacionLatitud,
    @ubicacionLongitud,
    @ubicacionAltitud
)

END