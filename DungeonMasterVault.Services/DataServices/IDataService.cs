// <copyright file="IDataService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Services.DataServices
{
    using System.Collections.Generic;
    using DungeonMasterVault.Core.Encounters;

    /// <summary>
    /// A Data Service
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Retrieves a collection of Encounters.
        /// </summary>
        /// <returns>A collection of encounters</returns>
        IEnumerable<Encounter> GetEncounters();

        /// <summary>
        ///  Retrieves a Encounter by ID
        /// </summary>
        /// <param name="id">The Encounter's ID.</param>
        /// <returns>The encounter with ID in the collection</returns>
        Encounter GetEncounter(string id);
    }
}