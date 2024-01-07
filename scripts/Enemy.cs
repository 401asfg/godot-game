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
			Vector2 targetDiff = GetTargetPositionDiff();
			Vector2 targetDir = targetDiff.Normalized();
			float targetDist = targetDiff.Length();

			Turn(targetDir.X);

			Vector2 moveDir = targetDir;

			if (targetDist < attackDistance) moveDir = Vector2.Zero;

			Move(moveDir, (float)delta);
			Animate(moveDir);
		}

		/// <returns>The difference vector between the target's position and this enemy's position; If the enemy's target is not set, produces a zero vector</returns>
		private Vector2 GetTargetPositionDiff()
		{
			if (target == null) return new Vector2(MOVE_DIR_IDLE, MOVE_DIR_IDLE);
			return target.Position - Position;
		}
	}
}
