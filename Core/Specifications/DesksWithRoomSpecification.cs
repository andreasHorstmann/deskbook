using Core.Entities;

namespace Core.Specifications
{
    public class DesksWithRoomSpecification : BaseSpecification<Desk>
    {
        public DesksWithRoomSpecification(DeskSpecParams deskParams)
            : base(x => 
                (string.IsNullOrEmpty(deskParams.Search) || x.Name.ToLower().Contains(deskParams.Search)) &&
                (!deskParams.RoomId.HasValue || x.RoomId == deskParams.RoomId))
        {
            AddInclude(x => x.Room);
            AddOrderBy(x => x.Name);
            ApplyPaging(deskParams.PageSize*(deskParams.PageIndex - 1), deskParams.PageSize);

            if(!string.IsNullOrEmpty(deskParams.Sort))
            {
                switch (deskParams.Sort)
                {
                    case "roomAsc":
                        AddOrderBy(p => p.RoomId);
                        break;
                    case "roomDesc":
                        AddOrderByDescending(p => p.RoomId);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public DesksWithRoomSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Room);
        }
    }
}