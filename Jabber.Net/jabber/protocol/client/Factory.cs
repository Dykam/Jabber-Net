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

namespace Jabber.protocol.client
{
    /// <summary>
    /// ElementFactory for the jabber:client namespace.
    /// </summary>
    [SVN(@"$Id$")]
    public class Factory : IPacketTypes
    {
        private static QnameType[] s_qnt = new QnameType[]
        {
            new QnameType("presence", URI.CLIENT, typeof(Presence)),
            new QnameType("message",  URI.CLIENT, typeof(Message)),
            new QnameType("iq",       URI.CLIENT, typeof(IQ)),
            new QnameType("error",    URI.CLIENT, typeof(Error)),
            // meh.  jabber protocol really isn't right WRT to namespaces.
            new QnameType("presence", URI.ACCEPT, typeof(Presence)),
            new QnameType("message",  URI.ACCEPT, typeof(Message)),
            new QnameType("iq",       URI.ACCEPT, typeof(IQ)),
            new QnameType("error",    URI.ACCEPT, typeof(Error))
        };
        QnameType[] IPacketTypes.Types { get { return s_qnt; } }
    }
}
