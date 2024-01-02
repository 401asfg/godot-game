using Godot;

namespace GodotGame
{
    /// <summary>
    /// An enemy character
    /// </summary>
    public partial class Enemy : CharacterBody2D
    {
        private const int MIN_HEALTH = 0;

        [Export]
        private int maxHealth;

        private int health;

        [Export]
        private int Health
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

        [Export]
        private int attackDamage;
    }
}
