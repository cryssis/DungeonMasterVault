// <copyright file="SettingsPartGeneralViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Mvvm.ViewModels
{
    using Windows.UI.Xaml;

    /// <summary>
    /// A View Model for the General Part of the Settings
    /// </summary>
    public class SettingsPartGeneralViewModel : ViewModelBase
    {
        private UWP.Services.SettingsServices.SettingsService settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsPartGeneralViewModel" /> class.
        /// </summary>
        public SettingsPartGeneralViewModel()
        {
            if (!GalaSoft.MvvmLight.ViewModelBase.IsInDesignModeStatic)
            {
                this.settings = UWP.Services.SettingsServices.SettingsService.Instance;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether The Light Theme is used
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
    }
}