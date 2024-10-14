using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InnoStudio
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; set; }

        [FoldoutGroup("Controller")]
        [SerializeField] private UIController uiController;
        [FoldoutGroup("Controller")]
        [SerializeField] private SoundManager soundManager;
        [FoldoutGroup("Controller")]
        [SerializeField] private FeatureController featureController;
        [FoldoutGroup("Controller")]
        [SerializeField] private EventGameController eventGameController;
        public UIController UIController => uiController;
        public SoundManager SoundManager => soundManager;
        public FeatureController FeatureController => featureController;
        public EventGameController EventGameController => eventGameController;
        public PlayerDataManager PlayerDataManager => PlayerDataManager.Instance;

        public GameFSMController GameFSMController;

        private LevelManager currentLevelManager;
        public LevelManager LevelManager
        {
            get => currentLevelManager;
            private set => currentLevelManager = value;
        }
        public bool IsLevelLoading { get; set; }

        private int currentLevel;
        private int displayLevel;
        private int maxLevel;
        private bool isLoop;
        public int CurrentLevel
        { 
            get 
            { 
                if (currentLevel >= maxLevel) 
                    return Index_Level_Loop; 
                return currentLevel; 
            }
        }
        
        public int DisplayLevel => displayLevel;
        public int MaxLevel => maxLevel;
        public bool IsLoop => isLoop;

        private DataLevel DataLevel;

        private const int Index_Level_Loop = 1;

        [FoldoutGroup("Data")]
        public DataLevelGame DataLevelGame;

        public bool isLoadSceneLevel;

        private void Awake()
        {
            Instance = this;
            GameFSMController = new GameFSMController();
            GameFSMController.AddState(new LobbyAction());
            GameFSMController.AddState(new InGameAction());
            GameFSMController.AddState(new EndGameAction());
        }

        private void Start()
        {
            UIController.Init();
            DataLevel dataLevel = new DataLevel();
            PlayerDataManager.SetDataLevel(dataLevel);
            LoadDataLevel();
            GameFSMController.ChangeState(GameStateID.Lobby);
        }

        public void Update()
        {
            GameFSMController.OnUpdate();
        }

        public void FixedUpdate()
        {
            GameFSMController.OnFixedUpdate();
        }

        public void LateUpdate()
        {
            GameFSMController.OnLateUpdate();
        }

        public void StartLevel()
        {
            if (isLoadSceneLevel)
            {
                SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
            }
        }

        public void UnloadSceneGame()
        {
            SceneManager.UnloadSceneAsync(1);
        }

        public void RegisterLevelManager(LevelManager levelManager)
        {
            LevelManager = levelManager;
            GameFSMController.ChangeState(GameStateID.InGame);
            uiController.OpenLoading(false);
            IsLevelLoading = false;
        }

        public void DelayedEndgame(LevelResult result, float delayTime = .5f)
        {
            StartCoroutine(DelayedEndgameCoroutine(result, delayTime));
        }

        private IEnumerator DelayedEndgameCoroutine(LevelResult result, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            EndLevel(result);
        }

        public void EndLevel(LevelResult result)
        {
            GameFSMController.ChangeState(GameStateID.EndGame);
            if (result == LevelResult.Win)
            {
                IncreaseLevel();
            }
        }

        public void IncreaseLevel()
        {
            currentLevel++;
            displayLevel++;

            if (currentLevel >= MaxLevel)
            {
                currentLevel = Index_Level_Loop;
                if (!isLoop)
                {
                    isLoop = true;
                }
            }

            DataLevel.currentLevel = currentLevel;
            DataLevel.levelDisplay = displayLevel;
            DataLevel.isLoop = isLoop;
            DataLevel.maxLevel = MaxLevel;
            PlayerDataManager.SetDataLevel(DataLevel);
        }

        public void LoadDataLevel()
        {
            DataLevel = PlayerDataManager.GetDataLevel();

            if (DataLevel == null)
            {
                DataLevel = new DataLevel();
                DataLevel.isLoop = false;
                DataLevel.maxLevel = DataLevelGame.GetCountLevel();
                DataLevel.currentLevel = 0;
                DataLevel.levelDisplay = 1;
            }

            if (DataLevel.isLoop)
            {
                if (DataLevelGame.GetCountLevel() > DataLevel.maxLevel)
                {
                    DataLevel.currentLevel = DataLevel.maxLevel;
                    DataLevel.maxLevel = DataLevelGame.GetCountLevel();
                    DataLevel.isLoop = false;
                }
            }
            currentLevel = DataLevel.currentLevel;
            displayLevel = DataLevel.levelDisplay;
            isLoop = DataLevel.isLoop;
            maxLevel = DataLevel.maxLevel;
            PlayerDataManager.SetDataLevel(DataLevel);
        }
    }
}


