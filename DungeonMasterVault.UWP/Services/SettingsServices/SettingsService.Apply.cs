// <copyright file="SettingsService.Apply.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.UWP.Services.SettingsServices
{
    using System;
    using Windows.UI.Xaml;

    /// <summary>
    /// A Settings Service class.
    /// </summary>
    public partial class SettingsService
    {
        /// <summary>
        /// Applies the Use of Shell's BackButton to the App
        /// </summary>
        /// <param name="value">The App uses the Shell's BackButton</param>
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
        /// Applies the Theme to the App
        /// </summary>
        /// <param name="value">The theme to be applied</param>
        public void ApplyAppTheme(ApplicationTheme value)
        {
            Views.Shell.HamburgerMenu.RefreshStyles(value);
        }

        private void ApplyCacheMaxDuration(TimeSpan value)
        {
            Template10.Common.BootStrapper.Current.CacheMaxDuration = value;
        }
    }
}