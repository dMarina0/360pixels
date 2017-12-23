using MD._360pixels.Repository.Core;
using MD._360pixels.RepositoryAbstraction;
using MD._360pixels.RepositoryAbstraction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace MD._360pixels.Repository
{
    public class containerIoC
    {
        private IUnityContainer _container;

        private static containerIoC _instance;

        private containerIoC()
        {
            _container = new UnityContainer();
            _container.RegisterType<IRepositoryContext, RepositoryContext>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IBlogRepository, BlogRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ICategoryRepository, CategoryRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IChallengeRepository, ChallengeRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IPhotoRepository, PhotoRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUserProfileRepository, UserProfileRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUserChallengesRepository, UserChallengeRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IBlogPhotosRepository, BlogPhotosRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ICategoriesPhotosRepository, CategoriesPhotosRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IChallengesPhotosRepository, ChallengesPhotosRepository>(new ContainerControlledLifetimeManager());
        }
        public static containerIoC Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new containerIoC();
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
