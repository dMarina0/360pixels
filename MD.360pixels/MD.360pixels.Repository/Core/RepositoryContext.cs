using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Repository.Core
{
    public class RepositoryContext :IDisposable
    {
        private static BlogRepository _blogRepository;
        private static PhotoRepository _photoRepository;
        private static CategoryRepository _categoryRepository;
        private static ChallengeRepository _challengeRepository;
        private static UserProfileRepository _userProfileRepository;

        public RepositoryContext() { }


        public static BlogRepository blogRepository
        {
            get
                { 
            if (_blogRepository == null)
            {
                _blogRepository = new BlogRepository();
            }
            return _blogRepository;
        }
            
        }

        public static PhotoRepository photoRepository
        {
            get{

                if (_photoRepository == null)
                {
                    _photoRepository = new PhotoRepository();
                }
                return _photoRepository;
            }
            
        }

        public static CategoryRepository categoryRepository
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

        public static ChallengeRepository challengeRepository
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

        public static UserProfileRepository userProfileRepository
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
