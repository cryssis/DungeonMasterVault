// <copyright file="DieRoll.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Core.Dice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text.RegularExpressions;
    using DungeonMasterVault.Core.Dice;
    using DungeonMasterVault.Core.Utils;
    using DungeonsMasterVault.Core.Dice;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a Dice Roll composed of several die rolls and a modifier.
    /// </summary>
    [DataContract]
    public class DieRoll
    {
        private const string SingleDieRollRegexString = "?<count>([0-9]+)d?<die>([0-9]+)";
        private const string ExtraDieRollRegexString = "(?<extra>(\\+?<extraCount>([0-9]+)d?<extraDie>([0-9]+))*)";
        private const string ModDieRollRegexString = "?<mod>((\\+|-)[0-9]+)?";

        /// <summary>
        /// Private storage for the Random generator
        /// </summary>
        private static Random rand = new Random();

        private int count;
        private int die;
        private int mod;
        private List<DieRollElement> extraRolls;

        /// <summary>
        /// Initializes a new instance of the <see cref="DieRoll"/> class.
        /// </summary>
        public DieRoll()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DieRoll"/> class.
        /// </summary>
        /// <param name="count">The number of dice.</param>
        /// <param name="die">The type of die.</param>
        /// <param name="mod">The modifier to the roll's result.</param>
        public DieRoll(int count, int die, int mod)
        {
            this.count = count;
            this.die = die;
            this.mod = mod;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DieRoll"/> class.
        /// </summary>
        /// <param name="roll">The DieRoll to copy from.</param>
        public DieRoll(DieRoll roll)
        {
            this.CopyFrom(roll);
        }

        /// <summary>
        /// Gets the Random generator for this DieRoll.
        /// </summary>
        public static Random Random
        {
            get
            {
                return rand;
            }
        }

        /// <summary>
        /// Gets or sets the number of dice for this DieRoll
        /// </summary>
        [JsonIgnore]
        public int Count
        {
            get
            {
                return this.count;
            }

            set
            {
                if (this.count != value)
                {
                    this.count = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of die for this DieRoll
        /// </summary>
        [JsonIgnore]
        public int Die
        {
            get
            {
                return this.die;
            }

            set
            {
                if (this.die != value)
                {
    this.die = value;
}
            }
        }

        /// <summary>
        /// Gets or sets the modifier for this DieRoll
        /// </summary>
        [JsonIgnore]
        public int Mod
        {
            get
            {
                return this.mod;
            }

            set
            {
                if (this.mod != value)
                {
                    this.mod = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the DieRollElement for the main Roll of the DieRoll
        /// </summary>
        [JsonIgnore]
        public DieRollElement Element
        {
            get
            {
                return new DieRollElement(this);
            }

            set
            {
                this.Count = value.Count;
                this.Die = value.Die;
            }
        }

        /// <summary>
        /// Gets or sets the other rolls that sum up to this roll.
        /// </summary>
        [JsonIgnore]
        public List<DieRollElement> ExtraRolls
        {
            get
            {
                return this.extraRolls;
            }

            set
            {
                if (this.extraRolls != value)
                {
                    this.extraRolls = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the all the Dice Roll that sums this roll.
        /// </summary>
        [JsonIgnore]
        public List<DieRollElement> AllRolls
        {
            get
            {
                List<DieRollElement> elements = new List<DieRollElement>() { this.Element };

                if (this.extraRolls != null)
                {
                    foreach (DieRollElement element in this.extraRolls)
                    {
                        elements.Add(element);
                    }
                }

                return elements;
            }

            set
            {
                System.Diagnostics.Debug.Assert(value.Count > 0, "Invalid roll. The number of dice must be at least one.");

                this.Count = value[0].Count;
                this.Die = value[0].Die;

                this.extraRolls = new List<DieRollElement>();
                for (int i = 1; i < value.Count; i++)
                {
                    this.extraRolls.Add(value[i]);
                }
            }
        }

        /// <summary>
        /// Gets the total number of dice to roll.
        /// </summary>
        [JsonIgnore]
        public int TotalCount
        {
            get
            {
                int total = this.Count;

                if (this.ExtraRolls != null)
                {
                    foreach (DieRollElement element in this.ExtraRolls)
                    {
                        total += element.Count;
                    }
                }

                return total;
            }
        }

        /// <summary>
        /// Gets or sets the Dice Roll expressed on a string.
        /// </summary>
        [DataMember]
        public string Text
        {
            get
            {
                string text = string.Empty;
                text += this.Count;
                text += "d" + this.Die;
                if (this.ExtraRolls != null && this.ExtraRolls.Count > 0)
                {
                    foreach (DieRollElement element in this.ExtraRolls)
                    {
                        text += "+" + element.Count + "d" + element.Die;
                    }
                }

                if (this.Mod != 0)
                {
                    text += this.Mod.PlusFormat();
                }

                return text;
            }

            set
            {
                this.CopyFrom(DieRoll.FromString(value));
            }
        }

        /// <summary>
        /// Compares for Equal two DieRoll.
        /// </summary>
        /// <param name="x">The First DieRoll.</param>
        /// <param name="y">The Second DieRoll.</param>
        /// <returns>True if both DieRoll are the same.</returns>
        public static bool operator ==(DieRoll x, DieRoll y)
        {
            if ((((object)x) == null) ^ (((object)y) == null))
            {
                return false;
            }

            if (((object)x) == null)
            {
                return true;
            }

            return x.Equals(y);
        }

        /// <summary>
        /// Compares for Not Equal two DieRoll.
        /// </summary>
        /// <param name="x">The First DieRoll.</param>
        /// <param name="y">The Second DieRoll.</param>
        /// <returns>True if both DieRoll are not the same.</returns>
        public static bool operator !=(DieRoll x, DieRoll y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Creates a new instance of DieRoll from its string representation.
        /// </summary>
        /// <param name="text">The String representation for the roll.</param>
        /// <returns>A new instance of DieRoll matching the string representation.</returns>
        public static DieRoll FromString(string text)
        {
            return FromString(text, 0);
        }

        /// <summary>
        /// Creates a new instance of DieRoll from its string representation.
        /// </summary>
        /// <param name="text">A string containing the representation for the roll.</param>
        /// <param name="start">The starting position inside text to match the string representation for the roll.</param>
        /// <returns>A new instance of DieRoll matching the string representation.</returns>
        public static DieRoll FromString(string text, int start)
        {
            DieRoll roll = null;

            if (text != null)
            {
                try
                {
                    Regex regRoll = new Regex(SingleDieRollRegexString + ExtraDieRollRegexString + ModDieRollRegexString);

                    Match match = regRoll.Match(text, start);

                    if (match.Success)
                    {
                        roll = new DieRoll();
                        roll.Count = int.Parse(match.Groups["count"].Value);
                        roll.Die = int.Parse(match.Groups["die"].Value);

                        if (roll.Die == 0)
                        {
                            throw new FormatException("Invalid Die Roll");
                        }

                        if (match.Groups["extra"].Success)
                        {
                            roll.ExtraRolls = new List<DieRollElement>();

                            Regex regExtra = new Regex(SingleDieRollRegexString);

                            foreach (Match m in regExtra.Matches(match.Groups["extra"].Value))
                            {
                                DieRollElement element = new DieRollElement(int.Parse(m.Groups["extraCount"].Value), int.Parse(m.Groups["extraDie"].Value));
                                if (element.Die == 0)
                                {
                                    throw new FormatException("Invalid Die Roll");
                                }

                                roll.ExtraRolls.Add(element);
                            }
                        }

                        if (match.Groups["mod"].Success)
                        {
                            roll.Mod = int.Parse(match.Groups["mod"].Value);
                        }
                    }
                }
                catch (FormatException)
                {
                    roll = null;
                }
                catch (OverflowException)
                {
                    roll = null;
                }
            }

            return roll;
        }

        /// <summary>
        /// Make a random roll for this DieRoll
        /// </summary>
        /// <returns>A RollResult object with the resulting rolling of the dice.</returns>
        public RollResult Roll()
        {
            RollResult result = new RollResult();
            result.Mod = this.Mod;
            result.Total = this.Mod;

            foreach (DieRollElement element in this.AllRolls)
            {
                for (int i = 0; i < element.Count; i++)
                {
                    DieResult res = new DieResult();
                    res.Die = element.Die;
                    res.Result += Random.Next(1, element.Die + 1);
                    result.Total += res.Result;
                    result.Rolls.Add(res);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns the average roll result for this die roll.
        /// </summary>
        /// <returns>The average result of the roll.</returns>
        public int AverageRoll()
        {
            return (int)(this.AllRolls.Sum(roll => (Math.Floor((decimal)((roll.Die + 1) * roll.Count)) / 2)) + this.Mod);
        }

        /// <summary>
        /// Returns the number of dice of a type in the roll.
        /// </summary>
        /// <param name="die">The type of dice to count.</param>
        /// <returns>The number of dice for the type in the roll.</returns>
        public int DieCount(int die)
        {
            int count = 0;
            foreach (DieRollElement d in this.AllRolls)
            {
                if (d.Die == die)
                {
                    count += d.Count;
                }
            }

            return count;
        }

        /// <summary>
        /// Creates a new instance of this class with the values of this object.
        /// </summary>
        /// <returns>A new instance with the same values.</returns>
        public object Clone()
        {
            return new DieRoll(this);
        }

        /// <summary>
        /// Convert the DieRoll to its string representation.
        /// </summary>
        /// <returns>The string representation for this Die Roll</returns>
        public override string ToString()
        {
            return this.Text;
        }

        /// <summary>
        /// Returns a HashCode for the DieRoll.
        /// </summary>
        /// <returns>The HashCode for this DieRoll.</returns>
        public override int GetHashCode()
        {
            int value = (this.Die << 8) * (this.Count << 4) ^ this.Mod;

            if (this.ExtraRolls != null && this.ExtraRolls.Count > 0)
            {
                int extra = 0;
                foreach (DieRollElement element in this.ExtraRolls)
                {
                    extra ^= element.GetHashCode();
                }

                value |= extra << 12;
            }

            return value;
        }

        /// <summary>
        /// Determina si el objeto especificado es igual al objeto actual.
        /// </summary>
        /// <param name="obj">El objeto a comparar.</param>
        /// <returns>True si los objetos son iguales.</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(DieRoll))
            {
                return false;
            }

            DieRoll roll = (DieRoll)obj;

            if (roll.ExtraRolls == null ^ this.ExtraRolls == null)
            {
                return false;
            }

            if (this.ExtraRolls != null)
            {
                if (roll.ExtraRolls.Count != this.ExtraRolls.Count)
                {
                    return false;
                }

                for (int i = 0; i < this.ExtraRolls.Count; i++)
                {
                    if (roll.ExtraRolls[i] != this.ExtraRolls[i])
                    {
                        return false;
                    }
                }
            }

            return roll.Count == this.Count && roll.Die == this.Die && roll.Mod == this.Mod;
        }

        /// <summary>
        /// Copy the values of a DieRoll in this object.
        /// </summary>
        /// <param name="roll">The original DieRoll.</param>
        private void CopyFrom(DieRoll roll)
        {
            if (roll == null)
            {
                this.Count = 0;
                this.Die = 0;
                this.Mod = 0;
            }
            else
            {
                this.Count = roll.Count;
                this.Die = roll.Die;
                this.Mod = roll.Mod;

                if (roll.ExtraRolls != null)
                {
                    this.ExtraRolls = new List<DieRollElement>();

                    foreach (DieRollElement element in roll.ExtraRolls)
                    {
                        this.ExtraRolls.Add(new DieRollElement(element.Count, element.Die));
                    }
                }
                else
                {
                    this.ExtraRolls = null;
                }
            }
        }
    }
}