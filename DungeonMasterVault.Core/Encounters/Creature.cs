// <copyright file="Creature.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Core.Encounters
{
    using System;
    using System.Runtime.Serialization;
    using Dice;
    using Monsters;
    using Newtonsoft.Json;
    using Template10.Mvvm;

    /// <summary>
    /// A member of an encounter
    /// </summary>
    public class Creature : BindableBase
    {
        /// <summary>
        /// Private storage for Random engine
        /// </summary>
        private static Random rand = new Random();

        private string name;

        private int hp;

        /// <summary>
        /// Private storage for Maximun Hit Points
        /// </summary>
        private int maxHp;

        /// <summary>
        /// Private storage for Temporary Hit Points
        /// </summary>
        private int tempHp;

        /// <summary>
        /// Private storage for Notes
        /// </summary>
        private string notes;

        /// <summary>
        /// Private storage for ID
        /// </summary>
        private Guid id;

        /// <summary>
        /// Private storage for Monster flag
        /// </summary>
        private bool isMonster;

        /// <summary>
        /// Private storage for Monster stats
        /// </summary>
        private MonsterStat monster;

        /// <summary>
        /// Private storage for Blank Monster flag
        /// </summary>
        private bool isBlank;

        /// <summary>
        /// Private storage for Creature with Ready Action flag
        /// </summary>
        private bool isReadying;

        /// <summary>
        /// Private storage for Creature Hidden flag
        /// </summary>
        private bool isHidden;

        /// <summary>
        /// Private storage for Creature Active flag
        /// </summary>
        private bool isActive;

        /// <summary>
        /// Private storage for Creature Current Initiative
        /// </summary>
        private int currentInit;

        /// <summary>
        /// Private storage for Creature Initiative Tie Breaker
        /// </summary>
        private int initTiebreaker;

        /// <summary>
        /// Private storage for Creature Initiative has changed flag
        /// </summary>
        private bool hasInitChanged;

        /// <summary>
        /// Private storage for Creature Initiative Roll Result
        /// </summary>
        private int initRolled;

        /// <summary>
        /// Private storage for Creature Initiative Count
        /// </summary>
        private InitiativeCount initCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Creature"/> class.
        /// </summary>
        public Creature()
        {
            this.initTiebreaker = rand.Next();
            this.monster = MonsterStat.BlankMonsterStat();
            this.hp = this.monster.HitPoints;
            this.maxHp = this.monster.HitPoints;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Creature"/> class.
        /// </summary>
        /// <param name="name">The Creature name</param>
        public Creature(string name)
            : this()
        {
            this.name = name;
            this.monster.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Creature"/> class.
        /// </summary>
        /// <param name="monster">A monster stat</param>
        /// <param name="rollHitPoints">the hit points are rolled</param>
        public Creature(MonsterStat monster, bool rollHitPoints)
            : this()
        {
            this.monster = (MonsterStat)monster.Clone();
            this.name = this.monster.Name;

            if (!rollHitPoints || !this.TryParseHitPoints())
            {
                this.hp = monster.HitPoints;
            }

            this.maxHp = this.hp;
            this.isMonster = true;
        }

        /// <summary>
        /// Gets or sets the Name of the Creature
        /// </summary>
        [DataMember]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.Set(ref this.name, value))
                {
                    this.RaisePropertyChanged("DisplayName");
                    if (this.IsBlank)
                    {
                        if (this.monster != null)
                        {
                            this.monster.Name = this.name;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the Creature Current Hit Points
        /// </summary>
        [DataMember]
        public int HitPoints
        {
            get { return this.hp; }
            set { this.Set(ref this.hp, value); }
        }

        /// <summary>
        /// Gets or sets the Creature Maximun Hit Points
        /// </summary>
        [DataMember]
        public int MaxHitPoints
        {
            get
            {
                return this.maxHp;
            }

            set
            {
                this.Set(ref this.maxHp, value);
                if (this.IsBlank)
                {
                    if (this.monster == null)
                    {
                        this.monster.HitPoints = this.maxHp;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the Creature temporary Hit Points
        /// </summary>
        [DataMember]
        public int TempHitPoints
        {
            get { return this.tempHp; }
            set { this.Set(ref this.tempHp, value); }
        }

        /// <summary>
        /// Gets or sets the Creature Notes
        /// </summary>
        [DataMember]
        public string Notes
        {
            get { return this.notes; }
            set { this.Set(ref this.notes, value); }
        }

        /// <summary>
        /// Gets or sets the Creature Unique ID
        /// </summary>
        [DataMember]
        public Guid ID
        {
            get
            {
                if (this.id == Guid.Empty)
                {
                    this.id = Guid.NewGuid();
                }

                return this.id;
            }

            set
            {
                this.Set(ref this.id, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Creature is a Monster
        /// </summary>
        [DataMember]
        public bool IsMonster
        {
            get { return this.isMonster; }
            set { this.Set(ref this.isMonster, value); }
        }

        /// <summary>
        /// Gets or sets the Creature as a Monster
        /// </summary>
        [DataMember]
        public MonsterStat Monster
        {
            get { return this.monster; }
            set { this.Set(ref this.monster, value); }
        }

        /// <summary>
        /// Gets the Creature Monster Stats
        /// </summary>
        [JsonIgnore]
        public MonsterStat Stats
        {
            get { return this.monster; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Creature is a blank Creature/Monster
        /// </summary>
        [DataMember]
        public bool IsBlank
        {
            get { return this.isBlank; }
            set { this.Set(ref this.isBlank, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Creature is Redying an action
        /// </summary>
        [DataMember]
        public bool IsReadying
        {
            get { return this.isReadying; }
            set { this.Set(ref this.isReadying, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Creature is Hidden
        /// </summary>
        [DataMember]
        public bool IsHidden
        {
            get
            {
                return this.isHidden;
            }

            set
            {
                if (this.Set(ref this.isHidden, value))
                {
                    this.RaisePropertyChanged("DisplayName");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Creature is the Active Creature
        /// </summary>
        [DataMember]
        [JsonIgnore]
        public bool IsActive
        {
            get { return this.isActive; }
            set { this.Set(ref this.isActive, value); }
        }

        /// <summary>
        /// Gets or sets the Creature Current Initive value
        /// </summary>
        [DataMember]
        public int CurrentInitiative
        {
            get { return this.currentInit; }
            set { this.Set(ref this.currentInit, value); }
        }

        /// <summary>
        /// Gets or sets the Creature Tiebreaker for initiative
        /// </summary>
        [DataMember]
        public int InitiativeTiebreaker
        {
            get { return this.initTiebreaker; }
            set { this.Set(ref this.initTiebreaker, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Creature Initiative has changed
        /// </summary>
        [DataMember]
        public bool HasInitiativeChanged
        {
            get { return this.hasInitChanged; }
            set { this.Set(ref this.hasInitChanged, value); }
        }

        /// <summary>
        /// Gets or sets the Creature original Initiative
        /// </summary>
        [DataMember]
        public int InitiativeRolled
        {
            get { return this.initRolled; }
            set { this.Set(ref this.initRolled, value); }
        }

        /// <summary>
        /// Gets or sets the Creature Initiative Count
        /// </summary>
        [DataMember]
        public InitiativeCount InitiativeCount
        {
            get { return this.initCount; }
            set { this.Set(ref this.initCount, value); }
        }

        /// <summary>
        /// Gets the Name of the Creature to display.
        /// </summary>
        [DataMember]
        [JsonIgnore]
        public string DisplayName
        {
            get
            {
                if (this.isHidden)
                {
                    return "??????";
                }
                else
                {
                    return this.name;
                }
            }
        }

        /// <summary>
        /// Gets the Creature Minimun Hit Points allowed
        /// </summary>
        [JsonIgnore]
        public int MinHitPoints
        {
            get { return -this.MaxHitPoints; }
        }

        /// <summary>
        /// Creates a new instance of this Creature with the same values
        /// </summary>
        /// <returns>Returns a copy of this Creature</returns>
        public object Clone()
        {
            Creature creature = new Creature();

            creature.name = this.name;
            creature.hp = this.hp;
            creature.maxHp = this.maxHp;
            creature.notes = this.notes;
            creature.id = Guid.NewGuid();

            creature.isMonster = this.isMonster;
            if (this.monster == null)
            {
                creature.monster = null;
            }
            else
            {
                creature.monster = (MonsterStat)this.monster.Clone();
            }

            creature.isActive = this.isActive;
            creature.currentInit = this.currentInit;
            creature.hasInitChanged = false;
            creature.initRolled = this.initRolled;
            if (this.initCount != null)
            {
                creature.initCount = new InitiativeCount(this.initCount);
            }

            creature.isHidden = this.isHidden;

            return creature;
        }

        /// <summary>
        /// Returns a string representation for the Creature
        /// </summary>
        /// <returns>A string representation for the Creature</returns>
        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Tries to parse the string expression of Monster Hit Dice
        /// </summary>
        /// <returns>The Monster Hit Dice string expression was succesfully parsed and set to HitPoints</returns>
        public bool TryParseHitPoints()
        {
            DieRoll dr = DieRoll.FromString(this.monster.HitDice);
            if (dr != null)
            {
                this.HitPoints = dr.Roll().Total;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adjust Creature HitPoints
        /// </summary>
        /// <param name="changeHitPoints">The change on HitPoints to be adjusted.</param>
        /// <returns>The Creature HitPoints after the adjustment.</returns>
        public int AdjustHitPoints(int changeHitPoints)
        {
            return this.AdjustHitPoints(changeHitPoints, 0);
        }

        /// <summary>
        /// Adjust Creature HitPoints and TempHitPoints.
        /// </summary>
        /// <param name="changeHitPoints">The change on HitPoints to be adjusted.</param>
        /// <param name="changeTempHitPoints">The change on TempHitPoints to be adjusted.</param>
        /// <returns>The Creature HitPoints after the adjustment.</returns>
        public int AdjustHitPoints(int changeHitPoints, int changeTempHitPoints)
        {
            int oldHitPoints = this.hp + this.tempHp;
            int adjust = changeHitPoints;

            if (this.tempHp > 0)
            {
                if (adjust < 0)
                {
                    if (-adjust <= this.tempHp)
                    {
                        this.TempHitPoints += adjust;
                        adjust = 0;
                    }
                    else
                    {
                        adjust = adjust - this.TempHitPoints;
                        this.TempHitPoints = 0;
                    }
                }
            }

            this.TempHitPoints = Math.Max(this.TempHitPoints + changeTempHitPoints, 0);
            this.HitPoints = Math.Max(this.HitPoints + adjust, 0);

            return this.HitPoints;
        }
    }
}