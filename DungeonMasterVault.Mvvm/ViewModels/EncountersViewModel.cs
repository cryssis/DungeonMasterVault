// <copyright file="EncountersViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Mvvm.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using DungeonMasterVault.Core.Encounters;
    using GalaSoft.MvvmLight.Command;
    using Services.DataServices;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// A ViewModel for a encounters collection
    /// </summary>
    public class EncountersViewModel : ViewModelBase
    {
        private ObservableCollection<Encounter> encounters;
        private RelayCommand<Encounter> selectEncounterCommand;
        private readonly IDataService dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EncountersViewModel"/> class.
        /// </summary>
        public EncountersViewModel(IDataService dataService)
        {
            this.dataService = dataService;

            if (GalaSoft.MvvmLight.ViewModelBase.IsInDesignModeStatic)
            {
                encounters = new ObservableCollection<Encounter>(dataService.GetEncounters());
            }
        }

        /// <summary>
        /// Gets or sets the encounter collection
        /// </summary>
        public ObservableCollection<Encounter> Encounters
        {
            get { return this.encounters; }
            set { this.Set(ref this.encounters, value); }
        }

        /// <summary>
        /// Gets the selected encounter
        /// </summary>
        public RelayCommand<Encounter> SelectEncounterCommand
        {
            get
            {
                return this.selectEncounterCommand ?? (this.selectEncounterCommand = new RelayCommand<Encounter>((selectedItem) =>
                {
                    if (selectedItem == null)
                    {
                        return;
                    }

                    this.NavigationService.Navigate(Pages.EncounterDetail, selectedItem.ID);
                }));
            }
        }

        /// <summary>
        /// Implementation of OnNavigatedTo
        /// </summary>
        /// <param name="parameter">The parameters of the navigation</param>
        /// <param name="mode">The navigation Mode</param>
        /// <param name="state">THe state of the app</param>
        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            // Load real data
            encounters = new ObservableCollection<Encounter>(dataService.GetEncounters());

            base.OnNavigatedTo(parameter, mode, state);
        }
    }
}