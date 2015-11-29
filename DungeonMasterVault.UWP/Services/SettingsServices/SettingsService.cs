// <copyright file="SettingsService.cs" company="Roberto Sobreviela">
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
    public partial class SettingsService : ISettingsService
    {
        private Template10.Services.SettingsService.ISettingsHelper helper;

        /// <summary>
        /// Initializes static members of the <see cref="SettingsService"/> class.
        /// </summary>
        static SettingsService()
        {
            // implement a singleton pattern
            Instance = Instance ?? new SettingsService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsService" /> class.
        /// </summary>
        private SettingsService()
        {
            this.helper = new Template10.Services.SettingsService.SettingsHelper();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static SettingsService Instance { get; }

        /// <summary>
        /// Gets or sets a value indicating whether use shell back button.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the app theme.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the cache max duration.
        /// </summary>
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
