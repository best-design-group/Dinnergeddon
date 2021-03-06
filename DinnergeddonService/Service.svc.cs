﻿using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace DinnergeddonService
{
    [ServiceBehavior]
    public class DinnergeddonService : IAccountService, IHighscoreService
    {
        private readonly IAccountController accountController;
        private readonly ILobbyController lobbyController;
        private readonly IHighscoreController highscoreController;

        public DinnergeddonService()
        {
            accountController = new AccountController();
            lobbyController = new LobbyController(LobbyContainer.GetInstance(), accountController);
            highscoreController = new HighscoreController();
        }

        /// <summary>
        /// This method adds a role to an account with accountId
        /// </summary>
        /// <param name="accountId">The id of the account that's to be added a role</param>
        /// <param name="roleName">The name of the role</param>
        /// <returns>If the operation was successful</returns>
        public bool AddToRole(Guid accountId, string roleName)
        {
            return accountController.AddToRole(accountId, roleName);
        }

        /// <summary>
        /// This method tries to find an account by searching for the email
        /// </summary>
        /// <param name="email">The email to be found</param>
        /// <returns>An account with email</returns>
        public Account FindByEmail(string email)
        {
            return accountController.FindByEmail(email);
        }

        /// <summary>
        /// This method tries to find an account by it's ID
        /// </summary>
        /// <param name="id">The id of an account</param>
        /// <returns>An account with ID</returns>
        public Account FindById(Guid id)
        {
            return accountController.FindById(id);
        }

        /// <summary>
        /// This method tries to find an acount by it's username
        /// </summary>
        /// <param name="username">The username of the account</param>
        /// <returns>An account with username</returns>
        public Account FindByUsername(string username)
        {
            return accountController.FindByUsername(username);
        }

        /// <summary>
        /// Gets all accounts on the system
        /// </summary>
        /// <returns>A list of all accounts saved on the database</returns>
        public IEnumerable<Account> GetAccounts()
        {
            return accountController.GetAccounts();
        }

        /// <summary>
        /// Gets all roles an account with accountId has
        /// </summary>
        /// <param name="accountId">The id of account</param>
        /// <returns>A list of all the roles an account with accountId has</returns>
        public IEnumerable<string> GetRoles(Guid accountId)
        {
            return accountController.GetAccountRoles(accountId);
        }

        /// <summary>
        /// This method adds a new account to the system
        /// </summary>
        /// <param name="account">An account to be added</param>
        /// <returns>If the account was added</returns>
        public bool InsertAccount(Account account)
        {
            return accountController.InsertAccount(account);
        }

        /// <summary>
        /// Checks if an account with accountId has a role with roleName
        /// </summary>
        /// <param name="accountId">The id of the account to be checked</param>
        /// <param name="roleName">The name of the role</param>
        /// <returns>If the account has this role</returns>
        public bool IsInRole(Guid accountId, string roleName)
        {
            return accountController.IsInRole(accountId, roleName);
        }

        /// <summary>
        /// Updates an account with new it's new information.
        /// Since the ID of an account is immutable (cannot change), the account that's going to be changed will be the one
        /// that has the ID of the account passed to this method
        /// </summary>
        /// <param name="updatedAccount">The new account informaiton</param>
        /// <returns>If the account was changed</returns>
        public bool UpdateAccount(Account updatedAccount)
        {
            return accountController.UpdateAccount(updatedAccount);
        }

        /// <summary>
        /// Deletes an already existing account from the system
        /// </summary>
        /// <param name="account">The account to be deleted</param>
        /// <returns>If the account was deleted successfuly</returns>
        public bool DeleteAccount(Account account)
        {
            return accountController.DeleteAccount(account);
        }

        /// <summary>
        /// Verifies that the credentials of an account are correct
        /// </summary>
        /// <param name="name">The username or email of the account</param>
        /// <param name="password">The password of the account</param>
        /// <returns>The accout that was authenticated</returns>
        public Account VerifyCredentials(string name, string password)
        {
            return accountController.VerifyCredentials(name, password);
        }

        public bool GetEmailConfirmed(Account account)
        {
            return accountController.GetEmailConfirmed(account);
        }

        public void SetEmailConfirmed(Account account, bool confirmed)
        {
            accountController.SetEmailConfirmed(account, confirmed);
        }

        public int GetHighscore(Guid accountId)
        {
            return highscoreController.GetHighscore(accountId);
        }

        public IDictionary<Guid, int> GetHighscores()
        {
            return highscoreController.GetHighscores();
        }

        public IDictionary<Guid, int> GetTopNHighscores(int n)
        {
            return highscoreController.GetHighscores(n);
        }

        public bool RemoveFromRole(Guid accountId, string roleName)
        {
            return accountController.RemoveFromRole(accountId, roleName);
        }

        public Lobby GetNewDummyLobby()
        {
            return new Lobby();
        }
    }
}