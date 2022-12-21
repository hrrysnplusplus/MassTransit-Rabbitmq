namespace HomeOwnerService.Models
{
    public class HomeOwner
    {
        public int HomeOwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public AlarmServiceType AlarAlarmServiceType { get; set; }
        public SubscriptionStatus SubSubscriptionStatus { get; set; }

    }
}