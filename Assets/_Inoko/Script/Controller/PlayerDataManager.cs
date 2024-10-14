using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio
{
    public class PlayerDataManager : MonoBehaviour
    {
        public static PlayerDataManager Instance {  get; set; }

        private void Awake()
        {
            Instance = this;
        }

        public void SetDataLevel(DataLevel gameLevel)
        {
            PlayerPrefs.SetString("DataLevel", JsonUtility.ToJson(gameLevel));
        }

        public DataLevel GetDataLevel()
        {
            DataLevel gameLevel = JsonUtility.FromJson<DataLevel>(PlayerPrefs.GetString("DataLevel", null));
            return gameLevel;
        }
    }

    [System.Serializable]
    public class DataLevel
    {
        public int currentLevel;
        public int maxLevel;
        public int levelDisplay;
        public bool isLoop;
    }
}
