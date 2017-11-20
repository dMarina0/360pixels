USE [360pixelsDB]


--UPDATE SP--
CREATE PROCEDURE [dbo].[360pixelsDB_UpdateUserProfile]
(
	@UserID uniqueidentifier
)
AS
	BEGIN
	UPDATE UserProfile
	SET UserName='updateUserName'
	 WHERE UserID=@UserID
 
END 
GO

DECLARE @UserID uniqueidentifier = 'FE1B7EFD-571A-DEAA-4513-DB413054A827';
EXECUTE [dbo].[360pixelsDB_UpdateUserProfile] @UserID

CREATE PROCEDURE [dbo].[360pixelsDB_UpdateBlog]
(
	@BlogID uniqueidentifier
)
AS
	BEGIN
	UPDATE Blog
	SET Autor='updateBLOG'
	 WHERE BlogID=@BlogID
 
END 
GO

DECLARE @BlogID uniqueidentifier = 'be42e930-ee29-484e-3a1a-9d8b184c0400';
EXECUTE [dbo].[360pixelsDB_UpdateBlog] @BlogID


CREATE PROCEDURE [dbo].[360pixelsDB_Challenges]
(
	@ChallengeID uniqueidentifier
)
AS
	BEGIN
	UPDATE Challenges
	SET ChallengeName='updateChallenge'
	 WHERE ChallengeID=@ChallengeID
 
END 
GO

DECLARE @ChallengeID uniqueidentifier = '34aa90ba-df2e-457e-810d-d87f58eb13d0';
EXECUTE [dbo].[360pixelsDB_Challenges] @ChallengeID


CREATE PROCEDURE [dbo].[360pixelsDB_Categories]
(
	@CategoryID uniqueidentifier
)
AS
	BEGIN
	UPDATE Categories
	SET CategoryName='updateCategoryName'
	 WHERE CategoryID=@CategoryID
 
END 
GO

DECLARE @CategoryID uniqueidentifier = '9A18C663-B8AC-4781-7478-45FD04AD5166';
EXECUTE [dbo].[360pixelsDB_Categories] @CategoryID

CREATE PROCEDURE [dbo].[360pixelsDB_UpdateAboutUser]
(
	@AboutUserID uniqueidentifier
)
AS
	BEGIN
	UPDATE AboutUser
	SET FirstName='updateFirstName'
	 WHERE AboutUserID=@AboutUserID
 
END 
GO

DECLARE @AboutUserID uniqueidentifier = 'fa14d418-0ba8-48f5-847d-837228350ec7';
EXECUTE [dbo].[360pixelsDB_UpdateAboutUser] @AboutUserID



--DELETE SP--



CREATE PROCEDURE [dbo].[360pixelsDB_DeleteBlog]
(
	@BlogID uniqueidentifier
)
AS
	BEGIN
	DELETE b
	FROM Blog b
	INNER JOIN BlogPhotos p ON b.BlogID=p.BlogID

	WHERE b.blogID=@BlogID
 
END 
GO

DECLARE @BlogID uniqueidentifier = 'a7695725-7701-47ee-a4f6-f49b9bab8d33';
EXECUTE [dbo].[360pixelsDB_DeleteBlog] @BlogID

CREATE PROCEDURE [dbo].[360pixelsDB_DeleteCategories]
(
	@CategoryID uniqueidentifier
)
AS
	BEGIN
	DELETE FROM Categories
	WHERE CategoryID=@CategoryID
 
END 
GO

DECLARE @CategoryID uniqueidentifier = '8738C663-B8AC-4781-7478-45FD04AD5166';
EXECUTE [dbo].[360pixelsDB_DeleteCategories] @CategoryID


CREATE PROCEDURE [dbo].[360pixelsDB_DeleteCategories]
(
	@CategoryID uniqueidentifier
)
AS
	BEGIN
	DELETE c
	FROM Categories c
		INNER JOIN CategoriesPhotos p ON c.CategoryID= p.CategoryID
	WHERE c.CategoryID=@CategoryID
	
 
END 
GO

DECLARE @CategoryID uniqueidentifier = '8738C663-B8AC-4781-7478-45FD04AD5166';
EXECUTE [dbo].[360pixelsDB_DeleteCategories] @CategoryID

CREATE PROCEDURE [dbo].[360pixelsDB_DeleteChallenge]
(
	@ChallengeID uniqueidentifier
)
AS
	BEGIN
	DELETE FROM Challenges
	--WHERE ChallengeID=@ChallengeID
	USING Challenges
	  INNER JOIN ChallengesPhotos ON Challenges.ChallengeID= ChallengesPhotos.ChallengeID
	WHERE ChallengeID=@ChallengeID

 
END 
GO

DECLARE @ChallengeID uniqueidentifier = 'd5f840f0-6677-40cf-8160-238c3e028383';
EXECUTE [dbo].[360pixelsDB_DeleteChallenge] @ChallengeID


CREATE PROCEDURE [dbo].[360pixelsDB_DeletePhotos]
(
	@PhotoID uniqueidentifier
)
AS
	BEGIN
	DELETE FROM Photos
	WHERE PhotoID=@PhotoID
	
 
END 
GO

DECLARE @PhotoID uniqueidentifier = '3da9940d-6756-4395-96a6-04c9a537d8b9'
EXECUTE [dbo].[360pixelsDB_DeletePhotos] @PhotoID


CREATE PROCEDURE [dbo].[360pixelsDB_DeleteUser]
(
	@UserID uniqueidentifier
)
AS
	BEGIN
	DELETE s
	FROM UserProfile s
		INNER JOIN UserChallenges c ON s.UserID= c.UserID
	WHERE s.UserID=@UserID
	
 
END 
GO

DECLARE @UserID uniqueidentifier = 'DD117EFD-571A-DEAA-4513-DB413054A827'
EXECUTE [dbo].[360pixelsDB_DeleteUser] @UserID



					--READ BY ID SP--

--get user by id--
CREATE PROCEDURE [dbo].[360pixelsDB_UserProfileReadById]
(
	@UserID uniqueidentifier
)
AS
BEGIN
	SELECT s.UserName
	FROM UserProfile s
		LEFT JOIN AboutUser e ON s.UserID=e.UserID
		
	WHERE s.UserID = @UserID
	GROUP BY s.UserName
	
END
GO

DECLARE @UserID uniqueidentifier = '77117EFD-5713-DEAA-1995-DB413054A833'
EXECUTE [dbo].[360pixelsDB_UserProfileReadById ] @UserID

--get location for photos from a blog--
CREATE PROCEDURE [dbo].[360pixelsDB_BlogReadById]
(
	@BlogID uniqueidentifier
)
AS
BEGIN
	SELECT p.Location
	FROM Blog s
		INNER JOIN BlogPhotos e ON s.BlogID=e.BlogID
		INNER JOIN Photos p ON e.PhotoID=P.PhotoID
	WHERE s.BlogID = @BlogID
	GROUP BY p.Location
	
END
GO

DECLARE @BlogID uniqueidentifier = '2c41f622-77eb-4100-aaeb-73697122c091'
EXECUTE [dbo].[360pixelsDB_BlogReadById ] @BlogID

--get number of photos from a category(ActionCategory)--
CREATE PROCEDURE [dbo].[360pixelsDB_CategoriesReadById]
(
	@CategoryID uniqueidentifier
)
AS
BEGIN
	SELECT s.CategoryName, COUNT(e.PhotoID)
	FROM Categories s
		INNER JOIN CategoriesPhotos e ON s.CategoryID=e.CategoryID
		INNER JOIN Photos p ON e.PhotoID=P.PhotoID
	WHERE s.CategoryID = @CategoryID
	GROUP BY s.CategoryName
	
END
GO

DECLARE @CategoryID uniqueidentifier = 'ABBBFE06-A8BE-A97D-F2DD-5164F385C21C'
EXECUTE [dbo].[360pixelsDB_CategoriesReadById ] @CategoryID


--get challenge,photos from challenge and no. of likes--
CREATE PROCEDURE [dbo].[360pixelsDB_ChallengesReadById]
(
	@ChallengeID uniqueidentifier
)
AS
BEGIN
	SELECT s.ChallengeName, p.Likes , p.Photo
	FROM Challenges s
		INNER JOIN ChallengesPhotos e ON s.ChallengeID=e.ChallengeID
		INNER JOIN Photos p ON e.PhotoID=p.PhotoID
	WHERE s.ChallengeID = @ChallengeID
	GROUP BY s.ChallengeName , p.Likes , p.Photo
	
END
GO

DECLARE @ChallengeID uniqueidentifier = '2ca80ebc-66f2-4d4e-b5f5-c12fc73093fc'
EXECUTE [dbo].[360pixelsDB_ChallengesReadById ] @ChallengeID

--get location of a user--
CREATE PROCEDURE [dbo].[360pixelsDB_AboutUserReadById]
(
	@AbouUserID uniqueidentifier
)
AS
BEGIN
	SELECT s.Country 
	FROM AboutUser s
		RIGHT JOIN UserProfile e ON s.UserID=e.UserID
		
	WHERE s.AboutUserID = @AbouUserID
	GROUP BY s.Country
	
END
GO

DECLARE @AboutUserID uniqueidentifier = 'fa14d418-0ba8-48f5-847d-837228350ec7'
EXECUTE [dbo].[360pixelsDB_AboutUserReadById ] @AboutUserID



		--		VIEWS  --


--GET challenge name and users from a challenge--
CREATE VIEW [dbo].[360pixels_UserChallenges]
AS
SELECT p.UserName , ch.ChallengeName
FROM UserProfile p
    INNER JOIN UserChallenges c ON p.UserID= c.UserID
	INNER JOIN Challenges ch ON ch.ChallengeID=c.ChallengeID

GO

--Get number photos for user MARC--
CREATE VIEW [dbo].[GetNoPhotosView]
AS
SELECT COUNT(ph.PhotoID) as NoPhotos, p.UserName
FROM UserProfile p
	LEFT JOIN UserProfilePhotos ph ON p.UserID=ph.UserID
	WHERE p.UserName ='MARC'
	GROUP BY p.UserName

GO

SELECT * FROM [dbo].[GetNoPhotosView]

CREATE VIEW [dbo].[GetArticleDetailView]
AS
SELECT b.Content , b.Autor ,b.Title
 FROM Blog b
	WHERE b.Title LIKE 't%'
GO
SELECT * FROM [dbo].[GetArticleDetailView]

				--CREATE SP--


CREATE PROCEDURE [dbo].[360pixels_CreateUserProfile]
AS

	--IF object_id('dbo.UserProfile') IS NOT NULL
         --DROP TABLE UserProfile
	CREATE TABLE UserProfile(UserID uniqueidentifier NOT NULL, UserName nvarchar(50));

GO

EXEC [dbo].[360pixels_CreateUserProfile]


	

CREATE PROCEDURE [dbo].[360pixels_CreateAboutUser]
AS

CREATE TABLE [AboutUser](
	[AboutUserID] uniqueidentifier NOT NULL,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar(50) NOT NULL,
	[Camera] nvarchar(20) NOT NULL,
	[BirthDay] DATE NOT NULL,
	[Country] nvarchar(100) NOT NULL,
	[Website] nvarchar(50) NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_AboutUser] PRIMARY KEY ([AboutUserID]),
CONSTRAINT [FK_AboutUser_UserProfile] FOREIGN KEY ([UserID])
	REFERENCES [UserProfile] ([UserID]));

GO

CREATE PROCEDURE [dbo].[360pixels_CreateCategories]
AS

	CREATE TABLE [Categories](
	[CategoryID] uniqueidentifier NOT NULL,
	[CategoryName] nvarchar(50) NOT NULL
CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID]));

GO



CREATE PROCEDURE [dbo].[360pixels_CreateChallenges]
AS

CREATE TABLE [Challenges](
	[ChallengeID] uniqueidentifier NOT NULL,
	[ChallengeName] nvarchar(100) NOT NULL,
	[Description] nvarchar(100) ,
CONSTRAINT [PK_Challenges] PRIMARY KEY ([ChallengeID]));

GO

CREATE PROCEDURE [dbo].[360pixels_CreateBlog]
AS
CREATE TABLE [Blog](
	[BlogID] uniqueidentifier NOT NULL,
	[Title] nvarchar(100) NOT NULL,
	[Autor] nvarchar(100) NOT NULL,
	[Content] nvarchar(300) NOT NULL,
	[Date] DATE NOT NULL,
	[Type] nvarchar(50) NOT NULL,
CONSTRAINT [PK_Blog] PRIMARY KEY ([BlogID]));

GO

CREATE PROCEDURE [dbo].[360pixels_CreatePhotos]
AS
CREATE TABLE [Photos](
	[PhotoID] uniqueidentifier NOT NULL,
	[Photo] nvarchar(100) NOT NULL,
	[Comments] nvarchar(200) ,
	[Likes] int ,
	[Location] nvarchar(100) NOT NULL
CONSTRAINT [PK_Photos] PRIMARY KEY ([PhotoID]));

GO