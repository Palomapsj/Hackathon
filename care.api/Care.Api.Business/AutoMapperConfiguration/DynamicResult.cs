public class DynamicResult
{
    private readonly IDictionary<string, object> _values = new Dictionary<string, object>();

    public object this[string key]
    {
        get => _values.ContainsKey(key) ? _values[key] : null;
        set => _values[key] = value;
    }

    public bool ContainsKey(string key)
    {
        return _values.ContainsKey(key);
    }
}
