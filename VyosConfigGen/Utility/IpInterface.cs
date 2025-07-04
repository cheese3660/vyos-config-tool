using System.Net;

namespace VyosConfigGen;

public struct IpInterface
{
    public IpAddress Ip;
    public IpNetwork Network;
    public int SubnetMask;

    public IpInterface(string i)
    {
        var split = i.Split('/');
        Ip = new IpAddress(split[0]);
        SubnetMask = int.Parse(split[1]);
        Network = new IpNetwork(new IpAddress(Ip.Address & (0xFFFFFFFFU << (32 - SubnetMask))), SubnetMask);
    }


    public override string ToString()
    {
        return $"{Ip}/{SubnetMask}";
    }
}