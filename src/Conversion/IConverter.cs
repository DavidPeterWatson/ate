using System.IO;
using System.Collections.Concurrent;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ate.Conversion
{

    /// <summary>
    /// Interface for importing Data Models
    /// </summary>
    public interface IConverter
    {
        ExportResults<T> Export<T>(T type, string[] parameters);
        ImportResults<T> Import<T>(string[] parameters);

        string Name { get; }

        List<string> Extensions { get; }

    }


}