using System.Collections.Generic;
using System.IO;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
namespace Savable
{
    public class SaveService
    {
        Dictionary<string, ISavable> _cached = new();

        public void Upload(ISavable savable, string id = null)
        {
            var savableType = savable.GetType().Name;
            var path = GetPath(savableType, id);

            if (!_cached.TryAdd(path, savable))
                _cached[path] = savable;
        }

        public T Load<T>(string id = null) where T : ISavable, new()
        {
            var path = GetPath(typeof(T).Name, id);

            if (_cached.TryGetValue(path, out var savable))
                return (T)savable;

            return LoadFromDisk<T>(path);
        }

        public void UploadAllToDisk()
        {
            foreach (var savable in _cached)
            {
                UploadToDisk(savable.Value, savable.Key);
            }
        }

        void UploadToDisk(ISavable savable, string id)
        {
            var json = JsonConvert.SerializeObject(savable);
            var savableType = savable.GetType().Name;
            var path = GetPath(savableType, id);
            var dir = Path.GetDirectoryName(path);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (!File.Exists(path))
                File.Create(path).Dispose();

            using var tw = new StreamWriter(path);
            tw.Write(json);
        }

        T LoadFromDisk<T>(string id) where T : ISavable, new()
        {
            var path = GetPath(typeof(T).Name, id);
            T obj;

            if (!File.Exists(path))
            {
                obj = new();
            }
            else
            {
                var json = File.ReadAllText(path);
                obj = JsonConvert.DeserializeObject<T>(json);
            }

            _cached.Add(path, obj);

            return obj;
        }

        string GetPath(string savableType, string id)
        {
            var dir = $"{Application.persistentDataPath}/{savableType}";
            if (id == null)
            {
                return $"{dir}.txt";
            }
            return $"{dir}/{id}.txt";
        }
    }
}
