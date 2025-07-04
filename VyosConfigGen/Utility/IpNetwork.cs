namespace VyosConfigGen;

public struct IpNetwork(IpAddress networkAddress, int subnetMask)
{
    public IpAddress NetworkAddress = networkAddress;
    public int SubnetMask = subnetMask;
    
    public IpAddress this[uint index] => new(NetworkAddress.Address + index);
    public override string ToString()
    {
        return $"{NetworkAddress}/{SubnetMask}";
    }
}