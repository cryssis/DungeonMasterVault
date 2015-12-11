// <copyright file="App.xaml.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.UWP
{
    using System.Threading.Tasks;
    using Mvvm.ViewModels;
    using Services.SettingsServices;
    using Views;
    using Windows.ApplicationModel.Activation;
    using Windows.UI.Xaml;

    // Documentation on APIs used in this page:
    // https://github.com/Windows-XAML/Template10/wiki

    /// <summary>
    /// The Entry point for the App
    /// </summary>
    sealed partial class App : Template10.Common.BootStrapper
    {
        private ISettingsService settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.SplashFactory = (e) => new Views.Splash(e);

            this.settings = SettingsService.Instance;
            this.RequestedTheme = this.settings.AppTheme;
            this.CacheMaxDuration = this.settings.CacheMaxDuration;
            this.ShowShellBackButton = this.settings.UseShellBackButton;
        }

        /// <inheritdoc />
        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            var keys = this.PageKeys<Pages>();
            keys.Add(Pages.Main, typeof(MainPage));
            keys.Add(Pages.Settings, typeof(SettingsPage));
            keys.Add(Pages.Encounters, typeof(EncountersPage));
            keys.Add(Pages.EncounterDetail, typeof(EncounterDetailPage));

            // Setting up the hamburger shell
            var nav = this.NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);
            Window.Current.Content = new Views.Shell(nav);
            await Task.Yield();
        }

        /// <inheritdoc />
        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // Perform any long-running load
            await Task.Delay(0);

            // Navigate to the first page inside the shell
            this.NavigationService.Navigate(Pages.Main);
        }
    }
}