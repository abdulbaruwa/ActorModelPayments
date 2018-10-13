using System;
using Payments.Interfaces.Eventing;

namespace Payments.Interfaces.State
{
    [Serializable]
    public class AccountState : ICanApplyEvent<AccountOperation, AccountState>
    {
        public AccountState(decimal balance)
        {
            Balance = balance;
        }

        public AccountState() : this(0.0m)
        {
        }

        public decimal Balance { get; }


        public AccountState ApplyEvent(TimestampedValue<AccountOperation> value, AccountState currentState)
        {
            return value.Value.Match(Credit(currentState), Debit(currentState));
        }

        private Func<decimal, AccountState> Debit(AccountState currentState)
        {
            return  amount => new AccountState(currentState.Balance - amount);
        }

        private static Func<decimal, AccountState> Credit(AccountState current)
        {
            return amount => new AccountState(current.Balance + amount);
        }
    }
}