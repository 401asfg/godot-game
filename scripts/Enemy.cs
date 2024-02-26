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

        protected override Vector2 GetDirection()
        {
			return GetTargetPositionDiff().Normalized();
        }

        protected override void MoveAndSlide(Vector2 dir)
        {
			if (GetTargetPositionDiff().Length() < attackDistance) dir = Vector2.Zero;
            base.MoveAndSlide(dir);
        }

		private Vector2 GetTargetPositionDiff() {
			if (target == null) return new Vector2(MOVE_DIR_IDLE, MOVE_DIR_IDLE);
			return target.Position - Position;
		}
    }
}
