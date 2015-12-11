// <copyright file="Splash.xaml.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.UWP.Views
{
    using System;
    using Windows.ApplicationModel.Activation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// A Splash screen user control.
    /// </summary>
    /// <remarks>
    /// DOCS: https://github.com/Windows-XAML/Template10/wiki/Docs-%7C-SplashScreen
    /// </remarks>
    public sealed partial class Splash : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Splash"/> class.
        /// </summary>
        /// <param name="splashScreen">The injected SlpashScreen.</param>
        public Splash(SplashScreen splashScreen)
        {
            this.InitializeComponent();

            Action resize = () =>
            {
                if (splashScreen.ImageLocation.Top == 0)
                {
                    this.MyImage.Visibility = Visibility.Collapsed;
                    return;
                }
                else
                {
                    this.MyCanvas.Background = null;
                    this.MyImage.Visibility = Visibility.Visible;
                }

                this.MyImage.Height = splashScreen.ImageLocation.Height;
                this.MyImage.Width = splashScreen.ImageLocation.Width;
                this.MyImage.SetValue(Canvas.TopProperty, splashScreen.ImageLocation.Top);
                this.MyImage.SetValue(Canvas.LeftProperty, splashScreen.ImageLocation.Left);
                this.ProgressTransform.TranslateY = this.MyImage.Height / 2;
            };
            Window.Current.SizeChanged += (s, e) => resize();
            resize();
        }
    }
}