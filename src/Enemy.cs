using System.Windows.Markup;
using Godot;

namespace GodotGame
{
	/// <summary>
	/// An enemy character
	/// </summary>
	public partial class Enemy : Character
	{
		[Export]
		private int attackDamage;

		[Export]
		private float attackDistance;

		private Node2D target = null;

		/// <summary>
		/// Initializes the class
		/// </summary>
		/// <param name="position">The starting position of the enemy</param>
		/// <param name="target">The target of the enemy</param>
		public void Init(Vector2 position, Node2D target)
		{
			Position = position;
			this.target = target;
		}

		public override void _Process(double delta)
		{
			if (target == null) return;

			Vector2 targetDiff = GetTargetPositionDiff();
			Vector2 targetDir = targetDiff.Normalized();
			float targetDist = targetDiff.Length();

			if (targetDist < attackDistance) return;

			Walk(targetDir, (float)delta);
		}

		/// <returns>Produces the difference vector between the target's position and this enemy's position</returns>
		private Vector2 GetTargetPositionDiff()
		{
			return target.Position - Position;
		}
	}
}
