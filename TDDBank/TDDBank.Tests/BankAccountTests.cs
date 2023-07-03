namespace TDDBank.Tests
{
    public class BankAccountTests
    {

        /// Bankkonto
        //- Kontostand abfragen
        //- Betrag einzahlen(nicht Negativ)
        //- Betrag abheben(nicht Negativ)
        //	- Darf nicht unter 0 fallen
        //- Neues Konto hat 0 als Kontostand
        [Fact]
        public void New_account_should_have_0_as_balance()
        {
            var ba = new BankAccount();

            Assert.Equal(0, ba.Balance);
        }

        [Fact]
        public void Deposit_should_add_to_balance()
        {
            var ba = new BankAccount();

            ba.Deposit(6m);
            ba.Deposit(3m);

            Assert.Equal(9m, ba.Balance);
        }

        [Fact]
        public void Deposit_a_negative_or_zero_amount_throws_ArgumentException()
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Deposit(-1));
            Assert.Throws<ArgumentException>(() => ba.Deposit(0));
        }

        [Fact]
        public void Withdraw_should_substract_from_balance()
        {
            var ba = new BankAccount();
            ba.Deposit(12m);

            ba.Withdraw(3m);

            Assert.Equal(9m, ba.Balance);

            ba.Withdraw(9m);

            Assert.Equal(0m, ba.Balance);
        }

        [Fact]
        public void Withdraw_a_negative_or_zero_amount_throws_ArgumentException()
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Withdraw(-1));
            Assert.Throws<ArgumentException>(() => ba.Withdraw(0));
        }

        [Fact]
        public void Withdraw_more_than_balance_throws_InvalidOpException()
        {
            var ba = new BankAccount();
            ba.Deposit(12m);

            Assert.Throws<InvalidOperationException>(() => ba.Withdraw(13m));
        }
    }
}