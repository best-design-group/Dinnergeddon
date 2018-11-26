﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using DinnergeddonUI.DinnergeddonService;

namespace DinnergeddonUI
{
    class DashboardViewModel : INotifyPropertyChanged
    {
        private readonly IAuthenticationService _authenticationService;
        private string _username;
        private readonly DelegateCommand _joinLobbyCommand;
        private readonly DelegateCommand _logoutCommand;
        LobbyServiceClient _proxy = new LobbyServiceClient();



        public DashboardViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _logoutCommand = new DelegateCommand(Logout, CanLogout);
            _joinLobbyCommand = new DelegateCommand(JoinLobby, CanJoin);

        }

        public DelegateCommand JoinLobbyCommand { get { return _joinLobbyCommand; } }
        public DelegateCommand LogoutCommand { get { return _logoutCommand; } }


        public string Username
        {
            get { return _username; }
            set { _username = value; NotifyPropertyChanged("Username"); }
        }

        private bool CanLogout(object parameter)
        {
            return IsAuthenticated;
        }

        private bool CanJoin(object parameter)
        {
            //implement check
            return true;
        }

        public string AuthenticatedUser
        {
            get
            {
                if (IsAuthenticated)
                    return string.Format("Signed in as {0}. {1}",
                          Thread.CurrentPrincipal.Identity.Name,
                          Thread.CurrentPrincipal.IsInRole("admin") ? "You are an administrator!"
                              : "You are NOT a member of the administrators group.");

                return "Not authenticated!";
            }
        }

        public bool IsAuthenticated
        {
            get { return Thread.CurrentPrincipal.Identity.IsAuthenticated; }
        }

        private void JoinLobby(object parameter)
        {
            Guid lobbyId = (Guid)parameter;
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            var userId = customPrincipal.Identity.Id;
            _proxy.JoinLobby(userId, lobbyId);

            Window lobby = new LobbyWindow(lobbyId);
            lobby.Show();

        }
        private void Logout(object parameter)
        {
            Window dashboard = parameter as Window;
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal != null)
            {
                customPrincipal.Identity = new AnonymousIdentity();
                NotifyPropertyChanged("AuthenticatedUser");
                NotifyPropertyChanged("IsAuthenticated");
                // _loginCommand.RaiseCanExecuteChanged();
                _logoutCommand.RaiseCanExecuteChanged();
                dashboard.Close();
                //MainWindow mw = new MainWindow();
                //mw.Show();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<EventArgs> RequestClose;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}