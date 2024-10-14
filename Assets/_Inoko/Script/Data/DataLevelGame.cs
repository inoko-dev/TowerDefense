using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio 
{
    [CreateAssetMenu(fileName = "Data Level", menuName = "ScriptableObjects/Data Level", order = 1)]
    public class DataLevelGame : ScriptableObject
    {
        public LevelObject[] levelObjects;

        public int GetCountLevel()
        {
            return levelObjects.Length;
        }
    }

    [System.Serializable]
    public class LevelObject
    {
        public int id;
        public TextAsset dataLevel;
    }
}
