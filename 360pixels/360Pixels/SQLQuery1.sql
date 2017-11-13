USE [DBfor360pixels]

--Get the winner for a challenge--
SELECT p.UserName, p.NrLikes , c.Name
FROM Challenges c
	INNER JOIN ChallengesPhotos p ON c.ChallengeID = p.ChallengeID
	ORDER BY p.NrLikes desc

--Get challenges where a user is registered--
SELECT c.Name, p.UserName
FROM Challenges c
	INNER JOIN ChallengesPhotos p ON c.ChallengeID = p.ChallengeID
WHERE p.UserName = 'marina'


--Get all challenges and user which participate--
SELECT c.Name, p.UserName
FROM Challenges c
	INNER JOIN ChallengesPhotos p ON c.ChallengeID = p.ChallengeID

--Get photos with nrLikes >50--
SELECT MIN(p.NrLikes), p.PhotoName
FROM ChallengesPhotos p 
GROUP BY p.PhotoName
HAVING MIN(p.NrLikes) >50


SELECT *
FROM NewsBlog
WHERE Date = '2016-05-10';

--GET all articles from 2012--
SELECT * 
FROM NewsBlog
 WHERE YEAR(Date) = 2012

 --Get details about article by title--
 SELECT b.Content , b.Autor ,b.Title
 FROM InspirationBlog b
	WHERE Title LIKE 'git%'


 --GET challenge name and number of photos from each challenge
SELECT c.Name , COUNT(ph.ChallengePhotosID)
FROM Challenges c
	LEFT JOIN ChallengesPhotos ph ON c.ChallengeID = ph.ChallengeID
	GROUP BY c.Name

--Get all photos BY  category name--
SELECT c.Name , cat.Name
FROM PhotosCategory cat 
	RIGHT JOIN Category c On cat.CategoryID = cat.CategoryID
WHERE c.Name='Portrait';

--Get number of photos added by a user on userprofile page--
SELECT COUNT(ph.PhotosFromProfileID) , p.UserName
FROM UserProfile p
	LEFT JOIN PhotosFromProfile ph ON p.UserID=ph.UserID
	WHERE p.UserName ='MARC'
	GROUP BY p.UserName

-- search photos by title on category--
SELECT p.Name , c.Name
FROM Category c
	INNER JOIN PhotosCategory p ON c.CategoryID = p.CategoryID
	WHERE p.Name LIKE '%2'

--Get all user from a location--
SELECT u.UserName 
FROM UserProfile u
	RIGHT JOIN AboutUser a ON u.UserID= a.UserID
	WHERE a.Location = 'Cluj'

--get user enrolled in challenges and challenge name--
SELECT p.UserName , ca.Name
FROM UserProfile p
    inner join UserChallenges c ON p.UserID= c.UserID
	inner join Challenges ca ON ca.ChallengeID=c.ChallengeID



	














	
	


	







