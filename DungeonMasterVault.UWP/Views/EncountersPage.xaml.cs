// <copyright file="EncountersPage.xaml.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.UWP.Views
{
    using System.Collections.Generic;
    using System.Linq;
    using Mvvm.ViewModels;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// Encounters List Page
    /// </summary>
    public sealed partial class EncountersPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EncountersPage" /> class.
        /// </summary>
        public EncountersPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        /// <summary>
        /// Gets the strongly-typesd view model that enables x:bind.
        /// </summary>
        public EncountersViewModel ViewModel => this.DataContext as EncountersViewModel;
    }
}
