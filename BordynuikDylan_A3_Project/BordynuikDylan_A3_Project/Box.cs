using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BordynuikDylan_A3_Project
{
    public class Obstacle
    {
        public Vector2 position;
        private float obstacleSpeed = 3f;

        public Obstacle(Vector2 startPosition)
        {
            position = startPosition;
        }

        public void Move()
        {
            // Move the obstacle left across the screen
            position.X -= obstacleSpeed;

            // Reset obstacle position if it goes off screen
            if (position.X < 0)
            {
                position.X = 380;
            }
        
            // Increase obstacle speed to a cap of 10
            if (obstacleSpeed < 10)
            {
                obstacleSpeed = obstacleSpeed + Time.DeltaTime / 2;
            }

        }
    }
}
