using System.ComponentModel.DataAnnotations;

public class SerilogSettings
{
    [Required(AllowEmptyStrings = false)]
    public string LoggingEndpoint { get; set; }
    public string MinimumLevel { get; set; }
}
