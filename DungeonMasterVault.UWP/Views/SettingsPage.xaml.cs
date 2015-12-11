// <copyright file="SettingsPage.xaml.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.UWP.Views
{
    using DungeonMasterVault.UWP.ViewModels;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// A Settings Page
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsPage"/> class.
        /// </summary>
        public SettingsPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        /// <summary>
        /// Gets strongly-typed view model to enable x:bind
        /// </summary>
        public SettingsPageViewModel ViewModel => this.DataContext as SettingsPageViewModel;

        /// <inheritdoc />
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