// <copyright file="SettingsService.cs" company="Roberto Sobreviela">
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
    /// <remarks>
    /// DOCS: https://github.com/Windows-XAML/Template10/wiki/Docs-%7C-SettingsService///
    /// </remarks>
    public partial class SettingsService : ISettingsService
    {
        private Template10.Services.SettingsService.ISettingsHelper helper;

        static SettingsService()
        {
            // implement singleton pattern
            Instance = Instance ?? new SettingsService();
        }

        private SettingsService()
        {
            this.helper = new Template10.Services.SettingsService.SettingsHelper();
        }

        /// <summary>
        /// Gets the static singleton Instance for this class.
        /// </summary>
        public static SettingsService Instance { get; }

        /// <inheritdoc />
        public bool UseShellBackButton
        {
            get
            {
                return this.helper.Read<bool>(nameof(this.UseShellBackButton), true);
            }

            set
            {
                this.helper.Write(nameof(this.UseShellBackButton), value);
                this.ApplyUseShellBackButton(value);
            }
        }

        /// <inheritdoc />
        public ApplicationTheme AppTheme
        {
            get
            {
                var theme = ApplicationTheme.Dark;
                var value = this.helper.Read<string>(nameof(this.AppTheme), theme.ToString());
                return Enum.TryParse<ApplicationTheme>(value, out theme) ? theme : ApplicationTheme.Dark;
            }

            set
            {
                this.helper.Write(nameof(this.AppTheme), value.ToString());
                this.ApplyAppTheme(value);
            }
        }

        /// <inheritdoc />
        public TimeSpan CacheMaxDuration
        {
            get
            {
                return this.helper.Read<TimeSpan>(nameof(this.CacheMaxDuration), TimeSpan.FromDays(2));
            }

            set
            {
                this.helper.Write(nameof(this.CacheMaxDuration), value);
                this.ApplyCacheMaxDuration(value);
            }
        }
    }
}