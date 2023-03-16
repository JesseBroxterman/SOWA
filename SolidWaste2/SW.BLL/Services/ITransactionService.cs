﻿using SW.BLL.DTOs;
using SW.DM;

namespace SW.BLL.Services
{
    public interface ITransactionService
    {
        Task AddTransaction(Transaction transaction);
        Task<ICollection<Transaction>> GetByCustomer(int customerId);
        Task<decimal> GetCurrentBalance(int customerId);
        Task<Transaction> GetLatest(int customerId);
        Task<Transaction> GetById(int transactionId);
        Task AddKanpayTransaction(Transaction transaction, TransactionKanPayFee fee, int kanpayid, string user);

        // Transaction 
        Task<Transaction> GetLatesetTransaction(int customerId);

        // Delinquency 
        Task<decimal> GetRemainingBalanceFromLastBill(int customerId);
        Task<decimal> GetPastDueAmount(int customerId);
        Task<decimal> Get30DaysPastDueAmount(int customerId);
        Task<decimal> Get60DaysPastDueAmount(int customerId);
        Task<decimal> Get90DaysPastDueAmount(int customerId);
        Task<decimal> GetRemainingCurrentBalance(DateTime date, int days, int customerId);
        Task<decimal> GetCollectionsBalance(int customerId);
        Task<decimal> GetCounselorsBalance(int customerId);
        Task<ICollection<CustomerDelinquency>> GetAllDelinquencies();
        Task<ICollection<Transaction>> GetPayments(DateTime thruDate, Transaction bill);
    }
}
