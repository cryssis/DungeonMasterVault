// <copyright file="WindowsViewModelLocator.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.UWP.ViewModels
{
    using GalaSoft.MvvmLight.Ioc;
    using Microsoft.Practices.ServiceLocation;
    using Mvvm.ViewModels;

    /// <summary>
    /// A ViewModelLocator for Windows UWP App
    /// </summary>
    public class WindowsViewModelLocator : ViewModelLocatorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsViewModelLocator" /> class.
        /// </summary>
        public WindowsViewModelLocator()
            : base()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<SettingsPageViewModel>();
        }

        /// <summary>
        /// Gets the Main Page View Model.
        /// </summary>
        public MainPageViewModel MainPage
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }

        /// <summary>
        /// Gets the Settings Page View Model.
        /// </summary>
        public SettingsPageViewModel SettingsPage
        {
            get { return ServiceLocator.Current.GetInstance<SettingsPageViewModel>(); }
        }
    }
}