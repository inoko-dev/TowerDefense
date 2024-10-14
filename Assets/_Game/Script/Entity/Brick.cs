using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio 
{
    public class Brick : Entity
    {
        private TypeColor typeColor;
        private bool isClaim;

        public TypeColor TypeColor { get { return typeColor; } set {  typeColor = value; } }

        public void Claim(Human human)
        {
            if (isClaim || typeColor != TypeColor.none)
            {
                return;
            }

            if (!human.IsFullBrick)
            {
                human.AddBrick(this);
            }
        }

        public void AnimationJumpToHuman(Transform parent, Vector3 target)
        {
            if (isClaim) return;
            isClaim = true;
            transform.SetParent(parent);
            transform.DOLocalJump(target, 3, 1, .3f);
        }

        public override TypeEntity TypeEntity()
        {
            return InnoStudio.TypeEntity.brick;
        }
    }
}
