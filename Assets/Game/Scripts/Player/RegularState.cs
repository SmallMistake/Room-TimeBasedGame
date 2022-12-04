
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
	public class RegularState : State
	{
		public RegularState(PlayerStateMachine stateMachine) : base(stateMachine) {
		}

		enum direction { left, right, up, down };

		private List<direction> keysPressed = new List<direction>();

		override
		public void FixedUpdate()
		{


			stateMachine.horizontalMove = Input.GetAxisRaw("Horizontal") * stateMachine.moveSpeed;
			stateMachine.verticalMove = Input.GetAxisRaw("Vertical") * stateMachine.moveSpeed;

			Vector2 movement = new Vector2(stateMachine.horizontalMove * stateMachine.moveSpeed, stateMachine.verticalMove * stateMachine.moveSpeed);
			movement *= Time.deltaTime;

			stateMachine.playerRigidbody.AddForce(movement);

			//Deal with animation
			stateMachine.animator.SetFloat("Vertical Speed", movement.y);
			stateMachine.animator.SetFloat("Horizontal Speed", movement.x);
		}
	}
}
