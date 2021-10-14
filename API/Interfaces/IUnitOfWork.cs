using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
         ICandidateRepository CandidateRepository { get; }

        Task<bool> Complete();
        bool HasChages();
    }
}