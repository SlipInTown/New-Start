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
            var savePlayer = new SavedData();

            _data.Save(savePlayer, Path.Combine(_path, _fileName));

            Debug.Log("Сейв успешный");
        }

        public void Load(PlayerBase player)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);
            Debug.Log("Лоад успешный");
            for (int i = 0; i < player.baseBoolBadArray.Length; i++)
            {
                player.badCompArray[i].enabled = newPlayer._saveBadArray[i];
                
            }

            for (int i = 0; i < player.baseBoolGoodArray.Length; i++)
            {
                player.goodCompArray[i].enabled = newPlayer._saveGoodArray[i];
            }

            Debug.Log("Лоад успешный");
        }
    }
}