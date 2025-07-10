namespace VyosConfigLibrary.Config.Firewall.Rule;

public class AddAddressToGroup : BaseVyosConfigNode<AddAddressToGroup>
{
    public AddressGroupValue? DestinationAddress { get; set; }
    public AddressGroupValue? SourceAddress { get; set; }
}