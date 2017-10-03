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


using bedrock.util;
using Jabber.protocol;
using Jabber.protocol.iq;

namespace Jabber.protocol.x
{
    /// <summary>
    /// ElementFactory for all currently supported IQ namespaces.
    /// </summary>
    [SVN(@"$Id$")]
    public class Factory : IPacketTypes
    {
        private static QnameType[] s_qnt = new QnameType[]
        {
                    new QnameType("x",     URI.XDELAY,    typeof(Delay)),
                    new QnameType("x",     URI.XEVENT,    typeof(Event)),
                    new QnameType("x",     URI.XOOB,      typeof(OOB)),
                    new QnameType("x",     URI.XROSTER,   typeof(Roster)),
                    new QnameType("item",  URI.XROSTER,   typeof(Item)),
                    new QnameType("group", URI.XROSTER,   typeof(Group)),

                    new QnameType("x",     URI.XDATA,     typeof(Data)),
                    new QnameType("field", URI.XDATA,     typeof(Field)),
                    new QnameType("option",URI.XDATA,     typeof(Option)),

                    new QnameType("c",     URI.CAPS,      typeof(Caps)),
        };
        QnameType[] IPacketTypes.Types { get { return s_qnt; } }
    }
}
