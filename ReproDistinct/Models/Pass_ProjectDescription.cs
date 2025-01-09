using System.ComponentModel.DataAnnotations.Schema;

namespace ReproDistinct.Models;

public partial class Pass_ProjectDescription : IIdentifiableEntity<Guid>
{
    [Column("PassId")]
    public Guid Id { get; set; }

    public string? ProjectDescription { get; set; }
}