// <copyright file="AboutPartViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.UWP.ViewModels
{
    using System;
    using Windows.UI.Xaml;

    /// <summary>
    /// The About part of the Settings View Model
    /// </summary>
    public class AboutPartViewModel : DungeonMasterVault.Mvvm.ViewModels.ViewModelBase
    {
        /// <summary>
        /// Gets the App Logo
        /// </summary>
        public Uri Logo => Windows.ApplicationModel.Package.Current.Logo;

        /// <summary>
        /// Gets the App Display Name
        /// </summary>
        public string DisplayName => Windows.ApplicationModel.Package.Current.DisplayName;

        /// <summary>
        /// Gets the App Publisher name
        /// </summary>
        public string Publisher => Windows.ApplicationModel.Package.Current.PublisherDisplayName;

        /// <summary>
        /// Gets the App version string
        /// </summary>
        public string Version
        {
            get
            {
                var ver = Windows.ApplicationModel.Package.Current.Id.Version;
                return ver.Major.ToString() + "." + ver.Minor.ToString() + "." + ver.Build.ToString() + "." + ver.Revision.ToString();
            }
        }

        /// <summary>
        /// Gets the RateMe Uri value
        /// </summary>
        public Uri RateMe => new Uri("http://bing.com");
    }
}