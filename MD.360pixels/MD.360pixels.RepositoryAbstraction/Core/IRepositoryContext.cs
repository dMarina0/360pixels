using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.RepositoryAbstraction.Core
{
    public interface IRepositoryContext: IDisposable
    {
        IBlogRepository BlogRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IChallengeRepository ChallengeRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        IUserChallengesRepository UserChallengesRepository { get; }
        IBlogPhotosRepository BlogPhotosRepository { get; }
        ICategoriesPhotosRepository CategoriesPhotosRepository { get; }
        IChallengesPhotosRepository ChallengesPhotosRepository { get; }
    }
}
