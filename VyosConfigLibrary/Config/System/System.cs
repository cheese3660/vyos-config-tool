namespace VyosConfigLibrary.Config.System;

public class System : BaseVyosConfigNode<System>
{
    public ConfigManagement.ConfigManagement? ConfigManagement { get; set; }
    // TODO: Acceleration
    // TODO: Conntrack
    public Console.Console? Console { get; set; }
    // TODO: Flow Accounting
    // TODO: FRR
    // TODO: Host information
    // TODO: IP
    // TODO: IPV6
    // TODO: LCD
    public Login.Login? Login { get; set; }
    // TODO: System DNS
    public Option.Option? Option { get; set; }
    // TODO: System Proxy
    // TODO: sFlow
    public Syslog.Syslog? Syslog { get; set; }
    // TODO: Sysctl
    // TODO: Task Scheduler
    // TODO: Time Zone
    // TODO: Updates
    // TODO: Default Gateway/Route
    public Wireless.Wireless? Wireless { get; set; }
    
    public string? Hostname { get; set; }
    public string? DomainName { get; set; }
    
}