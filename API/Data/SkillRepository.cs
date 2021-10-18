using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SkillRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<SkillDto> GetSkillByIdAsync(string skillName)
        {
            return await _context.Skills
                .Where(s => s.SkillName == skillName)
                .ProjectTo<SkillDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<SkillDto>> GetSkillsAsync()
        {
            return await _context.Skills
                .ProjectTo<SkillDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        
    }
}