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

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
        }

        /// <summary>
        /// Gets the Main Page View Model.
        /// </summary>
        public MainViewModel MainPage
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        /// <summary>
        /// Gets the Settings Page View Model.
        /// </summary>
        public SettingsViewModel SettingsPage
        {
            get { return ServiceLocator.Current.GetInstance<SettingsViewModel>(); }
        }

        /// <summary>
        /// Gets the Encounters Page View Model.
        /// </summary>
        public EncountersViewModel EncountersPage
        {
            get { return ServiceLocator.Current.GetInstance<EncountersViewModel>(); }
        }

        /// <summary>
        /// Gets the Encounter Detail Page View Model.
        /// </summary>
        public EncounterDetailViewModel EncounterDetailPage
        {
            get { return ServiceLocator.Current.GetInstance<EncounterDetailViewModel>(); }
        }
    }
}
