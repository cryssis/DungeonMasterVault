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
            return encounters;
        }

        private void InitEncounters()
        {
            var Encounters = from n in Enumerable.Range(1,3)
                             select new Encounter                
                {
                    ID = "R" + n,
                    Name = "R" + n + ". Sample Encounter",
                    Adventure = "Runtime Adventure",
                    Budget = new long?(100)
                };                
            }
        }
    }
}