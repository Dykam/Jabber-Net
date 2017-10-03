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

namespace Jabber.protocol.iq
{
    /// <summary>
    /// ElementFactory for all currently supported IQ namespaces.
    /// </summary>
    [SVN(@"$Id$")]
    public class Factory : IPacketTypes
    {
        private static QnameType[] s_qnt = new QnameType[]
        {
            new QnameType("query", URI.AUTH,     typeof(Auth)),
            new QnameType("query", URI.REGISTER, typeof(Register)),
            new QnameType("query", URI.ROSTER,   typeof(Roster)),
            new QnameType("item",  URI.ROSTER,   typeof(Item)),
            new QnameType("group", URI.ROSTER,   typeof(Group)),
            new QnameType("query", URI.AGENTS,   typeof(AgentsQuery)),
            new QnameType("agent", URI.AGENTS,   typeof(Agent)),
            new QnameType("query", URI.OOB,      typeof(OOB)),
            new QnameType("query", URI.TIME,     typeof(Time)),
            new QnameType("query", URI.VERSION,  typeof(Version)),
            new QnameType("query", URI.LAST,     typeof(Last)),
            new QnameType("item",  URI.BROWSE,   typeof(Browse)),
            new QnameType("geoloc",URI.GEOLOC,   typeof(GeoLoc)),
            
            
            new QnameType("query",      URI.PRIVATE,   typeof(Private)),
            new QnameType("storage",    URI.BOOKMARKS, typeof(Bookmarks)),
            new QnameType("url",        URI.BOOKMARKS, typeof(BookmarkURL)),
            new QnameType("conference", URI.BOOKMARKS, typeof(BookmarkConference)),
            new QnameType("note",       URI.BOOKMARKS, typeof(BookmarkNote)),

            // VCard
            new QnameType("vCard", URI.VCARD, typeof(VCard)),
            new QnameType("N",     URI.VCARD, typeof(VCard.VName)),
            new QnameType("ORG",   URI.VCARD, typeof(VCard.VOrganization)),
            new QnameType("TEL",   URI.VCARD, typeof(VCard.VTelephone)),
            new QnameType("EMAIL", URI.VCARD, typeof(VCard.VEmail)),
            new QnameType("GEO",   URI.VCARD, typeof(VCard.VGeo)),
            new QnameType("PHOTO", URI.VCARD, typeof(VCard.VPhoto)),
            new QnameType("ADR", URI.VCARD, typeof(VCard.VAddress)),

            // Disco
            new QnameType("query",    URI.DISCO_ITEMS, typeof(DiscoItems)),
            new QnameType("item",     URI.DISCO_ITEMS, typeof(DiscoItem)),
            new QnameType("query",    URI.DISCO_INFO, typeof(DiscoInfo)),
            new QnameType("identity", URI.DISCO_INFO, typeof(DiscoIdentity)),
            new QnameType("feature",  URI.DISCO_INFO, typeof(DiscoFeature)),

            // PubSub
            new QnameType("pubsub",        URI.PUBSUB, typeof(PubSub)),
            new QnameType("affiliations",  URI.PUBSUB, typeof(Affiliations)),
            new QnameType("create",        URI.PUBSUB, typeof(Create)),
            new QnameType("items",         URI.PUBSUB, typeof(Items)),
            new QnameType("publish",       URI.PUBSUB, typeof(Publish)),
            new QnameType("retract",       URI.PUBSUB, typeof(Retract)),
            new QnameType("subscribe",     URI.PUBSUB, typeof(Subscribe)),
            new QnameType("subscriptions", URI.PUBSUB, typeof(Subscriptions)),
            new QnameType("unsubscribe",   URI.PUBSUB, typeof(Unsubscribe)),

            new QnameType("configure",     URI.PUBSUB, typeof(Configure)),
            new QnameType("options",       URI.PUBSUB, typeof(PubSubOptions)),
            new QnameType("affiliation",   URI.PUBSUB, typeof(Affiliation)),
            new QnameType("item",          URI.PUBSUB, typeof(PubSubItem)),
            new QnameType("subscription",  URI.PUBSUB, typeof(PubSubSubscription)),

            // Pubsub event notifications
            new QnameType("event",         URI.PUBSUB_EVENT, typeof(PubSubEvent)),
            new QnameType("associate",     URI.PUBSUB_EVENT, typeof(EventAssociate)),
            new QnameType("collection",    URI.PUBSUB_EVENT, typeof(EventCollection)),
            new QnameType("configuration", URI.PUBSUB_EVENT, typeof(EventConfiguration)),
            new QnameType("disassociate",  URI.PUBSUB_EVENT, typeof(EventDisassociate)),
            new QnameType("items",         URI.PUBSUB_EVENT, typeof(EventItems)),
            new QnameType("item",          URI.PUBSUB_EVENT, typeof(PubSubItem)),
            new QnameType("purge",         URI.PUBSUB_EVENT, typeof(EventPurge)),
            new QnameType("retract",       URI.PUBSUB_EVENT, typeof(EventRetract)),
            new QnameType("subscription",  URI.PUBSUB_EVENT, typeof(EventSubscription)),

            // Pubsub owner use cases
            new QnameType("pubsub",        URI.PUBSUB_OWNER, typeof(PubSubOwner)),
            new QnameType("affiliations",  URI.PUBSUB_OWNER, typeof(OwnerAffliliations)),
            new QnameType("affiliation",   URI.PUBSUB_OWNER, typeof(OwnerAffiliation)),
            new QnameType("configure",     URI.PUBSUB_OWNER, typeof(OwnerConfigure)),
            new QnameType("default",       URI.PUBSUB_OWNER, typeof(OwnerDefault)),
            new QnameType("delete",        URI.PUBSUB_OWNER, typeof(OwnerDelete)),
            new QnameType("purge",         URI.PUBSUB_OWNER, typeof(OwnerPurge)),
            new QnameType("subscriptions", URI.PUBSUB_OWNER, typeof(OwnerSubscriptions)),
            new QnameType("subscription",  URI.PUBSUB_OWNER, typeof(PubSubSubscription)),

            // Pubsub errors
            new QnameType("closed-node",                    URI.PUBSUB_ERRORS, typeof(ClosedNode)),
            new QnameType("configuration-required",         URI.PUBSUB_ERRORS, typeof(ConfigurationRequired)),
            new QnameType("invalid-jid",                    URI.PUBSUB_ERRORS, typeof(InvalidJID)),
            new QnameType("invalid-options",                URI.PUBSUB_ERRORS, typeof(InvalidOptions)),
            new QnameType("invalid-payload",                URI.PUBSUB_ERRORS, typeof(InvalidPayload)),
            new QnameType("invalid-subid",                  URI.PUBSUB_ERRORS, typeof(InvalidSubid)),
            new QnameType("item-forbidden",                 URI.PUBSUB_ERRORS, typeof(ItemForbidden)),
            new QnameType("item-required",                  URI.PUBSUB_ERRORS, typeof(ItemRequired)),
            new QnameType("jid-required",                   URI.PUBSUB_ERRORS, typeof(JIDRequired)),
            new QnameType("max-items-exceeded",             URI.PUBSUB_ERRORS, typeof(MaxItemsExceeded)),
            new QnameType("max-nodes-exceeded",             URI.PUBSUB_ERRORS, typeof(MaxNodesExceeded)),
            new QnameType("nodeid-required",                URI.PUBSUB_ERRORS, typeof(NodeIDRequired)),
            new QnameType("not-in-roster-group",            URI.PUBSUB_ERRORS, typeof(NotInRosterGroup)),
            new QnameType("not-subscribed",                 URI.PUBSUB_ERRORS, typeof(NotSubscribed)),
            new QnameType("payload-too-big",                URI.PUBSUB_ERRORS, typeof(PayloadTooBig)),
            new QnameType("payload-required",               URI.PUBSUB_ERRORS, typeof(PayloadRequired)),
            new QnameType("pending-subscription",           URI.PUBSUB_ERRORS, typeof(PendingSubscription)),
            new QnameType("presence-subscription-required", URI.PUBSUB_ERRORS, typeof(PresenceSubscriptionRequired)),
            new QnameType("subid-required",                 URI.PUBSUB_ERRORS, typeof(SubidRequired)),
            new QnameType("unsupported",                    URI.PUBSUB_ERRORS, typeof(Unsupported)),
            new QnameType("unsupported-access-model",       URI.PUBSUB_ERRORS, typeof(UnsupportedAccessModel)),

            // Multi-user chat
            new QnameType("x",       URI.MUC, typeof(RoomX)),
            new QnameType("history", URI.MUC, typeof(History)),

            new QnameType("x",       URI.MUC_USER, typeof(UserX)),
            new QnameType("decline", URI.MUC_USER, typeof(Decline)),
            new QnameType("invite",  URI.MUC_USER, typeof(Invite)),
            new QnameType("destroy", URI.MUC_USER, typeof(Destroy)),
            new QnameType("item",    URI.MUC_USER, typeof(RoomItem)),
            new QnameType("actor",   URI.MUC_USER, typeof(RoomActor)),

            new QnameType("query",   URI.MUC_ADMIN, typeof(AdminQuery)),
            new QnameType("item",    URI.MUC_ADMIN, typeof(AdminItem)),

            new QnameType("query",   URI.MUC_OWNER, typeof(OwnerQuery)),
            new QnameType("destroy", URI.MUC_OWNER, typeof(OwnerDestroy)),
        };

        QnameType[] IPacketTypes.Types { get { return s_qnt; } }
    }
}
