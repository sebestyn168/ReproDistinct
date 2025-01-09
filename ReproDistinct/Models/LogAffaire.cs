using System.ComponentModel.DataAnnotations;

namespace ReproDistinct.Models
{
    public class LogAffaire : IIdentifiableEntity<long>
    {
        public long Id { get; set; }

        public Guid PassId { get; set; }

        [MaxLength(15)]
        public string? AtlasId { get; set; }

        public DateTime TimeStamp { get; set; }

        public string? Sent { get; set; }

        public string? Received { get; set; }

        public string? Operation { get; set; }

        public string? Message { get; set; }

        [MaxLength(150)]
        public string? AtlasMessage { get; set; }
    }
}