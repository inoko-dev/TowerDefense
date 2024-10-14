using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnoStudio
{
    public enum TypeEntity
    {
        none,
        character,
        ai,
        brick,
        archer,
        crossbow,
        cannon,
    }

    public enum TypeColor
    {
        none,
        blue,
        red,
        green,
        yellow,
        pink,
        violet,
    }

    public abstract class Entity : MonoBehaviour
    {
        protected TypeEntity _typeEntity;
        protected int _hp;

        public int HP { get { return _hp; } set { _hp = value; } }

        public abstract TypeEntity TypeEntity();
    }
}
