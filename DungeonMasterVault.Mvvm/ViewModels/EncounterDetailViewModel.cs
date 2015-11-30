// <copyright file="EncounterDetailViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Mvvm.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using DungeonMasterVault.Core.Encounters;
    using Services.DataServices;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// A ViewModel for the Encounter Detail
    /// </summary>
    public class EncounterDetailViewModel : ViewModelBase
    {
        private Encounter selectedEncounter;
        private IDataService dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EncounterDetailViewModel"/> class.
        /// </summary>
        public EncounterDetailViewModel(IDataService dataService)
        {
            this.dataService = dataService;

            if (GalaSoft.MvvmLight.ViewModelBase.IsInDesignModeStatic)
            {
                selectedEncounter = dataService.GetEncounter(string.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the SelectedEncounter
        /// </summary>
        public Encounter SelectedEncounter
        {
            get { return this.selectedEncounter; }
            set { this.Set(ref this.selectedEncounter, value); }
        }

        /// <summary>
        /// OnNavigatedTo implementation for Encounter Detail View Model.
        /// </summary>
        /// <param name="parameter">the parameter.</param>
        /// <param name="mode">the mode.</param>
        /// <param name="state">the state.</param>
        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            base.OnNavigatedTo(parameter, mode, state);

            string id = (string)parameter;
            this.SelectedEncounter = dataService.GetEncounter(id);
        }
    }
}