// <copyright file="ViewModelBase.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Mvvm.ViewModels
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// A base class for ViewModels
    /// </summary>
    public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase, Template10.Services.NavigationService.INavigable
    {
        private bool isLoading;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        public ViewModelBase()
        {
            if (this.IsInDesignMode)
            {
                this.LoadDesignTimeData();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is loading.
        /// </summary>
        [JsonIgnore]
        public virtual bool IsLoading
        {
            get { return this.isLoading; }
            set { this.Set(ref this.isLoading, value); }
        }

        /// <summary>
        /// Gets or sets the navigation service.
        /// </summary>
        [JsonIgnore]
        public Template10.Services.NavigationService.INavigationService NavigationService { get; set; }

        /// <summary>
        /// Gets or sets the dispatcher.
        /// </summary>
        [JsonIgnore]
        public Template10.Common.IDispatcherWrapper Dispatcher { get; set; }

        /// <summary>
        /// Gets or sets the session state.
        /// </summary>
        [JsonIgnore]
        public Template10.Common.IStateItems SessionState { get; set; }

        /// <summary>
        /// Default OnNavigatedTo implementation.
        /// </summary>
        /// <param name="parameter">the parameter.</param>
        /// <param name="mode">the mode.</param>
        /// <param name="state">the state.</param>
        public virtual void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            /* nothing by default */
        }

        /// <summary>
        /// Default OnNavigatedFromAsync implementation.
        /// </summary>
        /// <param name="state">the state.</param>
        /// <param name="suspending">the suspending.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public virtual Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending) => Task.FromResult<object>(null);

        /// <summary>
        /// Default OnNavigatingFrom implementation.
        /// </summary>
        /// <param name="args">the args.</param>
        public virtual void OnNavigatingFrom(Template10.Services.NavigationService.NavigatingEventArgs args)
        {
            /* nothing by default */
        }

        /// <summary>
        /// Loads Sample data for DesignTime
        /// </summary>
        protected virtual void LoadDesignTimeData()
        {
            /* nothing by default */
        }
    }
}
