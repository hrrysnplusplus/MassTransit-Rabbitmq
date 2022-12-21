using HomeOwnerService.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlarmService.Models
{
    public class Alarm
    {
        public int Id { get; set; }
        public DateTime AlarmTriggerDate { get; set; }


        [ForeignKey("HomeOwner")]
        public int HomeownerId { get; set; }
        public HomeOwner HomeOwner { get; set; }

    }
}