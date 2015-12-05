// <copyright file="ViewModelBase.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Mvvm.ViewModels
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// A base class for ViewModels
    /// </summary>
    public class ViewModelBase : Template10.Mvvm.ViewModelBase
    {
        private bool isLoading;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        public ViewModelBase()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether is loading.
        /// </summary>
        [JsonIgnore]
        public virtual bool IsLoading
        {
            get { return this.isLoading; }
            set { this.Set(ref this.isLoading, value); }
        }
    }
}