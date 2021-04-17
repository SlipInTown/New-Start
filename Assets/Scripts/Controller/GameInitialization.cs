using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexSpace
{
    public class GameInitialization
    {
        public GameInitialization(Controllers controllers, UnityEngine.UI.Button data)
        {
            controllers.Add(new BlueCubesController());
            controllers.Add(new RestartSceneController());
            controllers.Add(new ButtonController(data));
            //Camera camera = Camera.main;
            //var inputInitialization = new InputInitialization();
            //var playerFactory = new PlayerFactory(data.Player);
            //var playerInitialization = new PlayerInitialization(playerFactory, data.Player.Position);
            //var enemyFactory = new EnemyFactory(data.Enemy);
            //var enemyInitialization = new EnemyInitialization(enemyFactory);
            //controllers.Add(inputInitialization);
            //controllers.Add(playerInitialization);
            //controllers.Add(enemyInitialization);
            //controllers.Add(new InputController(inputInitialization.GetInput()));
            //controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), data.Player));


        }
    }
}