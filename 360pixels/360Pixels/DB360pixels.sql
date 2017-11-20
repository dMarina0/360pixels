USE [360pixelsDB]

CREATE TABLE [Photos](
[PhotoID] uniqueidentifier NOT NULL,
[Photo] nvarchar(100) NOT NULL,
[Comments] nvarchar(200) ,
[Likes] int ,
[Location] nvarchar(100) NOT NULL
CONSTRAINT [PK_Photos] PRIMARY KEY ([PhotoID]));

CREATE TABLE [UserProfile](
[UserID] uniqueidentifier NOT NULL,
[UserName] nvarchar(100) NOT NULL,
CONSTRAINT [PK_UserProfile] PRIMARY KEY([UserID]));

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

CREATE TABLE [Categories](
[CategoryID] uniqueidentifier NOT NULL,
[CategoryName] nvarchar(50) NOT NULL
CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID]));

CREATE TABLE [Challenges](
[ChallengeID] uniqueidentifier NOT NULL,
[ChallengeName] nvarchar(100) NOT NULL,
[Description] nvarchar(100) ,
CONSTRAINT [PK_Challenges] PRIMARY KEY ([ChallengeID]));

CREATE TABLE [UserChallenges](
[UserID] uniqueidentifier NOT NULL,
[ChallengeID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_UserChallenges] PRIMARY KEY([UserID],[ChallengeID]),
CONSTRAINT [FK_UserChallenges_UserProfile] FOREIGN KEY ([UserID])
		REFERENCES [UserProfile] ([UserID]),
CONSTRAINT [FK_UserChallenges_Challenges] FOREIGN KEY ([ChallengeID])
		REFERENCES [Challenges] ([ChallengeID]));

CREATE TABLE [Blog](
[BlogID] uniqueidentifier NOT NULL,
[Title] nvarchar(100) NOT NULL,
[Autor] nvarchar(100) NOT NULL,
[Content] nvarchar(300) NOT NULL,
[Date] DATE NOT NULL,
[Type] nvarchar(50) NOT NULL,
CONSTRAINT [PK_Blog] PRIMARY KEY ([BlogID]));

CREATE TABLE [BlogPhotos](
[BlogID] uniqueidentifier NOT NULL,
[PhotoID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_BlogPhotos] PRIMARY KEY ([BlogID],[PhotoID]),
CONSTRAINT [FK_BlogPhotos_Blog] FOREIGN KEY ([BlogID])
		REFERENCES [Blog]([BlogID]),
CONSTRAINT [FK_BlogPhotos_Photos] FOREIGN KEY ([PhotoID])
		REFERENCES [Photos]([PhotoID]));

CREATE TABLE [CategoriesPhotos](
[CategoryID] uniqueidentifier NOT NULL,
[PhotoID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_CategoriesPhotos] PRIMARY KEY ([CategoryID],[PhotoID]),
CONSTRAINT [FK_CategoriesPhotos_Categories] FOREIGN KEY ([CategoryID])
		REFERENCES [Categories]([CategoryID]),
CONSTRAINT [FK_CategoriesPhotos_Photos] FOREIGN KEY ([PhotoID])
		REFERENCES [Photos]([PhotoID]));

CREATE TABLE [ChallengesPhotos](
[ChallengeID] uniqueidentifier NOT NULL,
[PhotoID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_ChallengesPhotos] PRIMARY KEY ([ChallengeID],[PhotoID]),
CONSTRAINT [FK_ChallengesPhotos_Challenges] FOREIGN KEY ([ChallengeID])
		REFERENCES [Challenges]([ChallengeID]),
CONSTRAINT [FK_ChallengesPhotos_Photos] FOREIGN KEY ([PhotoID])
		REFERENCES [Photos]([PhotoID]));

CREATE TABLE [UserProfilePhotos](
[UserID] uniqueidentifier NOT NULL,
[PhotoID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_UserProfilePhotos] PRIMARY KEY ([UserID],[PhotoID]),
CONSTRAINT [FK_UserProfilePhotos_UserProfile] FOREIGN KEY ([UserID])
		REFERENCES [UserProfile]([UserID]),
CONSTRAINT [FK_UserProfilePhotos_Photos] FOREIGN KEY ([PhotoID])
		REFERENCES [Photos]([PhotoID]));

INSERT INTO UserProfile VALUES ('FE1B7EFD-571A-DEAA-4513-DB413054A827', 'Muchtamir');
INSERT INTO UserProfile VALUES ('353E116F-3D66-C91A-7F69-9350261B440D', 'Marzena');
INSERT INTO UserProfile VALUES ('DD117EFD-571A-DEAA-4513-DB413054A827', 'Tagliarino');
INSERT INTO UserProfile VALUES ('77117EFD-571A-DEAA-1995-DB413054A827', 'APERS');
INSERT INTO UserProfile VALUES ('77117EFD-5713-DEAA-1995-DB413054A833', 'MARC' );
INSERT INTO UserProfile VALUES ('77117CCC-5713-DEAA-1995-DB413054A833', 'Franke' );
INSERT INTO UserProfile VALUES ('77117CCC-5713-DEAA-1995-DB413054A843', 'dMarina');

INSERT INTO AboutUser VALUES('fa14d418-0ba8-48f5-847d-837228350ec7','Doci','Marina','nikon','1995-11-17','Romania','website ','77117CCC-5713-DEAA-1995-DB413054A843');
INSERT INTO AboutUser VALUES('62955515-8d31-4ec3-9bfe-1b06452a8829','Neil','Krug','canon','2015-12-17','China','web ','FE1B7EFD-571A-DEAA-4513-DB413054A827');

INSERT INTO UserProfilePhotos VALUES('FE1B7EFD-571A-DEAA-4513-DB413054A827','a2253231-11e1-46a4-bb96-215f787b30d4');
INSERT INTO UserProfilePhotos VALUES('DD117EFD-571A-DEAA-4513-DB413054A827','1a3c2085-eb15-43b7-a334-3a441e1cca61');
INSERT INTO UserProfilePhotos VALUES('353E116F-3D66-C91A-7F69-9350261B440D','f17d3e49-d968-4e0e-bb93-17822b326a0e');
INSERT INTO UserProfilePhotos VALUES('77117EFD-5713-DEAA-1995-DB413054A833','c4e917a3-7d74-4677-9319-4e5ed5a8975f');
INSERT INTO UserProfilePhotos VALUES('DD117EFD-571A-DEAA-4513-DB413054A827','0ac5e5ad-e582-4475-9cd6-9ffeb56c51de');
INSERT INTO UserProfilePhotos VALUES('77117EFD-5713-DEAA-1995-DB413054A833','aa4747eb-5bdf-4862-a565-cf99735996eb');
INSERT INTO UserProfilePhotos VALUES('DD117EFD-571A-DEAA-4513-DB413054A827','8187a192-90f3-4c08-b4a0-fb246ef43979');
INSERT INTO UserProfilePhotos VALUES('FE1B7EFD-571A-DEAA-4513-DB413054A827','c9d4fd93-36fd-4581-8a85-b18ac28cf2f0');

INSERT INTO Categories VALUES ('9A18C663-B8AC-4781-7478-45FD04AD5166' , 'Abstract');
INSERT INTO Categories VALUES ('8738C663-B8AC-4781-7478-45FD04AD5166' , 'Portrait');
INSERT INTO Categories VALUES ('9A1833AB-B8AC-4781-7478-45FD04AD5166' , 'Street');
INSERT INTO Categories VALUES ('ADDDFE06-A8BE-A3D5-F2DD-5164F385C21C' , 'Architecture');
INSERT INTO Categories VALUES ('ABBBFE06-A8BE-A97D-F2DD-5164F385C21C' , 'Action');
INSERT INTO Categories VALUES ('95FFFE06-A8BE-A97D-F2DD-5164F385C21C' , 'Landscape');
INSERT INTO Categories VALUES ('10FFFE06-A8BE-A97D-F2DD-5164F385C21C' , 'Macro');

INSERT INTO CategoriesPhotos VALUES('DD117EFD-571A-DEAA-4513-DB413054A827','a2253231-11e1-46a4-bb96-215f787b30d4');
INSERT INTO CategoriesPhotos VALUES('10FFFE06-A8BE-A97D-F2DD-5164F385C21C','1a3c2085-eb15-43b7-a334-3a441e1cca61');
INSERT INTO CategoriesPhotos VALUES('8738C663-B8AC-4781-7478-45FD04AD5166','3da9940d-6756-4395-96a6-04c9a537d8b9');
INSERT INTO CategoriesPhotos VALUES('9A18C663-B8AC-4781-7478-45FD04AD5166','aa4747eb-5bdf-4862-a565-cf99735996eb');
INSERT INTO CategoriesPhotos VALUES('DD117EFD-571A-DEAA-4513-DB413054A827','aa4747eb-5bdf-4862-a565-cf99735996eb');
INSERT INTO CategoriesPhotos VALUES('ABBBFE06-A8BE-A97D-F2DD-5164F385C21C','cb1cc651-affc-4c5d-99ce-e73410393cd4');
INSERT INTO CategoriesPhotos VALUES('ADDDFE06-A8BE-A3D5-F2DD-5164F385C21C','aa4747eb-5bdf-4862-a565-cf99735996eb');
INSERT INTO CategoriesPhotos VALUES('ABBBFE06-A8BE-A97D-F2DD-5164F385C21C','8187a192-90f3-4c08-b4a0-fb246ef43979');




INSERT INTO Challenges VALUES ('34aa90ba-df2e-457e-810d-d87f58eb13d0','Flowers','aaaaa');
INSERT INTO Challenges VALUES ('d5f840f0-6677-40cf-8160-238c3e028383','Fall','assssaaazzza');
INSERT INTO Challenges VALUES ('2ca80ebc-66f2-4d4e-b5f5-c12fc73093fc','Art of Photography','wwwwaaaaa');
INSERT INTO Challenges VALUES ('706e200d-4819-4c82-9c6e-3f4ad984d42b','Reflections','112dsdsasssasaaazzza');
INSERT INTO Challenges VALUES ('886673dc-698b-4e70-a2d4-7188cf140204','Just Portaits','rsdaaaaaa');
INSERT INTO Challenges VALUES ('d7f9fc1c-d39a-42ce-a437-56c88306e024','Snow','asfsdfzcssssaaazzza');
INSERT INTO Challenges VALUES ('314190d4-2fd2-474c-8212-b93d90123111','White','sdaaawwwwaaaaa');
INSERT INTO Challenges VALUES ('474b1a89-ed68-4164-bd8f-44c01799d987','Wide','gfsdgds112dsdsasssasaaazzza');

INSERT INTO ChallengesPhotos VALUES('474b1a89-ed68-4164-bd8f-44c01799d987','8187a192-90f3-4c08-b4a0-fb246ef43979');
INSERT INTO ChallengesPhotos VALUES('2ca80ebc-66f2-4d4e-b5f5-c12fc73093fc','a2253231-11e1-46a4-bb96-215f787b30d4');
INSERT INTO ChallengesPhotos VALUES('d7f9fc1c-d39a-42ce-a437-56c88306e024','0ac5e5ad-e582-4475-9cd6-9ffeb56c51de');
INSERT INTO ChallengesPhotos VALUES('706e200d-4819-4c82-9c6e-3f4ad984d42b','3a3c2085-eb65-43b7-a334-3a441e1cca68');
INSERT INTO ChallengesPhotos VALUES('34aa90ba-df2e-457e-810d-d87f58eb13d0','276401d6-2860-4fe5-a266-d132a7cb2e69');
INSERT INTO ChallengesPhotos VALUES('706e200d-4819-4c82-9c6e-3f4ad984d42b','276401d6-2860-4fe5-a266-d132a7cb2e69');
INSERT INTO ChallengesPhotos VALUES('314190d4-2fd2-474c-8212-b93d90123111','a2253231-11e1-46a4-bb96-215f787b30d4');

INSERT INTO Blog VALUES('c2a2f930-aa29-484e-9a3b-7d8b184c0425', 'First article' ,'nu stiu','aaaaaaa','2000-11-10','Inspiration');
INSERT INTO Blog VALUES('b142f930-aa29-484e-3a1a-7d8b184c0425', 'second' ,'stiu','aaaaadddaaaaaaa','2007-01-10','News');
INSERT INTO Blog VALUES('be42e930-ee29-484e-3a1a-9d8b184c0400', 'third' ,'marina','fasfasa','2012-11-01','Inspiration');
INSERT INTO Blog VALUES('a7695725-7701-47ee-a4f6-f49b9bab8dd3', 'HElLO' ,'nu stiu','kjdasd','2016-05-10','News');
INSERT INTO Blog VALUES('2c41f622-77eb-4100-aaeb-73697122c099', 'World' ,'stiu','sasdxzzzz','2011-03-04','News');
INSERT INTO Blog VALUES('49a16ba4-7c7b-4b4b-a9ed-fba4dea9483b', '!' ,'marina','fjasjfkhasdf','2009-11-01','Inspiration');
INSERT INTO Blog VALUES('c2a2f930-aa29-484e-9a3b-7d8b184c0422', 'First article' ,'nu stiu','aaaaaaa','2000-11-10','Learn');
INSERT INTO Blog VALUES('b142f930-aa29-484e-3a1a-7d8b184c0429', 'second' ,'stiu','aaaaadddaaaaaaa','2007-01-10','Learn');
INSERT INTO Blog VALUES('be42e930-ee29-484e-3a1a-9d8b184c0411', 'third' ,'marina','fasfasa','2012-11-01','Inspiration');
INSERT INTO Blog VALUES('a7695725-7701-47ee-a4f6-f49b9bab8d33', 'HElLO' ,'nu stiu','kjdasd','2016-05-10','Learn');
INSERT INTO Blog VALUES('2c41f622-77eb-4100-aaeb-73697122c091', 'World' ,'stiu','sasdxzzzz','2011-03-04','Learn');
INSERT INTO Blog VALUES('49a16ba4-7c7b-4b4b-a9ed-fba4dea9483C', '!' ,'marina','fjasjfkhasdf','2009-11-01','News');

INSERT INTO BlogPhotos VALUES('49a16ba4-7c7b-4b4b-a9ed-fba4dea9483C','cb1cc651-affc-4c5d-99ce-e73410393cd4');
INSERT INTO BlogPhotos VALUES('2c41f622-77eb-4100-aaeb-73697122c091','276401d6-2860-4fe5-a266-d132a7cb2e69');
INSERT INTO BlogPhotos VALUES('c2a2f930-aa29-484e-9a3b-7d8b184c0425','3a3c2085-eb65-43b7-a334-3a441e1cca68');
INSERT INTO BlogPhotos VALUES('b142f930-aa29-484e-3a1a-7d8b184c0429','3da9940d-6756-4395-96a6-04c9a537d8b9');
INSERT INTO BlogPhotos VALUES('a7695725-7701-47ee-a4f6-f49b9bab8dd3','dace2abd-4896-4a74-bdcb-88eda2540e20');
INSERT INTO BlogPhotos VALUES('49a16ba4-7c7b-4b4b-a9ed-fba4dea9483C','0ac3e3ad-e382-4475-9cd6-9ffeb56c51de');
INSERT INTO BlogPhotos VALUES('be42e930-ee29-484e-3a1a-9d8b184c0411','8187a192-90f3-4c08-b4a0-fb246ef43979');


INSERT INTO Photos VALUES('c9d4fd93-36fd-4581-8a85-b18ac28cf2f0','p1.jpg','good',10,'Cluj');
INSERT INTO Photos VALUES('f17d3e49-d968-4e0e-bb93-17822b326a0e','p5.jpg','look good',5,'Bistrita');
INSERT INTO Photos VALUES('a2253231-11e1-46a4-bb96-215f787b30d4','p31.jpg','bad',1,'NY');
INSERT INTO Photos VALUES('c4e917a3-7d74-4677-9319-4e5ed5a8975f','p22.jpg','comment',1,'Tokyo');
INSERT INTO Photos VALUES('cb1cc651-affc-4c5d-99ce-e73410393cd4','p11.jpg','bad',1,'bucuresti');
INSERT INTO Photos VALUES('3da9940d-6756-4395-96a6-04c9a537d8b9','p50.jpg','good',1,'BN');
INSERT INTO Photos VALUES('3a3c2085-eb65-43b7-a334-3a441e1cca68','p66.jpg','the best',1,'BN');
INSERT INTO Photos VALUES('8187a192-90f3-4c08-b4a0-fb246ef43979','p55.jpg','wonderfull',1,'Sibiu');
INSERT INTO Photos VALUES('276401d6-2860-4fe5-a266-d132a7cb2e69','p7.jpg','comment5',1,'Bistrita');
INSERT INTO Photos VALUES('dace2abd-4896-4a74-bdcb-88eda2540e20','p51.jpg','bad',1,'BN');
INSERT INTO Photos VALUES('abee6f53-7dc7-4368-9edc-9814b3dcacad','p111.jpg','bad',1,'Cluj');
INSERT INTO Photos VALUES('b8f1a925-eacc-47c5-9c20-ced64f71b945','p39.jpg','bad',1,'BN');
INSERT INTO Photos VALUES('aa4747eb-5bdf-4862-a565-cf99735996eb','p42.jpg','comment2',1,'BN');
INSERT INTO Photos VALUES('0ac5e5ad-e582-4475-9cd6-9ffeb56c51de','p27.jpg','best 360 photo',1,'BN');
INSERT INTO Photos VALUES('31825ab5-c675-4748-ae05-bead72f19f91','p12.jpg','wiinner',1,'Timisoara');
INSERT INTO Photos VALUES('0ac3e3ad-e382-4475-9cd6-9ffeb56c51de','p41.jpg','awesome',1,'Craiova');
INSERT INTO Photos VALUES('1a3c2085-eb15-43b7-a334-3a441e1cca61','p44.jpg','bad',1,'BN');


