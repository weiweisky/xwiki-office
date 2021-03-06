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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XWiki.Model
{
    /// <summary>
    /// Class used to store data about the wiki structure.
    /// Contains the list of spaces and documents.
    /// </summary>
    [Serializable]
    public class Wiki
    {
        /// <summary>
        /// A list with all spaces in the wiki.
        /// </summary>
        public List<Space> spaces;
        /// <summary>
        /// Default constructor. Instantiates the spaces list.
        /// </summary>
        public Wiki()
        {
            spaces = new List<Space>();
        }

        /// <summary>
        /// Wiki indexer. Gets the instance of the specified space in the wiki.
        /// </summary>
        /// <param name="spaceName">The name of the wiki space.</param>
        /// <returns>A instance of the space.</returns>
        public Space this[String spaceName]
        {
            get
            {
                foreach (Space space in spaces)
                {
                    if (space.name == spaceName)
                    {
                        return space;
                    }
                }
                String message = "There is no space '" + spaceName + "in the wiki";
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Gets all document instances in the wiki.
        /// </summary>
        /// <returns>A list with all document instances.</returns>
        public List<XWikiDocument> GetAllDocuments()
        {
            List<XWikiDocument> allDocs = new List<XWikiDocument>();
            foreach (Space space in this.spaces)
            {
                foreach (XWikiDocument doc in space.documents)
                {
                    allDocs.Add(doc);
                }
            }
            return allDocs;
        }

        /// <summary>
        /// Removes a XWikiDocument instance from the wiki structure.
        /// This has no effect on the server. It only affects the document list
        /// Word works with.
        /// </summary>
        public void RemoveXWikiDocument(XWikiDocument doc)
        {
            foreach (Space space in spaces)
            {
                if (space.name == doc.space)
                {
                    space.documents.Remove(doc);
                }
            }
        }

        /// <summary>
        /// Gets the unplublished spaces and documents from wiki structure instance.
        /// </summary>
        /// <returns>A new WikiStructure instance containing only the unpublished spaces and documents.</returns>
        public Wiki GetUnpublishedWikiStructure()
        {
            Wiki unpublishedStruct = new Wiki();
            foreach (Space sp in spaces)
            {
                //space with unpublished pages?
                if (!sp.published)
                {
                    unpublishedStruct.spaces.Add(sp);
                }
                else
                {
                    List<XWikiDocument> docs = sp.GetUnpublishedDocuments();
                    if (docs.Count > 0)
                    {
                        sp.documents = docs;
                        unpublishedStruct.spaces.Add(sp);
                    }
                }
            }
            return unpublishedStruct;
        }

        /// <summary>
        /// Specifies if the wiki contains a given space.
        /// </summary>
        /// <param name="spaceName">The name of the searched space.</param>
        /// <returns>True if a space with the given name exists in the wiki. False otherwise.</returns>
        public bool ContainsSpace(string spaceName)
        {
            foreach (Space space in spaces)
            {
                if (space.name == spaceName)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds a collection of spaces to the wiki.
        /// </summary>
        /// <param name="_spaces"></param>
        public void AddSpaces(IEnumerable<Space> _spaces)
        {
            spaces.AddRange(_spaces);
        }

        /// <summary>
        /// Adds a collection of spaces to the wiki.
        /// </summary>
        /// <param name="_spaces"></param>
        public void AddSpaces(IEnumerable<String> _spaces)
        {
            foreach (String spaceName in _spaces)
            {
                Space space = new Space();
                space.name = spaceName;
                space.published = true;
                spaces.Add(space);
            }        
        }

        /// <summary>
        /// Gets the XWiki Document for a given id.
        /// </summary>
        /// <param name="pageFullName">The full name of the page.</param>
        public XWikiDocument GetPageById(String pageFullName)
        {
            String[] wikiPageName = pageFullName.Split('.');
            if (wikiPageName.Length > 2)
            {
                throw new InvalidPageNameException();
            }
            Space space = this[wikiPageName[0]];
            return space[wikiPageName[1]];
        }
    }
}