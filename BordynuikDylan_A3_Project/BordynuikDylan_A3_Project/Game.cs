/* Project Name: Box Jumper
 * Description: A 2D platformer game where the player must jump over boxes as long as possible.
 * Authors: Dylan Bordynuik
 * Date: March 13, 2025
 * Last Updated: March 16, 2025
 */

// Include the namespaces (code libraries) you need below.
using System;
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

            score += 1 * Time.DeltaTime;
            int intScore = (int)score;

            scoreText = intScore.ToString();

            Window.ClearBackground(new Color("152238"));

            if (Input.IsKeyboardKeyDown(KeyboardInput.Enter))
            {
                colorwheel = (colorwheel + 1) % playerColors.Length;
            }

            DrawPlayer();

            DrawBox();

            DrawScore();
        }

        public void DrawPlayer()
        {

            // Draw the player

            Draw.FillColor = playerColors[colorwheel];
            Draw.Rectangle(50, 200, 20, 20);
        }

        public void DrawBox()
        {
            // Draw the box
            Draw.FillColor = Color.White;
            Draw.Rectangle(380, 200, 20, 20);
        }

        public void DrawScore()
        {
            // Draw the score
          

            
            Draw.FillColor = Color.White;
            Text.Draw("Score: ", 10, 10);
            Text.Draw(scoreText, 120, 10);
        }

        void movePlayer()
        {
            float moveY = 0;

            if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
                moveY = moveY - 1; // Jump

        }
    }

}
