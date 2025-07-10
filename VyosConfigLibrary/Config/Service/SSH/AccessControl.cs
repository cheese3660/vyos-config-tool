namespace VyosConfigLibrary.Config.Service.SSH;

public class AccessControl : BaseVyosConfigNode<AccessControl>
{
    public AccessControlValue? Allow { get; set; }
    public AccessControlValue? Deny { get; set; }
}