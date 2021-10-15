using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface ICandidateRepository
    {
        void Update(Candidate candidate);
        Task<IEnumerable<CandidateDto>> GetCandidatesAsync();
        Task<CandidateDto> GetCandidateAsync(string username);
        Task<IEnumerable<CandidateDto>> GetCandidatesByFilterAsync(CandidateParams candidateParams);
        Task<string> GetCandidateCity (string username);
    }
}