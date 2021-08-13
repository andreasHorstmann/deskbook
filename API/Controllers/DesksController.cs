using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;
using API.Errors;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    public class DesksController : BaseApiController
    {
        private readonly IGenericRepository<Desk> _deskRepo;
        private readonly IGenericRepository<Room> _roomRepo;
        private readonly IMapper _mapper;
        public DesksController(IGenericRepository<Desk> deskRepo, IGenericRepository<Room> roomRepo, IMapper mapper)
        {
            _mapper = mapper;
            _roomRepo = roomRepo;
            _deskRepo = deskRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DeskToReturnDto>>> GetDesks()
        {
            var spec = new DesksWithRoomSpecification();
            var desks = await _deskRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Desk>, IReadOnlyList<DeskToReturnDto>>(desks));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeskToReturnDto>> GetDesk(int id)
        {
            var spec = new DesksWithRoomSpecification(id);
            var desk = await _deskRepo.GetEntityWithSpec(spec);
            if(desk == null) return NotFound(new ApiResponse(400));
            return _mapper.Map<Desk, DeskToReturnDto>(desk);
        }

        [HttpGet("rooms")]
        public async Task<ActionResult<IReadOnlyList<Room>>> GetRooms()
        {
            return Ok(await _roomRepo.ListAllAsync());
        }
    }
}