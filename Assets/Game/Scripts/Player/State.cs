using System;
using System.Collections;

namespace Player
{
    public class State
    {
        internal PlayerStateMachine stateMachine;

        public State(PlayerStateMachine playerMovementMachine)
        {
            stateMachine = playerMovementMachine;
        }

        public virtual IEnumerator Start()
        {
            yield break;
        }

        public virtual void Update()
        {
        }

        public virtual void FixedUpdate()
        {
        }

        public virtual string GetStateName()
        {
            return "TODO State Name";
        }
    }
}
