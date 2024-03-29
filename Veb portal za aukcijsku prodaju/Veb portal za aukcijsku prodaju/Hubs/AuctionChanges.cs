﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Veb_portal_za_aukcijsku_prodaju.Controllers;
using Veb_portal_za_aukcijsku_prodaju.Helpers;

namespace Veb_portal_za_aukcijsku_prodaju.Hubs
{
    public class AuctionChanges : Hub
    {

        public static class mutex { public static string forLock = "key"; }

        public void SendBid(string auctionID, string userID)
        {
            lock(mutex.forLock)
            {
                string fullUserName = "";
                string newPrice = "";
                bool noTokens = false;
                double timeRemaining = -1;

                new HelpMethods().BidAuction(Int32.Parse(auctionID), Int32.Parse(userID), out fullUserName, out newPrice, out noTokens, out timeRemaining);

                // Call the updateLastBid method to update auction.
                Clients.All.updateLastBidHome(userID, auctionID, fullUserName, newPrice, noTokens, timeRemaining);
                Clients.All.updateLastBidAuction(auctionID, fullUserName, newPrice, noTokens);
            }            
        }

        public void ChangeStartPrice(string auctionID, string newPrice)
        {
            
            new HelpMethods().ChangePrice(Int32.Parse(auctionID), newPrice);            

            Clients.All.changeStartPriceAdmin(auctionID, newPrice);
        }

        public void ActivateAuction(string auctionID, double startCalc)
        {
            DateTime start = DateTime.Now;

            new HelpMethods().OpenAuction(Int32.Parse(auctionID));

            double remaining = (DateTime.Now - start).TotalSeconds;
            Clients.All.auctionOpened(auctionID, remaining);                       
        }

        public void ChangeAuctionStatusOver(string auctionID)
        {
            int id = Int32.Parse(auctionID);
            string newStatus = new HelpMethods().AuctionOver(id);
            
            Clients.All.auctionStatusChangedOver(auctionID, newStatus);
        }
/*
        public void Hello()
        {
            Clients.All.hello();
        }
 * */
    }
}
