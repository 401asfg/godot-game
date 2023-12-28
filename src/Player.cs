using Godot;

namespace Test
{
	public partial class Player : Node2D
	{
		[Export]
		private int speed;

		public override void _Process(double delta)
		{
			int hdir = (int)Input.GetAxis(InputActions.PLAYER_MOVE_LEFT, InputActions.PLAYER_MOVE_RIGHT);
			int vdir = (int)Input.GetAxis(InputActions.PLAYER_MOVE_UP, InputActions.PLAYER_MOVE_DOWN);
			Position += new Vector2(hdir * speed, vdir * speed);
		}
	}
}
