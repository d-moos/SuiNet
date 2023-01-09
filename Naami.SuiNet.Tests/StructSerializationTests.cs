using Naami.SuiNet.Types;
using ServiceStack;

namespace Naami.SuiSdk.Tests;

public class StructSerializationTests
{
    public record Foo(ulong MyValue, ulong MyString)
    {
        public ObjectId? NextCursor { get; init; }
    }

    [Test]
    public void ObjectId_With_Value()
    {
        var json ="{\"nextCursor\": \"hasValue\", \"myValue\": 5, \"myString\": 5}";

        var serviceStackFoo = json.FromJson<Foo>();
        Assert.That(serviceStackFoo.NextCursor.HasValue);
    }
    
    [Test]
    public void ObjectId_With_NULL_Value()
    {
        var json ="{\"nextCursor\": null, \"myValue\": 5, \"myString\": 5}";

        var serviceStackFoo = json.FromJson<Foo>();
        Assert.That(!serviceStackFoo.NextCursor.HasValue);
    }
    
        
    [Test]
    public void ObjectId_Without_Value()
    {
        var json ="{\"myValue\": 5, \"myString\": 5}";

        var serviceStackFoo = json.FromJson<Foo>();
        Assert.That(!serviceStackFoo.NextCursor.HasValue);
    }
}