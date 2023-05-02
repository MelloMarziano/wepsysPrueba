USE DBMATRICULAS
GO

IF EXISTS (SELECT * FROM sys.objects WHERE [type]='p' AND name = 'stp_findByMatricula')
DROP PROCEDURE stp_findByMatricula
GO

CREATE PROCEDURE stp_findByMatricula(
    @matricula VARCHAR(10)
)
AS
BEGIN

SELECT * FROM [DBMATRICULAS].[dbo].[PERSONA] WHERE Matricula = @matricula

END