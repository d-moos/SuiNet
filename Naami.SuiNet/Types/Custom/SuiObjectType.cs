namespace Naami.SuiNet.Types.Custom;

/// <summary>
/// surely something that needs refactoring. it does it job but it's.. ugly.
/// -> https://github.com/stella3d/SuiDotNet/blob/3becea54c0187f29c93f26ed24b399c0f15f300e/src/SuiDotNet.Client/SuiEx.cs#L10
/// promising regex
/// </summary>

public readonly struct SuiObjectType
{
    private const byte PackageIndex = 0;
    private const byte ModuleIndex = 1;
    private const byte StructIndex = 2;
    
    private readonly string _raw;

    public string Package => _raw.Split("::")[PackageIndex];
    public string Module => _raw.Split("::")[ModuleIndex];
    public StructType Struct => new(_raw.Split("::", count: 3)[StructIndex]);

    public SuiObjectType(string raw)
    {
        _raw = raw;
    }

    public override string ToString()
        => _raw;

    public static implicit operator SuiObjectType(string raw) => new(raw);
    public static implicit operator string(SuiObjectType suiObjectType) => suiObjectType._raw;
}

public readonly struct StructType
{
    private readonly string _raw;

    private string[] SplitGenerics(string s)
    {
        const char limiter = ',';
        const char open = '<';
        const char close = '>';

        var stat = 0;

        var index = 0;
        var bar = new List<string>();

        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (c == open)
                stat++;
            else if (c == close)
                stat--;
            else if (c == limiter && stat == 0)
            {
                bar.Add(s.Substring(index, i - index));
                index = ++i;
            }
        }

        bar.Add(s.Substring(index));

        return bar.ToArray();
    }

    public SuiObjectType[] GenericTypes
    {
        get
        {
            if (!_raw.Contains("<"))
                return Array.Empty<SuiObjectType>();

            var start = _raw.IndexOf("<");
            var end = _raw.LastIndexOf(">");

            return SplitGenerics(_raw.Substring(start + 1, end - start))
                .Select(x => new SuiObjectType(x))
                .ToArray();
        }
    }

    public string Name {
        get
        {
            var i = _raw.IndexOf("<");
            if (i == -1)
                return _raw;

            return _raw.Substring(0, i);
        }
    }

    public StructType(string raw)
    {
        _raw = raw;
    }
}