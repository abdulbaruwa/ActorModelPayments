using System;

namespace Payments.Interfaces.Eventing
{
    public interface ICanApplyEvent<TEvent, TState>
    {
        TState ApplyEvent(TimestampedValue<TEvent> value, TState currentState);
    }


    [Serializable]
    public class TimestampedValue<TValue>
    {
        public TimestampedValue(TValue value, DateTime timestamp)
        {
            Timestamp = timestamp;
            Value = value;
        }

        public DateTime Timestamp { get; set; }
        public TValue Value { get; set; }

        public override string ToString() => $"[At {Timestamp:O}] : {Value}";
    }
}