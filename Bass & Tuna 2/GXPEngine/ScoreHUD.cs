using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GXPEngine
{
    internal class ScoreHUD : EasyDraw
    {
        int score;
        public ScoreHUD() : base(400, 50)
        {
            TextFont(new Font("OCR A Extended", 30, FontStyle.Regular));
            TextAlign(CenterMode.Min, CenterMode.Min);
            Fill(255, 255, 255);
            MyGame myGame = (MyGame)game;
            Text("Score: " +  myGame.GetScore(), 0, 0); // the score is visible when the game starts
            score = myGame.GetScore();


        }
        void Update()  //this gets called only when the level updates
        {
            MyGame myGame = (MyGame)game;
            if (score != myGame.GetScore()) 
            {
                Clear(0, 0, 0, 0);
                Text("Score: " + myGame.GetScore(), 0, 0);
                score = myGame.GetScore();
            }


        }


    }
}
