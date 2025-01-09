using System.ComponentModel.DataAnnotations.Schema;

namespace ReproDistinct.Models;

public partial class Link_Echeancier_Mission :
    ExternalLink<EcheancierModel, Guid, Guid>,
    IIdentifiableEntity<long>
{
    [Column("EcheancierId")]
    public override Guid EntityId { get; set; }

    [Column("MissionId")]
    public override Guid SourceId { get; set; }
}