namespace Portfolio.Domain.Interfaces.Common
{
    public interface IEntity
    {
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
    }
}
