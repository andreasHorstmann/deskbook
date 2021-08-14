using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class DesksWithFiltersForCountSpecification : BaseSpecification<Desk>
    {
        public DesksWithFiltersForCountSpecification(DeskSpecParams deskParams) 
            : base(x => (!deskParams.RoomId.HasValue || x.RoomId == deskParams.RoomId))
        {
        }
    }
}