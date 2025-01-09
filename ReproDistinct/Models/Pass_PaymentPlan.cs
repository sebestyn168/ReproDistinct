using System.ComponentModel.DataAnnotations.Schema;

namespace ReproDistinct.Models;

public partial class Pass_PaymentPlan : IIdentifiableEntity<Guid>
{
    [Column("PassId")]
    public Guid Id { get; set; }

    public string? PaymentPlan { get; set; }
}