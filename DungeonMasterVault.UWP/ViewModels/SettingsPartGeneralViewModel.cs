// <copyright file="SettingsPartGeneralViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

using Windows.UI.Xaml;

namespace DungeonMasterVault.Mvvm.ViewModels
{
    /// <summary>
    /// A View Model for the General Part of the Settings
    /// </summary>
    public class SettingsPartGeneralViewModel : ViewModelBase
    {
        private Services.SettingsServices.SettingsService settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsPartGeneralViewModel" /> class.
        /// </summary>
        public SettingsPartGeneralViewModel()
        {
            if (!this.IsInDesignMode)
            {
                this.settings = Services.SettingsServices.SettingsService.Instance;
            }
        }

        public bool UseLightThemeButton
        {
            get
            {
                return this.settings.AppTheme.Equals(ApplicationTheme.Light);
            }

            set
            {
                this.settings.AppTheme = value ? ApplicationTheme.Light : ApplicationTheme.Dark;
                base.RaisePropertyChanged();
            }
        }
    }
}
