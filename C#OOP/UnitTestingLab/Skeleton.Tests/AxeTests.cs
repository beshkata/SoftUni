using NUnit.Framework;

[TestFixture]
public class AxeTests
{


    [Test]
    public void WhenAttackShouldLooseDurability()
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(15, 15);

        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doesn't change after attack");
    }

    [Test]
    public void WhenAttackWithZeroDurabilityShouldThrow()
    {
        Axe axe = new Axe(10, 0);
        Dummy dummy = new Dummy(15, 15);

        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}