// <copyright file="XPTable.cs" company="Roberto Sobreviela">
// Copyright (c) Roberto Sobreviela. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.
// </copyright>

namespace DungeonMasterVault.Core.Rules
{
    using System.Collections.Generic;

    /// <summary>
    /// A utility class for XP calculations
    /// </summary>
    public static class XPTable
    {
        private static Dictionary<string, int> xpTable;

        /// <summary>
        /// Initializes static members of the <see cref="XPTable"/> class.
        /// </summary>
        static XPTable()
        {
            xpTable = new Dictionary<string, int>();
            xpTable.Add("0", 10);
            xpTable.Add("1/8", 25);
            xpTable.Add("1/4", 50);
            xpTable.Add("1/2", 100);
            xpTable.Add("1", 200);
            xpTable.Add("2", 450);
            xpTable.Add("3", 700);
            xpTable.Add("4", 1100);
            xpTable.Add("5", 1800);
            xpTable.Add("6", 2300);
            xpTable.Add("7", 2900);
            xpTable.Add("8", 3900);
            xpTable.Add("9", 5000);
            xpTable.Add("10", 5900);
            xpTable.Add("11", 7200);
            xpTable.Add("12", 8400);
            xpTable.Add("13", 10000);
            xpTable.Add("14", 11500);
            xpTable.Add("15", 13000);
            xpTable.Add("16", 15000);
            xpTable.Add("17", 18000);
            xpTable.Add("18", 20000);
            xpTable.Add("19", 22000);
            xpTable.Add("20", 25000);
            xpTable.Add("21", 33000);
            xpTable.Add("22", 41000);
            xpTable.Add("23", 50000);
            xpTable.Add("24", 62000);
            xpTable.Add("25", 75000);
            xpTable.Add("26", 90000);
            xpTable.Add("27", 105000);
            xpTable.Add("28", 120000);
            xpTable.Add("29", 135000);
            xpTable.Add("30", 155000);
        }

        /// <summary>
        /// Returns the XP Value by Challenge Rating
        /// </summary>
        /// <param name="crText">The Challenge Rating</param>
        /// <returns>The XP Value for the Challenge Rating</returns>
        public static long XPbyCR(string crText)
        {
            try
            {
                long xpVal = 0;
                if (xpTable.ContainsKey(crText))
                {
                    xpVal = xpTable[crText];
                }

                return xpVal;
            }
            catch
            {
                throw;
            }
        }
    }
}