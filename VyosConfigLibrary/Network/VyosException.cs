namespace VyosConfigLibrary.Network;

public class VyosException(VyosErrorInformation errorInformation) : Exception(
    $"Type: {errorInformation.Type}; Location: {errorInformation.Loc}; Message: {errorInformation.Msg}; Input: {errorInformation.Input}")
{
    public VyosErrorInformation ErrorInformation { get; } = errorInformation;
}