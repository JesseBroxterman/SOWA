﻿using SW.DM;

namespace SW.BLL.Services;

public interface ITransactionCodeRuleService
{
    Task<ICollection<TransactionCodeRule>> GetByTransactionCodeId(int transactionCodeId);
    Task<ICollection<TransactionCodeRule>> GetByContainerAndTransactionCode(Container container, int transactionCodeId);
}
