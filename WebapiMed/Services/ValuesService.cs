using System.Collections.Generic;
using Microsoft.Extensions.Logging;

public class ValuesService
{

    private static List<ValueEntity> valuesRepository;

    private ILogger<ValuesService> _logger;

    public ValuesService(ILogger<ValuesService> logger)
    {
        valuesRepository = new List<ValueEntity>();
        _logger = logger;
    }

}