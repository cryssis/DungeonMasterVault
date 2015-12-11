// <copyright file="SampleDataService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Services.DataServices
{
    using System.Collections.Generic;
    using System.Linq;
    using DungeonMasterVault.Core.Encounters;

    /// <summary>
    /// A class for DesignTime data
    /// </summary>
    public class SampleDataService : IDataService
    {
        private List<Encounter> encounters;

        /// <summary>
        /// Initializes a new instance of the <see cref="SampleDataService"/> class.
        /// </summary>
        public SampleDataService()
        {
            this.InitEncounters();
        }

        /// <inheritdoc />
        public Encounter GetEncounter(string id)
        {
            return this.encounters.Where(x => x.ID == id).FirstOrDefault();
        }

        /// <inheritdoc />
        public IEnumerable<Encounter> GetEncounters()
        {
            return this.encounters;
        }

        /// <summary>
        /// Initializes the internal encounter list
        /// </summary>
        private void InitEncounters()
        {
            this.encounters = (from n in Enumerable.Range(1, 3)
                               select new Encounter
                               {
                                   ID = "R" + n,
                                   Name = "R" + n + ". Sample Encounter",
                                   Adventure = "Runtime Adventure",
                                   Budget = new long?(100)
                               }).ToList<Encounter>();
        }
    }
}