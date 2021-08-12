using Core.Entities;

namespace Core.Specifications
{
    public class DesksWithRoomSpecification : BaseSpecification<Desk>
    {
        public DesksWithRoomSpecification()
        {
            AddInclude(x => x.Room);
        }

        public DesksWithRoomSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Room);
        }
    }
}