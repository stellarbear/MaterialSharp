using System;
using System.Reflection;

namespace MaterialSharp
{
    public class MaterialSharp
    {
        public static Version Version => Assembly.GetExecutingAssembly().GetName().Version;
    }
}
