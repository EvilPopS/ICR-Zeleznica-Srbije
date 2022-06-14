using Newtonsoft.Json;
using System.IO;
using ZeleznicaSrbije.Database.Repositories;

namespace ZeleznicaSrbije.Database {
    internal class FileReaderWriter {

        public static void UpdateFile<T>(string filePath, Repository<T> repo) {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(repo, Formatting.Indented));
        }

        public static Repository<T> ReadFile<T>(string filePath) {
             return JsonConvert.DeserializeObject<Repository<T>>(File.ReadAllText(filePath));
        }
    }
}
