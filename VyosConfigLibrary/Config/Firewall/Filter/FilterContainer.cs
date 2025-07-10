namespace VyosConfigLibrary.Config.Firewall.Filter;

public class FilterContainer : BaseVyosConfigNode<FilterContainer>
{
    public Filter? Filter { get; set; }
    // TODO: Prerouting
}