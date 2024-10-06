

using SportApp_Domain.Entities;

namespace SportApp_Infrastructure.Model.Owner
{
    public class CreateOwnerModel
    {
        public Guid UserId { get; set; }
        public ICollection<SportField> Fields { get; set; } = new List<SportField>();
    }
}
