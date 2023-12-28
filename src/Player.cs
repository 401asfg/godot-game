using Godot;

namespace Test
{
	public partial class Player : Node2D
	{
		[Export]
		private int speed;

		public override void _Process(double delta)
		{
			HandleMoveInput();
		}

		// FIXME: does this need to be able to handle collisions? (MoveAndCollide/Slide?)
		// FIXME: does this need to be adjusted with delta?
		private void HandleMoveInput()
		{
			int hdir = (int)Input.GetAxis(InputActions.PLAYER_MOVE_LEFT, InputActions.PLAYER_MOVE_RIGHT);
			int vdir = (int)Input.GetAxis(InputActions.PLAYER_MOVE_UP, InputActions.PLAYER_MOVE_DOWN);
			Vector2 dir = new Vector2(hdir, vdir);

			Position += dir * speed;
		}
	}
}
