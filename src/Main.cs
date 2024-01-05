using Godot;

namespace GodotGame
{
	/// <summary>
	/// The root node of the scene
	/// </summary>
	public partial class Main : Node
	{
		public override void _Ready()
		{
			GD.Randomize();
		}
	}
}
