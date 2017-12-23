using MD._360pixels.Business.Core;
using MD._360pixels.Repository;
using MD._360Pixels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MD._360pixels.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            using (BusinessContext business = new BusinessContext())
            {
                // crudBlog(business);
                // crudCategory(business);
                //crudChallenge(business);
                //crudPhoto(business);
                //crudUserProfile(business);
                //crudUserChallenges(business);
            }
            
        }

        public static void crudUserChallenges(BusinessContext business)
        {
            UserChallengeRepository userChallenge = new UserChallengeRepository();
            List<UserChallenge> userChallenges = new List<UserChallenge>();


            business.UserChallengesBusiness.Delete(new Guid("353E116F-3D66-C91A-7F69-9350261B440D"), new Guid("34aa90ba-df2e-457e-810d-d87f58eb13d0"));

            userChallenges = business.UserChallengesBusiness.ReadAll();

            foreach (UserChallenge us in userChallenges)
            {
                Console.WriteLine(" Users :{0} \n Challenges:{1} ", us.UserID, us.ChallengeID);
            }

            Console.ReadKey();
        }
        public static void crudUserProfile(BusinessContext business)
        {
            UserProfileRepository userRepository = new UserProfileRepository();
            List<UserProfile> users = new List<UserProfile>();
            

            //Update
            UserProfile user = new UserProfile();
            user.UserID = new Guid("FE1B7EFD-571A-DEAA-4513-DB413054A827");
            user.UserName = "Update UserName";
            user.FirstName = "Doci";
            user.LastName = "Marina";
            user.Camera = "";
            user.BirthDay = new DateTime(1995, 11, 17);
            user.Country = "Romania";
            user.Website = "webUpdate";

           business.UserProfileBusiness.Update(user);

            //Delete
            business.UserProfileBusiness.Delete(new Guid("77117CCC-5713-DEAA-1995-DB413054A843"));

            //Insert
            UserProfile u3 = new UserProfile();
            u3.UserID = Guid.NewGuid();
            u3.UserName = "TEST  -- INSERT METHOD";
            u3.FirstName = "Doci";
            u3.LastName = "Marina";
            u3.Camera = "";
            u3.BirthDay = new DateTime(1995, 11, 17);
            u3.Country = "Romania";
            u3.Website = "webUpdate";

            business.UserProfileBusiness.Insert(u3);

            //Read By Id
            UserProfile u = new UserProfile();
            u = business.UserProfileBusiness.ReadById(new Guid("77117EFD-571A-DEAA-1995-DB413054A827"));
            Console.WriteLine(" Read by Id : \n {0} {1} {2} {3} {4} \n", u.UserID, u.UserName, u.FirstName, u.LastName, u.Camera);


            //Read All
            users = business.UserProfileBusiness.ReadAll();


            Console.WriteLine("--------READ ALL METHOD-------");
            foreach (UserProfile us in users)
            {
                Console.WriteLine(" UserName :{0} \n FirstName:{1} \n LastName: {2} ", us.UserName, us.FirstName, us.LastName);
            }

            Console.ReadKey();
        }

        public static void crudBlog(BusinessContext business)
        {
            BlogRepository blogrepo = new BlogRepository();
            List<Blog> blogs = new List<Blog>();

            //Update
            Blog b = new Blog();
            b.BlogID = new Guid("c2a2f930-aa29-484e-9a3b-7d8b184c0422");
            b.Title = "1 Decembrie";
            b.Author = "Marina";
            b.Content = "La multi ani Romanica";
            b.Date = new DateTime(2017, 12, 1);
            b.Type = "News";
            business.BlogBusiness.Update(b);

            //Insert
            Blog b2 = new Blog();
            b2.BlogID = Guid.NewGuid();
            b2.Title = "2 decembrie";
            b2.Author = "Marina";
            b2.Content = "Romanica";
            b2.Date = new DateTime(2017, 12, 1);
            b2.Type = "News";

            business.BlogBusiness.Insert(b2);
            //DELETE 

            business.BlogBusiness.Delete(new Guid("a7695725-7701-47ee-a4f6-f49b9bab8dd3"));

            //READ BY ID
            Blog b1 = new Blog();
             b1 = business.BlogBusiness.ReadById(new Guid("a7695725-7701-47ee-a4f6-f49b9bab8d33"));
            Console.WriteLine("Read by ID: \n TITLE:{0}\n Type: {1} ", b1.Title, b1.Type);


            //Read All
            blogs = business.BlogBusiness.ReadAll();
            Console.WriteLine("            === Read All ==         ");
            foreach (Blog bl in blogs)
            {
                Console.WriteLine("Title: {0} \n ", bl.Title);
            }
            Console.ReadKey();

        }

        public static void crudPhoto(BusinessContext business)
        {
            PhotoRepository photorepo = new PhotoRepository();
            List<Photos> photos = new List<Photos>();

            //INSERT
            Photos photo = new Photos();
            photo.PhotoID = Guid.NewGuid();
            photo.Photo = "p2.jpg";
            photo.Likes = 10;
            photo.Location = "cluj";
            photo.Comment = "Test INsert";

            business.PhotoBusiness.Insert(photo);



            // DELETE
            business.PhotoBusiness.Delete(new Guid("cb1cc651-affc-4c5d-99ce-e73410393cd4"));

            // Read BY ID
            
            Photos b2 = business.PhotoBusiness.ReadById(new Guid("31825ab5-c675-4748-ae05-bead72f19f91"));
            Console.WriteLine(" Read by ID : \n Photo:{0} \n NrLikes:{1} ", b2.Photo, b2.Likes);


            // Update
            Photos p1 = new Photos();
            p1.PhotoID = new Guid("1a3c2085-eb15-43b7-a334-3a441e1cca61");
            p1.Photo = "UpdatePhoto.jpg";
            p1.Likes = 10;
            p1.Location = "cluj";
            p1.Comment = "best";

            business.PhotoBusiness.Update(p1);

            // Read All
            photos = business.PhotoBusiness.ReadAll();
            Console.WriteLine("====== READ ALL=======");
            foreach (Photos p in photos)
            {
                Console.WriteLine("PhotoName: {0} \n NrLikes: {1} \n Location: {2} \n Comment: {3} ", p.Photo, p.Likes, p.Location, p.Comment);


            }

            Console.ReadKey();

        }

        public static void crudCategory(BusinessContext business)
        {
            CategoryRepository categoryrepo = new CategoryRepository();
            List<Category> categories = new List<Category>();
            //INSERT
            Category category = new Category();
            category.CategoryID = Guid.NewGuid();
            category.CategoryName = "Animals--insert";
            business.CategoryBusiness.Insert(category);


            //DELETE

            business.CategoryBusiness.Delete(new Guid("9A1833AB-B8AC-4781-7478-45FD04AD5166"));


            // UPDATE
            Category c2 = new Category();
            c2.CategoryID = new Guid("9A18C663-B8AC-4781-7478-45FD04AD5166");
            c2.CategoryName = "Humans";

            business.CategoryBusiness.Update(c2);


            // Read By ID 
            
            Category c4 = business.CategoryBusiness.ReadById(new Guid("8738C663-B8AC-4781-7478-45FD04AD5166"));
            Console.WriteLine(" Read by ID : ID: {0}  \n CategoryName: {1} ", c4.CategoryID, c4.CategoryName);


            categories = business.CategoryBusiness.ReadAll();
            Console.WriteLine("=======Read all Categories=====");
            foreach (Category c in categories)
            {
                Console.WriteLine("{0} ", c.CategoryName);
            }
            Console.ReadKey();

        }

        public static void crudChallenge(BusinessContext business)
        {
            ChallengeRepository challengerepo = new ChallengeRepository();
            List<Challenge> challenges = new List<Challenge>();

            //INSERT
            Challenge challenge = new Challenge();
            challenge.ChallengeID = Guid.NewGuid();
            challenge.ChallengeName = "Street art--insert";
            challenge.Description = "Whether used as a backdrop or as part of your main composition there's no denying that graffiti can add a real punch to your street photography.";
            business.ChallengeBusiness.Insert(challenge);


            // DELETE

            business.ChallengeBusiness.Delete(new Guid("d7f9fc1c-d39a-42ce-a437-56c88306e024"));


            // UPDATE
            Challenge c2 = new Challenge();
            c2.ChallengeID = new Guid("886673dc-698b-4e70-a2d4-7188cf140204");
            c2.ChallengeName = "ChallengeUpdate";
            c2.Description = "DescriptionUpdate";

            business.ChallengeBusiness.Update(c2);

            // Read By ID 
            Challenge c4 = new Challenge();
            c4 = business.ChallengeBusiness.ReadById(new Guid("34aa90ba-df2e-457e-810d-d87f58eb13d0"));
            Console.WriteLine(" Read by ID : \n Challenge: {0} \n Description:  {1} \n ", c4.ChallengeName, c4.Description);


            challenges = business.ChallengeBusiness.ReadAll();
            Console.WriteLine("====== Read all Challenges==== \n");
            foreach (Challenge c in challenges)
            {
                Console.WriteLine("Challenge: {0}  \n  Description: {1}", c.ChallengeName, c.Description);
            }
            Console.ReadKey();

        }
    }
}
