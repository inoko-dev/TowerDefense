using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio
{
    public interface GameState 
    {
        GameStateID GameStateID();
        void OnEnter();
        void OnExit();
        void OnUpdate();
        void OnFixedUpdate();
        void OnLateUpdate();
    }
}