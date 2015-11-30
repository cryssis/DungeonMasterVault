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

    /// <summary>
    /// A ViewModel for a encounters collection
    /// </summary>
    public class EncountersViewModel : ViewModelBase
    {
        private ObservableCollection<Encounter> encounters;
        private RelayCommand<Encounter> selectEncounterCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="EncountersViewModel"/> class.
        /// </summary>
        public EncountersViewModel()
        {
            if (this.IsInDesignMode)
            {
                this.LoadDesignTimeData();
            }
            else
            {
                this.encounters = new ObservableCollection<Encounter>(this.GetSampleRuntimeItems());
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

        /// <inheritdoc/>
        protected override void LoadDesignTimeData()
        {
            base.LoadDesignTimeData();

            for (var i = 1; i < 10; i++)
            {
                var encounter = new Encounter()
                {
                    ID = "DS" + i.ToString(),
                    Name = "DS" + i.ToString() + ". Design Time Encounter",
                    Adventure = "Design Adventure"
                };
                this.Encounters.Add(encounter);
            }
        }

        /// <summary>
        /// Gets a list of sample encounters for runtime
        /// </summary>
        /// <returns>A list of sample encounters</returns>
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
