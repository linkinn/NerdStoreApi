namespace NSE.WebAPI.Core.Idendity
{
    public class AppSettings
    {
      public string ?Secret { get; set; }
      public int ExpirationHours { get; set; }
      public string ?Issuer { get; set; }
      public string ?ValidIn { get; set; }
    }
}