// <copyright file="MonsterStat.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Core.Monsters
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Rules;
    using Template10.Mvvm;

    /// <summary>
    /// A Monster Statistics class.
    /// </summary>
    public class MonsterStat : BindableBase
    {
        private string name;
        private string cr;
        private string xp;
        private string hd;
        private int hp;

        /// <summary>
        /// Initializes a new instance of the <see cref="MonsterStat"/> class.
        /// </summary>
        public MonsterStat()
        {
        }

        /// <summary>
        /// Gets or sets the Monster Name
        /// </summary>
        [DataMember]
        public string Name
        {
            get { return this.name; }
            set { this.Set(ref this.name, value); }
        }

        /// <summary>
        /// Gets or sets the Monster Challenge Rating
        /// </summary>
        [DataMember]
        public string ChallengeRating
        {
            get { return this.cr; }
            set { this.Set(ref this.cr, value); }
        }

        /// <summary>
        /// Gets or sets the Monster Experience Points
        /// </summary>
        [DataMember]
        public string XP
        {
            get { return this.xp; }
            set { this.Set(ref this.xp, value); }
        }

        /// <summary>
        /// Gets the Monster XP value
        /// </summary>
        [JsonIgnore]
        public long? XPValue
        {
            get
            {
                if (this.xp != null)
                {
                    long value = 0;
                    if (long.TryParse(this.xp, out value))
                    {
                        return value;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Gets or sets the Monster Hit Dice
        /// </summary>
        [DataMember]
        public string HitDice
        {
            get { return this.hd; }
            set { this.Set(ref this.hd, value); }
        }

        /// <summary>
        /// Gets or sets the Monster Hit Points
        /// </summary>
        [DataMember]
        public int HitPoints
        {
            get { return this.hp; }
            set { this.Set(ref this.hp, value); }
        }

        /// <summary>
        /// Creates a new Instance for a default monster.
        /// </summary>
        /// <returns>A new monster with blank or default stats.</returns>
        public static MonsterStat BlankMonsterStat()
        {
            MonsterStat m = new MonsterStat();

            m.HitPoints = 5;
            m.HitDice = "1d8";
            m.ChallengeRating = "1";
            m.XP = XPTable.XPbyCR(m.ChallengeRating).ToString();

            return m;
        }

        /// <summary>
        /// Creates a copy of this monster.
        /// </summary>
        /// <returns>A new object with the same values than this monster.</returns>
        public object Clone()
        {
            MonsterStat m = new MonsterStat();

            m.name = this.name;
            m.cr = this.cr;
            m.xp = this.xp;
            m.hd = this.hd;
            m.hp = this.hp;

            return m;
        }
    }
}