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

            
            crudUserProfile();
           //crudBlog();
           // crudPhoto();
           // crudCategory();
            //crudChallenge();
        }
        public static void crudUserProfile()
        {
            UserProfileRepository userRepository = new UserProfileRepository();
            List<UserProfile> users = new List<UserProfile>();

            //Update
            UserProfile user = new UserProfile();
            user.UserID = new Guid("77117CCC-5713-DEAA-1995-DB413054A843");
            user.UserName = "Update";
            user.FirstName = "Doci";
            user.LastName = "Marina";
            user.Camera = "";
            user.BirthDay = new DateTime(1995, 11, 17);
            user.Country = "Romania";
            user.Website = "webUpdate";

            userRepository.Update(user);

            //Delete
            UserProfile u2 = new UserProfile();
            u2.UserID = new Guid("77117EFD-5713-DEAA-1995-DB413054A833");

            userRepository.Delete(u2);

            //Insert
            UserProfile u3 = new UserProfile();
            u3.UserID = Guid.NewGuid();
            u3.UserName = "doMar  -- INSERT METHOD";
            u3.FirstName = "Doci";
            u3.LastName = "Marina";
            u3.Camera = "";
            u3.BirthDay = new DateTime(1995, 11, 17);
            u3.Country = "Romania";
            u3.Website = "webUpdate";

            userRepository.Insert(u3);

            //Read By Id
            UserProfile u1 = new UserProfile();
            u1.UserID = new Guid("77117EFD-571A-DEAA-1995-DB413054A827");
            UserProfile u = userRepository.ReadById(u1);
            Console.WriteLine(" Read by Id : \n {0} {1} {2} {3} {4} \n", u.UserID, u.UserName, u.FirstName, u.LastName, u.Camera);


            //Read All
            users = userRepository.ReadAll();


            Console.WriteLine("--------READ ALL METHOD-------");
            foreach (UserProfile us in users)
            {
                Console.WriteLine(" UserName :{0} \n FirstName:{1} \n LastName: {2} ", us.UserName, us.FirstName, us.LastName);
            }

            Console.ReadKey();
        }

        public static void crudBlog()
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
            blogrepo.Update(b);

            //Insert
            Blog b2 = new Blog();
            b2.BlogID = Guid.NewGuid();
            b2.Title = "2 decembrie";
            b2.Author = "Marina";
            b2.Content = "Romanica";
            b2.Date = new DateTime(2017, 12, 1);
            b2.Type = "News";

            blogrepo.Insert(b2);
            //DELETE 
            b.BlogID = new Guid("a7695725-7701-47ee-a4f6-f49b9bab8dd3");
            blogrepo.Delete(b);

            //READ BY ID
            Blog b1 = new Blog();
            b1 = blogrepo.ReadById(b);
            Console.WriteLine("Read by ID: \n TITLE:{0}\n Type: {1} ", b1.Title, b1.Type);


            //Read All
            blogs = blogrepo.ReadAll();
            Console.WriteLine("            === Read All ==         ");
            foreach (Blog blog in blogs)
            {
                Console.WriteLine("Title: {0} \n Author:  {1} \n Content {2} ", blog.Title, blog.Author, blog.Content);
            }
            Console.ReadKey();



        }

        public static void crudPhoto()
        {
            PhotoRepository photorepo = new PhotoRepository();
            List<Photos> photos = new List<Photos>();

            //INSERT
            Photos photo = new Photos();
            photo.PhotoID = Guid.NewGuid();
            photo.Photo = "p2.jpg";
            photo.Likes = 10;
            photo.Location = "cluj";
            photo.Comment = "best";

            photorepo.Insert(photo);



            // DELETE
            Photos b = new Photos();
            b.PhotoID = new Guid("3da9940d-6756-4395-96a6-04c9a537d8b9");
            photorepo.Delete(b);

            // Read BY ID
            Photos b1 = new Photos();
            b1.PhotoID = new Guid("31825ab5-c675-4748-ae05-bead72f19f91");
            Photos b2 = photorepo.ReadById(b1);
            Console.WriteLine(" Read by ID : \n Photo:{0} \n NrLikes:{1} ", b2.Photo, b2.Likes);


            // Update
            Photos p1 = new Photos();
            p1.PhotoID = new Guid("1a3c2085-eb15-43b7-a334-3a441e1cca61");
            p1.Photo = "UpdatePhoto.jpg";
            p1.Likes = 10;
            p1.Location = "cluj";
            p1.Comment = "best";

            photorepo.Update(p1);

            // Read All
            photos = photorepo.ReadAll();
            Console.WriteLine("====== READ ALL=======");
            foreach (Photos p in photos)
            {
                Console.WriteLine("PhotoName: {0} \n NrLikes: {1} \n Location: {2} \n Comment: {3} ", p.Photo, p.Likes, p.Location, p.Comment);


            }

            Console.ReadKey();

        }

        public static void crudCategory()
        {
            CategoryRepository categoryrepo = new CategoryRepository();
            List<Category> categories = new List<Category>();
            //INSERT
            Category category = new Category();
            category.CategoryID = Guid.NewGuid();
            category.CategoryName = "Animals";
            categoryrepo.Insert(category);


            //DELETE
            Category c1 = new Category();
            c1.CategoryID = new Guid("9A1833AB-B8AC-4781-7478-45FD04AD5166");

            categoryrepo.Delete(c1);


            // UPDATE
            Category c2 = new Category();
            c2.CategoryID = new Guid("9A18C663-B8AC-4781-7478-45FD04AD5166");
            c2.CategoryName = "Humans";

            categoryrepo.Update(c2);


            // Read By ID 
            Category c3 = new Category();
            c3.CategoryID = new Guid("8738C663-B8AC-4781-7478-45FD04AD5166");
            Category c4 = categoryrepo.ReadById(c3);
            Console.WriteLine(" Read by ID : ID: {0}  \n CategoryName: {1} ", c4.CategoryID, c4.CategoryName);


            categories = categoryrepo.ReadAll();
            Console.WriteLine("=======Read all Categories=====");
            foreach (Category c in categories)
            {
                Console.WriteLine("{0} ", c.CategoryName);
            }
            Console.ReadKey();

        }

        public static void crudChallenge()
        {
            ChallengeRepository challengerepo = new ChallengeRepository();
            List<Challenge> challenges = new List<Challenge>();

            //INSERT
            Challenge challenge = new Challenge();
            challenge.ChallengeID = Guid.NewGuid();
            challenge.ChallengeName = "Street art";
            challenge.Description = "Whether used as a backdrop or as part of your main composition there's no denying that graffiti can add a real punch to your street photography.";
            challengerepo.Insert(challenge);


            // DELETE
            Challenge c1 = new Challenge();
            c1.ChallengeID = new Guid("34aa90ba-df2e-457e-810d-d87f58eb13d0");

            challengerepo.Delete(c1);


            // UPDATE
            Challenge c2 = new Challenge();
            c2.ChallengeID = new Guid("886673dc-698b-4e70-a2d4-7188cf140204");
            c2.ChallengeName = "ChallengeUpdate";
            c2.Description = "DescriptionUpdate";

            challengerepo.Update(c2);

            // Read By ID 
            Challenge c3 = new Challenge();
            c3.ChallengeID = new Guid("706e200d-4819-4c82-9c6e-3f4ad984d42b");
            Challenge c4 = challengerepo.ReadById(c3);
            Console.WriteLine(" Read by ID : \n Challenge: {0} \n Description:  {1} \n ", c4.ChallengeName, c4.Description);


            challenges = challengerepo.ReadAll();
            Console.WriteLine("====== Read all Challenges==== \n");
            foreach (Challenge c in challenges)
            {
                Console.WriteLine("Challenge: {0}  \n  Description: {1}", c.ChallengeName, c.Description);
            }
            Console.ReadKey();

        }
    }
}
