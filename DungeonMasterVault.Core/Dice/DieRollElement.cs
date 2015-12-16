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
        private int number = default(int);
        private int side = default(int);

        /// <summary>
        /// Initializes a new instance of the <see cref="DieRollElement"/> class.
        /// </summary>
        public DieRollElement()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DieRollElement"/> class.
        /// </summary>
        /// <param name="number">The number of dice.</param>
        /// <param name="side">The die's sides.</param>
        public DieRollElement(int number, int side)
        {
            this.Number = number;
            this.Side = side;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DieRollElement"/> class.
        /// </summary>
        /// <param name="roll">A DieRoll object</param>
        public DieRollElement(DieRoll roll)
        {
            this.Number = roll.Number;
            this.Side = roll.Side;
        }

        /// <summary>
        /// Gets or sets the number of Dice of this type to be rolled.
        /// </summary>
        public int Number
        {
            get { return this.number; } set { this.Set(ref this.number, value); }
        }

        /// <summary>
        /// Gets or sets the type of die to be rolled.
        /// </summary>
        public int Side
        {
            get { return this.side; } set { this.Set(ref this.side, value); }
        }

        /// <summary>
        /// Gets the DieRollElement expressed on text.
        /// </summary>
        [JsonIgnore]
        public string Text
        {
            get
            {
                return this.Number + "d" + this.Side;
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

            return this.Number == element.Number && this.Side == element.Side;
        }

        /// <summary>
        /// Returns a HashCode for the DieRollElement.
        /// </summary>
        /// <returns>The HashCode for the DieRollElement.</returns>
        public override int GetHashCode()
        {
            return (this.Number << 8) | this.Side;
        }

        /// <summary>
        /// Do a Dice Roll for this DieRollElement
        /// </summary>
        /// <returns>The result of the roll.</returns>
        public int Roll()
        {
            int result = 0;

            if (this.Side == 1)
            {
                result = this.Side * this.Number;
            }
            else if (this.Side > 1)
            {
                for (int i = 0; i < this.Number; i++)
                {
                    result += DieRoll.Random.Next(1, this.Side + 1);
                }
            }

            return result;
        }
    }
}