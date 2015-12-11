// <copyright file="ISettingsService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.UWP.Services.SettingsServices
{
    using System;
    using Windows.UI.Xaml;

    /// <summary>
    /// A Settings Service interface.
    /// </summary>
    public interface ISettingsService
    {
        /// <summary>
        /// Gets or sets a value indicating whether the App's Shell BackButton is used
        /// </summary>
        bool UseShellBackButton { get; set; }

        /// <summary>
        /// Gets or sets the Application Theme
        /// </summary>
        ApplicationTheme AppTheme { get; set; }

        /// <summary>
        /// Gets or sets the Maximum Cache Duration for the Navigation
        /// </summary>
        TimeSpan CacheMaxDuration { get; set; }
    }
}