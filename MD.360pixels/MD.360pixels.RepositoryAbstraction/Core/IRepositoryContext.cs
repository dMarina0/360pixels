using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD._360pixels.RepositoryAbstraction.Core
{
    public interface IRepositoryContext: IDisposable
    {
        IBlogRepository blogRepository { get; }
        ICategoryRepository categoryRepository { get; }
        IChallengeRepository challengeRepository { get; }
        IPhotoRepository photoRepository { get; }
        IUserProfileRepository userProfileRepository { get; }
    }
}
