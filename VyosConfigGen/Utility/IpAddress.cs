namespace VyosConfigGen;

public struct IpAddress
{
    public uint Address;

    public IpAddress(uint address)
    {
        Address = address;
    }

    public IpAddress(string address)
    {
        var split = address.Split('.');
        uint total = 0;
        total += uint.Parse(split[0]) * (1u << 24);
        total += uint.Parse(split[1]) * (1u << 16);
        total += uint.Parse(split[2]) * (1u << 8);
        total += uint.Parse(split[3]);
        Address = total;
    }

    public override string ToString()
    {
        return $"{(Address >> 24) & 255}.{(Address >> 16) & 255}.{(Address >> 8) & 255}.{Address & 255}";
    }
}