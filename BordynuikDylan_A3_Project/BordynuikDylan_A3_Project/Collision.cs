using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BordynuikDylan_A3_Project
{
    public class Collision
    {
        public static bool Check(Player player, Obstacle obstacle)
        {
            // Check if the player has collided with the obstacle
            if (player.position.X < obstacle.position.X + 20 &&
                player.position.X + 20 > obstacle.position.X &&
                player.position.Y < obstacle.position.Y + 20 &&
                player.position.Y + 20 > obstacle.position.Y)
            {
                return true; // Collision detected
            }
            return false; // No collision
        }
    }
}
