using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio 
{
    public class AIHuman : Human
    {
        public override void Init()
        {
            base.Init();
        }

        public override TypeEntity TypeEntity()
        {
            return InnoStudio.TypeEntity.ai;
        }
    }
}
