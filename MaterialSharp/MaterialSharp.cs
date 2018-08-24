using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MaterialSharp
{
    class MaterialSharp
    {
        public static Version Version => Assembly.GetExecutingAssembly().GetName().Version;
    }
}
