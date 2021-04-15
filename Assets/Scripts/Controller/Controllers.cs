﻿using System.Collections.Generic;

namespace AlexSpace
{
    public class Controllers : IBonus, IExecute
    {
        private readonly List<IBonus> _bonusControllers;
        private readonly List<IInitialization> _initializeControllers;
        private readonly List<IExecute> _executeControllers;
        //private readonly List<ILateExecute> _lateControllers;
        private readonly List<ICleanup> _cleanupControllers;

        internal Controllers()
        {
            _initializeControllers = new List<IInitialization>();
            _executeControllers = new List<IExecute>();
            //_lateControllers = new List<ILateExecute>();
            _cleanupControllers = new List<ICleanup>();
        }

        public void Effect()
        {
            for (var index = 0; index < _bonusControllers.Count; ++index)
            {
                _bonusControllers[index].Effect();
            }
        }

        public void Initialization()
        {
            for (var index = 0; index < _initializeControllers.Count; ++index)
            {
                _initializeControllers[index].Initialization();
            }
        }

        public void Execute()
        {
            for (var index = 0; index < _executeControllers.Count; ++index)
            {
                _executeControllers[index].Execute();
            }
        }

        public Controllers Add(IController controller)
        {
            if (controller is IInitialization initializeController)
            {
                _initializeControllers.Add(initializeController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }

            //if (controller is ILateExecute lateExecuteController)
            //{
            //    _lateControllers.Add(lateExecuteController);
            //}

            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }

            return this;
        }
        public void Cleanup()
        {
            for (var index = 0; index < _cleanupControllers.Count; ++index)
            {
                _cleanupControllers[index].Cleanup();
            }
        }
    }
}