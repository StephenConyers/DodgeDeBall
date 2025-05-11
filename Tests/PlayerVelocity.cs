namespace PlayerTests;

using System.Numerics;
using CommandLine;
using GdUnit4;
using static GdUnit4.Assertions;

[TestSuite]
public class PlayerVelocity
{
    private Player _test_data;

    [BeforeTest]
    public void Setup()
    {
        _test_data = new Player();
    }

    [AfterTest]
    public void Free()
    {
        _test_data.Free();
    }

    [TestCase]
    public void VelocityUp()
    {
        var vel = Godot.Vector2.Zero;
        vel = _test_data.MoveUp(vel);

        AssertBool(vel.Y != 0).IsTrue(); 
    }

    [TestCase]
    public void VelocityDown()
    {
        var vel = Godot.Vector2.Zero;
        vel = _test_data.MoveDown(vel);

        AssertBool(vel.Y != 0).IsTrue(); 
    }

    [TestCase]
    public void VelocityLeft()
    {
        var vel = Godot.Vector2.Zero;
        vel = _test_data.MoveLeft(vel);

        AssertBool(vel.X != 0).IsTrue(); 
    }

    [TestCase]
    public void VelocityRight()
    {
        var vel = Godot.Vector2.Zero;
        vel = _test_data.MoveRight(vel);

        AssertBool(vel.X != 0).IsTrue(); 
    }
}
