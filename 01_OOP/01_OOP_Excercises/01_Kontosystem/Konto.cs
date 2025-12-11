using System.Buffers;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;

namespace _01_Kontosystem
{
    public class Konto
    {
        public User Owner { get; }
        public float Balance { get; private set; }
        public float Fee { get; private set; }

        public Konto(User owner, float fee = 0, float initialBalance = 0)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            if (fee < 0) throw new ArgumentOutOfRangeException(
                nameof(fee), "Gebühr darf nicht negativ sein");
            if (initialBalance < 0) throw new ArgumentOutOfRangeException(
                nameof(initialBalance), "Startsaldo darf nicht negativ sein");
            Fee = fee;
            Balance = initialBalance;
        }
        public void Deposit(float amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(
                nameof(amount), "Betrag muss größer 0 sein");
            Balance += amount;
        }

        public bool TryWithdraw(float amount, out string error)
        {
            error = string.Empty;

            if (amount <= 0)
            {
                error = "Betrag muss größer 0 sein";
                return false;
            }
            float total = amount + Fee;
            if (total > Balance)
            {
                error = "Zu wenig Guthaben (mit Gebühr)";
                return false;
            }
            Balance -= total;
            return true;
        }
    }
}