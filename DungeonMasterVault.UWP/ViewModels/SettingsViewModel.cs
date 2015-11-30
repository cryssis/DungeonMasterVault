// <copyright file="SettingsViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Mvvm.ViewModels
{
    /// <summary>
    /// A enumeration of Settings Parts for strong-type navigation
    /// </summary>
    public enum SettingsParts
    {
        /// <summary>
        /// The General Settings
        /// </summary>
        General,

        /// <summary>
        /// The About
        /// </summary>
        About
    }

    /// <summary>
    /// A ViewModel for Settings
    /// </summary>
    public class SettingsViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets the General Part View Model of the Settings
        /// </summary>
        public SettingsPartGeneralViewModel SettingsPartViewModel { get; }

        /// <summary>
        /// Gets the About Part View Model of the Settings.
        /// </summary>
        public SettingsPartAboutViewModel AboutPartViewModel { get; }
    }
}
