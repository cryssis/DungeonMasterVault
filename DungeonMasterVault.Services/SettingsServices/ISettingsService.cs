// <copyright file="ISettingsService.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Services.SettingsServices
{
    using System;
    using Windows.UI.Xaml;

    /// <summary>
    /// A Settings Service Interface
    /// </summary>
    public interface ISettingsService
    {
        /// <summary>
        /// Gets or sets a value indicating whether use shell back button.
        /// </summary>
        bool UseShellBackButton { get; set; }

        /// <summary>
        /// Gets or sets the app theme.
        /// </summary>
        ApplicationTheme AppTheme { get; set; }

        /// <summary>
        /// Gets or sets the maximun cache duration.
        /// </summary>
        TimeSpan CacheMaxDuration { get; set; }
    }
}
