using System.Text.Json.Serialization;
using VyosConfigLibrary.Config.Utilities;
using VyosConfigLibrary.Utilities;

namespace VyosConfigLibrary.Config.Interfaces.Components.Ip;

public class Ip : BaseVyosConfigNode<Ip>
{
    /// <summary>
    /// Clamps the TCP MSS value to a specific value or "clamp-mss-to-pmtu"
    /// </summary>
    public string? AdjustMss { get; set; }

    /// <summary>
    /// A wrapper around AdjustMss to set its value as an integer
    /// </summary>
    [JsonIgnore]
    public int? AdjustMssInt
    {
        get => AdjustMss != null ? int.Parse(AdjustMss) : null;
        set => AdjustMss = value?.ToString();
    }

    /// <summary>
    /// Once a neighbor has been found, the entry is considered to be valid for at least for this specific time.
    /// An entry’s validity will be extended if it receives positive feedback from higher level protocols.
    /// <br/> <br/>
    /// This defaults to 30 seconds.
    /// </summary>
    public int? ArpCacheTimeout { get; set; }

    /// <summary>
    /// If set the kernel can respond to arp requests with addresses from other interfaces.
    /// This may seem wrong but it usually makes sense, because it increases the chance of successful communication.
    /// IP addresses are owned by the complete host on Linux, not by particular interfaces.
    /// Only for more complex setups like load-balancing, does this behaviour cause problems.
    /// <br/> <br/>
    /// If not set (default) allows you to have multiple network interfaces on the same subnet,
    /// and have the ARPs for each interface be answered based on whether or not the kernel would route a packet from
    /// the ARP’d IP out that interface (therefore you must use source based routing for this to work).
    /// </summary>
    public ConfigFlag? DisableArpFilter { get; set; }

    /// <summary>
    /// Configure interface-specific Host/Router behaviour.
    /// If set, the interface will switch to host mode and IPv6 forwarding will be disabled on this interface.
    /// </summary>
    public ConfigFlag? DisableForwarding { get; set; }
    
    /// <summary>
    /// Define different modes for IP directed broadcast forwarding as described in
    /// <a href="https://datatracker.ietf.org/doc/html/rfc1812.html">RFC 1812</a> and
    /// <a href="https://datatracker.ietf.org/doc/html/rfc2644.html">RFC 2644</a>.
    /// <br/><br/>
    /// If configured, incoming IP directed broadcast packets on this interface will be forwarded.
    /// <br/><br/>
    /// If this option is unset (default), incoming IP directed broadcast packets will not be forwarded.
    /// </summary>
    public ConfigFlag? EnableDirectedBroadCast { get; set; }
    
    /// <summary>
    /// Define behavior for gratuitous ARP frames whose IP is not already present in the ARP table.
    /// If configured create new entries in the ARP table.
    /// <br/><br/>
    /// Both replies and requests type gratuitous arp will trigger the ARP table to be updated, if this setting is on.
    /// <br/><br/>
    /// If the ARP table already contains the IP address of the gratuitous arp frame,
    /// the arp table will be updated regardless if this setting is on or off.
    /// </summary>
    public ConfigFlag? EnableArpAccept { get; set; }
    
    /// <summary>
    /// Define different restriction levels for announcing the local source IP address from IP packets in ARP requests
    /// sent on interface.
    /// <br/><br/>
    /// Use any local address, configured on any interface if this is not set.
    /// <br/><br/>
    /// If configured, try to avoid local addresses that are not in the target’s subnet for this interface.
    /// This mode is useful when target hosts reachable via this interface require the source IP address in ARP requests
    /// to be part of their logical network configured on the receiving interface. When we generate the request we will
    /// check all our subnets that include the target IP and will preserve the source address if it is from such subnet.
    /// If there is no such subnet we select source address according to the rules for level 2.
    /// </summary>
    public ConfigFlag? EnableArpAnnounce { get; set; }
    
    /// <summary>
    /// Define different modes for sending replies in response to received ARP requests that resolve local target IP
    /// addresses:
    /// <br/><br/>
    /// If configured, reply only if the target IP address is local address configured on the incoming interface.
    /// <br/><br/>
    /// If this option is unset (default), reply for any local target IP address, configured on any interface.
    /// </summary>
    public ConfigFlag? EnableArpIgnore { get; set; }
    
    /// <summary>
    /// Use this command to enable proxy Address Resolution Protocol (ARP) on this interface.Proxy ARP allows an
    /// Ethernet interface to respond with its own MAC address to ARP requests for destination IP addresses on subnets
    /// attached to other interfaces on the system. Subsequent packets sent to those destination IP addresses are
    /// forwarded appropriately by the system.
    /// </summary>
    public ConfigFlag? EnableProxyArp { get; set; }
    
    /// <summary>
    /// Private VLAN proxy arp. Basically allow proxy arp replies back to the same interface
    /// (from which the ARP request/solicitation was received)
    /// </summary>
    public ConfigFlag? ProxyArpPvlan { get; set; }
    
    public IpSourceValidation? SourceValidation { get; set; }
}