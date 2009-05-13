﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace XWord
{
    /// <summary>
    /// Represents the context of the add-in.
    /// </summary>
    public class AddinStatus
    {
        private bool taskPaneShown;
        private NameValueCollection taskPaneSelectedPage;
        private bool loggedIn;
        private bool connectedWithServer;
        private String serverURL;
        private String syntax;

        /// <summary>
        /// The syntax used to save the wiki pages.
        /// <remarks>The conversion is done on the web server</remarks>
        /// </summary>
        public String Syntax
        {
            get { return syntax; }
            set { syntax = value; }
        }

        /// <summary>
        /// The URL of the server to which the user is conected.
        /// </summary>
        public String ServerURL
        {
            get { return serverURL; }
            set { serverURL = value; }
        }
        
        /// <summary>
        /// Specifies if the user is logged in to XWiki server or not.
        /// </summary>
        public bool LoggedIn
        {
            get { return loggedIn; }
            set { loggedIn = value; }
        }

        /// <summary>
        /// Specifies if the server is connected to the XWiki server or not.
        /// </summary>
        public bool ConnectedWithServer
        {
            get { return connectedWithServer; }
            set { connectedWithServer = value; }
        }
        
        /// <summary>
        /// Gets the value of the curently selected tree node representing a page
        /// </summary>
        public NameValueCollection TaskPaneSelectedPage
        {
            get 
            {
                if(taskPaneSelectedPage == null)
                {
                    taskPaneSelectedPage = new NameValueCollection();
                }
                return taskPaneSelectedPage;                
            }
            set { taskPaneSelectedPage = value; }
        }

        /// <summary>
        /// Gets/Sets the status of the task pane.
        /// The keys are: "page" and "space".
        /// </summary>
        public bool TaskPaneShown
        {
            get { return taskPaneShown; }
            set { taskPaneShown = value; }
        }

        /// <summary>
        /// Sets the values corresponding to the selected page in the tree view
        /// </summary>
        /// <param name="space">The value for the "space" key.</param>
        /// <param name="page">The value for the "page" key.</param>
        public void SetTaskPaneSelectedPage(String space, String page)
        {
            taskPaneSelectedPage.Add("space", space);
            taskPaneSelectedPage.Add("page", page);
        }
    }
}
