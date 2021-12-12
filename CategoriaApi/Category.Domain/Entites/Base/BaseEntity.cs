namespace Categories.Domain.Entites.Base
{
    public abstract class BaseEntity
    {
        public virtual long Id { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Updated { get; set; }
    }
}
