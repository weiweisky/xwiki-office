﻿#region LGPL license
/*
 * See the NOTICE file distributed with this work for additional
 * information regarding copyright ownership.
 *
 * This is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as
 * published by the Free Software Foundation; either version 2.1 of
 * the License, or (at your option) any later version.
 *
 * This software is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this software; if not, write to the Free
 * Software Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
 * 02110-1301 USA, or see the FSF site: http://www.fsf.org.
 */
#endregion //license

using System;

namespace XWiki.XmlRpc
{
    /// <summary>
    /// Contains information about a version of a page.
    /// </summary>
    public struct PageHistorySummary
    {
        /// <summary>
        /// The version of the page.
        /// </summary>
        public int version;

        /// <summary>
        /// The minor version of the page.
        /// </summary>
        public int minorVersion;

        /// <summary>
        /// The date and time of the modification.
        /// </summary>
        public DateTime modified;

        /// <summary>
        /// The username that made the modification.
        /// </summary>
        public string modifier;

        /// <summary>
        /// The id of the page version.
        /// </summary>
        public String id;
    }
}