// <copyright file="SampleDataService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Services.DataServices
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Core.Dice;
    using DungeonMasterVault.Core.Encounters;

    /// <summary>
    /// A class for DesignTime data
    /// </summary>
    public class SampleDataService : IDataService
    {
        private ObservableCollection<Adventure> allAdventures = new ObservableCollection<Adventure>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SampleDataService"/> class.
        /// </summary>
        public SampleDataService()
        {
            this.allAdventures = new ObservableCollection<Adventure>();

            var advDice = new DieRoll(1, 4, 1);
            var encDice = new DieRoll(2, 6, 3);

            var adventures = from a in Enumerable.Range(1, advDice.Roll().Total)
                             select new Adventure
                             {
                                 Code = "A" + a.ToString(),
                                 Title = "Adventure " + a.ToString(),
                             };

            foreach (var a in adventures)
            {
                a.Encounters = new ObservableCollection<Encounter>();

                var max = encDice.Roll().Total;

                for (int e = 1; e <= max; e++)
                {
                    var encounter = new Encounter()
                    {
                        ID = a.Code + "." + "R" + e,
                        Name = a.Code + "." + "R" + e + ". RunTime Encounter",
                        Adventure = a.Code,
                        Budget = new long?(100)
                    };
                    a.Encounters.Add(encounter);
                }

                this.allAdventures.Add(a);
            }
        }

        /// <summary>
        /// Gets a collection of all adventures
        /// </summary>
        public ObservableCollection<Adventure> AllAdventures
        {
            get { return this.allAdventures; }
        }

        /// <inheritdoc />
        public IEnumerable<Adventure> GetAdventures()
        {
            return this.allAdventures;
        }

        /// <inheritdoc />
        public Adventure GetAdventure(string code)
        {
            var matches = this.allAdventures.Where((adventure) => adventure.Code.Equals(code));
            if (matches.Count() == 1)
            {
                return matches.First();
            }

            return null;
        }

        /// <inheritdoc />
        public Encounter GetEncounter(string id)
        {
            var matches = this.allAdventures.SelectMany(adventure => adventure.Encounters).Where((encounter) => encounter.ID.Equals(id));
            if (matches.Count() == 1)
            {
                return matches.First();
            }

            return null;
        }
    }
}