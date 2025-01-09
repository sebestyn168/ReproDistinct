using System.ComponentModel.DataAnnotations.Schema;

namespace ReproDistinct.Models;

public partial class Pass_PricingProjectDescription : IIdentifiableEntity<Guid>
{
    [Column("PassId")]
    public Guid Id { get; set; }

    public string? PricingProjectDescription { get; set; }
}