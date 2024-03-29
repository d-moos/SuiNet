﻿using Naami.SuiNet.Apis.Event;

namespace Naami.SuiNet.Tests.Integration.Apis.Event;

public abstract class BaseEventApiSpecification
{
    protected readonly IEventApi EventApi;

    public BaseEventApiSpecification()
    {
        EventApi = new EventApi(Utils.JsonRpcClient.Value);
    }
}