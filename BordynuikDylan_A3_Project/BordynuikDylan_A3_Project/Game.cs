/* Project Name: Box Jumper
 * Description: A 2D platformer game where the player must jump over boxes as long as possible.
 * Authors: Dylan Bordynuik
 * Date: March 13, 2025
 * Last Updated: March 17, 2025
 */

// Include the namespaces (code libraries) you need below.
using System;
using System.Net.Http.Headers;
using System.Numerics;
using BordynuikDylan_A3_Project;


// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:

        public float score;
        public string scoreText;
        public const int Digits = 1;

        Color[] playerColors = { Color.Gray, Color.Clear, Color.Red, Color.Blue, Color.Cyan, Color.Magenta, Color.Green };
        public int colorwheel = 0;

       
        private Player player;
        private Obstacle obstacle;

        public Game()
        {
            player = new Player(new Vector2(50, 200)); // Initialize player at start position
            obstacle = new Obstacle(new Vector2(380, 200)); // Initialize obstacle at start position
        }
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Box Jumper");
            Window.SetSize(400, 400);
            Draw.LineColor = Color.Black;
            Window.TargetFPS = 60;
        }

        public void Update()
        {
            // Score updates
            score += 1 * Time.DeltaTime;
            int intScore = (int)score;
            scoreText = intScore.ToString();

            // Clear background
            Window.ClearBackground(new Color("152238"));

            if (Input.IsKeyboardKeyDown(KeyboardInput.Enter))
            {
                colorwheel = (colorwheel + 1) % playerColors.Length;
            }

            // Move player based on spacebar input
            bool jumpPressed = Input.IsKeyboardKeyDown(KeyboardInput.Space);
            player.Move(jumpPressed);

            // Move the obstacle
            obstacle.Move();

            // Check for collision
            if (Collision.Check(player, obstacle))
            {
                // Reset score on collision
                score = 0;
            }

            // Draw elements
            DrawPlayer();
            DrawObstacle();
            DrawScore();
        }

        public void DrawPlayer()
        {
            // Draw the player
            Draw.FillColor = playerColors[colorwheel];
            Draw.Rectangle(player.position.X, player.position.Y, 20, 20);
        }

        public void DrawObstacle()
        {
            // Draw the obstacle (box)
            Draw.FillColor = Color.White;
            Draw.Rectangle(obstacle.position.X, obstacle.position.Y, 20, 20);
        }

        public void DrawScore()
        {
            // Draw the score at the top of the screen
            Draw.FillColor = Color.White;
            Text.Draw("Score: ", 10, 10);
            Text.Draw(scoreText, 120, 10);
        }
    }
}

