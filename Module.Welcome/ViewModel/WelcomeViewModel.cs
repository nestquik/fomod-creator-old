﻿using System;
using System.Windows.Input;
using FomodInfrastructure;
using FomodInfrastructure.Interface;
using FomodInfrastructure.MvvmLibrary.Commands;
using FomodModel.Base;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.ServiceLocation;
using Module.Welcome.PrismEvent;
using Prism.Events;

namespace Module.Welcome.ViewModel
{
    public class WelcomeViewModel
    {
        public WelcomeViewModel(IAppService appService, IDialogCoordinator dialogCoordinator, IEventAggregator eventAggregator, IServiceLocator serviceLocator)
        {
            _appService = appService;
            _dialogCoordinator = dialogCoordinator;
            _serviceLocator = serviceLocator;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenLink>().Subscribe(OpenProject);
        }

        public string Header { get; } = "Welcome";

        #region Services

        private readonly IAppService _appService;

        private readonly IDialogCoordinator _dialogCoordinator;

        private readonly IEventAggregator _eventAggregator;

        private readonly IServiceLocator _serviceLocator;

        #endregion

        #region Commands

        private ICommand _closeApplicationCommand;

        public ICommand CloseApplicationCommand
        {
            get { return _closeApplicationCommand ?? (_closeApplicationCommand = new RelayCommand(_appService.CloseApp)); }
        }

        private ICommand _createProjectCommand;

        public ICommand CreateProjectCommand
        {
            get { return _createProjectCommand ?? (_createProjectCommand = new RelayCommand(CreateProject)); }
        }

        private ICommand _openProjectCommand;

        public ICommand OpenProjectCommand
        {
            get { return _openProjectCommand ?? (_openProjectCommand = new RelayCommand<string>(OpenProject)); }
        }

        #endregion

        #region Methods

        private async void CreateProject()
        {
            var repository = _serviceLocator.GetInstance<IRepository<ProjectRoot>>();
            var path = repository.CreateData();
            switch (repository.RepositoryStatus)
            {
                case RepositoryStatus.FolderIsAlreadyUsed:
                    await _dialogCoordinator.ShowMessageAsync(this, "Error", "Folder already used."); //TODO: Localize
                    break;
                case RepositoryStatus.Ok:
                    OpenProject(path);
                    break;
                case RepositoryStatus.Cancel:
                    break;
                case RepositoryStatus.None:
                    break;
                case RepositoryStatus.Error:
                    await _dialogCoordinator.ShowMessageAsync(this, "Error", "An error occurred while creating the project."); //TODO: Localize
                    break;
                case RepositoryStatus.CantUseFolder:
                    await _dialogCoordinator.ShowMessageAsync(this, "Error", "The specified folder doesn't correspond to necessary requirements."); //TODO: Localize
                    break;
                default:
                    throw new ApplicationException();
            }
        }

        private async void OpenProject(string p)
        {
            var repository = _serviceLocator.GetInstance<IRepository<ProjectRoot>>();
            var x = repository.LoadData(p);
            if (x == null)
            {
                switch (repository.RepositoryStatus)
                {
                    case RepositoryStatus.CantUseFolder:
                        if(!_appService.IsOpenProjectsFromCommandLine)
                            await _dialogCoordinator.ShowMessageAsync(this, "Error", "The specified folder doesn't correspond to necessary requirements."); //TODO: Localize
                        break;
                    case RepositoryStatus.Error:
                        if (!_appService.IsOpenProjectsFromCommandLine)
                            await _dialogCoordinator.ShowMessageAsync(this, "Error", "An error occured while loading the project folder."); //TODO: Localize
                        break;
                    case RepositoryStatus.Cancel:
                        break;
                    case RepositoryStatus.None:
                        break;
                    case RepositoryStatus.Ok:
                        break;
                    case RepositoryStatus.FolderIsAlreadyUsed:
                        break;
                    default:
                        throw new ApplicationException();
                }
            }
            else
            {
                _appService.CreateEditorModule(repository);
                _eventAggregator.GetEvent<OpenProjectEvent>().Publish(x);
            }
        }

        #endregion
    }
}