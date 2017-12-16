using MD._360pixels.RepositoryAbstraction.Core;
using MD._360pixels.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.Business.Core
{
   public  class BusinessContext: IDisposable
    {
        private static BusinessContext _businessInstance;

        private IRepositoryContext _repositoryContext;

        private BlogBusiness _blogBusiness;
        private CategoryBusiness _categoryBusiness;
        private ChallengeBusiness _challengeBusiness;
        private PhotoBusiness _photoBusiness;
        private UserProfileBusiness _userProfileBusiness;

        public BusinessContext()
        {
            _businessInstance = this;
            _repositoryContext = Getter.Instance();
        }

        internal static BusinessContext Current
        {
            get
            {
                if(_businessInstance == null)
                {
                    throw new Exception("BussinesContext error");
                }
                return _businessInstance;
            }
        }
        internal IRepositoryContext repositoryContext
        {
            get
            {
                return _repositoryContext;
            }
        }

        public CategoryBusiness categoryBusiness
        {
            get
            {
                if (_categoryBusiness == null)
                {
                    _categoryBusiness = new CategoryBusiness();
                }
                return _categoryBusiness;
            }
        }

        public BlogBusiness blogBusiness
        {
            get
            {
                if(_blogBusiness == null)
                {
                    _blogBusiness = new BlogBusiness();
                }
                return _blogBusiness;
                    
            }
        }
        public ChallengeBusiness challengeBusiness
        {
            get
            {
                if (_challengeBusiness == null)
                {
                    _challengeBusiness = new ChallengeBusiness();
                }
                return _challengeBusiness;

            }
        }
        public PhotoBusiness photoBusiness
        {
            get
            {
                if (_photoBusiness == null)
                {
                    _photoBusiness = new PhotoBusiness();
                }
                return _photoBusiness;

            }
        }
        public UserProfileBusiness userProfileBusiness
        {
            get
            {
                if (_userProfileBusiness == null)
                {
                    _userProfileBusiness = new UserProfileBusiness();
                }
                return _userProfileBusiness;

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
                if (_blogBusiness != null)
                {

                    _blogBusiness = null;
                }
                if (_categoryBusiness != null)
                {

                    _categoryBusiness = null;
                }
                if (_userProfileBusiness != null)
                {

                    _userProfileBusiness = null;
                }
                if (_repositoryContext != null)
                {
                    _repositoryContext.Dispose();
                    _repositoryContext = null;
                }

                if (_businessInstance != null)
                {
                    _businessInstance = null;
                }
                if (_photoBusiness != null)
                {

                    _photoBusiness = null;
                }


            }
        }

        ~BusinessContext()
        {
            Dispose(false);
        }
        #endregion

    }
}
