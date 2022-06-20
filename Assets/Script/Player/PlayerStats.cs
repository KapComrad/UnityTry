using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        public static PlayerStats singleton { get; private set; }

        [SerializeField] private int _health= 3;
        [SerializeField] private int _score = 0;
        [SerializeField] private int _numberOfJumps = 1;

        public int Health
        {
            get { return _health; }
            private set { _health = value; }
        }

        public int Score
        {
            get { return _score; }
            private set { _score = value; }
        }

        public int NumberOfJumps { get { return _numberOfJumps; } set { _numberOfJumps = value; } }

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

        public void ScoreIncrease()
        {
            _score++;
        }

    }
}

