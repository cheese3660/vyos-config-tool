namespace VyosConfigLibrary.Config.System.Login;

public class Authentication
{
    public string? PlaintextPassword { get; set; }
    public string? EncryptedPassword { get; set; }
    public string? Principle { get; set; }
    public Dictionary<string, PublicKeys>? PublicKeys { get; set; }
    public Otp? Otp { get; set; }
}