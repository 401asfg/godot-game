using Godot;

namespace GodotGame
{
    /// <summary>
    /// A character in the game world
    /// </summary>
    public abstract partial class Character : CharacterBody2D
    {
        protected const int MIN_HEALTH = 0;
        private const int MOVE_DIR_IDLE = 0;
        // FIXME: change sprite frame name to reflect this change
        private const string ANIM_WALK = "walk";

        [Export]
        protected int moveSpeed;

        [Export]
        protected AnimatedSprite2D animatedSprite;

        [Export]
        protected int maxHealth;

        private int health;

        [Export]
        protected int Health
        {
            get
            {
                return health;
            }

            set
            {
                value = value < MIN_HEALTH ? MIN_HEALTH : value;
                health = value > maxHealth ? maxHealth : value;
            }
        }

        /// <summary>
        /// Moves the character in the given dir with the walk animation for that dir
        /// </summary>
        /// <param name="dir">The direction to walk the character in</param>
        /// <param name="delta">The time elapsed since the previous frame</param>
        protected virtual void Walk(Vector2 dir, float delta)
        {
            Move(dir, delta);
            AnimateWalk(dir);
        }

        /// <summary>
        /// Move the character in the given dir
        /// </summary>
        /// <param name="dir">The direction to move the character in</param>
        /// <param name="delta">The time elapsed since the previous frame</param>
        protected virtual void Move(Vector2 dir, float delta)
        {
            Position += dir * moveSpeed * delta;
        }

        /// <summary>
        /// Animate the character's sprite according to the given moveDir
        /// </summary>
        /// <param name="moveDir">The current movement direction of the character</param>
        protected virtual void AnimateWalk(Vector2 moveDir)
        {
            if (moveDir.X == MOVE_DIR_IDLE && moveDir.Y == MOVE_DIR_IDLE)
            {
                animatedSprite.Stop();
                return;
            }

            if (moveDir.X != MOVE_DIR_IDLE) animatedSprite.FlipH = moveDir.X < MOVE_DIR_IDLE;
            animatedSprite.Play(ANIM_WALK);
        }
    }
}
