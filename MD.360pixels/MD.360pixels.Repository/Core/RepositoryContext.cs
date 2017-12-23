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
    public class RepositoryContext : IRepositoryContext
    {

        private static IRepositoryContext _instance;
        private static IBlogRepository _blogRepository;
        private static IPhotoRepository _photoRepository;
        private static ICategoryRepository _categoryRepository;
        private static IChallengeRepository _challengeRepository;
        private static IUserProfileRepository _userProfileRepository;
        private static IUserChallengesRepository _userChallengeRepository;
        private static IBlogPhotosRepository _blogPhotosRepository;
        private static ICategoriesPhotosRepository _categoriesPhotosRepository;
        private static IChallengesPhotosRepository _challengesPhotosRepository;

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
                return containerIoC.Instance.Resolve<IRepositoryContext>();
            }
        }


        public IBlogRepository BlogRepository
        {
            get
            {
                if (_blogRepository == null)
                {
                    _blogRepository = new BlogRepository();
                }
                return containerIoC.Instance.Resolve<IBlogRepository>();

            }

        }
        public IBlogPhotosRepository BlogPhotosRepository
        {
            get
            {
                return containerIoC.Instance.Resolve<IBlogPhotosRepository>();
            }

        }

        public IPhotoRepository PhotoRepository
        {
            get {

                if (_photoRepository == null)
                {
                    _photoRepository = new PhotoRepository();
                }
                return _photoRepository;
            }

        }

        public ICategoryRepository CategoryRepository
        {
            get
            {

                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository();
                }
                return containerIoC.Instance.Resolve<ICategoryRepository>();
            }

        }
        public ICategoriesPhotosRepository CategoriesPhotosRepository
        {
            get
            {

                return containerIoC.Instance.Resolve<ICategoriesPhotosRepository>();
            }

        }

        public IChallengeRepository ChallengeRepository
        {
            get
            {

                if (_challengeRepository == null)
                {
                    _challengeRepository = new ChallengeRepository();
                }
                return containerIoC.Instance.Resolve<IChallengeRepository>();
            }

        }

        public IUserProfileRepository UserProfileRepository
        {
            get
            {

                if (_userProfileRepository == null)
                {
                    _userProfileRepository = new UserProfileRepository();
                }
                return containerIoC.Instance.Resolve<IUserProfileRepository>();
            }

        }

        public IUserChallengesRepository UserChallengesRepository
        {

            get
            {
                if (_userChallengeRepository == null)
                {
                    _userChallengeRepository = new UserChallengeRepository();
                }
                return containerIoC.Instance.Resolve<IUserChallengesRepository>();
            }
        }
        public IChallengesPhotosRepository ChallengesPhotosRepository
        {
            get
            {
                return containerIoC.Instance.Resolve<IChallengesPhotosRepository>();
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
                if (_blogPhotosRepository != null)
                {

                    _blogPhotosRepository = null;
                }
                if (_userChallengeRepository != null)
                {

                    _userChallengeRepository = null;
                }

                if (_categoryRepository != null)
                {
                   
                    _categoryRepository = null;
                }
                if (_challengeRepository != null)
                {
                    
                    _challengeRepository = null;
                }
                if (_challengesPhotosRepository != null)
                {

                    _challengesPhotosRepository = null;
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
