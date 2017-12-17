using MD._360pixels.RepositoryAbstraction;
using MD._360pixels.RepositoryAbstraction.Core;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MD._360pixels.Repository.Core
{
    public  class RepositoryContext :IRepositoryContext
    {
       
        private static IRepositoryContext _instance;
        private static IBlogRepository _blogRepository;
        private static IPhotoRepository _photoRepository;
        private static ICategoryRepository _categoryRepository;
        private static IChallengeRepository _challengeRepository;
        private static IUserProfileRepository _userProfileRepository;
   
        public RepositoryContext()
        {
            _instance = this;
            
        }

        internal static IRepositoryContext Current
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("RepositoryContext error");
                }
                return _instance;
            }
        }


        public IBlogRepository blogRepository
        {
            get
             {
             if (_blogRepository == null)
            {
                    _blogRepository = new BlogRepository();
            }
                return _blogRepository;
                //return IoCcontainer.Instance.Resolve<IBlogRepository>();

            }

        }

        public   IPhotoRepository photoRepository
        {
            get{

                if (_photoRepository == null)
                {
                    _photoRepository = new PhotoRepository();
                }
                return _photoRepository;
            }
            
        }

        public  ICategoryRepository categoryRepository
        {
            get
            {

                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository();
                }
                return _categoryRepository;
            }

        }

        public  IChallengeRepository challengeRepository
        {
            get
            {

                if (_challengeRepository == null)
                {
                    _challengeRepository = new ChallengeRepository();
                }
                return _challengeRepository;
            }

        }

        public  IUserProfileRepository userProfileRepository
        {
            get
            {

                if (_userProfileRepository == null)
                {
                    _userProfileRepository = new UserProfileRepository();
                }
                return _userProfileRepository;
            }

        }


        #region IDisposable Implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                if( _instance != null )
                {
                    _instance = null;
                }
                if (_blogRepository != null)
                {
                   
                    _blogRepository = null;
                }

                if (_categoryRepository != null)
                {
                   
                    _categoryRepository = null;
                }
                if (_challengeRepository != null)
                {
                    
                    _challengeRepository = null;
                }

                if (_photoRepository != null)
                {

                    _photoRepository = null;
                }
                if (_userProfileRepository != null)
                {

                    _userProfileRepository = null;
                }
            }
        }

        ~RepositoryContext()
        {
            Dispose(false);
        }
        #endregion



    }
}
