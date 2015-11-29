// <copyright file="EncounterDetailPage.xaml.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.UWP.Views
{
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class EncounterDetailPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EncounterDetailPage"/> class.
        /// </summary>
        public EncounterDetailPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }
    }
}
