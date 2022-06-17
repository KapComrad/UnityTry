using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        public static PlayerStats singleton { get; private set; }

        [SerializeField] private int _health= 3;

        public int Health
        {
            get { return _health; }
            private set { _health = value; }
        }


        private void Awake()
        {
            if (!singleton)
            {
                singleton = this;
                DontDestroyOnLoad(this);

            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void HealthDecrease()
        {
            _health--;
        }

        public void HealthIncrease()
        {
            _health++;
        }




    }
}

