CREATE PROCEDURE dbo.spMovie_GetAllMovies
AS
BEGIN 
	SET NOCOUNT ON;
	SELECT Id, Name, Description, ReleaseDate, LastScreeningDate, MovieType, MovieLenght, ImageString, BannerImageString 
	FROM Movie 
END

EXEC dbo.spMovie_GetAllMoviesToday 

GRANT EXECUTE to dbStoredProcedureOnlyAcces
