namespace VyosConfigLibrary.Config.Service.NTP;

public class Ptp : BaseVyosConfigNode<Ptp>
{
    public int? Port {get; set;}
}