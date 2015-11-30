// <copyright file="DieRollElement.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Core.Dice
{
    using Newtonsoft.Json;
    using Template10.Mvvm;

    /// <summary>
    /// Represents an element on a die roll.
    /// </summary>
    public class DieRollElement : BindableBase
    {
        private int count = default(int);
        private int die = default(int);

        /// <summary>
        /// Initializes a new instance of the <see cref="DieRollElement"/> class.
        /// </summary>
        public DieRollElement()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DieRollElement"/> class.
        /// </summary>
        /// <param name="count">The number of dice.</param>
        /// <param name="die">The type of die.</param>
        public DieRollElement(int count, int die)
        {
            this.Count = count;
            this.Die = die;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DieRollElement"/> class.
        /// </summary>
        /// <param name="roll">A DieRoll object</param>
        public DieRollElement(DieRoll roll)
        {
            this.Count = roll.Count;
            this.Die = roll.Die;
        }

        /// <summary>
        /// Gets or sets the number of Dice of this type to be rolled.
        /// </summary>
        public int Count
        {
            get { return this.count; } set { this.Set(ref this.count, value); }
        }

        /// <summary>
        /// Gets or sets the type of die to be rolled.
        /// </summary>
        public int Die
        {
            get { return this.die; } set { this.Set(ref this.die, value); }
        }

        /// <summary>
        /// Gets the DieRollElement expressed on text.
        /// </summary>
        [JsonIgnore]
        public string Text
        {
            get
            {
                return this.Count + "d" + this.Die;
            }
        }

        /// <summary>
        /// Compares for Equal two DieRollElements.
        /// </summary>
        /// <param name="x">The First DieRollElement.</param>
        /// <param name="y">The Second DieRollElement.</param>
        /// <returns>True if both DieRollElements are the same.</returns>
        public static bool operator ==(DieRollElement x, DieRollElement y)
        {
            if (((object)x) == null ^ ((object)y) == null)
            {
                return false;
            }

            if (((object)x) == null)
            {
                return false;
            }

            return x.Equals(y);
        }

        /// <summary>
        /// Comperes for Not Equal two DieRollElements.
        /// </summary>
        /// <param name="x">The First DieRollElement.</param>
        /// <param name="y">The Second DieRollElement.</param>
        /// <returns>True if both DieRollElements are not the same.</returns>
        public static bool operator !=(DieRollElement x, DieRollElement y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Converts the DieRollElement to string.
        /// </summary>
        /// <returns>The DieRollElement converted to string.</returns>
        public override string ToString()
        {
            return this.Text;
        }

        /// <summary>
        /// Compares one object with the DieRollElement.
        /// </summary>
        /// <param name="obj">The object to be compared.</param>
        /// <returns>The object is the same that the DieRollElement.</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(DieRollElement))
            {
                return false;
            }

            DieRollElement element = (DieRollElement)obj;

            return this.Count == element.Count && this.Die == element.Die;
        }

        /// <summary>
        /// Returns a HashCode for the DieRollElement.
        /// </summary>
        /// <returns>The HashCode for the DieRollElement.</returns>
        public override int GetHashCode()
        {
            return (this.Count << 8) | this.Die;
        }

        /// <summary>
        /// Do a Dice Roll for this DieRollElement
        /// </summary>
        /// <returns>The result of the roll.</returns>
        public int Roll()
        {
            int result = 0;

            if (this.Die == 1)
            {
                result = this.Die * this.Count;
            }
            else if (this.Die > 1)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    result += DieRoll.Random.Next(1, this.Die + 1);
                }
            }

            return result;
        }
    }
}