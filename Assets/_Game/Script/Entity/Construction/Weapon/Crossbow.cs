using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio 
{
    public class Crossbow : Construction
    {
        public override TypeEntity TypeEntity()
        {
            return InnoStudio.TypeEntity.crossbow;
        }
    }
}
