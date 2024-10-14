using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio
{
    public abstract class Mob : Entity
    {
        protected int _atk;
        protected string _name;
        protected bool _isDie;
        public int ATK { get { return _atk; } }
        public bool IsDie { get { return _isDie; } }

        public string Name { get { return _name; } }
    }
}
