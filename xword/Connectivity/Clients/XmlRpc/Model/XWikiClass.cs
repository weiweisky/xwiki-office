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
using CookComputing.XmlRpc;

namespace XWiki.XmlRpc
{
    /// <summary>
    /// Contains information about a XWiki class.
    /// </summary>
    public struct XWikiClass
    {
        /// <summary>
        /// The id of the class
        /// </summary>
        public string id;

        /// <summary>
        /// The propertyToAttributesMap translated into a .net dictionary.
        /// The keys are the properties names, while the values are also dictionaries describing the class property.
        /// </summary>
        [XmlRpcMember("propertyToAttributesMap")]
        public XmlRpcStruct classDictionary;

        /// <summary>
        /// Gets the properties names for the XWiki class.
        /// </summary>
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public String[] Properties
        {
            get
            {
                String[] properties = new string[classDictionary.Count];
                int index = 0;
                foreach (String key in classDictionary.Keys)
                {
                    properties[index] = key;
                    index++;
                }
                return properties;
            }
        }
    }
}
