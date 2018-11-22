﻿using Model;
using Controller;
using System;
using System.Collections.Generic;

namespace DinnergeddonService
{
    public class AccountService : IAccontService
    {
        private readonly IAccountController accountController;
        
        public AccountService()
        {
            accountController = new AccountController();
        }

        public bool AddToRole(Guid accountId, string roleName)
        {
            return accountController.AddToRole(accountId, roleName);
        }

        public Account FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Account FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Account FindByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetRoles(Guid accountId)
        {
            throw new NotImplementedException();
        }

        public bool InsertAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public bool IsInRole(Guid accountId, string roleName)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAccount(Account updatedAccount)
        {
            throw new NotImplementedException();
        }
    }
}