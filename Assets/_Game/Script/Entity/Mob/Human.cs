using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio
{
    public abstract class Human : Mob
    {
        [SerializeField] protected TypeColor _typeColor;
        [SerializeField] protected float radius = 2;
        [SerializeField] protected LayerMask layerMask;
        public TypeColor TypeColor => _typeColor;
        private float timeCheck = .5f;
        private const float Time_Reset = .5f;
        private const float Offset = .15f;
        [SerializeField] private Transform posHoldBricks;
        [SerializeField] private float[] posHolds;
        private const int MAX_BRICK = 10;
        [SerializeField] private List<Brick> holdBricks;
        public bool IsFullBrick => holdBricks.Count >= MAX_BRICK || current >= MAX_BRICK;
        private int current;

        [SerializeField] protected Animator animator;

        public virtual void Init()
        {
            posHolds = new float[MAX_BRICK];
            for (int i = 1; i < posHolds.Length; i++)
            {
                posHolds[i] = posHolds[i - 1] + Offset;
            }
            holdBricks = new List<Brick>();
        }

        public virtual void OnUpdate()
        {
            if (!IsDie) return;

            timeCheck -= Time.deltaTime;
            if (timeCheck < 0)
            {
                timeCheck = Time_Reset;
                CheckBrick();
            }
        }

        private void CheckBrick()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, layerMask);
            foreach (var hitCollider in hitColliders)
            {
                Brick brick = hitCollider.GetComponent<Brick>();
                brick.Claim(this);
            }
        }

        public void AddBrick(Brick brick)
        {
            if (holdBricks.Contains(brick)) return;

            holdBricks.Add(brick);
            Vector3 pos = posHoldBricks.transform.localPosition;
            pos.y = posHolds[current];
            brick.AnimationJumpToHuman(posHoldBricks, pos);
            current++;
        }

        public void RemoveBrick(Brick brick)
        {
            if (holdBricks.Contains(brick)) return;

            holdBricks.Remove(brick);
        }
    }
}
