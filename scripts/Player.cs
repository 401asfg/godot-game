using Godot;

namespace GodotGame
{
	/// <summary>
	/// The character that is controlled by the player
	/// </summary>
	public partial class Player : Character
	{
        protected override Vector2 GetDirection()
        {
			int hdir = (int)Input.GetAxis(InputActions.PLAYER_MOVE_LEFT, InputActions.PLAYER_MOVE_RIGHT);
			int vdir = (int)Input.GetAxis(InputActions.PLAYER_MOVE_UP, InputActions.PLAYER_MOVE_DOWN);
			return new Vector2(hdir, vdir).Normalized();
        }
    }
}
