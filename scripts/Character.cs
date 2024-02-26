// FIXME: enemies sometimes get caught on the player

using Godot;

namespace GodotGame
{
    /// <summary>
    /// A character in the game world
    /// </summary>
    public abstract partial class Character : CharacterBody2D
    {
        protected const int MIN_HEALTH = 0;
        protected const int MOVE_DIR_IDLE = 0;
        protected const string ANIM_MOVE = "move";

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
        /// Move the character in the given dir, slide on collision
        /// </summary>
        /// <param name="dir">The direction to move the character in</param>
        protected virtual void MoveAndSlide(Vector2 dir)
        {
            Velocity = dir * moveSpeed;
            MoveAndSlide();
        }

        /// <summary>
        /// Turn the player to face the given horizontal direction; Don't turn if hDir is zero
        /// </summary>
        /// <param name="hDir">The horizontal direction to turn towards</param>
        protected virtual void Turn(float hDir)
        {
            if (hDir != MOVE_DIR_IDLE) animatedSprite.FlipH = hDir < MOVE_DIR_IDLE;
        }

        /// <summary>
        /// Animate the character's sprite according to the given moveDir
        /// </summary>
        /// <param name="moveDir">The current movement direction of the character</param>
        protected virtual void Animate(Vector2 moveDir)
        {
            if (moveDir.X == MOVE_DIR_IDLE && moveDir.Y == MOVE_DIR_IDLE)
            {
                animatedSprite.Stop();
                return;
            }

            animatedSprite.Play(ANIM_MOVE);
        }
    }
}
