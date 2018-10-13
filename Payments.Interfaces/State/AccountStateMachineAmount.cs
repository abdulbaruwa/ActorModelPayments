using System;

namespace Payments.Interfaces.State
{
    [Serializable]
    public class AccountStateMachineAmount : IComparable
    {
        public AccountStateMachineAmount():this(decimal.Zero)
        {
        }

        private AccountStateMachineAmount(decimal value)
        {
            Value = value;
            if(value < 0.0M) throw new ArgumentOutOfRangeException(nameof(value), value, "cannot be less than zero");
        }

        public decimal Value { get; }
        public int CompareTo(object obj)
        {
            var otherAmount = obj as AccountStateMachineAmount;
            return Value.CompareTo(otherAmount?.Value ?? decimal.MinusOne);
        }

        protected bool Equals(AccountStateMachineAmount other)
        {
            return Equals((object) other);
        }



    }
}