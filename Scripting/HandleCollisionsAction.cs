using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp.Scripting
{
    public class HandleCollisionsAction : Action
    
    {
        PhysicsService _physicsService = new PhysicsService();
        AudioService _audioService = new AudioService();
        public HandleCollisionsAction(PhysicsService physicsService)
        {
            _physicsService = physicsService;
        }   
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> ballList = cast["balls"];
            List<Actor> bricksList = cast["bricks"];
            Actor paddle = cast["paddle"][0];
            List<Actor> toRemove = new List<Actor>();
            foreach (Actor actor in ballList)
            {
                Ball ball = (Ball)actor;
                int x = ball.GetX();
                int y = ball.GetY();
                int x_paddle = paddle.GetX();
                int y_paddle = paddle.GetY();
                
                if (_physicsService.IsCollision(paddle, ball))
                {
                    ball.BounceVertical();
                    _audioService.PlaySound(Constants.SOUND_BOUNCE);
                }

                foreach (Actor brick in bricksList)
                {
                    if(_physicsService.IsCollision(ball, brick))
                    {
                        Ball b = (Ball)ball;
                        b.BounceVertical();
                        _audioService.PlaySound(Constants.SOUND_BOUNCE);
                        toRemove.Add(brick);
                        
                    }
                    
                }
                // BrickCleanUp();

                // void BrickCleanUp()
                // {
                foreach (Brick brick in toRemove)
                {
                    bricksList.Remove(brick);   
                }

                toRemove.Clear();
                //}
            }
        }
    }
}