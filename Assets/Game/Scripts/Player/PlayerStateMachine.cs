using UnityEngine;

namespace Player 
{ 
    public class PlayerStateMachine : StateMachine {

        internal float horizontalMove = 0f;
        internal float verticalMove = 0f;
        internal Rigidbody2D playerRigidbody;
        internal Vector3 lastPositionOnSolidGround;
        public float moveSpeed = 40f;
        internal SpriteRenderer spriteRenderer;
        public Animator animator;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            SetState(new RegularState(this));
        }

        void Update()
        {
            State.Update();
        }


        void FixedUpdate()
        {
            State.FixedUpdate();
        }

        public void setToRegularState()
        {
            SetState(new RegularState(this));
        }
        /*
        public void respawnAtSSpot()
        {
            SetState(new RespawnState(this));
        }

        public void Die()
        {
            FindObjectOfType<GameOverScript>().Activate();
            SetState(new DieState(this));
        }
        */
    }
}
