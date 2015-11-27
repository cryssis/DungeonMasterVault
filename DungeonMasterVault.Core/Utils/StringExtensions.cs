// <copyright file="StringExtensions.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Core.Utils
{
    using System;

    /// <summary>
    /// Static string extension methods for formatting.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Format a integer on a string with sign and space.
        /// </summary>
        /// <param name="number">The integer number to format.</param>
        /// <returns>The string that contains the integer with its sign and a space.</returns>
        public static string PlusFormatSpaceNumber(int number)
        {
            if (number >= 0)
            {
                return "+ " + number.ToString();
            }
            else
            {
                return "- " + Math.Abs(number).ToString();
            }
        }

        /// <summary>
        /// Format a integer on a string with sign.
        /// </summary>
        /// <param name="number">The integer number to format.</param>
        /// <returns>The string that contains the integer with its sign.</returns>
        public static string PlusFormatNumber(int number)
        {
            if (number >= 0)
            {
                return "+" + number.ToString();
            }
            else
            {
                return number.ToString();
            }
        }

        /// <summary>
        /// Format a nullable integer on a string with sign.
        /// </summary>
        /// <param name="number">The nullable integer number to format.</param>
        /// <returns>The string that contains the integer with its sign.</returns>
        public static string PlusFormatNumber(int? number)
        {
            if (number == null)
            {
                return "-";
            }
            else
            {
                return ((int)number).PlusFormat();
            }
        }

        /// <summary>
        /// Static Integer Method to format a integer on a string with sign.
        /// </summary>
        /// <param name="number">The integer number to format.</param>
        /// <returns>The string that contains the integer with its sign.</returns>
        public static string PlusFormat(this int number)
        {
            return PlusFormatNumber(number);
        }

        /// <summary>
        /// Static Nullable Integer Method to format a nullable integer on a string with sign.
        /// </summary>
        /// <param name="number">The nullable integer number to format.</param>
        /// <returns>The string that contains the integer with its sign.</returns>
        public static string PlusFormat(this int? number)
        {
            return PlusFormatNumber(number);
        }
    }
}