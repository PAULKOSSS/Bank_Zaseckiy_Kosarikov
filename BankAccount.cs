using System;

namespace BankAccountNS
{
    /// <summary>
    /// Демонстрационный класс банковского счёта.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        private BankAccount() { }

        /// <summary>
        /// Инициализирует новый экземпляр класса BankAccount с указанными именем клиента и балансом.
        /// </summary>
        /// <param name="customerName">Имя владельца счёта</param>
        /// <param name="balance">Начальный баланс</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Возвращает имя владельца счёта.
        /// </summary>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Возвращает текущий баланс счёта.
        /// </summary>
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Снимает указанную сумму со счёта.
        /// </summary>
        /// <param name="amount">Сумма снятия</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Выбрасывается, если сумма меньше нуля или превышает текущий баланс.
        /// </exception>
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }
            m_balance -= amount;
        }

        /// <summary>
        /// Вносит указанную сумму на счёт.
        /// </summary>
        /// <param name="amount">Сумма пополнения</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Выбрасывается, если сумма меньше нуля.
        /// </exception>
        public void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            m_balance += amount;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
            Console.ReadLine();
        }
    }
}