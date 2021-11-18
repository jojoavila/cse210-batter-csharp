using System;
namespace cse210_batter_csharp.Casting
{
    public class Ball : Actor
    {
        public Ball()
        {
            SetWidth(Constants.BALL_WIDTH);
            SetHeight(Constants.BALL_HEIGHT);
            SetImage(Constants.IMAGE_BALL);
            

            int x = Constants.BALL_X;
            int y = Constants.BALL_Y;
            Point _position = new Point(x,y);
            SetPosition(_position);

            SetVelocity(new Point(5,-5));

        }

        public void BounceVertical()
        {
            int dx = _velocity.GetX();
            int dy = _velocity.GetY();

            _velocity = new Point(dx,-dy);
        }
        public void BounceHorizontal()
        {
            int dx = _velocity.GetX();
            int dy = _velocity.GetY();

            _velocity = new Point(-dx,dy);
        }
    }
}