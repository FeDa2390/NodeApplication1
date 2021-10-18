using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    internal class CandidateRepository : ICandidateRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CandidateRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CandidateDto> GetCandidateAsync(string username)
        {
            return await _context.Candidates
                .Where(x => x.Username == username)
                .ProjectTo<CandidateDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }


        public async Task<IEnumerable<CandidateDto>> GetCandidatesAsync()
        {
            return await _context.Candidates
                .ProjectTo<CandidateDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public void Update(Candidate candidate)
        {
            _context.Entry(candidate).State = EntityState.Modified;
        }

        public async Task<IEnumerable<CandidateDto>> GetCandidatesByFilterAsync(CandidateParams candidateParams)
        {
            var query = _context.Candidates.AsQueryable();
            // if (!String.IsNullOrEmpty(candidateParams.City))
            // {
            //     query = query.Where(x => x.City == candidateParams.City);
            // }
             
            var minAge = DateTime.Today.AddYears(-candidateParams.MaxAge - 1);
            var maxAge = DateTime.Today.AddYears(-candidateParams.MinAge);

            query = query.Where(c => c.DateOfBirth >= minAge && c.DateOfBirth <= maxAge);

            return await query.ProjectTo<CandidateDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public Task<string> GetCandidateCity(string username)
        {
            return _context.Candidates
                .Where(x => x.Username == username)
                .Select(x => x.City).FirstOrDefaultAsync();
        }

        public async Task<Candidate> GetCandidateByIdAsync(int id)
        {
            return await _context.Candidates
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }
    }
}