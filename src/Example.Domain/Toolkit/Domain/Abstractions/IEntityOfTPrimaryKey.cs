namespace Example.Domain.Toolkit.Domain.Abstractions
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; }

        bool IsTransient();
    }
}
