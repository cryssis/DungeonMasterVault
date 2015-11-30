// <copyright file="MainPage.xaml.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.UWP.Views
{
    using Mvvm.ViewModels;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// The Landing page for the app
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage" /> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        /// <summary>
        /// Gets the strongly-type view model to enable x:bind.
        /// </summary>
        public MainViewModel ViewModel => this.DataContext as MainViewModel;
    }
}
