using Naami.SuiNet.Types;
using ServiceStack;

namespace Naami.SuiSdk.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddressOwnership()
    {
        const string expectedAddress = $"0x7daeb6a4184d871f01ad7778e0604646b434574b";
        var addressOwnerJson = "{\"AddressOwner\": \"" + expectedAddress + "\"}";

        var addressOwner = addressOwnerJson.FromJson<Owner>();
        Assert.That(addressOwner.Ownership, Is.EqualTo(Ownership.AddressOwner));
        Assert.That(addressOwner.AddressOwnership!.AddressOwner, Is.EqualTo(expectedAddress));
    }

    [Test]
    public void ObjectOwnership()
    {
        const string expectedAddress = $"0x7daeb6a4184d871f01ad7778e0604646b434574b";
        var objectOwnerJson = "{\"ObjectOwner\": \"" + expectedAddress + "\"}";

        var objectOwner = objectOwnerJson.FromJson<Owner>();
        Assert.That(objectOwner.Ownership, Is.EqualTo(Ownership.ObjectOwner));
        Assert.That(objectOwner.ObjectOwnership!.ObjectOwner, Is.EqualTo(expectedAddress));
    }

    [Test]
    public void SharedOwnership()
    {
        const ulong expectedInitialSharedVersion = 3;
        var sharedOwnerJson = "{\"initial_shared_version\": " + expectedInitialSharedVersion + "}";

        var sharedOwner = sharedOwnerJson.FromJson<Owner>();
        Assert.That(sharedOwner.Ownership, Is.EqualTo(Ownership.Shared));
        Assert.That(sharedOwner.SharedOwnership!.InitialSharedVersion, Is.EqualTo(expectedInitialSharedVersion));
    }

    [Test]
    public void ImmutableOwnership()
    {
        var immutableJson = "\"Immutable\"";

        var immutable = immutableJson.FromJson<Owner>();
        Assert.That(immutable.Ownership, Is.EqualTo(Ownership.Immutable));
    }
}