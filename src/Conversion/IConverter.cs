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
        ExportResults<T> Export<T>(T Type, string[] Parameters);
        ImportResults<T> Import<T>(string[] Parameters);

        string Name { get; }

        List<string> Extensions { get; }

    }


}