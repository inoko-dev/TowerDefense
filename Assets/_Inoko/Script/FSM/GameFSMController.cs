using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio
{
    public enum GameStateID
    {
        Lobby,
        InGame,
        EndGame,
    }

    public class GameFSMController
    {
        private GameStateID currentState;

        private GameState[] gameStates;

        public GameFSMController()
        {
            int numStates = System.Enum.GetNames(typeof(GameStateID)).Length;
            gameStates = new GameState[numStates];
        }

        public void AddState(GameState newState)
        {
            int index = (int)newState.GameStateID();
            gameStates[index] = newState;
        }

        public void ChangeState(GameStateID newStateID)
        {
            GameState()?.OnExit();
            currentState = newStateID;
            GameState()?.OnEnter();
        }

        public void OnFixedUpdate()
        {
            GameState()?.OnFixedUpdate();
        }

        public void OnLateUpdate()
        {
            GameState()?.OnLateUpdate();
        }

        public void OnUpdate()
        {
            GameState()?.OnUpdate();
        }

        public GameState GameState()
        {
            int index = (int)currentState;
            return gameStates[index];
        }

        public GameStateID CurrentGameState => currentState;
    }
}
