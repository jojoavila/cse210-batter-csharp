using System;
namespace cse210_batter_csharp.Casting
{
    public class Paddle : Actor
    {
        public Paddle()
        {
            SetWidth(Constants.PADDLE_WIDTH);
            SetHeight(Constants.PADDLE_HEIGHT);
            SetImage(Constants.IMAGE_PADDLE);
            

            int x = Constants.PADDLE_X;
            int y = Constants.PADDLE_Y;
            Point _position = new Point(x,y);
            SetPosition(_position);

            SetVelocity(new Point(5,0));

        }
    }
}