// <copyright file="Shell.xaml.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.UWP.Views
{
    using System.ComponentModel;
    using Template10.Common;
    using Template10.Controls;
    using Template10.Services.NavigationService;
    using Windows.UI.Core;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// A Shell with Hamburger Menu support form Template10
    /// </summary>
    public sealed partial class Shell : Page, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shell"/> class.
        /// </summary>
        /// <param name="navigationService">The navigation service injected.</param>
        public Shell(NavigationService navigationService)
        {
            Instance = this;
            this.InitializeComponent();
            this.MyHamburgerMenu.NavigationService = navigationService;
        }

        /// <summary>
        /// Event handler for the PropertyChanged event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the Instance.
        /// </summary>
        public static Shell Instance { get; set; }

        /// <summary>
        /// Gets the Hamburger menu in the Shell.
        /// </summary>
        public static HamburgerMenu HamburgerMenu
        {
            get { return Instance.MyHamburgerMenu; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the app is busy.
        /// </summary>
        public bool IsBusy { get; set; } = false;

        /// <summary>
        /// Gets or sets the busy text.
        /// </summary>
        public string BusyText { get; set; } = "Please wait...";

        /// <summary>
        /// Toggles the App on busy mode.
        /// </summary>
        /// <param name="busy">the app is busy.</param>
        /// <param name="text">the text showing while is busy.</param>
        public static void SetBusy(bool busy, string text = null)
        {
            WindowWrapper.Current().Dispatcher.Dispatch(() =>
            {
                if (busy)
                {
                    SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                }
                else
                {
                    BootStrapper.Current.UpdateShellBackButton();
                }

                Instance.IsBusy = busy;
                Instance.BusyText = text;

                Instance.PropertyChanged?.Invoke(Instance, new PropertyChangedEventArgs(nameof(IsBusy)));
                Instance.PropertyChanged?.Invoke(Instance, new PropertyChangedEventArgs(nameof(BusyText)));
            });
        }
    }
}
