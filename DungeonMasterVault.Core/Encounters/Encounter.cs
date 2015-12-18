// <copyright file="Encounter.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Core.Encounters
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using Template10.Mvvm;

    /// <summary>
    /// A Encounter
    /// </summary>
    public class Encounter : BindableBase
    {
        private ObservableCollection<Creature> creatures;
        private string id;
        private string name;
        private string adventure;
        private long? budget;

        /// <summary>
        /// Initializes a new instance of the <see cref="Encounter"/> class.
        /// </summary>
        public Encounter()
        {
            this.creatures = new ObservableCollection<Creature>();
        }

        /// <summary>
        /// Gets or sets the Encounter Creature Collection
        /// </summary>
        [DataMember]
        public ObservableCollection<Creature> Creatures
        {
            get { return this.creatures; }
            set { this.Set(ref this.creatures, value); }
        }

        /// <summary>
        /// Gets or sets the Encounter ID
        /// </summary>
        [DataMember]
        public string ID
        {
            get { return this.id; }
            set { this.Set(ref this.id, value); }
        }

        /// <summary>
        /// Gets or sets the Encounter Name
        /// </summary>
        [DataMember]
        public string Name
        {
            get { return this.name; }
            set { this.Set(ref this.name, value); }
        }

        /// <summary>
        /// Gets or sets the Adventure Code the Encounter belongs to
        /// </summary>
        [DataMember]
        public string Adventure
        {
            get { return this.adventure; }
            set { this.Set(ref this.adventure, value); }
        }

        /// <summary>
        /// Gets or sets the Encounter XP budget
        /// </summary>
        [DataMember]
        public long? Budget
        {
            get { return this.budget; }
            set { this.Set(ref this.budget, value); }
        }

        /// <summary>
        /// Adds a Creature to the Encounter's Creature Collection
        /// </summary>
        /// <param name="creature">The Creature to be added</param>
        public void AddCreature(Creature creature)
        {
            this.Creatures.Add(creature);
        }

        /// <summary>
        /// Adds a new Blank Creature to the Encounter's Creature Collection
        /// </summary>
        /// <param name="monster">The Creature is a Monster</param>
        /// <param name="hidden">The Creature is hidden</param>
        public void AddBlank(bool monster, bool hidden = false)
        {
            Creature m = new Creature();
            m.IsBlank = true;
            m.IsMonster = monster;
            m.IsHidden = hidden;
            m.Name = this.GetUnusedName(monster ? "Monster" : "Player");
            this.AddCreature(m);
        }

        /// <summary>
        /// Gets the next unused name for the name given
        /// </summary>
        /// <param name="name">The name given</param>
        /// <returns>The nave given with a number postfix.</returns>
        public string GetUnusedName(string name)
        {
            string check = name + " 1";

            for (int i = 2; i < int.MaxValue; i++)
            {
                bool found = false;
                foreach (Creature c in this.Creatures)
                {
                    if (c.Name == check)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    check = name + " " + i;
                    continue;
                }

                break;
            }

            return check;
        }

        /// <summary>
        /// Calculates the sum of Monsters XP
        /// </summary>
        private void CalculateEncounterBudget()
        {
            long xp = 0;
            foreach (Creature c in from x in this.Creatures where x.IsMonster select x)
            {
                if (c.Monster != null && c.Monster.XP != null)
                {
                    long? monsterXP = c.Monster.XPValue;
                    if (monsterXP != null)
                    {
                        xp += monsterXP.Value;
                    }
                }
            }

            this.Budget = xp;
        }
    }
}