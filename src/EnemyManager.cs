using System;
using System.Collections.Generic;
using Godot;

namespace GodotGame
{
    /// <summary>
    /// Manages all enemies in the game world
    /// </summary>
    public partial class EnemyManager : Node
    {
        public class SpawnRangeException : Exception { }

        [Export]
        private float maxSpawnDistance;

        [Export]
        private float minSpawnDistance;

        [Export]
        private PackedScene enemyResource;
        private List<Enemy> enemies;

        [Export]
        private Player player;

        public override void _Ready()
        {
            if (maxSpawnDistance < minSpawnDistance) throw new Exception("Max spawn distance is less than its min spawn distance");
            enemies = new List<Enemy>();
        }

        private void Spawn(float distance, float angle)
        {
            Node enemy = enemyResource.Instantiate();
            AddChild(enemy);
            enemies.Add((Enemy)enemy);
            // TODO: implement
        }
    }
}
