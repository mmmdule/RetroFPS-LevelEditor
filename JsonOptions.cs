using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelEditor {
    internal class JsonOptions {
        private static JsonSerializerOptions myDefaultOptions = new JsonSerializerOptions {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };

        public static JsonSerializerOptions MyDefaultOptions { get => myDefaultOptions;  }
    }
}
