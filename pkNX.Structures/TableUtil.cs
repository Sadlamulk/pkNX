using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace pkNX.Structures;

public static class TableUtil
{
    /// <summary>
    /// Converts an enumerable list of <see cref="T"/> to a tab separated sheet.
    /// </summary>
    /// <typeparam name="T">Object Type</typeparam>
    /// <param name="arr">Array of type T</param>
    /// <returns>2 dimensional sheet of cells</returns>
    public static string GetTable<T>(IEnumerable<T> arr) where T : class => string.Join(Environment.NewLine, GetTableRaw(arr));

    private const char sep = '\t';
    private static IEnumerable<string> GetTableRaw<T>(IEnumerable<T> arr) where T : class
        => Table(arr).Select(row => string.Join(sep, row));
    private static IEnumerable<string> GetTableRaw<T>(IEnumerable<T> arr, Type t) where T : class
        => Table(arr, t).Select(row => string.Join(sep, row));

    public static string GetNamedTable<T>(IEnumerable<T> arr, IList<string> names, string? name = null) where T : class
    {
        var list = GetTableRaw(arr).ToArray();

        // slap in name to column header
        list[0] = $"Index{sep}{name ?? typeof(T).Name}{sep}{list[0]}";

        // slap in row name to row
        for (int i = 1; i < list.Length; i++)
            list[i] = $"{i - 1}{sep}{names[i - 1]}{sep}{list[i]}";

        return string.Join(Environment.NewLine, list);
    }

    public static string GetNamedTypeTable<T>(IList<T> arr, IList<string> names, string? name = null) where T : class
    {
        var t = arr[0].GetType();
        if (t.Name.StartsWith("tableReader_")) // FlatBuffer generated wrapper
            t = t.BaseType;
        if (t is null)
            throw new ArgumentException("Type is null");

        var list = GetTableRaw(arr, t).ToArray();

        // slap in name to column header
        list[0] = $"Index{sep}{name ?? t.Name}{sep}{list[0]}";

        // slap in row name to row
        for (int i = 1; i < names.Count + 1; i++)
            list[i] = $"{i - 1}{sep}{names[i - 1]}{sep}{list[i]}";

        return string.Join(Environment.NewLine, list);
    }

    private static IEnumerable<IEnumerable<string>> Table<T>(IEnumerable<T> arr) where T : class
    {
        var type = typeof(T);
        yield return GetNames(type);
        foreach (var z in arr)
            yield return GetValues(z, type);
    }

    private static IEnumerable<IEnumerable<string>> Table<T>(IEnumerable<T> arr, Type type) where T : class
    {
        yield return GetNames(type);
        foreach (var z in arr)
            yield return GetValues(z, type);
    }

    private static IEnumerable<string> GetNames(Type type)
    {
        foreach (var z in type.GetProperties())
            yield return z.Name;
        foreach (var z in type.GetFields())
            yield return z.Name;
    }

    private static IEnumerable<string> GetValues(object obj, Type type)
    {
        foreach (var z in type.GetProperties())
            yield return GetFormattedString(z.GetValue(obj, null));

        foreach (var z in type.GetFields())
            yield return GetFormattedString(z.GetValue(obj));
    }

    private static string GetFormattedString(object? obj)
    {
        if (obj == null)
            return string.Empty;
        if (obj is ulong u)
            return u.ToString("X16");
        if (obj is IEnumerable x and not string)
            return string.Join('|', JoinEnumerator(x.GetEnumerator()).Select(GetFormattedString));

        var objType = obj.GetType();
        if (objType.IsEnum)
            return obj.ToString() ?? string.Empty;
        var mi = objType.GetMethods().First(z => z.Name == nameof(obj.ToString));
        if (mi.DeclaringType == objType)
            return obj.ToString() ?? string.Empty;

        var props = objType.GetProperties();
        return string.Join('|', props.Select(z => GetFormattedString(z.GetValue(obj))));
    }

    private static IEnumerable<object> JoinEnumerator(IEnumerator x)
    {
        while (x.MoveNext())
            yield return x.Current;
    }
}
