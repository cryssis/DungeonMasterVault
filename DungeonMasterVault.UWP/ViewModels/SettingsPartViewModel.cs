// <copyright file="SettingsPartViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.UWP.ViewModels
{
    using System;
    using Windows.UI.Xaml;

    /// <summary>
    /// The General Settings part of the settings ViewModel
    /// </summary>
    public class SettingsPartViewModel : DungeonMasterVault.Mvvm.ViewModels.ViewModelBase
    {
        private string busyText = "Please wait...";
        private Services.SettingsServices.SettingsService settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsPartViewModel"/> class.
        /// </summary>
        public SettingsPartViewModel()
        {
            if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                this.settings = Services.SettingsServices.SettingsService.Instance;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether The shell back button is used
        /// </summary>
        public bool UseShellBackButton
        {
            get
            {
                return this.settings.UseShellBackButton;
            }

            set
            {
                this.settings.UseShellBackButton = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Light Theme is used.
        /// </summary>
        public bool UseLightThemeButton
        {
            get
            {
                return this.settings.AppTheme.Equals(ApplicationTheme.Light);
            }

            set
            {
                this.settings.AppTheme = value ? ApplicationTheme.Light : ApplicationTheme.Dark;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the App Busy Text
        /// </summary>
        public string BusyText
        {
            get { return this.busyText; }
            set { this.Set(ref this.busyText, value); }
        }

        /// <summary>
        /// Shows the Busy layer
        /// </summary>
        public void ShowBusy()
        {
            Views.Shell.SetBusy(true, this.busyText);
        }

        /// <summary>
        /// Hides the Busy layer
        /// </summary>
        public void HideBusy()
        {
            Views.Shell.SetBusy(false);
        }
    }
}