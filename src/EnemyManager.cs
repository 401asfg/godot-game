using System;
using Godot;

namespace GodotGame
{
	/// <summary>
	/// Manages all enemies in the game world
	/// </summary>
	public partial class EnemyManager : Node
	{
		private const float MIN_DEGREE = 0f;
		private const float MAX_DEGREE = 360f;

		[Export]
		private float maxSpawnDistance;

		[Export]
		private float minSpawnDistance;

		[Export]
		private PackedScene[] enemies;

		[Export]
		private double[] enemySpawnIntervals;

		[Export]
		private Player player;

		private RandomNumberGenerator random;

		public override void _Ready()
		{
			if (maxSpawnDistance < minSpawnDistance) throw new Exception("Max Spawn Distance is less than its Min Spawn Distance");
			random = new RandomNumberGenerator();
			CreateSpawnTimers(enemies, enemySpawnIntervals);
		}

		/// <summary>
		/// Creates a set of infinitely looping timers that each spawn one of the enemies when triggered
		/// </summary>
		/// <param name="enemies">The enemies to spawn instances of</param>
		/// <param name="enemySpawnIntervals">The seconds between the repeated spawns for each of the given enemies</param>
		/// <exception cref="ArgumentException">Thrown if the length of enemies and enemySpawnIntervals aren't equal</exception>
		private void CreateSpawnTimers(PackedScene[] enemies, double[] enemySpawnIntervals)
		{
			if (enemies.Length != enemySpawnIntervals.Length) throw new ArgumentException("Enemies aren't matched one to one by their Spawn Intervals");

			for (int i = 0; i < enemies.Length; i++)
			{
				CreateSpawnTimer(enemies[i], enemySpawnIntervals[i]);
			}
		}

		/// <summary>
		/// Creates a timer that triggers the given enemy to be spawned every spawnInterval amount of time
		/// </summary>
		/// <param name="enemy">The enemy to instantiate when the timer timesout</param>
		/// <param name="spawnInterval">The seconds between every spawn trigger</param>
		private void CreateSpawnTimer(PackedScene enemy, double spawnInterval)
		{
			Timer timer = new Timer()
			{
				Autostart = true,
				OneShot = false,
				WaitTime = spawnInterval
			};

			timer.Timeout += () => SpawnRandomPosition(enemy);
			AddChild(timer);
		}

		/// <summary>
		/// Spawns the given enemy at a random position; The spawn position will be minSpawnDistance to maxSpawnDistance (inclusive) distance from the player
		/// </summary>
		/// <param name="enemy">The enemy to spawn</param>
		private void SpawnRandomPosition(PackedScene enemy)
		{
			float distance = random.RandfRange(minSpawnDistance, maxSpawnDistance);
			float degree = random.RandfRange(MIN_DEGREE, MAX_DEGREE);
			Spawn(enemy, distance, degree);
		}

		/// <summary>
		/// Spawns an enemy at the given distance from the player, at the given angle
		/// </summary>
		/// <param name="enemy">The enemy to spawn an instance of</param>
		/// <param name="distance">The distance to spawn the enemy from the player</param>
		/// <param name="degree">The degree of the spawn circle at which to spawn the enemy, relative to the player</param>
		private void Spawn(PackedScene enemy, float distance, float degree)
		{
			float enemyX = distance * Mathf.Sin(degree);
			float enemyY = distance * Mathf.Cos(degree);
			Vector2 enemyPos = new Vector2(enemyX, enemyY) + player.Position;

			Enemy enemyInst = enemy.Instantiate<Enemy>();
			enemyInst.Init(enemyPos, player);

			AddChild(enemyInst);
		}
	}
}
