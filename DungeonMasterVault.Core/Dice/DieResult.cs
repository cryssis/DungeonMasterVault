// <copyright file="DieResult.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Core.Dice
{
    using System.Runtime.Serialization;

    /// <summary>
    /// DieResult represents the result of rolling a die.
    /// </summary>
    [DataContract]
    public class DieResult
    {
        /// <summary>
        /// Gets or sets the number of sides
        /// </summary>
        [DataMember]
        public int Side { get; set; }

        /// <summary>
        /// Gets or sets the result of rolling the die
        /// </summary>
        [DataMember]
        public int Result { get; set; }
    }
}