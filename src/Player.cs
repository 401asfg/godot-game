using Godot;

namespace GodotGame
{
	/// <summary>
	/// The character that is controlled by the player
	/// </summary>
	public partial class Player : CharacterBody2D
	{
		private const int MOVE_SPEED = 10;

		// FIXME: will this work for all monitor frame rates?
		public override void _PhysicsProcess(double delta)
		{
			Vector2 moveInput = GetMoveInput();
			Move(moveInput);
		}

		/// <summary>
		/// Move the player in the given dir
		/// </summary>
		/// <param name="dir">The direction to move the player in</param>
		public void Move(Vector2 dir)
		{
			// FIXME: does this need to be able to handle collisions? (MoveAndCollide/Slide?)
			Position += dir * MOVE_SPEED;
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
