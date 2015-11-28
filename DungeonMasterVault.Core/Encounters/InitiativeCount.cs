// <copyright file="InitiativeCount.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Core.Encounters
{
    using System;
    using Template10.Mvvm;

    /// <summary>
    /// A class that represents the order in a initiative list
    /// </summary>
    public class InitiativeCount : BindableBase
    {
        private int initBase;
        private int initDex;
        private int initTiebreaker;

        /// <summary>
        /// Initializes a new instance of the <see cref="InitiativeCount"/> class.
        /// </summary>
        public InitiativeCount()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InitiativeCount"/> class.
        /// </summary>
        /// <param name="value">The base initiative.</param>
        /// <param name="dex">The dexterity modifier</param>
        /// <param name="tiebreaker">The tiebreaker for ties</param>
        public InitiativeCount(int value, int dex, int tiebreaker)
        {
            this.initBase = value;
            this.initDex = dex;
            this.initTiebreaker = tiebreaker;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InitiativeCount"/> class.
        /// </summary>
        /// <param name="count">The InitiativeCount to be copied</param>
        public InitiativeCount(InitiativeCount count)
            : this(count.initBase, count.initDex, count.initTiebreaker)
        {
        }

        /// <summary>
        /// Gets or sets the base initiative
        /// </summary>
        public int Base
        {
            get { return this.initBase; }
            set { this.Set(ref this.initBase, value); }
        }

        /// <summary>
        /// Gets or sets the dexterity modifier to the initiative
        /// </summary>
        public int Dex
        {
            get { return this.initDex; }
            set { this.Set(ref this.initDex, value); }
        }

        /// <summary>
        /// Gets or sets the tiebreaker for initiative ties
        /// </summary>
        public int Tiebreaker
        {
            get { return this.initTiebreaker; }
            set { this.Set(ref this.initTiebreaker, value); }
        }

        /// <summary>
        /// Gets the string representation for the initiative
        /// </summary>
        public string Text
        {
            get { return this.ToString(); }
        }

        /// <summary>
        /// Compares for Equal two InitiativeCounts.
        /// </summary>
        /// <param name="x">The First InitiativeCount.</param>
        /// <param name="y">The Second InitiativeCount.</param>
        /// <returns>True if both InitiativeCount are the same.</returns>
        public static bool operator ==(InitiativeCount x, InitiativeCount y)
        {
            object a = (object)x;
            object b = (object)y;

            if (a == null || b == null)
            {
                return a == null && b == null;
            }

            return x.CompareTo(y) == 0;
        }

        /// <summary>
        /// Compares for not Equal two InitiativeCounts.
        /// </summary>
        /// <param name="x">The First InitiativeCount.</param>
        /// <param name="y">The Second InitiativeCount.</param>
        /// <returns>True if both InitiativeCount are not the same.</returns>
        public static bool operator !=(InitiativeCount x, InitiativeCount y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Compares for Greater than two InitiativeCounts.
        /// </summary>
        /// <param name="x">The First InitiativeCount.</param>
        /// <param name="y">The Second InitiativeCount.</param>
        /// <returns>True if First InitiativeCount is greater than the second InitiativeCount.</returns>
        public static bool operator >(InitiativeCount x, InitiativeCount y)
        {
            return x.CompareTo(y) > 0;
        }

        /// <summary>
        /// Compares for Less than two InitiativeCounts.
        /// </summary>
        /// <param name="x">The First InitiativeCount.</param>
        /// <param name="y">The Second InitiativeCount.</param>
        /// <returns>True if First InitiativeCount is less than the second InitiativeCount.</returns>
        public static bool operator <(InitiativeCount x, InitiativeCount y)
        {
            return x.CompareTo(y) < 0;
        }

        /// <summary>
        /// Compares for Greater or equal two InitiativeCounts.
        /// </summary>
        /// <param name="x">The First InitiativeCount.</param>
        /// <param name="y">The Second InitiativeCount.</param>
        /// <returns>True if First InitiativeCount is greater or equal than the second InitiativeCount.</returns>
        public static bool operator >=(InitiativeCount x, InitiativeCount y)
        {
            return x.CompareTo(y) >= 0;
        }

        /// <summary>
        /// Compares for Less or equal two InitiativeCounts.
        /// </summary>
        /// <param name="x">The First InitiativeCount.</param>
        /// <param name="y">The Second InitiativeCount.</param>
        /// <returns>True if First InitiativeCount is less or equal than the second InitiativeCount.</returns>
        public static bool operator <=(InitiativeCount x, InitiativeCount y)
        {
            return x.CompareTo(y) <= 0;
        }

        /// <summary>
        /// Creates a copy of this InitiativeCount
        /// </summary>
        /// <returns>A copy of this InitiativeCount</returns>
        public object Clone()
        {
            return new InitiativeCount(this);
        }

        /// <summary>
        /// Returns a string representation for this InitiativeCount
        /// </summary>
        /// <returns>A string representing the InitiativeCount</returns>
        public override string ToString()
        {
            return this.initBase + "-" + this.initDex + "-" + this.initTiebreaker;
        }

        /// <summary>
        /// Determines if the specified object is equal to the current instance
        /// </summary>
        /// <param name="obj">The object to be compared to.</param>
        /// <returns>True if the object equals the instance.</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(InitiativeCount))
            {
                return this == (InitiativeCount)obj;
            }

            return base.Equals(obj);
        }

        /// <summary>
        /// Returns a HashCode for the InitiativeCount.
        /// </summary>
        /// <returns>The HashCode for this InitiativeCount.</returns>
        public override int GetHashCode()
        {
            return (this.Base << 8) ^ (this.Dex << 4) ^ this.Tiebreaker;
        }

        /// <summary>
        /// Compares an object to this InitiativeCount
        /// </summary>
        /// <param name="obj">The object to be compared to.</param>
        /// <returns>The difference between objects expressed in integer number</returns>
        public int CompareTo(object obj)
        {
            if (obj.GetType() != typeof(InitiativeCount))
            {
                throw new ArgumentException("Cannot compare", "obj");
            }
            else
            {
                return this.CompareTo((InitiativeCount)obj);
            }
        }

        /// <summary>
        /// Compares an InitiativeCount to this InitiativeCount
        /// </summary>
        /// <param name="count">The InitiativeCount to be compared to.</param>
        /// <returns>The difference between InitiativeCount values expressed in integer number</returns>
        public int CompareTo(InitiativeCount count)
        {
            if (this.Base != count.Base)
            {
                return this.Base.CompareTo(count.Base);
            }

            if (this.Dex != count.Dex)
            {
                return this.Dex.CompareTo(count.Dex);
            }

            return this.Tiebreaker.CompareTo(count.Tiebreaker);
        }
    }
}