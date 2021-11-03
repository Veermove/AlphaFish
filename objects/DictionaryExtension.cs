using System.Collections.Generic;
public static class Extensions {
    public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key, TValue @default = default(TValue)) {
        if (@this == null) return @default;

        TValue value;

        return @this.TryGetValue(key, out value) ? value : @default;
    }
}
