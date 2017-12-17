using MD._360pixels.Repository;
using MD._360pixels.Repository.Core;
using MD._360pixels.RepositoryAbstraction;
using MD._360pixels.RepositoryAbstraction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace MD._360pixels.Test
{
    public class IoCcontainer
    {
        private IUnityContainer _container;

        private static IoCcontainer _instance;

        private IoCcontainer()
        {
            _container = new UnityContainer();
            _container.RegisterType<IRepositoryContext, RepositoryContext>();
            _container.RegisterType<IBlogRepository, BlogRepository>();
            _container.RegisterType<ICategoryRepository, CategoryRepository>();
            _container.RegisterType<IChallengeRepository, ChallengeRepository>();
            _container.RegisterType<IPhotoRepository, PhotoRepository>();
            _container.RegisterType<IUserProfileRepository, UserProfileRepository>();
        }
        public static IoCcontainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IoCcontainer();
                }
                return _instance;
            }
        }
        public T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }
    }
}
