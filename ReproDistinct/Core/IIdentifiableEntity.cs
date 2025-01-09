namespace ReproDistinct.Core;

public interface IIdentifiableEntity<K>
    where K : struct
{
    K Id { get; set; }
}
