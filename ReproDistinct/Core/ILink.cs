using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReproDistinct.Core;

public interface ILink<KEntity, KSource> : IIdentifiableEntity<long>
{
    KEntity EntityId { get; set; }

    KSource SourceId { get; set; }
}

public abstract class Link<TEntity, KEntity, TSource, KSource>
    : ILink<KEntity, KSource>
    where TEntity : class, IIdentifiableEntity<KEntity>
    where KEntity : struct
    where TSource : class, IIdentifiableEntity<KSource>
    where KSource : struct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public abstract KEntity EntityId { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public TEntity? Entity { get; set; }

    public abstract KSource SourceId { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public TSource? Source { get; set; }
}

public abstract class ExternalLink<TEntity, KEntity, KSource>
    : ILink<KEntity, KSource>
    where TEntity : class, IIdentifiableEntity<KEntity>
    where KEntity : struct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public abstract KEntity EntityId { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual TEntity? Entity { get; set; }

    public abstract KSource SourceId { get; set; }
}