// <copyright file="SettingsPage.xaml.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.UWP.Views
{
    using Mvvm.ViewModels;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsPage" /> class.
        /// </summary>
        public SettingsPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        /// <summary>
        /// Gets the Strongly-typed ViewModels that enable x:bind
        /// </summary>
        public SettingsViewModel ViewModel => this.DataContext as SettingsViewModel;

        /// <summary>
        /// Settings OnNavigatedTo implementation.
        /// </summary>
        /// <param name="e">the navigation event args.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int index;
            if (int.TryParse(e.Parameter?.ToString(), out index))
            {
                this.MyPivot.SelectedIndex = index;
            }
        }
    }
}
