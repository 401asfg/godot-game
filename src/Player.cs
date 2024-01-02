using Godot;

namespace GodotGame
{
	/// <summary>
	/// The character that is controlled by the player
	/// </summary>
	public partial class Player : CharacterBody2D
	{
		private const int MOVE_SPEED = 600;

		private const int MOVE_INPUT_IDLE = 0;
		private const string ANIM_RUN = "run";

		[Export]
		private AnimatedSprite2D animatedSprite;

		public override void _Process(double delta)
		{
			Vector2 moveInput = GetMoveInput();
			Move(moveInput, (float)delta);
			Animate(moveInput);
		}

		/// <summary>
		/// Move the player in the given dir
		/// </summary>
		/// <param name="dir">The direction to move the player in</param>
		/// <param name="delta">The time elapsed since the previous frame</param>
		private void Move(Vector2 dir, float delta)
		{
			Position += dir * MOVE_SPEED * delta;
		}

		/// <summary>
		/// Animate the player's sprite according to the given moveInput
		/// </summary>
		/// <param name="moveInput">The current input value for player movement</param>
		private void Animate(Vector2 moveInput)
		{
			if (moveInput == new Vector2(MOVE_INPUT_IDLE, MOVE_INPUT_IDLE))
			{
				animatedSprite.Stop();
				return;
			}

			if (moveInput.X != MOVE_INPUT_IDLE) animatedSprite.FlipH = moveInput.X < MOVE_INPUT_IDLE;
			animatedSprite.Play(ANIM_RUN);
		}

		/// <returns>The current direction of the move input</returns>
		private static Vector2 GetMoveInput()
		{
			int hdir = (int)Input.GetAxis(InputActions.PLAYER_MOVE_LEFT, InputActions.PLAYER_MOVE_RIGHT);
			int vdir = (int)Input.GetAxis(InputActions.PLAYER_MOVE_UP, InputActions.PLAYER_MOVE_DOWN);
			return new Vector2(hdir, vdir).Normalized();
		}
	}
}
