using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp.Scripting
{
    public class HandleOffScreenAction : Action
    {
        PhysicsService _physicsService = new PhysicsService();
        AudioService audioService = new AudioService();
        OutputService outputService = new OutputService();
        
        public HandleOffScreenAction(PhysicsService physicsService)
        {
            _physicsService = physicsService;
        }        
        
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> ballList = cast["balls"];
            Actor paddle = cast["paddle"][0];
            List<Actor> ballToRemove = new List<Actor>();

            
            foreach (Actor actor in ballList)
            {
                Ball ball = (Ball)actor;
                int x = ball.GetX();
                int y = ball.GetY();
                if (x <= 0 || x >= 780)
                {
                    ball.BounceHorizontal();
                    audioService.PlaySound(Constants.SOUND_BOUNCE);
                }
                if (y <= 0)
                {
                    ball.BounceVertical();
                    audioService.PlaySound(Constants.SOUND_BOUNCE);
                }
                foreach (Actor remobableBall in ballList)
                {
                    if (y > 650)
                    {
                        Ball b = (Ball)ball;
                        b.BounceVertical();
                        audioService.PlaySound(Constants.SOUND_OVER);
                        ballToRemove.Add(remobableBall);
                    }
                }
                               
            }
            foreach (Ball ball in ballToRemove)
            {
                ballList.Remove(ball);
                //finishGame();   
            }

            ballToRemove.Clear();
            
            
            void finishGame()
            {
                Environment.Exit(0);
            }
        }
    }
}