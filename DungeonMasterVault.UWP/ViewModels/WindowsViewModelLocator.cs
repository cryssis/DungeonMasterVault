// <copyright file="WindowsViewModelLocator.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.UWP.ViewModels
{
    using DungeonMasterVault.Services.DataServices;
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

            if (GalaSoft.MvvmLight.ViewModelBase.IsInDesignModeStatic)
            {
                // Design Time
                SimpleIoc.Default.Register<IDataService, DesignTimeDataService>();
            }
            else
            {
                // Runtime
                SimpleIoc.Default.Register<IDataService, SampleDataService>();
            }

            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<SettingsPageViewModel>();
        }

        /// <summary>
        /// Gets the Main Page View Model.
        /// </summary>
        public MainPageViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainPageViewModel>();

        /// <summary>
        /// Gets the Settings Page View Model.
        /// </summary>
        public SettingsPageViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsPageViewModel>();
    }
}