using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio 
{
    public class Archer : Soldier
    {
        public override TypeEntity TypeEntity()
        {
            return InnoStudio.TypeEntity.archer;
        }
    }
}
