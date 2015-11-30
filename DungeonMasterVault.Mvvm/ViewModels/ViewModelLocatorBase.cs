// <copyright file="ViewModelLocatorBase.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Mvvm.ViewModels
{
    using GalaSoft.MvvmLight.Ioc;
    using Microsoft.Practices.ServiceLocation;
    using Services.DataServices;

    /// <summary>
    /// A ViewModel locator class for Mvvm pattern.
    /// </summary>
    public class ViewModelLocatorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelLocatorBase"/> class.
        /// </summary>
        public ViewModelLocatorBase()
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

            SimpleIoc.Default.Register<EncountersViewModel>();
            SimpleIoc.Default.Register<EncounterDetailViewModel>();
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