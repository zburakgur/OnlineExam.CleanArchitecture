namespace Infrastructure.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; set; }
    }
}
