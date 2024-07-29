
namespace NikEp.Auth.Domain.ValueObjects
{
    public record class Id
    {
        private const int TimestampBits = 40;
        private const int DatacenterBits = 4;
        private const int InstanceBits = 8;
        private const int SequenceBits = 11;

        private long _sequence = 0L;

        private long DatacenterId { get; set; }
        private long InstanceId { get; set; }
        public DateTime Date { get; set; }

        public Id(long datacenterId, long instanceId, DateTime date)
        {

            DatacenterId = datacenterId;
            InstanceId = instanceId;
            Date = date;
        }

        public long GenerateID(DateTime date, int dataId, int instanceNumber)
        {
            var timestamp = GetTimestamp();
            var rnd = new Random();
            _sequence = (instanceNumber+rnd.Next());

            return ((timestamp << (DatacenterBits + InstanceBits + SequenceBits))
                    | (DatacenterId << (InstanceBits + SequenceBits))
                    | (InstanceId << SequenceBits)
                    | _sequence);
        }
        private long GetTimestamp()
        {
            return (long)(DateTime.UtcNow - Date).TotalMilliseconds;
        }
    }
}

