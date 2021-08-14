using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DeskRepository : IDeskRepository
    {
        private readonly StoreContext _context;
        public DeskRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Desk> GetDeskByIdAsync(int id)
        {
            return await _context.Desks
                .Include(p => p.Room)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Desk>> GetDeskAsync()
        {
            return await _context.Desks
                .Include(p => p.Room)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Room>> GetRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }
    }
}