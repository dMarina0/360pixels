USE [DBfor360pixels]

CREATE TABLE [UserProfile](
	[UserID] uniqueidentifier NOT NULL,
	[UserName] nvarchar(50) NOT NULL,
	[ProfilePhoto] nvarchar(100) NOT NULL,
	[CoverPhoto] nvarchar(100)  NOT NULL,
CONSTRAINT [PK_UserProfile] PRIMARY KEY ([UserID]));

CREATE TABLE [AboutUser](
	[AboutID] uniqueidentifier NOT NULL,
	[FirstName] nvarchar(50) NOT NULL,
	[LastName] nvarchar (50) NOT NULL,
	[Description] nvarchar (300) NOT NULL,
	[Location] nvarchar (100) NOT NULL,
	[CameraName] nvarchar (50) NOT NULL,
	[FacebookAccount] nvarchar(30) NOT NULL,
	[InstagramAccount] nvarchar(30) NOT NULL,
	[Website] nvarchar(30) NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	CONSTRAINT [PK_AboutUser] PRIMARY KEY ([AboutID]),
	CONSTRAINT [FK_About_UserProfile] FOREIGN KEY ([UserID])
    REFERENCES [UserProfile]([UserID]));

CREATE TABLE [PhotosFromProfile](
	[PhotosFromProfileID] uniqueidentifier NOT NULL,
	[Title] nvarchar(100) NOT NULL,
	[NumberLikes] int NOT NULL,
	[Location] nvarchar(100) NOT NULL,
	[Camera] nvarchar(50) NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	[Photo] nvarchar(50) NOT NULL,
	CONSTRAINT [PK_PhotosFromProfile] PRIMARY KEY ([PhotosFromProfileID]),
	CONSTRAINT [FK_PhotosFromProfile_UserProfile] FOREIGN KEY ([UserID])
    REFERENCES [UserProfile]([UserID]));

CREATE TABLE [Category](
	[CategoryID] uniqueidentifier NOT NULL,
	[Name] nvarchar(100) NOT NULL,
	CONSTRAINT [PK_Category] PRIMARY KEY ([CategoryID]));

CREATE TABLE [PhotosCategory](
	[PhotosCategoryID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	[Photo] nvarchar(100) NOT NULL,
	[CategoryID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_PhotosCategory] PRIMARY KEY ([PhotosCategoryID]),
CONSTRAINT [FK_PhotosCategory_Category] FOREIGN KEY ([CategoryID])
    REFERENCES [Category]([CategoryID]));

CREATE TABLE [LargeSizePhotoFromCategory](
	[LargeSizePhotoID] uniqueidentifier NOT NULL,
	[Title] nvarchar(100) NOT NULL,
	[Comments] nvarchar(500) NOT NULL,
	[Likes] int NOT NULL,
	[PhotoInfo] nvarchar(100) NOT NULL,
	[UserName] nvarchar(100) NOT NULL,
	[PhotosCategoryID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_LargeSizePhoto] PRIMARY KEY ([LargeSizePhotoID]),
CONSTRAINT [FK_LargeSizePhotoFromCategory_PhotosCategory] FOREIGN KEY ([PhotosCategoryID])
    REFERENCES [PhotosCategory]([PhotosCategoryID]));


CREATE TABLE [Challenges](
	[ChallengeID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	[Description] nvarchar(200) NOT NULL,
CONSTRAINT [PK_Challenges] PRIMARY KEY ([ChallengeID]));

CREATE TABLE [ChallengesPhotos](
	[ChallengePhotosID] uniqueidentifier NOT NULL,
	[PhotoName] nvarchar(100) NOT NULL,
	[UserName] nvarchar(50) NOT NULL,
	[NrLikes] int NOT NULL,
	[ChallengeID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_ChallengesPhotos] PRIMARY KEY ([ChallengePhotosID]),
CONSTRAINT [FK_ChallengesPhotos_Challenges] FOREIGN KEY ([ChallengeID])
    REFERENCES [Challenges]([ChallengeID]));


CREATE TABLE [UserChallenges](
	[UserID] uniqueidentifier NOT NULL,
	[ChallengeID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_UserChallenges] PRIMARY KEY ([UserID], [ChallengeID]),
CONSTRAINT [FK_UserChallenges_UserProfile] FOREIGN KEY ([UserID])
    REFERENCES [UserProfile]([UserID]),
CONSTRAINT [FK_UserChallenges_Challenges] FOREIGN KEY ([ChallengeID])
    REFERENCES [Challenges]([ChallengeID]));


CREATE TABLE [LearnBlog](
	[LearnBlogID] uniqueidentifier NOT NULL,
	[Title] nvarchar(100) NOT NULL,
	[Link] nvarchar(500) NOT NULL,
CONSTRAINT [PK_LearnBlog] PRIMARY KEY ([LearnBlogID]));

CREATE TABLE [NewsBlog](
	[NewsBlogID] uniqueidentifier NOT NULL,
	[Title] nvarchar(100) NOT NULL,
	[Autor] nvarchar(50) NOT NULL,
	[Content] nvarchar(500) NOT NULL,
	[Date] DATE NOT NULL,
	[Time] TIME NOT NULL,
CONSTRAINT [PK_NewsBlog] PRIMARY KEY ([NewsBlogID]));

CREATE TABLE [PhotosForNews](
	[NewsBlogPhotoID] uniqueidentifier NOT NULL,
	[Photo] nvarchar(50) NOT NULL,
CONSTRAINT [PK_NewsBlogPhotos] PRIMARY KEY ([NewsBlogPhotoID]));

CREATE TABLE [NewsPhotosRelation] (
    [NewsBlogID] uniqueidentifier NOT NULL,
	[NewsBlogPhotoID] uniqueidentifier NOT NULL
CONSTRAINT [PK_NewsBlogRelation] PRIMARY KEY ([NewsBlogID], [NewsBlogPhotoID]),
CONSTRAINT [FK_NewsBlogPhoto_NewsBlog] FOREIGN KEY ([NewsBlogID])
    REFERENCES [NewsBlog]([NewsBlogID]),
CONSTRAINT [FK_NewsBlogPhoto_PhotosForNews] FOREIGN KEY ([NewsBlogPhotoID])
    REFERENCES [PhotosForNews]([NewsBlogPhotoID]));

CREATE TABLE [InspirationBlog](
	[InspirationBlogID] uniqueidentifier NOT NULL,
	[Title] nvarchar(100) NOT NULL,
	[Autor] nvarchar(50) NOT NULL,
	[Content] nvarchar(500) NOT NULL,
	[Date] DATE NOT NULL,
	[Time] TIME NOT NULL,
CONSTRAINT [PK_InspirationBlog] PRIMARY KEY ([InspirationBlogID]));

CREATE TABLE [PhotosForInspiration](
	[InspirationBlogPhotoID] uniqueidentifier NOT NULL,
	[Photo] nvarchar(50) NOT NULL,
CONSTRAINT [PK_PhotosForInspiration] PRIMARY KEY ([InspirationBlogPhotoID]));

CREATE TABLE [InspirationPhotosRelation] (
    [InspirationBlogID] uniqueidentifier NOT NULL,
	[InspirationBlogPhotoID] uniqueidentifier NOT NULL
CONSTRAINT [PK_InspirationPhotosRelation] PRIMARY KEY ([InspirationBlogID], [InspirationBlogPhotoID]),
CONSTRAINT [FK_InspirationPhotosRelation_InspirationBlog] FOREIGN KEY ([InspirationBlogID])
    REFERENCES [InspirationBlog]([InspirationBlogID]),
CONSTRAINT [FK_InspirationPhotosRelation_PhotosForInspiration] FOREIGN KEY ([InspirationBlogPhotoID])
    REFERENCES [PhotosForInspiration]([InspirationBlogPhotoID]));


INSERT INTO UserProfile VALUES ('FE1B7EFD-571A-DEAA-4513-DB413054A827', 'Muchtamir', 'profile00' ,'cover01');
INSERT INTO UserProfile VALUES ('353E116F-3D66-C91A-7F69-9350261B440D', 'Marzena', 'profile100' ,'cover101');
INSERT INTO UserProfile VALUES ('DD117EFD-571A-DEAA-4513-DB413054A827', 'Tagliarino', 'profile111' ,'cover000');
INSERT INTO UserProfile VALUES ('77117EFD-571A-DEAA-1995-DB413054A827', 'APERS', 'prole111' ,'cover010');
INSERT INTO UserProfile VALUES ('77117EFD-5713-DEAA-1995-DB413054A833', 'MARC', 'pr2211' ,'cover032');
INSERT INTO UserProfile VALUES ('77117CCC-5713-DEAA-1995-DB413054A833', 'Franke', 'poza1' ,'cover0132');
INSERT INTO UserProfile VALUES ('77117CCC-5713-DEAA-1995-DB413054A843', 'dMarina', 'pozaprofil','cover');

INSERT INTO AboutUser VALUES('fa14d418-0ba8-48f5-847d-837228350ec7','Doci','Marina','description','Cluj','Nikon 3200','facebook ','instagram','web','77117CCC-5713-DEAA-1995-DB413054A843');
INSERT INTO AboutUser VALUES('62955515-8d31-4ec3-9bfe-1b06452a8829','Neil','Krug','description','??','Nikon D50','facebook ','instagram','web','FE1B7EFD-571A-DEAA-4513-DB413054A827');

INSERT INTO PhotosFromProfile VALUES('d325099d-7eac-4487-97f9-3a5582cae72d' , 'Hello',10,'Cluj','Nikonn 5200','77117EFD-571A-DEAA-1995-DB413054A827','poza1.jpg');
INSERT INTO PhotosFromProfile VALUES('9ab101da-b881-4013-bf9d-972605bca0c4' , 'Cat',5,'Cluj','Nikonn D50','77117EFD-5713-DEAA-1995-DB413054A833','poza2/jpg');
INSERT INTO PhotosFromProfile VALUES('3eb44cbc-15aa-4309-ac79-9ebc7f3ea249' , 'sssss',11,'Bistrita','Cannon D50','353E116F-3D66-C91A-7F69-9350261B440D','poza5');
INSERT INTO PhotosFromProfile VALUES('7df9ab34-db1b-47ee-81ec-1fd5afdb7777' , 'aCTION',32,'Bistrita','Cannon 1','77117EFD-571A-DEAA-1995-DB413054A827','poza3');

INSERT INTO Category VALUES ('9A18C663-B8AC-4781-7478-45FD04AD5166' , 'Abstract');
INSERT INTO Category VALUES ('8738C663-B8AC-4781-7478-45FD04AD5166' , 'Portrait');
INSERT INTO Category VALUES ('9A1833AB-B8AC-4781-7478-45FD04AD5166' , 'Street');
INSERT INTO Category VALUES ('ADDDFE06-A8BE-A3D5-F2DD-5164F385C21C' , 'Architecture');
INSERT INTO Category VALUES ('ABBBFE06-A8BE-A97D-F2DD-5164F385C21C' , 'Action');
INSERT INTO Category VALUES ('95FFFE06-A8BE-A97D-F2DD-5164F385C21C' , 'Landscape');
INSERT INTO Category VALUES ('10FFFE06-A8BE-A97D-F2DD-5164F385C21C' , 'Macro');


INSERT INTO PhotosCategory VALUES('877cb45b-fa81-462f-8f64-19c7793e4e4f', 'poza1','cat1.jpg','ADDDFE06-A8BE-A3D5-F2DD-5164F385C21C');
INSERT INTO PhotosCategory VALUES('0e64ec4c-df8c-458b-8512-4dae0604fd36', 'poza2','dog1.png','ADDDFE06-A8BE-A3D5-F2DD-5164F385C21C');
INSERT INTO PhotosCategory VALUES('703ff24e-3e69-480d-9d96-49e73876dd9b', 'poza2','dog3.jpeg','9A1833AB-B8AC-4781-7478-45FD04AD5166');
INSERT INTO PhotosCategory VALUES('209cfddb-086e-4379-b4ed-85c83b1d62c6', 'poza52','winter.jpg','8738C663-B8AC-4781-7478-45FD04AD5166');

INSERT INTO Challenges VALUES ('34aa90ba-df2e-457e-810d-d87f58eb13d0','Flowers','aaaaa');
INSERT INTO Challenges VALUES ('d5f840f0-6677-40cf-8160-238c3e028383','Fall','assssaaazzza');
INSERT INTO Challenges VALUES ('2ca80ebc-66f2-4d4e-b5f5-c12fc73093fc','Art of Photography','wwwwaaaaa');
INSERT INTO Challenges VALUES ('706e200d-4819-4c82-9c6e-3f4ad984d42b','Reflections','112dsdsasssasaaazzza');
INSERT INTO Challenges VALUES ('886673dc-698b-4e70-a2d4-7188cf140204','Just Portaits','rsdaaaaaa');
INSERT INTO Challenges VALUES ('d7f9fc1c-d39a-42ce-a437-56c88306e024','Snow','asfsdfzcssssaaazzza');
INSERT INTO Challenges VALUES ('314190d4-2fd2-474c-8212-b93d90123111','White','sdaaawwwwaaaaa');
INSERT INTO Challenges VALUES ('474b1a89-ed68-4164-bd8f-44c01799d987','Wide','gfsdgds112dsdsasssasaaazzza');

INSERT INTO ChallengesPhotos VALUES ('a5e6d693-389e-4596-9978-1f18a640897a' ,'photo0','aa',100,'886673dc-698b-4e70-a2d4-7188cf140204');
INSERT INTO ChallengesPhotos VALUES ('a5e6d693-389e-4596-0078-1f18a640897a' ,'photo3','abb',50,'886673dc-698b-4e70-a2d4-7188cf140204');
INSERT INTO ChallengesPhotos VALUES ('b3e6d693-389e-4596-9978-1f18a640897a' ,'photo6','marina',10,'314190d4-2fd2-474c-8212-b93d90123111');
INSERT INTO ChallengesPhotos VALUES ('a5e6d693-389e-4596-1000-1f18a640897a' ,'photonr','bala',5,'706e200d-4819-4c82-9c6e-3f4ad984d42b');
INSERT INTO ChallengesPhotos VALUES ('a566d693-389e-4596-1000-1f18a640897a' ,'photonr10','ala',55,'34aa90ba-df2e-457e-810d-d87f58eb13d0');
INSERT INTO ChallengesPhotos VALUES ('a766d693-389e-4596-1000-1f18a640897a' ,'photonr1','doci',110,'d7f9fc1c-d39a-42ce-a437-56c88306e024');


INSERT INTO UserChallenges VALUES('77117EFD-5713-DEAA-1995-DB413054A833','886673dc-698b-4e70-a2d4-7188cf140204');
INSERT INTO UserChallenges VALUES('77117CCC-5713-DEAA-1995-DB413054A833','34aa90ba-df2e-457e-810d-d87f58eb13d0');
INSERT INTO UserChallenges VALUES('DD117EFD-571A-DEAA-4513-DB413054A827','314190d4-2fd2-474c-8212-b93d90123111');
INSERT INTO UserChallenges VALUES('353E116F-3D66-C91A-7F69-9350261B440D','314190d4-2fd2-474c-8212-b93d90123111');



INSERT INTO NewsBlog VALUES('c2a2f930-aa29-484e-9a3b-7d8b184c0425', 'First article' ,'nu stiu','aaaaaaa','2000-11-10','02:10:00');
INSERT INTO NewsBlog VALUES('b142f930-aa29-484e-3a1a-7d8b184c0425', 'second' ,'stiu','aaaaadddaaaaaaa','2007-01-10','05:12:00');
INSERT INTO NewsBlog VALUES('be42e930-ee29-484e-3a1a-9d8b184c0400', 'third' ,'marina','fasfasa','2012-11-01','03:22:00');
INSERT INTO NewsBlog VALUES('a7695725-7701-47ee-a4f6-f49b9bab8dd3', 'HElLO' ,'nu stiu','kjdasd','2016-05-10','02:10:00');
INSERT INTO NewsBlog VALUES('2c41f622-77eb-4100-aaeb-73697122c099', 'World' ,'stiu','sasdxzzzz','2011-03-04','05:12:00');
INSERT INTO NewsBlog VALUES('49a16ba4-7c7b-4b4b-a9ed-fba4dea9483b', '!' ,'marina','fjasjfkhasdf','2009-11-01','03:22:00');
INSERT INTO NewsBlog VALUES('c2a2f930-aa29-484e-9a3b-7d8b184c0422', 'First article' ,'nu stiu','aaaaaaa','2000-11-10','02:10:00');
INSERT INTO NewsBlog VALUES('b142f930-aa29-484e-3a1a-7d8b184c0429', 'second' ,'stiu','aaaaadddaaaaaaa','2007-01-10','05:12:00');
INSERT INTO NewsBlog VALUES('be42e930-ee29-484e-3a1a-9d8b184c0411', 'third' ,'marina','fasfasa','2012-11-01','03:22:00');
INSERT INTO NewsBlog VALUES('a7695725-7701-47ee-a4f6-f49b9bab8d33', 'HElLO' ,'nu stiu','kjdasd','2016-05-10','02:10:00');
INSERT INTO NewsBlog VALUES('2c41f622-77eb-4100-aaeb-73697122c091', 'World' ,'stiu','sasdxzzzz','2011-03-04','05:12:00');
INSERT INTO NewsBlog VALUES('49a16ba4-7c7b-4b4b-a9ed-fba4dea9483C', '!' ,'marina','fjasjfkhasdf','2009-11-01','03:22:00');


INSERT INTO PhotosForNews VALUES('ac0ae926-fb8c-43c7-abf2-d37bb7b772f4' ,'inspiration1.jpg')
INSERT INTO PhotosForNews VALUES('86c5b1ac-856e-47c0-a0f2-9077d284c629' ,'inspiration100.jpg')
INSERT INTO PhotosForNews VALUES('72378b37-9d58-4478-bd71-397b0ed2924f' ,'inspiration0.jpg')
INSERT INTO PhotosForNews VALUES('5ad8570c-f05e-4c83-aa4b-4357e4d08d1d' ,'inspiration1001.jpg')

INSERT INTO NewsPhotosRelation VALUES('2c41f622-77eb-4100-aaeb-73697122c091','72378b37-9d58-4478-bd71-397b0ed2924f');
INSERT INTO NewsPhotosRelation VALUES('c2a2f930-aa29-484e-9a3b-7d8b184c0422','72378b37-9d58-4478-bd71-397b0ed2924f');
INSERT INTO NewsPhotosRelation VALUES('b142f930-aa29-484e-3a1a-7d8b184c0429','ac0ae926-fb8c-43c7-abf2-d37bb7b772f4');
INSERT INTO NewsPhotosRelation VALUES('b142f930-aa29-484e-3a1a-7d8b184c0429','72378b37-9d58-4478-bd71-397b0ed2924f');
INSERT INTO NewsPhotosRelation VALUES('49a16ba4-7c7b-4b4b-a9ed-fba4dea9483C','86c5b1ac-856e-47c0-a0f2-9077d284c629');


INSERT INTO InspirationBlog VALUES('6e553b59-6b04-4325-bf48-d9baad2f390f', 'github' ,'marina','fssssssssa','2011-01-10','01:22:00');
INSERT INTO InspirationBlog VALUES('86c46468-c4de-4af4-8d75-ac6f318fd7fa', 'git' ,'Docimarina','content','2002-10-10','04:25:00');
INSERT INTO InspirationBlog VALUES('4023db6e-f541-49ac-8903-b2dd5ac2e8a2', 'marina' ,'marina','fsdfsdfs','2013-01-10','01:22:00');
INSERT INTO InspirationBlog VALUES('43e02ea7-e88b-4c4e-a24f-82969ecdaacb', 'pixel' ,'marina','bbbbbbb','2001-04-10','12:22:00');
INSERT INTO InspirationBlog VALUES('06f01adc-bc0c-44e0-8b41-ac341344bc56', 'umt' ,'Docimarina','ffffffff','2017-06-10','03:25:00');
INSERT INTO InspirationBlog VALUES('82fdc751-c424-477c-8532-85b1c0535e25', 'microfost' ,'marina','asdasafsdsdsss','2017-09-10','12:22:00');

INSERT INTO PhotosForInspiration VALUES('9be7df3d-7b7b-450c-a860-bc06dc71cf7e','POZA1,jpg')
INSERT INTO PhotosForInspiration VALUES('1be7df3d-7b7b-450c-a860-bc06dc71cf7e','POZA33,jpg')
INSERT INTO PhotosForInspiration VALUES('1ce7df3d-7b7b-450c-a860-bc06dc71cf7e','POZA03,jpg')
INSERT INTO PhotosForInspiration VALUES('1ce9df3d-7b7b-450c-a860-bc06dc71cf7e','POZA17,jpg')
INSERT INTO PhotosForInspiration VALUES('0ce9df3d-7b7b-350c-a860-bc06dc71cf7e','POZA95,jpg')


INSERT INTO InspirationPhotosRelation VALUES('6e553b59-6b04-4325-bf48-d9baad2f390f','1ce9df3d-7b7b-450c-a860-bc06dc71cf7e')
INSERT INTO InspirationPhotosRelation VALUES('6e553b59-6b04-4325-bf48-d9baad2f390f','0ce9df3d-7b7b-350c-a860-bc06dc71cf7e')
INSERT INTO InspirationPhotosRelation VALUES('82fdc751-c424-477c-8532-85b1c0535e25','1be7df3d-7b7b-450c-a860-bc06dc71cf7e')
INSERT INTO InspirationPhotosRelation VALUES('43e02ea7-e88b-4c4e-a24f-82969ecdaacb','1be7df3d-7b7b-450c-a860-bc06dc71cf7e')

