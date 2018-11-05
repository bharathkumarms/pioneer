using System;

namespace js.pioneer.model
{
    public class Subscriber
    {
        public int SNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SubscriptionNo { get; set; }
        public string CustomerName { get; set; }
        public SubscriptionType Type { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Comments { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsInvalid { get; set; }
    }
}
