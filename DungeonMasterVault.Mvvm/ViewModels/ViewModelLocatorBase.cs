// <copyright file="ViewModelLocatorBase.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Mvvm.ViewModels
{
    using GalaSoft.MvvmLight.Ioc;
    using Microsoft.Practices.ServiceLocation;

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

            SimpleIoc.Default.Register<EncountersViewModel>();
            SimpleIoc.Default.Register<EncounterDetailViewModel>();
        }

        /// <summary>
        /// Gets the Encounters Page View Model.
        /// </summary>
        public EncountersViewModel EncountersViewModel => ServiceLocator.Current.GetInstance<EncountersViewModel>();

        /// <summary>
        /// Gets the Encounter Detail Page View Model.
        /// </summary>
        public EncounterDetailViewModel EncounterDetailViewModel => ServiceLocator.Current.GetInstance<EncounterDetailViewModel>();
    }
}