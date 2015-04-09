using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

using SuiteEvents.Common.Infrastructures;
using SuiteEvents.Common.Infrastructures.Modules;
using SuiteEvents.Common.Resources.Applications;
using SuiteEvents.Modules.ModuloUtenti.Utenti.Interfaces;
using SuiteEvents.ReadModel.Dtos;
using SuiteEvents.Providers.Abstracts;

namespace SuiteEvents.Modules.ModuloUtenti.Utenti.ViewModels
{
    internal class ModuloUtentiViewModel : ViewModel, IModuloUtentiViewModel
    {
        private readonly ModuloUtentiController _moduloUtentiController;
        private readonly ISuiteUsersProvider _suiteUsersProvider;

        private readonly ICommand _goBackCommand;
        private readonly ICommand _creaUtenteCommand;
        private readonly ICommand _salvaUtenteCommand;
        private readonly ICommand _rimuoviUtenteCommand;

        private ObservableCollection<SuiteUsers> _anagraficaUtenti;

        private SuiteUsers _selectedUser;
        
        public ModuloUtentiViewModel(IModulesUtenti moduloUtentiController,
            ISuiteUsersProvider suiteUsersProvider)
        {
            this._moduloUtentiController = (ModuloUtentiController) moduloUtentiController;
            this._suiteUsersProvider = suiteUsersProvider;

            this._goBackCommand = new CommandModel(this.OnGoBackCommand);
            this._creaUtenteCommand = new CommandModel(this.OnCreaUtenteCommand);
            this._salvaUtenteCommand = new CommandModel(this.OnSalvaUtenteCommand);
            this._rimuoviUtenteCommand = new CommandModel(this.OnRimuoviUtenteCommand);
        }

        #region Public Properties
        public ObservableCollection<SuiteUsers> AnagraficaUtenti
        {
            get 
            {
                return this._anagraficaUtenti ?? (this._anagraficaUtenti = new ObservableCollection<SuiteUsers>());
            }
            set
            {
                if (this._anagraficaUtenti == value) return;

                this._anagraficaUtenti = value;
                this.InvokePropertyChanged("AnagraficaUtenti");
            }
        }

        public SuiteUsers SelectedUser
        {
            get { return this._selectedUser; }
            set
            {
                if (this._selectedUser == value) return;

                this._selectedUser = value;
                this.InvokePropertyChanged("SelectedUser");
            }
        }
        #endregion

        #region Command
        public ICommand GoBackCommand
        {
            get { return this._goBackCommand; }
        }

        public ICommand CreaUtenteCommand
        {
            get { return this._creaUtenteCommand; }
        }

        public ICommand SalvaUtenteCommand
        {
            get { return this._salvaUtenteCommand; }
        }

        public ICommand RimuoviUtenteCommand
        {
            get { return this._rimuoviUtenteCommand; }
        }

        private void OnGoBackCommand(object parameter)
        {
            this._moduloUtentiController.InvokeCloseModuloUtenti(parameter);
        }

        private void OnCreaUtenteCommand(object parameter)
        {
            this.CreaNuovoUtente();
        }

        private void OnSalvaUtenteCommand(object parameter)
        {
            this.SalvaUtente();
        }

        private void OnRimuoviUtenteCommand(object parameter)
        { }
        #endregion

        #region Helpers
        private void CreaNuovoUtente()
        {
            this.SelectedUser = new SuiteUsers(Guid.NewGuid(), Configuration.Configuration.SuiteEventsSection.SuiteEventsApplicationName);

            this.AnagraficaUtenti.Add(this.SelectedUser);
        }

        private void SalvaUtente()
        {
            if (this.SelectedUser == null) return;

            if (String.IsNullOrEmpty(this.SelectedUser.UserName) || 
                String.IsNullOrWhiteSpace(this.SelectedUser.UserName))
            {
                MessageBox.Show(ExceptionResources.UserNameNullException,
                    "UserName");
                return;
            }
            
            if (String.IsNullOrEmpty(this.SelectedUser.Password) ||
                String.IsNullOrWhiteSpace(this.SelectedUser.Password))
            {
                MessageBox.Show(ExceptionResources.PasswordNullException,
                    "Password");
                return;
            }

            if (String.IsNullOrEmpty(this.SelectedUser.Nome) || 
                String.IsNullOrWhiteSpace(this.SelectedUser.Nome))
            {
                MessageBox.Show(ExceptionResources.NomeNullException, "Nome");
                return;
            }

            if (String.IsNullOrEmpty(this.SelectedUser.Cognome) ||
                String.IsNullOrWhiteSpace(this.SelectedUser.Cognome))
            {
                MessageBox.Show(ExceptionResources.CognomeNullException, "Cognome");
                return;
            }

            this._suiteUsersProvider.CreateSuiteUser(this.SelectedUser.UserName, this.SelectedUser.Password, this.SelectedUser.ApplicationName, 
                this.SelectedUser.Nome, this.SelectedUser.Cognome, this.SelectedUser.Email);
        }
        #endregion
    }
}
