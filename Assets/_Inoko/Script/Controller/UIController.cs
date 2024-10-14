using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio 
{
    public class UIController : MonoBehaviour
    {
        public UILobby UILobby;
        public UIInGame UIInGame;
        public UILose UILose;
        public UIWin UIWin;

        public void Init()
        {
            UILobby.Init();
            UIInGame.Init();
            UILose.Init();
            UIWin.Init();
        }

        public void OnEnterLobby()
        {
            UILobby.Show(true);
        }

        public void OnExitLobby()
        {
            UILobby.Show(false);
        }

        public void OnEnterInGame()
        {
            UIInGame.Show(true);
        }

        public void OnExitInGame()
        {
            UIInGame.Show(false);
        }

        public void OpenLoading(bool isLoading)
        {
            
        }
    }
}
