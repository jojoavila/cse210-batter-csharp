using System;
namespace cse210_batter_csharp.Casting
{
    public class Brick : Actor
    {
        /// <summary>
        /// Set the bricks.
        /// </summary>
        public Brick()
        {
            SetWidth(Constants.BRICK_WIDTH);
            SetHeight(Constants.BRICK_HEIGHT);
            SetImage(Constants.IMAGE_BRICK);
        }
    }
}