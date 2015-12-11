// <copyright file="SettingsPageViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.UWP.ViewModels
{
    /// <summary>
    /// The Settings View Model
    /// </summary>
    public class SettingsPageViewModel : DungeonMasterVault.Mvvm.ViewModels.ViewModelBase
    {
        /// <summary>
        /// Gets the the general settings part View Model
        /// </summary>
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();

        /// <summary>
        /// Gets the about settings part View Model
        /// </summary>
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
    }
}