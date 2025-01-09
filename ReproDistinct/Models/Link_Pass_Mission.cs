using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ReproDistinct.Models;

public class Link_Pass_Mission<P, PM> :
    ExternalLink<P, Guid, Guid>,
    IIdentifiableEntity<long>
    where P : Pass<P, PM>
    where PM : Link_Pass_Mission<P, PM>
{
    public override string ToString() => $"{SourceId} [{Id}]";

    [Column("PassId")]
    public override Guid EntityId { get; set; }

    [Column("MissionId")]
    public override Guid SourceId { get; set; }

    [NotMapped]
    [JsonIgnore]
    public bool IsSelected { get; set; }

    public bool? IsClientDemand { get; set; }

    public decimal? AmountSold { get; set; }
    public decimal? AmountReco { get; set; }

    public decimal? AmountCalculated { get; set; }

    [NotMapped]
    [JsonIgnore]
    public decimal AmountSoldPlusReco => (AmountSold ?? 0) + (AmountReco ?? 0);

    [NotMapped]
    [JsonIgnore]
    public int? AtlasChronoId { get; set; }

    public string? Detail { get; set; }

    public bool HasDiscount { get; set; }
}