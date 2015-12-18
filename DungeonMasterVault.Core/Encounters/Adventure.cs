// <copyright file="Adventure.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Core.Encounters
{
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;
    using Template10.Mvvm;

    /// <summary>
    /// An Adventure
    /// </summary>
    public class Adventure : BindableBase
    {
        private ObservableCollection<Encounter> encounters;
        private string code;
        private string title;

        /// <summary>
        /// Gets or sets the Code
        /// </summary>
        public string Code
        {
            get { return this.code; }
            set { this.Set(ref this.code, value); }
        }

        /// <summary>
        /// Gets or sets the Title
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set { this.Set(ref this.title, value); }
        }

        /// <summary>
        /// Gets or sets the adventure's encounter collection.
        /// </summary>
        [DataMember]
        public ObservableCollection<Encounter> Encounters
        {
            get { return this.encounters; }
            set { this.Set(ref this.encounters, value); }
        }
    }
}