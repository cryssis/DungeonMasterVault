// <copyright file="SettingsService.Apply.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Services.SettingsServices
{
    using System;
    using Windows.UI.Xaml;

    /// <summary>
    /// A Settings Service using Template10 support
    /// </summary>
    public partial class SettingsService
    {
        /// <summary>
        /// Apply the use shell back button setting.
        /// </summary>
        /// <param name="value">the setting value.</param>
        public void ApplyUseShellBackButton(bool value)
        {
            Template10.Common.BootStrapper.Current.NavigationService.Dispatcher.Dispatch(() =>
            {
                Template10.Common.BootStrapper.Current.ShowShellBackButton = value;
                Template10.Common.BootStrapper.Current.UpdateShellBackButton();
                Template10.Common.BootStrapper.Current.NavigationService.Refresh();
            });
        }

        /// <summary>
        /// Apply the app theme setting.
        /// </summary>
        /// <param name="value">the setting value.</param>
        public void ApplyAppTheme(ApplicationTheme value)
        {
            // Views.Shell.HamburgerMenu.RefreshStyles(value);
        }

        /// <summary>
        /// Apply the cache max duration setting
        /// </summary>
        /// <param name="value">the setting value.</param>
        private void ApplyCacheMaxDuration(TimeSpan value)
        {
            Template10.Common.BootStrapper.Current.CacheMaxDuration = value;
        }
    }
}
