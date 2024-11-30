using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;


namespace WeedInvaders
{
    internal class Missile
    {
        Texture2D missileTexture;
        Rectangle missileFrame;
        float missileSpeed = 1;
        
        private Vector2 Position;
        private bool IsActive;

        public void LoadContent(ContentManager cm)
        {
            missileTexture = cm.Load<Texture2D>("Missile Sprite Sheet");
            missileFrame = new Rectangle(0, 0, 4, 8);
        }
        public void Draw(SpriteBatch sb)
        {
            if (IsActive)
            {
                sb.Draw(missileTexture, Position, missileFrame, Color.White);
            }
        }

        public void Update(GameTime gt)
        {
            if (IsActive)
            {
                Position.Y -= missileSpeed;

                // Reset if off-screen
                if (Position.Y < 0)
                {
                    IsActive = false;
                    Position = new Vector2(-1, -1); // Off-screen
                }
            }
        }

        public void Launch(Vector2 startPosition)
        {
            if (!IsActive)
            {
                Position = startPosition;
                IsActive = true;
            }
        }
    }
}
