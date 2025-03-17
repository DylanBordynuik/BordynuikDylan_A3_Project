/* Project Name: Box Jumper
 * Description: A 2D platformer game where the player must jump over boxes as long as possible.
 * Authors: Dylan Bordynuik
 * Date: March 13, 2025
 * Last Updated: March 16, 2025
 */

// Include the namespaces (code libraries) you need below.
using System;
using System.Net.Http.Headers;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Color[] playerColors = { Color.Gray, Color.Clear, Color.Red, Color.Blue, Color.Cyan, Color.Magenta, Color.Green };
        int colorwheel = 0;
        float score;
        string scoreText;
        const int Digits = 1;
        Vector2 position;
        // player variables
        Vector2 velocity;
        Vector2 gravity = new Vector2(0, +10);
        Vector2 playerPosition = new Vector2(50, 200);
        float playerSpeed = 5f;
        bool isJumping = false;
        bool isOnGround = true;
        float jumpHeight = 5f;
        //obstacle variables
        Vector2 obstaclePosition = new Vector2(380, 200);
        float obstacleSpeed = 3f;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            // Set up window
            Window.SetTitle("Box Jumper");
            Window.SetSize(400, 400);
            // Outline Colour
            Draw.LineColor = Color.Black;
            Window.TargetFPS = 60;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            // score updates
            score += 1 * Time.DeltaTime;
            int intScore = (int)score;

            scoreText = intScore.ToString();

            // set background colour
            Window.ClearBackground(new Color("152238"));

            // fun little ability to change player colour
            if (Input.IsKeyboardKeyDown(KeyboardInput.Enter))
            {
                colorwheel = (colorwheel + 1) % playerColors.Length;
            }

            // draw game elements
            DrawPlayer();
            DrawBox();
            DrawScore();

            // player movement calls
            movePlayer();
            SimulateGravity();

            //Obstacle movement
            UpdateObstacle();

            // collision detection
            checkCollision();
        }

        public void DrawPlayer()
        {

            // Draw the player

            Draw.FillColor = playerColors[colorwheel];
            Draw.Rectangle(playerPosition.X, playerPosition.Y, 20, 20);
        }

        public void DrawBox()
        {
            // Draw the box
            Draw.FillColor = Color.White;
            Draw.Rectangle(obstaclePosition.X, obstaclePosition.Y, 20, 20);
        }

        public void DrawScore()
        {
            // Draw the score



            Draw.FillColor = Color.White;
            Text.Draw("Score: ", 10, 10);
            Text.Draw(scoreText, 120, 10);
        }

        public void movePlayer()
        {
            // jump logic (Press space to jump)
            if (Input.IsKeyboardKeyDown(KeyboardInput.Space) && isOnGround)
            {
                isJumping = true;
                isOnGround = false;
                velocity = new Vector2(0, -jumpHeight); // Set upward velocity for jump
            }

            // Update player position based on velocity
            playerPosition += velocity;

            // Check for landing (ground collision)
            if (playerPosition.Y >= 200)
            {
                playerPosition.Y = 200; // Keep player on the ground
                isOnGround = true;
                isJumping = false;
                velocity.Y = 0; // Reset velocity after landing
            }

        }

        public void SimulateGravity()
        {
            // Apply gravity only if player is in the air
            if (!isOnGround)
            {
                velocity.Y += gravity.Y * Time.DeltaTime;
            }
        }

        public void checkCollision()
        {
            // Check if the player has collided with the box
            if (playerPosition.X < obstaclePosition.X + 20 &&
                playerPosition.X + 20 > obstaclePosition.X &&
                playerPosition.Y < obstaclePosition.Y + 20 &&
                playerPosition.Y + 20 > obstaclePosition.Y)
            {
                // Collision detected, reset the score
                score = 0; // Reset score on collision
            }
        }

        public void UpdateObstacle()
        {
            // Move the obstacle left across the screen
            obstaclePosition.X -= obstacleSpeed;

            // Reset obstacle position if it goes off screen
            if (obstaclePosition.X < 0)
            {
                obstaclePosition.X = 380;
            }

            // Increase obstacle speed to a cap of 10
            if (obstacleSpeed < 10)
            {
                obstacleSpeed = obstacleSpeed + Time.DeltaTime / 2;
            }

        }

    }
}
