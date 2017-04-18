using System;
using DDD.CommercePoC.SharedKernel.Extensions;
using DDD.CommercePoC.SharedKernel.Model;

namespace DDD.CommercePoC.Shop.Core.Model.ValueObjects
{
    public sealed class Money : ValueObject<Money>
    {
        public Money(Currency currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }

        // ReSharper disable once UnusedMember.Local : Required by EF
        private Money() { }

        public Currency Currency { get; private set; }

        public decimal Amount { get; private set; }

        public override string ToString()
        {
            return string.Format(Currency.Description(), Amount);
        }

        public static Money operator +(Money x, Money y)
        {
            if (x.Currency != y.Currency)
                throw new ArgumentException("Cannot add Money of different currency!");

            return new Money(x.Currency, x.Amount + y.Amount);
        }

        public static Money operator -(Money x, Money y)
        {
            if (x.Currency != y.Currency)
                throw new ArgumentException("Cannot substract Money of different currency!");

            return new Money(x.Currency, x.Amount - y.Amount);
        }

        public static Money operator *(Money x, decimal factor)
        {
            return new Money(x.Currency, x.Amount * factor);
        }

        public static Money operator /(Money x, decimal divider)
        {
            if (divider == 0)
                throw new DivideByZeroException("You cannot divide Money with 0");

            return new Money(x.Currency, x.Amount / divider);
        }
    }
}