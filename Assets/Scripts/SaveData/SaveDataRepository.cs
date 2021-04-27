using System.IO;
using UnityEngine; 

namespace AlexSpace
{
    public sealed class SaveDataRepository : ISaveDataRepository
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;
        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                //_data = new PlayerPrefsData();
            }
            else
            {
                _data = new SerializableIXMLData<SavedData>();
            }
            _path = Path.Combine(Application.dataPath, _folderName);
        }
        
        public void Save(PlayerBase player)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var savePlayer = new SavedData
            {
                _position = player.transform.position,
                _name = "Alex",
                _isEnabled = true
            };

            Debug.Log("red");
            _data.Save(savePlayer, Path.Combine(_path, _fileName));
        }

        public void Load(PlayerBase player)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);
            player.transform.position = newPlayer._position;
            player.name = newPlayer._name;
            player.gameObject.SetActive(newPlayer._isEnabled);

            Debug.Log(player);
        }
    }
}