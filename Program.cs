﻿using System;
using cse210_batter_csharp.Services;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Scripting;
using System.Collections.Generic;

namespace cse210_batter_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // Bricks
            cast["bricks"] = new List<Actor>();

            // Adding the bricks here
            for (int i = 25; i < 750; i+=70)
            {
                for (int e = 10; e < 230; e+=40)
                {
                    Brick brick = new Brick();
                    brick.SetPosition(new Point(i,e));
                    cast["bricks"].Add(brick);
                }
            }
                           
            // The Ball (or balls if desired)
            cast["balls"] = new List<Actor>();

            // Adding the ball here
            Ball ball = new Ball();
            cast["balls"].Add(ball);

            // The paddle
            cast["paddle"] = new List<Actor>();

            // Adding the paddle here
            Paddle paddle = new Paddle();
            cast["paddle"].Add(paddle);

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            // Movement of the ball
            MoveActorsAction moveActorsAction = new MoveActorsAction();
            script["update"].Add(moveActorsAction);

            // Bouncing with the ceiling and walls
            HandleOffScreenAction handleOffScreenAction = new HandleOffScreenAction(physicsService);
            script["update"].Add(handleOffScreenAction);

            // Colliding with the bricks
            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction(physicsService);
            script["update"].Add(handleCollisionsAction);

            // Controling the paddle
            ControlActorsAction controlActorsAction = new ControlActorsAction(inputService);
            script["input"].Add(controlActorsAction);

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Batter", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();
            

            audioService.StopAudio();            

        }
    }
}
