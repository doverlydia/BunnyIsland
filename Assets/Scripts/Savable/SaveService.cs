using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Savable
{
    public class SaveService
    {
        Dictionary<string, ISavable> _cached = new();

        public void Upload(ISavable savable, string id)
        {
            var savableType = savable.GetType().Name;
            var path = GetPath(savableType, id);

            if (!_cached.TryAdd(path, savable))
                _cached[path] = savable;
        }

        public T Load<T>(string id) where T : ISavable
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
            var json = JsonUtility.ToJson(savable);
            var savableType = savable.GetType().Name;
            var dir = GetDir(savableType);
            var path = GetPath(savableType, id);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(path);

            if (!File.Exists(path))
                File.Create(path).Dispose();

            using var tw = new StreamWriter(path);
            tw.Write(json);
        }

        T LoadFromDisk<T>(string id) where T : ISavable
        {
            var path = GetPath(typeof(T).Name, id);

            if (!File.Exists(path))
                return default;

            var json = File.ReadAllText(path);
            T obj = JsonUtility.FromJson<T>(json);

            _cached.Add(path, obj);

            return obj;
        }

        string GetDir(string savableType)
        {
            return $"{Application.persistentDataPath}/{savableType}";
        }

        string GetPath(string savableType, string id)
        {
            return $"{GetDir(savableType)}/{id}.txt";
        }
    }
}
