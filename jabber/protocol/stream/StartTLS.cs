/* --------------------------------------------------------------------------
 * Copyrights
 * 
 * Portions created by or assigned to Cursive Systems, Inc. are 
 * Copyright (c) 2002-2004 Cursive Systems, Inc.  All Rights Reserved.  Contact
 * information for Cursive Systems, Inc. is available at
 * http://www.cursive.net/.
 *
 * License
 * 
 * Jabber-Net can be used under either JOSL or the GPL.  
 * See LICENSE.txt for details.
 * --------------------------------------------------------------------------*/
using System;
using System.Xml;

using bedrock.util;

namespace jabber.protocol.stream
{
    /// <summary>
    /// Start-TLS in stream features.
    /// </summary>
    [RCS(@"$Header$")]
    public class StartTLS : Element
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        public StartTLS(XmlDocument doc) :
            base(null, new XmlQualifiedName("starttls", jabber.protocol.URI.START_TLS), doc)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public StartTLS(string prefix, XmlQualifiedName qname, XmlDocument doc) : 
            base(prefix, qname, doc)
        {
        }

        /// <summary>
        /// Is starttls required?
        /// </summary>
        public bool Required
        {
            get { return this["required"] != null; }
            set 
            {
                if (value)
                {
                    if (this["required"] == null) 
                    {
                        SetElem("required", null);
                    }
                }
                else 
                {
                    if (this["required"] != null) 
                    {
                        RemoveElem("required");
                    }
                }
            }
        }
    }

    /// <summary>
    /// Start-TLS proceed.
    /// </summary>
    [RCS(@"$Header$")]
    public class Proceed : Element
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="xmlns"></param>
        public Proceed(XmlDocument doc, string xmlns) :
            base(null, new XmlQualifiedName("proceed", jabber.protocol.URI.START_TLS), doc)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public Proceed(string prefix, XmlQualifiedName qname, XmlDocument doc) : 
            base(prefix, qname, doc)
        {
        }
    }

    /// <summary>
    /// Start-TLS failure.
    /// </summary>
    [RCS(@"$Header$")]
    public class TLSFailure : Element
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="xmlns"></param>
        public TLSFailure(XmlDocument doc, string xmlns) :
            base(null, new XmlQualifiedName("failure", jabber.protocol.URI.START_TLS), doc)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
        public TLSFailure(string prefix, XmlQualifiedName qname, XmlDocument doc) : 
            base(prefix, qname, doc)
        {
        }
    }
}