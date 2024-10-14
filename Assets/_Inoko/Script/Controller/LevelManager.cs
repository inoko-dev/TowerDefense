using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio
{
    public enum LevelResult 
    {
        NotDecided,
        Win,
        Lose,
    }

    public abstract class LevelManager : MonoBehaviour
    {
        public TowerDefenseController TowerDefenseController;
        
        private static LevelManager instance;
        public static LevelManager Instance => instance;
        public LevelResult Result { get; set; }

        protected virtual void Awake()
        {
            instance = this;
        }

        protected virtual void Start()
        {
            SetUpLevelEnvironment();
            GameManager.Instance.RegisterLevelManager(this);
        }

        protected virtual void SetUpLevelEnvironment()
        {
            ResetLevelState();
        }

        public virtual void ResetLevelState()
        {
            Result = LevelResult.NotDecided;
        }

        public abstract void StartLevel();

        protected virtual void EndGame(LevelResult levelResult)
        {
            if (Result != LevelResult.NotDecided)
            {
                Debug.LogWarning(
                    $"Level has already ended with result ${Result} but another request for result ${levelResult} is still being sent!");
                return;
            }

            Result = levelResult;
            GameManager.Instance.DelayedEndgame(levelResult);
        }

        protected virtual void OnDestroy() { }

        public void SetEndGame(LevelResult levelResult)
        {
            EndGame(levelResult);
        }
    }
}