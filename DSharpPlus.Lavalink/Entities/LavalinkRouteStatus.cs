﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace DSharpPlus.Lavalink.Entities
{
    public class LavalinkRouteStatus
    {
        /// <summary>
        /// Gets the route planner type.
        /// </summary>
        [JsonIgnore]
        public RoutePlannerType? Class
            => this.GetRoutePlannerType(_class);

        /// <summary>
        /// Gets the details of the route planner.
        /// </summary>
        [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
        public LavalinkRouteStatusDetails Details { get; internal set; }

        [JsonProperty("class", NullValueHandling = NullValueHandling.Ignore)]
        internal string _class { get; set; }

        private RoutePlannerType? GetRoutePlannerType(string type)
        {
            switch(type)
            {
                case "RotatingIpRoutePlanner":
                    return RoutePlannerType.RotatingIpRoutePlanner;

                case "BalancingIpRoutePlanner":
                    return RoutePlannerType.BalancingIpRoutePlanner;

                case "NanoIpRoutePlanner":
                    return RoutePlannerType.NanoIpRoutePlanner;

                case "RotatingNanoIpRoutePlanner":
                    return RoutePlannerType.RotatingNanoIpRoutePlanner;

                default:
                    return null;
            }
        }
    }

    public class LavalinkRouteStatusDetails
    {
        /// <summary>
        /// Gets the details for the current IP block.
        /// </summary>
        [JsonProperty("ipBlock", NullValueHandling = NullValueHandling.Ignore)]
        public LavalinkIpBlock IpBlock { get; internal set; }

        /// <summary>
        /// Gets the collection of failed addresses.
        /// </summary>
        [JsonProperty("failingAddresses", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<LavalinkFailedAddress> FailedAddresses { get; internal set; }

        /// <summary>
        /// Gets the number of rotations since the restart of Lavalink.
        /// <para>Only present in the <see cref="RoutePlannerType.RotatingIpRoutePlanner"/>.</para>
        /// </summary>
        [JsonProperty("rotateIndex", NullValueHandling = NullValueHandling.Ignore)]
        public string RotateIndex { get; internal set; }

        /// <summary>
        /// Gets the current offset of the IP block.
        /// <para>Only present in the <see cref="RoutePlannerType.RotatingIpRoutePlanner"/>.</para>
        /// </summary>
        [JsonProperty("ipIndex", NullValueHandling = NullValueHandling.Ignore)]
        public string IpIndex { get; internal set; }

        /// <summary>
        /// Gets the current IP Address used by the planner.
        /// <para>Only present in the <see cref="RoutePlannerType.RotatingIpRoutePlanner"/>.</para>
        /// </summary>
        [JsonProperty("currentAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrentAddress { get; internal set; }

        /// <summary>
        /// Gets the current offset of the IP block.
        /// <para>Only present in the <see cref="RoutePlannerType.NanoIpRoutePlanner"/> and the <see cref="RoutePlannerType.RotatingNanoIpRoutePlanner"/>.</para>
        /// </summary>
        [JsonProperty("currentAddressIndex", NullValueHandling = NullValueHandling.Ignore)]
        public long CurrentAddressIndex { get; internal set; }

        /// <summary>
        /// Gets the information in which /64 block ips are chosen. This number increases on each ban.
        /// <para>Only present in the <see cref="RoutePlannerType.RotatingNanoIpRoutePlanner"/>.</para>
        /// </summary>
        [JsonProperty("blockIndex", NullValueHandling = NullValueHandling.Ignore)]
        public string BlockIndex { get; internal set; }
    }

    public enum RoutePlannerType
    {
        /// <summary>
        /// Route planner that switches the IP on ban.
        /// </summary>
        RotatingIpRoutePlanner = 1,

        /// <summary>
        /// Route planner that selects random IP addresses from the given block.
        /// </summary>
        BalancingIpRoutePlanner = 2,

        /// <summary>
        /// Route planner that switches the IP on every clock update.
        /// </summary>
        NanoIpRoutePlanner = 3,

        /// <summary>
        /// Route planner that switches the IP on every clock update and rotates to next IP block on a ban as a fallback. 
        /// </summary>
        RotatingNanoIpRoutePlanner = 4
    }


    public struct LavalinkIpBlock
    {
        /// <summary>
        /// Gets the type of the IP block.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; internal set; }

        /// <summary>
        /// Gets the size of the IP block.
        /// </summary>
        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public string Size { get; internal set; }
    }

    public struct LavalinkFailedAddress
    {
        /// <summary>
        /// Gets the failed address IP.
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; internal set; }

        /// <summary>
        /// Gets the failing timestamp in miliseconds.
        /// </summary>
        [JsonProperty("failingTimestamp", NullValueHandling = NullValueHandling.Ignore)]
        public ulong FailingTimestamp { get; internal set; }

        /// <summary>
        /// Gets the DateTime format of the failing address.
        /// </summary>
        [JsonProperty("failingTime", NullValueHandling = NullValueHandling.Ignore)]
        public string FailingTime { get; internal set; }
    }
}
