using System;

namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var transaction = new Transaction();
            transaction.TransactionComplete += AfterComplete;
            transaction.StartTransaction(false);
        }

        private static void AfterComplete(object sender, TransactionEventArgs e)
        {
            Console.WriteLine($"Completed: {e.Ok}, message: {e.Message}");
        }
    }

    //public delegate void Notify();

    public class Transaction
    {
        public event EventHandler<TransactionEventArgs> TransactionComplete;

        public void StartTransaction(bool ok)
        {

            //Do something;
            if (ok)
            {
                OnTransactionComplete("All ok", true);
            }
            else
            {
                OnTransactionComplete("Failed", false);

            }

        }

        protected virtual void OnTransactionComplete(string message, bool ok)
        {
            var eventArgs = new TransactionEventArgs
            {
                Ok = ok,
                Message = message
            };

            TransactionComplete?.Invoke(this, eventArgs);
        }
    }

    public class TransactionEventArgs : EventArgs
    {
        public string Message { get; set; }
        public bool Ok { get; set; }
    }
}
