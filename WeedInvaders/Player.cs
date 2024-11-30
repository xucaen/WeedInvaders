using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace WeedInvaders
{
    internal class Player
    {
        Texture2D playerTexture;
        Rectangle playerFrame;
        float playerSpeed = 1;

        Missile m;
        private bool FIRED = false;
        private Vector2 vector2;

        public Vector2 Position;

        public Player(Vector2 vector2)
        {
            this.Position = vector2;
        }

        public void LoadContent(ContentManager cm)
        {
            playerTexture = cm.Load<Texture2D>("Plant Sprite Sheet");
            playerFrame = new Rectangle(0, 0, 32, 32);
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(playerTexture, Position, playerFrame, Color.White);
        }

        public void Update(GameTime gt) 
        {
            //Player Update
            //check controls
            KeyboardState kbs = Keyboard.GetState();
            if( kbs.IsKeyDown(Keys.Left) || kbs.IsKeyDown(Keys.A) ) 
            {   
                this.Position.X -= playerSpeed;
                playerFrame.X = 0;
            }
            else if (kbs.IsKeyDown(Keys.Right) || kbs.IsKeyDown(Keys.D))
            {
                Position.X += playerSpeed;
                playerFrame.X = 32;
            }

            if(Position.X < 0)
                Position.X = 224;
            else if(Position.X > 224)
                Position.X = 0;

        }

    }
}
