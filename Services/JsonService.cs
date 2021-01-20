using Bot.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bot.Repository
{
    public class JsonService<T>{
        public IEnumerable<T> GetItems(string path)
        {
            if (!File.Exists(path))
            {
                return new List<T>();
            }

            var jsonString = File.ReadAllText(path);

            return JsonSerializer.Deserialize<IEnumerable<T>>(jsonString);

        }
        public  void AddItems(T item, string path)
        {          
                var items = GetItems(path)?.ToList();
                items.Add(item);
                using (FileStream createStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                var json = JsonSerializer.Serialize<List<T>>( items);
                byte[] bytes = Encoding.ASCII.GetBytes(json);
                createStream.Write(bytes, 0, bytes.Length);
                }         

        }      


    }

   
}
