namespace DungeonMasterVault.Services.DataServices
{
    using System.Collections.Generic;
    using DungeonMasterVault.Core.Encounters;

    /// <summary>
    /// A class for DesignTime data
    /// </summary>
    public class DesignTimeDataService : IDataService
    {
        /// <summary>
        /// Implementation of GetEncounter
        /// </summary>
        /// <param name="id">hte encounter id</param>
        /// <returns>The encounter found</returns>
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

        /// <summary>
        /// Implementation of GetEncounters
        /// </summary>
        /// <returns>A encounter collection</returns>
        public IEnumerable<Encounter> GetEncounters()
        {
            var encounters = new List<Encounter>();
            for (var i = 1; i < 10; i++)
            {
                var encounter = new Encounter()
                {
                    ID = "DS" + i.ToString(),
                    Name = "DS" + i.ToString() + ". Design Time Encounter",
                    Adventure = "Design Adventure",
                    Budget = new long?(100)
                };
                encounters.Add(encounter);
            }

            return encounters;
        }
    }
}