using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GXPEngine
{
    internal class PercentageHUD : EasyDraw
    {
        int score;
        public PercentageHUD() : base(110, 50)
        {
            TextFont(new Font("OCR A Extended", 30, FontStyle.Regular));
            TextAlign(CenterMode.Min, CenterMode.Min);
            Fill(255, 255, 255);
            MyGame myGame = (MyGame)game;
            Text(myGame.GetPercent() + "%", 0, 0); // the percantage is visible when the game starts
            score = myGame.GetPercent();

        }
        void Update()  //this gets called only when the level updates
        {
            MyGame myGame = (MyGame)game;
            if (score != myGame.GetPercent())
            {
                Clear(0, 0, 0, 0);
                Text(myGame.GetPercent() + "%", 0, 0);
                score = myGame.GetPercent();
            }

        }
    }
}
