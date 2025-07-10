using VyosConfigLibrary.Config.Utilities;

namespace VyosConfigLibrary.Config.System.Option;

public class Option : BaseVyosConfigNode<Option>
{
    public CtrlAltDelete? CtrlAltDelete { get; set; }
    public ConfigFlag? RebootOnPanic { get; set; }
    public int? RebootOnUpgradeFailure { get; set; }
    public ConfigFlag? StartupBeep { get; set; }
    public ConfigFlag? RootPartitionAutoResize { get; set; }
    // TODO: Kernel
    // TODO: HTTP Client
    // TODO: SSH Client
    // TODO: Performance
    // 
}
