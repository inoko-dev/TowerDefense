using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio 
{
    public class Character : Human
    {
        public override TypeEntity TypeEntity()
        {
            return InnoStudio.TypeEntity.character;
        }
    }
}
