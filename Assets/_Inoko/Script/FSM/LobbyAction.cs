using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio
{
    public class LobbyAction : GameState
    {
        public GameStateID GameStateID()
        {
            return InnoStudio.GameStateID.Lobby;
        }

        public void OnEnter()
        {
            Debug.Log("OnLobby");
            GameManager.Instance.UIController.OnEnterLobby();
        }

        public void OnExit()
        {
            GameManager.Instance.UIController.OnExitLobby();
        }

        public void OnFixedUpdate()
        {
        }

        public void OnLateUpdate()
        {

        }

        public void OnUpdate()
        {
        }
    }
}
