// <copyright file="ItemClickEventArgsConverter.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Mvvm.Converters
{
    using System;
    using DragonSphere.Core.Encounters;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Data;

    /// <summary>
    /// Converts from ItemClickEventArgs to types on DungeonVaultMaster.Core
    /// </summary>
    public sealed class ItemClickEventArgsConverter : IValueConverter
    {
        /// <summary>
        /// Converts an ItemClickEventArgs to its DungeonVaultMaster.Core type
        /// </summary>
        /// <param name="value">the value.</param>
        /// <param name="targetType">the target type.</param>
        /// <param name="parameter">the parameter.</param>
        /// <param name="language">the language.</param>
        /// <returns>The DungeonVaultMaster.Core object</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var args = value as ItemClickEventArgs;
            if (args == null)
            {
                throw new ArgumentException("Value is not ItemClickEventArgs");
            }

            if (args.ClickedItem is Encounter)
            {
                var selectedItem = args.ClickedItem as Encounter;
                return selectedItem;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Converts a DungeonVaultMaster.Core type in ItemClickEventArgs
        /// </summary>
        /// <param name="value">the value.</param>
        /// <param name="targetType">the target type.</param>
        /// <param name="parameter">the parameter.</param>
        /// <param name="language">the language.</param>
        /// <returns>The ItemClickEventArgs object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
