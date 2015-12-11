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
    /// The Shell for the App Frame
    /// </summary>
    /// <remarks>
    /// DOCS: https://github.com/Windows-XAML/Template10/wiki/Docs-%7C-SplitView
    /// </remarks>
    public sealed partial class Shell : Page, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shell"/> class.
        /// </summary>
        /// <param name="navigationService">The injected NavigationService</param>
        public Shell(NavigationService navigationService)
        {
            Instance = this;
            this.InitializeComponent();
            this.MyHamburgerMenu.NavigationService = navigationService;
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the HamburgerMenu
        /// </summary>
        public static HamburgerMenu HamburgerMenu
        {
            get { return Instance.MyHamburgerMenu; }
        }

        /// <summary>
        /// Gets or sets the singleton Shell instance.
        /// </summary>
        public static Shell Instance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the App is busy.
        /// </summary>
        public bool IsBusy { get; set; } = false;

        /// <summary>
        /// Gets or sets the Busy text for the App.
        /// </summary>
        public string BusyText { get; set; } = "Please wait...";

        /// <summary>
        /// Changes the App's busy mode.
        /// </summary>
        /// <param name="busy">The App is busy.</param>
        /// <param name="text">The text to show while is busy.</param>
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