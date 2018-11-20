﻿using Model;
using System.Collections.Generic;
using System;

namespace DBLayer
{
    public interface IAccountRepo
    {
        IEnumerable<Account> GetAccounts();

        Account GetAccountByID(Guid accountID);
        Account GetAccountByUsername(string username);
        Account GetAccountByEmail(string email);

        int InsertAccount(Account a);
        int DeleteAccount(Account a);
        int UpdateAccount(Account oldAccount, Account newAccount);

        void AddToRole(Guid accountID, string roleName);
        bool IsInsideRole(Guid accountID, string roleName);
    }
}
