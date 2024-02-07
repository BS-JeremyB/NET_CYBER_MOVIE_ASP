/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


EXEC NewUser 'johndoe@mail.be', 'Test1234=', 'johnleboss', 'doe', 'john'
EXEC NewUser 'janedoe@mail.be', 'Test1234=', 'petitlapindesbois','doe','jane'


INSERT INTO [Movie] (PosterUrl, Title, Description, Release,Score)
VALUES ('https://fr.web.img3.acsta.net/c_310_420/pictures/14/08/21/14/09/379570.jpg', 'Le Grand Bleu', 'Plouf', '1988-05-11', 5)


INSERT INTO [Movie] (PosterUrl, Title, Description, Release,Score)
VALUES ('https://fr.web.img3.acsta.net/c_310_420/medias/nmedia/18/66/14/37/18957591.jpg', 'Les Goonies', 'Bouffi Bouffon', '1985-12-04', 5)


INSERT INTO [UserMovie] (UserId, MovieId)
VALUES(1,1)
INSERT INTO [UserMovie] (UserId, MovieId)
VALUES(2,2)