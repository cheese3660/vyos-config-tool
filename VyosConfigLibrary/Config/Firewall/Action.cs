namespace VyosConfigLibrary.Config.Firewall;

public enum Action
{
    Accept,
    Drop,
    Reject,
    Continue,
    Return,
    Queue,
    Synproxy,
    Jump
}