using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Interfaces
{
    public interface ISkillRepository
    {
        Task<IEnumerable<SkillDto>> GetSkillsAsync();
        Task<SkillDto> GetSkillByIdAsync(string skillName);
    }
}