using System.Text;
using Naami.SuiNet.Types;
using Shouldly;

namespace Naami.SuiNet.Tests.Integration.Apis.Read;

public class ReadApiSpecifications : BaseReadApiSpecification
{
    [Test]
    public async Task GetObject()
    {
        var parsedObject = await ReadApi.GetObject<MyObject>(ObjectId);
        parsedObject.ObjectStatus.ShouldBe(ObjectStatus.Exists);
        
        parsedObject.ExistsResult!.Owner.AddressOwnership.AddressOwner.ShouldBe(Utils.TestingSignerAddress);
        parsedObject.ExistsResult!.Data.Fields!.Bar.ShouldBe<byte>(2);
    }

    [Test]
    public async Task GetRawObject()
    {
        var rawObject = await ReadApi.GetRawObject(ObjectId);
        rawObject.ObjectStatus.ShouldBe(ObjectStatus.Exists);

        rawObject.ExistsResult!.Owner.AddressOwnership!.AddressOwner.ShouldBe(Utils.TestingSignerAddress);
    }

    [Test]
    public async Task GetDynamicFields()
    {
        var dynamicFieldPage = await ReadApi.GetDynamicFields(ObjectId);
        dynamicFieldPage.Data.Length.ShouldBe(1);

        var childObject = await ReadApi.GetObject<ChildObject>(dynamicFieldPage.Data[0].ObjectId);
        childObject.ExistsResult!.Data.Fields!.Foo.ShouldBe<byte>(123);
    }

    [Test]
    public async Task GetDynamicFieldObject()
    {
        var name = ASCIIEncoding.ASCII.GetBytes("foo");
        var childObject = await ReadApi.GetDynamicFieldObject<ChildObject>(ObjectId, name);
        childObject.ExistsResult!.Data.Fields!.Foo.ShouldBe<byte>(123);
    }

    [Test]
    public async Task GetTransaction()
    {
        var transaction = await ReadApi.GetTransaction(TransactionDigest);
    }

    [Test]
    public async Task GetTotalTransactionNumber()
    {
        var result = await ReadApi.GetTotalTransactionNumber();
        result.ShouldNotBe(default);
    }

    [Test]
    public async Task GetTransactionsInRange()
    {
        var result = await ReadApi.GetTransactionsInRange(0, 1000);
        result.Length.ShouldBeGreaterThan(0);
    }
    
    [Test]
    public async Task GetTransactions()
    {
        const int length = 5000;
        var result = await ReadApi.GetTransactionsInRange(0, length);
        var transactions = await ReadApi.GetTransactions(result);

        transactions.Length.ShouldBe(length);
    }
}