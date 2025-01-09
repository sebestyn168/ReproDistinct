namespace ReproDistinct.Core;

public abstract class ConfigurationEntity<K> : IIdentifiableEntity<K>, ICodedEntity, ILabeledEntity
    where K : struct
{
    public K Id { get; set; } = default!;

    public string Code { get; set; }

    public string Label { get; set; } = String.Empty;

    public override string ToString() => $"[{Id}-{Code}] {Label}";
}