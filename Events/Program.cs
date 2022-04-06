﻿using System;

namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var transaction = new Transaction();
            transaction.TransactionComplete += AfterComplete;
            transaction.StartTransaction();
        }

        private static void AfterComplete(object sender, EventArgs e)
        {
            Console.WriteLine("Completed");
        }
    }

    //public delegate void Notify();

    public class Transaction
    {
        public event EventHandler TransactionComplete;

        public void StartTransaction()
        {
            //Do something;
            OnTransactionComplete();

        }

        protected virtual void OnTransactionComplete()
        {
            TransactionComplete?.Invoke(this, EventArgs.Empty);
        }
    }
}
