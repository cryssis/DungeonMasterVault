// <copyright file="EncountersViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Mvvm.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using DungeonMasterVault.Core.Encounters;
    using GalaSoft.MvvmLight.Command;
    using Services.DataServices;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// A ViewModel for a encounters collection
    /// </summary>
    public class EncountersViewModel : ViewModelBase
    {
        private readonly IDataService dataService;
        private List<Adventure> adventures;
        private ObservableCollection<Encounter> encounters;
        private RelayCommand<Encounter> gotoEncounterCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="EncountersViewModel"/> class.
        /// </summary>
        /// <param name="dataService">The Injected DataService</param>
        public EncountersViewModel(IDataService dataService)
        {
            this.dataService = dataService;

            if (GalaSoft.MvvmLight.ViewModelBase.IsInDesignModeStatic)
            {
                this.Encounters = new ObservableCollection<Encounter>(dataService.GetEncounters());

                var adventures = this.encounters.GroupBy(x => x.Adventure)
                    .Select(x => new Adventure { Title = x.Key, Encounters = x.ToList() });
                this.adventures = adventures.ToList();
            }
        }

        /// <summary>
        /// Gets or sets the Adventure groups
        /// </summary>
        public List<Adventure> Adventures { get; set; }

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
        public RelayCommand<Encounter> GoToEncounterCommand
        {
            get
            {
                return this.gotoEncounterCommand ?? (this.gotoEncounterCommand = new RelayCommand<Encounter>((selectedItem) =>
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
            this.Encounters = new ObservableCollection<Encounter>(this.dataService.GetEncounters());
            var adventures = this.encounters.GroupBy(x => x.Adventure)
                    .Select(x => new Adventure { Title = x.Key, Encounters = x.ToList() });
            this.adventures = adventures.ToList();

            base.OnNavigatedTo(parameter, mode, state);
        }
    }
}