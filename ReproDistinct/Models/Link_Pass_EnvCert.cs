using System.ComponentModel.DataAnnotations.Schema;

namespace ReproDistinct.Models;

public class Link_Pass_EnvCert<P, PM> :
    ExternalLink<P, Guid, Guid>,
    IIdentifiableEntity<long>
    where P : Pass<P, PM>
    where PM : Link_Pass_Mission<P, PM>
{
    [Column("PassId")]
    public override Guid EntityId { get; set; }

    [Column("EnvironmentalCertificationId")]
    public override Guid SourceId { get; set; }
}