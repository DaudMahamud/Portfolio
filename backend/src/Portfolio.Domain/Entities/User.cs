using Portfolio.Domain.Interfaces.Common;

namespace Portfolio.Domain.Entities
{
    public class User : IHasGuid, IEntity
    {
        public Guid Id { get; init; }
        public string Name { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
    }
}
