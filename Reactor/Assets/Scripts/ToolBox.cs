using System;
using System.Collections.Generic;

public static class ToolBox
{
    private static Dictionary<Type, object> _tools = new Dictionary<Type, object>();

    /// <summary>
    /// Registers the Tool. Use on Awake only.
    /// </summary>
    /// <typeparam name="T">The tool's type.</typeparam>
    /// <param name="tool">The tool to register.</param>
    /// <returns>False of Tool of Type T already exists, true otherwise.</returns>
    public static bool RegisterAsTool<T>(T tool)
    {
        if (GetTool<T>() != null)
            return false;

        _tools.Add(typeof(T), tool);
        return true;
    }

    /// <summary>
    /// Gets the Tool of type T. Use on Start only.
    /// </summary>
    /// <typeparam name="T">The Type of the tool.</typeparam>
    /// <returns>Object of Type T found in Toolbox, otherwise default(T)</returns>
    public static T GetTool<T>()
    {
        object tool;

        if (_tools.TryGetValue(typeof(T), out tool))
        {
            return (T)tool;
        }

        return default(T);
    }

    public static void UnregisterTool<T>(T tool)
    {
        _tools.Remove(typeof(T));
    }

    public static void ResetToolBox()
    {
        _tools = new Dictionary<Type, object>();
    }
}

