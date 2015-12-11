// <copyright file="DesignTimeDataService.cs" company="Roberto Sobreviela">
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
    public class DesignTimeDataService : IDataService
    {
        /// <inheritdoc />
        public Encounter GetEncounter(string id)
        {
            return new Encounter()
            {
                ID = "DS" + 1,
                Name = "DS" + 1 + ". Design Time Encounter",
                Adventure = "Design Adventure",
                Budget = new long?(100)
            };
        }

        /// <inheritdoc />
        public IEnumerable<Encounter> GetEncounters()
        {
            return (from n in Enumerable.Range(1, 3)
                    select new Encounter
                    {
                        ID = "DS" + n.ToString(),
                        Name = "DS" + n.ToString() + ". Design Time Encounter",
                        Adventure = "Design Adventure",
                        Budget = new long?(100)
                    }).ToList<Encounter>();
        }
    }
}