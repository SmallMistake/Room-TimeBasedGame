using System;
using UnityEngine;

namespace Player
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected State State;

        public void SetState(State state)
        {
            try
            {
                State = state;
                StartCoroutine(state.Start());

            } catch (NullReferenceException ex)
            {
                Debug.LogError("Please check the states on the player as you are missing a state");
                Debug.LogException(ex);
            }
        }

        public State GetState()
        {
            return State;
        }
    }
}
