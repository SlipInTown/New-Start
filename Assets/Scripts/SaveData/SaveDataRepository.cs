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
        
        public void Save(BonusArrayController player)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var savePlayer = new SavedData
            {
                _saveBadArray = player._boolBadArray,
                _saveGoodArray = player._boolGoodArray
            };

            Debug.Log(savePlayer.ToString());
            _data.Save(savePlayer, Path.Combine(_path, _fileName));
        }

        public void Load(BonusArrayController player)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);


            for (int i = 0; i < player._boolBadArray.Length; i++)
            {
                player._badCompArray[i].enabled = newPlayer._saveBadArray[i];
                
            }

            for (int i = 0; i < player._boolGoodArray.Length; i++)
            {
                player._goodCompArray[i].enabled = newPlayer._saveGoodArray[i];
            }
        }
    }
}