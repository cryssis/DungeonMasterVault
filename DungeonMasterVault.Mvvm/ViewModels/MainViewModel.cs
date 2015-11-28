// <copyright file="MainViewModel.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Mvvm.ViewModels
{
    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// A ViewModel for the Main Page
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand navigateToAboutCommand;

        /// <summary>
        /// Gets the navigate to about command.
        /// </summary>
        public RelayCommand NavigateToAboutCommand
        {
            get
            {
                return this.navigateToAboutCommand ?? (this.navigateToAboutCommand = new RelayCommand(() =>
                {
                    this.NavigationService.Navigate(Pages.Settings, SettingsParts.About);
                }));
            }
        }
    }
}
