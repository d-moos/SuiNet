using ServiceStack;

namespace Naami.SuiSdk.Types;

public readonly struct Owner
{
    private readonly string _rawJsonString;

    public Owner(string rawJsonString)
    {
        _rawJsonString = rawJsonString;
    }

    public Ownership Ownership
    {
        get
        {
            if (IsAddressOwnership(_rawJsonString))
                return Ownership.AddressOwner;

            if (IsSharedOwnership(_rawJsonString))
                return Ownership.Shared;

            if (IsObjectOwnership(_rawJsonString))
                return Ownership.ObjectOwner;

            if (IsImmutableOwnership(_rawJsonString))
                return Ownership.Immutable;

            throw new ArgumentException($"Unknown {nameof(Ownership)} type");
        }
    }

    public AddressOwnership? AddressOwnership => IsAddressOwnership(_rawJsonString) 
        ? _rawJsonString.FromJson<AddressOwnership>() 
        : null;
    
    public ObjectOwnership? ObjectOwnership => IsObjectOwnership(_rawJsonString) 
        ? _rawJsonString.FromJson<ObjectOwnership>() 
        : null;
    
    public SharedOwnership? SharedOwnership => IsSharedOwnership(_rawJsonString) 
        ? _rawJsonString.FromJson<SharedOwnership>() 
        : null;

    private static bool IsAddressOwnership(string rawOwner) => rawOwner.Contains(Ownership.AddressOwner.ToString());
    private static bool IsObjectOwnership(string rawOwner) => rawOwner.Contains(Ownership.ObjectOwner.ToString());
    private static bool IsSharedOwnership(string rawOwner) => rawOwner.Contains("initial_shared_version"); // TODO: camelCase
    private static bool IsImmutableOwnership(string rawOwner) => rawOwner.Contains(Ownership.Immutable.ToString());
};