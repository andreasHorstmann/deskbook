using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IDeskRepository
    {
        Task<Desk>GetDeskByIdAsync(int id);
        Task<IReadOnlyList<Desk>> GetDeskAsync();
        Task<IReadOnlyList<Room>> GetRoomsAsync();
    }
}