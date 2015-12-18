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
        /// Retrieves a collection of Adventures.
        /// </summary>
        /// <returns>A collection of adventures.</returns>
        IEnumerable<Adventure> GetAdventures();

        /// <summary>
        /// Retrieves an Adventure by Code
        /// </summary>
        /// <param name="code">The Adventure Code.</param>
        /// <returns>The Adventure with Code in the collection</returns>
        Adventure GetAdventure(string code);

        /// <summary>
        ///  Retrieves a Encounter by ID
        /// </summary>
        /// <param name="id">The Encounter's ID.</param>
        /// <returns>The encounter with ID in the collection</returns>
        Encounter GetEncounter(string id);
    }
}