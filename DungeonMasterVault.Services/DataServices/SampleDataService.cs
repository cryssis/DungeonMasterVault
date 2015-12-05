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
            InitEncounters();
        }

        /// <summary>
        /// Implementation of GetEncounter
        /// </summary>
        /// <param name="id">hte encounter id</param>
        /// <returns>The encounter found</returns>
        public Encounter GetEncounter(string id)
        {
            return encounters.Where(x => x.ID == id).FirstOrDefault();
        }

        /// <summary>
        /// Implementation of GetEncounters
        /// </summary>
        /// <returns>A encounter collection</returns>
        public IEnumerable<Encounter> GetEncounters()
        {
            if (encounters == null)
            {
                InitEncounters();
            }

            return encounters;
        }

        private void InitEncounters()
        {
            if (encounters == null)
            {
                encounters = new List<Encounter>();
            }
            else
            {
                encounters.Clear();
            }

            for (var i = 1; i < 35; i++)
            {
                var encounter = new Encounter()
                {
                    ID = "R" + i,
                    Name = "R" + i + ". Sample Encounter",
                    Adventure = "Runtime Adventure",
                    Budget = new long?(100)
                };
                encounters.Add(encounter);
            }
        }
    }
}