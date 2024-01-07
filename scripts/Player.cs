using Godot;

namespace GodotGame
{
	/// <summary>
	/// The character that is controlled by the player
	/// </summary>
	public partial class Player : Character
	{
		public override void _Process(double delta)
		{
			Vector2 moveInput = GetMoveInput();
			MoveAndSlide(moveInput);
			Turn(moveInput.X);
			Animate(moveInput);
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
