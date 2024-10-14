using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio 
{
    public class Character : Human
    {
        public override void Init()
        {
            base.Init();
        }

        public override void OnUpdate()
        {
            Movement();
            base.OnUpdate();
        }

        void Movement()
        {

        }

        public override TypeEntity TypeEntity()
        {
            return InnoStudio.TypeEntity.character;
        }
    }
}
