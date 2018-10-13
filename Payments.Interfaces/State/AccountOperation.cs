using System;

namespace Payments.Interfaces.State
{
    [Serializable]
    public abstract class AccountOperation
    {
        private AccountOperation()
        {
        }

        public static AccountOperation NewCredit(decimal creditAmount)
        {
            return new ChoiceTypes.Credit(creditAmount);
        }

        public static AccountOperation NewDebit(decimal debitAmount)
        {
            return new ChoiceTypes.Debit(debitAmount);
        }

        public abstract TResult Match<TResult>(Func<decimal, TResult> creditFunc, Func<decimal, TResult> debitFunc);

        private static class ChoiceTypes
        {
            [Serializable]
            internal class Credit : AccountOperation
            {
                public Credit(decimal amount)
                {
                    Amount = amount;
                }

                private decimal Amount { get; }


                public override TResult Match<TResult>(Func<decimal, TResult> creditFunc, Func<decimal, TResult> debitFunc)
                {
                    return creditFunc(Amount);
                }

                public override string ToString()
                {
                    return $"Credit {Amount}";
                }
            }

            [Serializable]
            internal class Debit : AccountOperation
            {
                public Debit(decimal amount)
                {
                    Amount = amount;
                }

                private decimal Amount { get; }

                public override TResult Match<TResult>(Func<decimal, TResult> creditFunc, Func<decimal, TResult> debitFunc)
                {
                    return debitFunc(Amount);
                }
                public override string ToString()
                {
                    return $"Debit {Amount}";
                }
            }
        }
    }
}