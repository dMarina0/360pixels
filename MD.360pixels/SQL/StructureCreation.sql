USE [pixelsDB]

CREATE TABLE [Photos](
[PhotoID] uniqueidentifier NOT NULL,
[Photo] nvarchar(100) NOT NULL,
[Likes] int ,
[Location] nvarchar(100) ,
[Comments] nvarchar(200) 
CONSTRAINT [PK_Photos] PRIMARY KEY ([PhotoID]));
GO

CREATE TABLE [UserProfile](
[UserID] uniqueidentifier NOT NULL,
[UserName] nvarchar(100) NOT NULL,
[FirstName] nvarchar(50) NOT NULL,
[LastName] nvarchar(50) NOT NULL,
[Camera] nvarchar(30),
[BirthDay] DATE ,
[Country] nvarchar(100) ,
[Website] nvarchar(50) ,
CONSTRAINT [PK_UserProfile] PRIMARY KEY([UserID]));
GO
 

CREATE TABLE [Categories](
[CategoryID] uniqueidentifier NOT NULL,
[CategoryName] nvarchar(50) NOT NULL
CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID]));
GO

CREATE TABLE [Challenges](
[ChallengeID] uniqueidentifier NOT NULL,
[ChallengeName] nvarchar(100) NOT NULL,
[Description] nvarchar(100) ,
CONSTRAINT [PK_Challenges] PRIMARY KEY ([ChallengeID]));

GO

UPDATE Challenges
SET Description ='https://www.w3schools.com/w3css/img_mountains.jpg'
WHERE ChallengeID ='34AA90BA-DF2E-457E-810D-D87F58EB13D0';
SELECT * FROM Challenges

CREATE TABLE [UserChallenges](
[UserID] uniqueidentifier NOT NULL,
[ChallengeID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_UserChallenges] PRIMARY KEY([UserID],[ChallengeID]),
CONSTRAINT [FK_UserChallenges_UserProfile] FOREIGN KEY ([UserID])
		REFERENCES [UserProfile] ([UserID]),
CONSTRAINT [FK_UserChallenges_Challenges] FOREIGN KEY ([ChallengeID])
		REFERENCES [Challenges] ([ChallengeID]));

GO

CREATE TABLE [Blog](
[BlogID] uniqueidentifier NOT NULL,
[Title] nvarchar(100) NOT NULL,
[Author] nvarchar(100) NOT NULL,
[Content] nvarchar(300) NOT NULL,
[Date] DATE NOT NULL,
[Type] nvarchar(50) NOT NULL,
CONSTRAINT [PK_Blog] PRIMARY KEY ([BlogID]));

GO

CREATE TABLE [BlogPhotos](
[BlogID] uniqueidentifier NOT NULL,
[PhotoID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_BlogPhotos] PRIMARY KEY ([BlogID],[PhotoID]),
CONSTRAINT [FK_BlogPhotos_Blog] FOREIGN KEY ([BlogID])
		REFERENCES [Blog]([BlogID]),
CONSTRAINT [FK_BlogPhotos_Photos] FOREIGN KEY ([PhotoID])
		REFERENCES [Photos]([PhotoID]));

GO

CREATE TABLE [CategoriesPhotos](
[CategoryID] uniqueidentifier NOT NULL,
[PhotoID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_CategoriesPhotos] PRIMARY KEY ([CategoryID],[PhotoID]),
CONSTRAINT [FK_CategoriesPhotos_Categories] FOREIGN KEY ([CategoryID])
		REFERENCES [Categories]([CategoryID]),
CONSTRAINT [FK_CategoriesPhotos_Photos] FOREIGN KEY ([PhotoID])
		REFERENCES [Photos]([PhotoID]));

GO

CREATE TABLE [ChallengesPhotos](
[ChallengeID] uniqueidentifier NOT NULL,
[PhotoID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_ChallengesPhotos] PRIMARY KEY ([ChallengeID],[PhotoID]),
CONSTRAINT [FK_ChallengesPhotos_Challenges] FOREIGN KEY ([ChallengeID])
		REFERENCES [Challenges]([ChallengeID]),
CONSTRAINT [FK_ChallengesPhotos_Photos] FOREIGN KEY ([PhotoID])
		REFERENCES [Photos]([PhotoID]));

GO

CREATE TABLE [UserProfilePhotos](
[UserID] uniqueidentifier NOT NULL,
[PhotoID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_UserProfilePhotos] PRIMARY KEY ([UserID],[PhotoID]),
CONSTRAINT [FK_UserProfilePhotos_UserProfile] FOREIGN KEY ([UserID])
		REFERENCES [UserProfile]([UserID]),
CONSTRAINT [FK_UserProfilePhotos_Photos] FOREIGN KEY ([PhotoID])
		REFERENCES [Photos]([PhotoID]));

GO


CREATE PROCEDURE [dbo].[UserProfile_Update]
(
	@UserID uniqueidentifier ,
	@UserName nvarchar(50) ,
	@FirstName nvarchar(50) ,
	@LastName nvarchar(50) ,
	@Camera nvarchar(30),
	@BirthDay DATE ,
	@Country nvarchar(100) ,
	@Website nvarchar(50) 
)
AS
	BEGIN
	UPDATE UserProfile
	SET UserName=@UserName,
		FirstName=@FirstName,
		LastName=@LastName,
		Camera=@Camera,
		BirthDay=@BirthDay,
		Country =@Country,
		Website=@Website
	 WHERE UserID=@UserID
 
END 
GO

CREATE PROCEDURE [dbo].[UserProfile_Delete]
(
	@UserID uniqueidentifier 
	
)
AS
BEGIN
	
	DELETE 
	FROM UserProfilePhotos
	WHERE UserID=@UserID

	DELETE 
	FROM UserChallenges
	WHERE UserID=@UserID

	DELETE 
	FROM UserProfile 
	WHERE UserID=@UserID
	
 
END 
GO

CREATE PROCEDURE [dbo].[UserProfile_Create]
(
	@UserID uniqueidentifier ,
	@UserName nvarchar(50),
	@FirstName nvarchar(50) ,
	@LastName nvarchar(50) ,
	@Camera nvarchar(30),
	@BirthDay DATE ,
	@Country nvarchar(100) ,
	@Website nvarchar(50)
)
AS

	
	INSERT INTO UserProfile VALUES(@UserID , @UserName,@FirstName,@LastName,@Camera,@BirthDay,@Country,@Website);

GO

CREATE PROCEDURE [dbo].[UserProfile_ReadAll]

AS
BEGIN
	SELECT s.UserID,
			s.UserName,
			s.FirstName,
			s.LastName,
			s.Camera,
			s.BirthDay,
			s.Country,
			s.Website
	FROM UserProfile s	
	
END
GO

CREATE PROCEDURE [dbo].[UserProfie_ReadById]
(
	@UserID uniqueidentifier
)
AS
BEGIN
		SELECT	s.UserID,
				s.UserName,
			s.FirstName,
			s.LastName,
			s.Camera,
			s.BirthDay,
			s.Country,
			s.Website
	FROM UserProfile s
	WHERE s.UserID = @UserID
	
	
END
GO

CREATE PROCEDURE [dbo].[Blog_Update]
(
	@BlogID uniqueidentifier,	
	@Title nvarchar(100) ,
	@Author nvarchar(100) ,
	@Content nvarchar(300) ,
	@Date Date ,
	@Type nvarchar(50) 
)
AS
	BEGIN
	UPDATE Blog
	SET Title =@Title,
		Author=@Author,
		Content=@Content,
		Date=@Date,
		Type=@Type
	WHERE BlogID=@BlogID
 
END 
GO



CREATE PROCEDURE [dbo].[Blog_Delete]
(
	@BlogID uniqueidentifier
)
AS
	BEGIN

	DELETE 
	FROM BlogPhotos
	WHERE BlogID=@BlogID
	
	DELETE 
	FROM Blog
	WHERE BlogID=@BlogID
 
END 
GO

CREATE PROCEDURE [dbo].[Blog_Create]
(
	@BlogID uniqueidentifier,	
	@Title nvarchar(100) ,
	@Author nvarchar(100) ,
	@Content nvarchar(300) ,
	@Date Date ,
	@Type nvarchar(50) 

)
AS 
BEGIN 

	INSERT INTO Blog VALUES(@BlogID, @Title, @Author, @Content, @Date, @Type);

END
GO

CREATE PROCEDURE [dbo].[Blog_ReadById]
(
	@BlogID uniqueidentifier
)
AS
BEGIN
	SELECT 	s.BlogID,	
			s.Title,
			s.Author,
			s.Content,
			s.Date,
			s.Type
	FROM Blog s
	WHERE s.BlogID = @BlogID
	
	
END
GO

CREATE PROCEDURE [dbo].[Blog_ReadAll]

AS
BEGIN
	SELECT  s.BlogID,
			s.Title,
			s.Author,
			s.Content,
			s.Date,
			s.Type
	FROM Blog s
	
END
GO

CREATE PROCEDURE [dbo].[Challenges_Update]
(
	@ChallengeID uniqueidentifier ,
	@ChallengeName nvarchar(100),
	@Description nvarchar(100)
)
AS
	BEGIN
	UPDATE Challenges
	SET ChallengeName=@ChallengeName,
		Description = @Description
	 WHERE ChallengeID=@ChallengeID
 
END 
GO



CREATE PROCEDURE [dbo].[Challenges_Delete]
(
	@ChallengeID uniqueidentifier
)
AS
	BEGIN
	DELETE 
	FROM ChallengesPhotos
	WHERE ChallengeID=@ChallengeID

	DELETE 
	FROM UserChallenges
	WHERE ChallengeID=@ChallengeID

	DELETE
	FROM Challenges
	WHERE ChallengeID=@ChallengeID

 
END 
GO


CREATE PROCEDURE [dbo].[Challenges_Create]
(
	@ChallengeID uniqueidentifier ,
	@ChallengeName nvarchar(100),
	@Description nvarchar(100)
)
AS
BEGIN 
	INSERT INTO Challenges VALUES(@ChallengeID ,@ChallengeName ,@Description);

END
GO

CREATE PROCEDURE [dbo].[Challenges_ReadById]
(
	@ChallengeID uniqueidentifier
)
AS
BEGIN
	SELECT s.ChallengeID,
			s.ChallengeName,
			s.Description
	FROM Challenges s
	WHERE s.ChallengeID = @ChallengeID
	
	
END
GO

CREATE PROCEDURE [dbo].[Challenges_ReadAll]

AS
BEGIN
	SELECT s.ChallengeID,
			s.ChallengeName,
			s.Description
	FROM Challenges s
	
END
GO


CREATE PROCEDURE [dbo].[Categories_Update]
(
	@CategoryID uniqueidentifier,
	@CategoryName nvarchar(100)
)
AS
	BEGIN
	UPDATE Categories
	SET CategoryName=@CategoryName
	 WHERE CategoryID=@CategoryID
 
END 
GO




CREATE PROCEDURE [dbo].[Categories_Delete]
(
	@CategoryID uniqueidentifier
)
AS
	BEGIN

	DELETE 
	FROM CategoriesPhotos
	WHERE CategoryID=@CategoryID

	DELETE 
	FROM Categories
	WHERE CategoryID=@CategoryID
 
END 
GO


CREATE PROCEDURE [dbo].[Categories_Create]
(
	@CategoryID uniqueidentifier,
	@CategoryName nvarchar(100)
)
AS
BEGIN 
		INSERT INTO Categories VALUES(@CategoryID , @CategoryName);

END
GO



CREATE PROCEDURE [dbo].[Categories_ReadById]
(
	@CategoryID uniqueidentifier
)
AS
BEGIN
	SELECT	s.CategoryID,
			s.CategoryName
	FROM Categories s
	WHERE s.CategoryID = @CategoryID
	
	
END
GO


CREATE PROCEDURE [dbo].[Categories_ReadAll]

AS
BEGIN
	SELECT s.CategoryID,
			s.CategoryName
	FROM Categories s
	
END
GO

CREATE PROCEDURE [dbo].[Photos_Create]
(
	@PhotoID uniqueidentifier ,
	@Photo nvarchar(100) ,
	@Likes int ,
	@Comments nvarchar(200),
	@Location nvarchar(100) 
)
AS
BEGIN
	INSERT INTO Photos VALUES(@PhotoID, @Photo , @Likes , @Comments ,@Location);

END
GO



CREATE PROCEDURE [dbo].[Photos_Delete]
(
	@PhotoID uniqueidentifier
)
AS
	BEGIN
	DELETE 
	FROM BlogPhotos
	WHERE PhotoID=@PhotoID

	DELETE 
	FROM CategoriesPhotos
	WHERE PhotoID=@PhotoID

	DELETE 
	FROM ChallengesPhotos
	WHERE PhotoID=@PhotoID

	DELETE 
	FROM UserProfilePhotos
	WHERE PhotoID=@PhotoID

	DELETE
	FROM Photos
	WHERE PhotoID=@PhotoID
	
 
END 
GO

CREATE PROCEDURE [dbo].[Photos_Update]
(
	@PhotoID uniqueidentifier ,
	@Photo nvarchar(100) ,
	@Likes int ,
	@Comments nvarchar(200),
	@Location nvarchar(100)
)
AS 
BEGIN 

	UPDATE Photos
	SET Photo=@Photo,
		Likes=@Likes,
		Comments=@Comments,
		Location=@Location
	WHERE PhotoID=@PhotoID
	
END
GO


CREATE PROCEDURE [dbo].[Photos_ReadByID]
(
		@PhotoID uniqueidentifier
)
AS
BEGIN 
	SELECT s.PhotoID,
			s.Photo,
			s.Likes,
			s.Location,
			s.Comments 
	FROM Photos s
	WHERE PhotoID=@PhotoID
END
GO


CREATE PROCEDURE [dbo].[Photos_ReadAll]

AS
BEGIN
	SELECT s.PhotoID,
			s.Photo,
			s.Likes,
			s.Location,
			s.Comments
	FROM Photos s
	
END
GO





CREATE PROCEDURE [dbo].[UserChallenges_Create]
(
	@UserID uniqueidentifier,
	@ChallengeID uniqueidentifier
)
AS
BEGIN
	INSERT INTO UserChallenges VALUES(@UserID, @ChallengeID);

END
GO





CREATE PROCEDURE [dbo].[UserChallenges_Delete]
(
	@UserID uniqueidentifier,
	@ChallengeID uniqueidentifier
)
AS
	BEGIN
	DELETE 
	FROM UserChallenges
	WHERE UserID=@UserID  And ChallengeID=@ChallengeID
	
 
END 
GO
CREATE PROCEDURE [dbo].[UserChallenges_ReadAll]

AS
BEGIN
	SELECT s.ChallengeID,
			s.UserID		
	FROM UserChallenges s	
	
END
GO




CREATE PROCEDURE [dbo].[BlogPhotos_Create]
(
	@BlogID uniqueidentifier,
	@PhotoID uniqueidentifier
)
AS
BEGIN
	INSERT INTO BlogPhotos VALUES(@BlogID, @PhotoID);

END
GO

CREATE PROCEDURE [dbo].[BlogPhotos_Delete]
(
	@BlogID uniqueidentifier,
	@PhotoID uniqueidentifier
)
AS
	BEGIN
	DELETE 
	FROM BlogPhotos
	WHERE BlogID=@BlogID  And PhotoID=@PhotoID
	
 
END 
GO
CREATE PROCEDURE [dbo].[BlogPhotos_ReadAll]

AS
BEGIN
	SELECT s.BlogID,
			s.PhotoID		
	FROM BlogPhotos s	
	
END
GO
	



CREATE PROCEDURE [dbo].[CategoriesPhotos_Create]
(
	@CategoryID uniqueidentifier,
	@PhotoID uniqueidentifier
)
AS
BEGIN
	INSERT INTO CategoriesPhotos VALUES(@CategoryID, @PhotoID);

END
GO

CREATE PROCEDURE [dbo].[CategoriesPhotos_Delete]
(
	@CategoryID uniqueidentifier,
	@PhotoID uniqueidentifier
)
AS
	BEGIN
	DELETE 
	FROM CategoriesPhotos
	WHERE CategoryID=@CategoryID  And PhotoID=@PhotoID
	
 
END 
GO
CREATE PROCEDURE [dbo].[CategoriesPhotos_ReadAll]

AS
BEGIN
	SELECT s.CategoryID,
			s.PhotoID		
	FROM CategoriesPhotos s	
	
END
GO





CREATE PROCEDURE [dbo].[ChallengesPhotos_Create]
(
	@ChallengeID uniqueidentifier,
	@PhotoID uniqueidentifier
)
AS
BEGIN
	INSERT INTO ChallengesPhotos VALUES(@ChallengeID, @PhotoID);

END
GO

CREATE PROCEDURE [dbo].[ChallengesPhotos_Delete]
(
	@ChallengeID uniqueidentifier,
	@PhotoID uniqueidentifier
)
AS
	BEGIN
	DELETE 
	FROM ChallengesPhotos
	WHERE ChallengeID=@ChallengeID  And PhotoID=@PhotoID
	
 
END 
GO
CREATE PROCEDURE [dbo].[ChallengesPhotos_ReadAll]

AS
BEGIN
	SELECT s.ChallengeID,
			s.PhotoID		
	FROM ChallengesPhotos s	
	
END
GO




CREATE PROCEDURE [dbo].[UserProfilePhotos_Create]
(
	@UserID uniqueidentifier,
	@PhotoID uniqueidentifier
)
AS
BEGIN
	INSERT INTO UserProfilePhotos VALUES(@UserID, @PhotoID);

END
GO

CREATE PROCEDURE [dbo].[UserProfilePhotos_Delete]
(
	@UserID uniqueidentifier,
	@PhotoID uniqueidentifier 
)
AS
	BEGIN
	DELETE 
	FROM UserProfilePhotos
	WHERE UserID=@UserID  And PhotoID=@PhotoID
	
 
END 
GO
CREATE PROCEDURE [dbo].[UserProfilePhotos_ReadAll]

AS
BEGIN
	SELECT s.UserID,
			s.PhotoID		
	FROM UserProfilePhotos s	
	
END
GO