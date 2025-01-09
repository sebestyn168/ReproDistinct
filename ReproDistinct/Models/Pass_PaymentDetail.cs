using System.ComponentModel.DataAnnotations.Schema;

namespace ReproDistinct.Models;

public partial class Pass_PaymentDetail : IIdentifiableEntity<Guid>
{
    [Column("PassId")]
    public Guid Id { get; set; }

    public string? PaymentDetail { get; set; }
}