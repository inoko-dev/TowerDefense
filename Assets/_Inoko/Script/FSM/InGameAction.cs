using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio
{
    public class InGameAction : GameState
    {
        public GameStateID GameStateID()
        {
            return InnoStudio.GameStateID.InGame;
        }

        public void OnEnter()
        {
            Debug.Log("OnInGame");
            GameManager.Instance.LevelManager.TowerDefenseController.Init();
        }

        public void OnExit()
        {
            
        }

        public void OnFixedUpdate()
        {
            
        }

        public void OnLateUpdate()
        {
            
        }

        public void OnUpdate()
        {
            GameManager.Instance.LevelManager.TowerDefenseController.OnUpdate();
        }
    }
}