using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CandidatesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CandidatesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateDto>>> GetCandidates()
        {
            var candidates = await _unitOfWork.CandidateRepository.GetCandidatesAsync();
            return Ok(candidates);
        }

        [HttpGet("{username}", Name = "GetCandidate")]
        public async Task<ActionResult<CandidateDto>> GetCandidate(string username)
        {
            return await _unitOfWork.CandidateRepository.GetCandidateAsync(username);
        }

        [HttpGet("filter-candidates")]
        public async Task<ActionResult<IEnumerable<CandidateDto>>> GetCandidateFromParams([FromQuery] CandidateParams candidateParams)
        {
            var candidates = await _unitOfWork.CandidateRepository.GetCandidatesByFilterAsync(candidateParams);
            return Ok(candidates);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCandidate(CandidateUpdateDto candidateUpdateDto)
        {
            var candidate = await _unitOfWork.CandidateRepository.GetCandidateByIdAsync(candidateUpdateDto.Id);

            _mapper.Map(candidateUpdateDto, candidate);

            _unitOfWork.CandidateRepository.Update(candidate);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to update candidate");
        }
    }
}