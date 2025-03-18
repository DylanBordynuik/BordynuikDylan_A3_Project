﻿using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BordynuikDylan_A3_Project
{
    public class Player
    {
        public Vector2 position;
        public Vector2 velocity;
        private Vector2 gravity = new Vector2(0, +10);
        private float jumpHeight = 5f;
        private bool isJumping = false;
        private bool isOnGround = true;

        // Constructor that takes a Vector2 for the player position
        public Player(Vector2 startPosition)
        {
            position = startPosition;
        }

        public void Move(bool jumpPressed)
        {
            if (jumpPressed && isOnGround)
            {
                isJumping = true;
                isOnGround = false;
                velocity = new Vector2(0, -jumpHeight); // set velocity to be up for jump
            }

            // apply gravity if player is in the air
            if (!isOnGround)
            {
                velocity.Y += gravity.Y * Time.DeltaTime;
            }

            // change player position based on velocity
            position += velocity;

            // Check for landing (ground collision)
            if (position.Y >= 200)
            {
                position.Y = 200; // Keep player on the ground
                isOnGround = true;
                isJumping = false;
                velocity.Y = 0; // Reset velocity after landing
            }
        }

    }
}