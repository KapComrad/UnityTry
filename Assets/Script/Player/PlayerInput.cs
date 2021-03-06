using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public float HorizontalInput { get; private set; }
        public bool JumpInputDown { get; private set; }
        public bool JumpInputUp { get; private set; }
        public bool Escape { get; private set; }
        public bool Tab { get; set; }

        private void Update()
        {
            HorizontalInput = Input.GetAxis("Horizontal");
            JumpInputDown = Input.GetButtonDown("Jump");
            JumpInputUp = Input.GetButtonUp("Jump");
            Escape = Input.GetButtonDown("Cancel");
            Tab = Input.GetButtonDown("Tab");
        }

    }

}

