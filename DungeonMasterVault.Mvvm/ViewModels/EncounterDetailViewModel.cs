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
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// A ViewModel for the Encounter Detail
    /// </summary>
    public class EncounterDetailViewModel : ViewModelBase
    {
        private Encounter selectedEncounter;

        /// <summary>
        /// Initializes a new instance of the <see cref="EncounterDetailViewModel"/> class.
        /// </summary>
        public EncounterDetailViewModel()
        {
            if (this.IsInDesignMode)
            {
                this.LoadDesignTimeData();
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
            var encounters = this.GetSampleRuntimeItems();
            var e = encounters.Where(x => x.ID == id).FirstOrDefault();
            this.SelectedEncounter = e;
        }

        /// <inheritdoc/>
        protected override void LoadDesignTimeData()
        {
            base.LoadDesignTimeData();

            this.SelectedEncounter = new Encounter()
            {
                ID = "DS" + 1,
                Name = "DS" + 1 + ". Design Time Encounter",
                Adventure = "Design Adventure"
            };
        }

        /// <summary>
        /// Gets a List of the sample runtime encounters.
        /// </summary>
        /// <returns>A List of Sample encounters</returns>
        private List<Encounter> GetSampleRuntimeItems()
        {
            var encounters = new List<Encounter>();
            for (var i = 1; i < 35; i++)
            {
                var encounter = new Encounter()
                {
                    ID = "R" + i,
                    Name = "R" + i + ". Sample Encounter",
                    Adventure = "Runtime Adventure"
                };
                encounters.Add(encounter);
            }

            return encounters;
        }
    }
}
