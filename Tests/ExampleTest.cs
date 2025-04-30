namespace ExampleTests;

using GdUnit4;
using static GdUnit4.Assertions;

[TestSuite]
public class ExampleTest
{
    [TestCase]
    public void Success()
    {
        AssertBool(true).IsTrue();
    }

    [TestCase]
    public void failed()
    {
        AssertBool(false).IsTrue();
    }
}
