using Microsoft.Extensions.Logging;

namespace TestPlugin;

public class TestClass
{
    public static void TestMethod(ILogger logger)
    {
        logger.LogInformation("TestPlugin.TestMethod() called!");
    }
}