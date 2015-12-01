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
        /// <returns></returns>
        IEnumerable<Encounter> GetEncounters();

        /// <summary>
        ///  Retrieves a Encounter by ID
        /// </summary>
        /// <param name="id">The Encounter's ID.</param>
        /// <returns>The encounter with ID</returns>
        Encounter GetEncounter(string id);
    }
}