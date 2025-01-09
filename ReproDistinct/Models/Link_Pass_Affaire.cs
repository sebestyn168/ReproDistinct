using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ReproDistinct.Models;

public class Link_Pass_Affaire<P, PM> :
    ExternalLink<P, Guid, char>,
    IIdentifiableEntity<long>
    where P : Pass<P, PM>
    where PM : Link_Pass_Mission<P, PM>
{
    [Column("PassId")]
    public override Guid EntityId { get; set; }

    /// <summary>
    /// Shadow EntitytId
    /// </summary>
    [NotMapped]
    [JsonIgnore]
    public Guid PassId
    {
        get => EntityId;
        set => EntityId = value;
    }

    [Column("AtlasGroupId")]
    public override char SourceId { get; set; }

    /// <summary>
    /// Shadow SourceId
    /// </summary>
    [NotMapped]
    [JsonIgnore]
    public char AtlasGroupId
    {
        get => SourceId;
        set => SourceId = value;
    }

    [MaxLength(15)]
    public string? AtlasId { get; set; }

    public StatutAffaire? StatutAffaire { get; set; }

    public DateTime? LastSendingDateTime { get; set; }

    public DateTime? LastControlDateTime { get; set; }

    public int? ReferenceId { get; set; }

    [NotMapped]
    [JsonIgnore]
    public bool Unexpected { get; set; }
}