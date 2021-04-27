using UnityEngine;

namespace AlexSpace
{
    public sealed class InputController : IExecute, IController
    {
        private readonly BonusArrayController _playerBase;
        private readonly ISaveDataRepository _saveDataRepository;
        private readonly KeyCode _saveKey = KeyCode.C;
        private readonly KeyCode _LoadKey = KeyCode.L;

        public InputController(BonusArrayController player)
        {
            _playerBase = player;

            _saveDataRepository = new SaveDataRepository();
        }

        public void Execute()
        {
            if (Input.GetKeyDown(_saveKey))
            {
                _saveDataRepository.Save(_playerBase);
            }

            if (Input.GetKeyDown(_LoadKey))
            {
                _saveDataRepository.Load(_playerBase);
            }
        }


    }
}