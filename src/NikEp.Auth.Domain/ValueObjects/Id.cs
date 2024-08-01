

namespace NikEp.Auth.Domain.ValueObjects
{
    public record class Id
    {
        private long DatacenterId { get; set; }
        private long InstanceId { get; set; }
        public DateTime Date { get; set; }

        public Id(long datacenterId, long instanceId, DateTime date)
        {

            DatacenterId = datacenterId;
            InstanceId = instanceId;
            Date = date;
        }
    }
}

