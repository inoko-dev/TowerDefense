using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio
{
    public class TowerDefenseController : MonoBehaviour
    {
        public Character character;
        public List<AIHuman> aiHumans;

        public void Init()
        {
            character.Init();
            foreach (AIHuman human in aiHumans)
            {
                human.Init();
            }    
        }

        public void OnUpdate()
        {
            character.OnUpdate();
            foreach (AIHuman human in aiHumans)
            {
                human.OnUpdate();
            }
        }
    }
}
