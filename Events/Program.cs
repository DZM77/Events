using System;

namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var transaction = new Transaction();
            transaction.TransactionComplete += AfterComplete;
            transaction.StartTransaction(true);
        }

        private static void AfterComplete(object sender, string e)
        {
            Console.WriteLine($"Completed message: {e}");
        }
    }

    //public delegate void Notify();

    public class Transaction
    {
        public event EventHandler<string> TransactionComplete;

        public void StartTransaction(bool ok)
        {

            //Do something;
            if (ok)
            {
                OnTransactionComplete("All ok");
            }
            else
            {
                OnTransactionComplete("Failed");

            }

        }

        protected virtual void OnTransactionComplete(string message)
        {
            TransactionComplete?.Invoke(this, message);
        }
    }
}
