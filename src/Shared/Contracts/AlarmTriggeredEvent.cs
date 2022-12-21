using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts
{
    public record AlarmTriggeredEvent
    {
        public int AlarmId { get; set; }
        public DateTime? AlarmEventDateTime { get; set; }
        public int HomeOwnerId { get; set; }
        public string Address { get; set; }

    }
}