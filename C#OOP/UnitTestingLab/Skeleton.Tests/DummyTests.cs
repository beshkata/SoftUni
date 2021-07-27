using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    [Test]
    public void WhenAttackedLooseHealth()
    {
        Dummy dummy = new Dummy(10, 10);

        dummy.TakeAttack(1);

        Assert.That(dummy.Health, Is.EqualTo(9));
    }

    [Test]
    public void WhenDeadDummyAttackedShouldThrow()
    {
        Dummy dummy = new Dummy(0, 10);

        Assert.That(() => dummy.TakeAttack(1), 
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void WhenDeadShouldGiveXP()
    {
        Dummy dummy = new Dummy(0, 10);

        Assert.That(dummy.GiveExperience(), Is.EqualTo(10), "Dummy doesn't give XP");
    }

    [Test]
    public void WhenAliveGiveExperienceShouldThrow()
    {
        Dummy dummy = new Dummy(10, 10);

        Assert.That(() => dummy.GiveExperience(), 
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }

}
