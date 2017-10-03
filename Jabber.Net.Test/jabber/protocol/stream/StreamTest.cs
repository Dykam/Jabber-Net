/* --------------------------------------------------------------------------
 * Copyrights
 *
 * Portions created by or assigned to Cursive Systems, Inc. are
 * Copyright (c) 2002-2008 Cursive Systems, Inc.  All Rights Reserved.  Contact
 * information for Cursive Systems, Inc. is available at
 * http://www.cursive.net/.
 *
 * License
 *
 * Jabber-Net is licensed under the LGPL.
 * See LICENSE.txt for details.
 * --------------------------------------------------------------------------*/
using System;

using System.Xml;
using System.Text.RegularExpressions;
using NUnit.Framework;

using bedrock.util;
using Jabber.protocol;
using Jabber.protocol.stream;
using fact = Jabber.protocol.stream.Factory;

namespace test.Jabber.protocol.stream
{
    /// <summary>
    /// Summary description for StreamTest.
    /// </summary>
    [SVN(@"$Id$")]
    [TestFixture]
    public class StreamTest
    {
        XmlDocument doc = new XmlDocument();
        [Test] public void Test_Create()
        {
            Stream s = new Stream(doc, "Jabber:client");
            Assert.IsTrue(
                Regex.IsMatch(s.ToString(),
                "<stream:stream id=\"[a-z0-9]+\" xmlns=\"Jabber:client\" xmlns:stream=\"http://etherx\\.Jabber\\.org/streams\" />",
                RegexOptions.IgnoreCase), s.ToString());
        }
        [Test] public void Test_Error()
        {
            Error err = new Error(doc);
            err.Message = "foo";
            Assert.AreEqual("<stream:error " +
                "xmlns:stream=\"http://etherx.Jabber.org/streams\">foo</stream:error>", err.ToString());
            ElementFactory sf = new ElementFactory();
            sf.AddType(new fact());
            XmlQualifiedName qname = new XmlQualifiedName(err.LocalName, err.NamespaceURI);
            Element p = (Element) sf.GetElement(err.Prefix, qname, doc);
            Assert.AreEqual(typeof(Error), p.GetType());
        }
        [Test] public void Test_StartTag()
        {
            Stream s = new Stream(doc, "Jabber:client");
            Assert.IsTrue(
                Regex.IsMatch(s.StartTag(),
                "<stream:stream xmlns:stream=\"http://etherx\\.Jabber\\.org/streams\" id=\"[a-z0-9]+\" xmlns=\"Jabber:client\">",
                RegexOptions.IgnoreCase), s.StartTag());
        }
    }
}
