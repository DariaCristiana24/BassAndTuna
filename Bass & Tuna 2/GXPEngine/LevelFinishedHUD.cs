using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GXPEngine
{
    public class LevelFinishedHUD : EasyDraw
    {

        public LevelFinishedHUD(bool gameOver) : base(700, 650)
        {
            //Clear(100, 100, 100, 200);
            TextFont(new Font("OCR A Extended", 30, FontStyle.Regular));
            TextAlign(CenterMode.Min, CenterMode.Min);
            
             MyGame myGame = (MyGame)game;
            if (gameOver )
            {
                Fill(255, 30, 30);
               // Fill(206, 48, 91);
                //Fill(206, 48, 91);
                Text(" GAME OVER!");
            }
            else
            {
               // Fill(204, 204, 0);
                Fill(250, 204, 87);
                Text(" Level Finished");

            }
            // Fill(255, 255, 255);
            //Fill(220,220,220);
            Fill(255,252,223);
            Text(" Score: " + myGame.GetScore(), 0, 50);
            Text(" Percentage: " + myGame.GetPercent() + "%", 0, 100);
            Text(" Extra Time: " + myGame.GetExtraTime(), 0, 200);
            Text(" Extra Tiles: " + myGame.GetTilesLeft(), 0, 150);


            Text(" Trash: " + myGame.GetTrash() /*+ "   Common: " + myGame.GetSmallFish()*/, 0, 340);
            Text(" Common: " + myGame.GetSmallFish(), 0, 380);
            Text(" Uncommon: " + myGame.GetMediumFish(), 0, 420);
            Text(" Rare: " + myGame.GetBigFish() /*+ "   Lucky: " + myGame.GetLuckyFish()*/, 0, 460);
            Text(" Lucky: " + myGame.GetLuckyFish(), 0, 500);

            TextFont(new Font("OCR A Extended", 20, FontStyle.Regular));
            Text(" Fish caught: ", 0, 300);

            TextFont(new Font("OCR A Extended", 13, FontStyle.Regular));
            Fill(180, 180, 180);

            Text(" Extra time is added to the percentage.", 0, 250);
            //Text(" Time running out result in no fish being caught.", 0, 570);

            //if (gameOver == false)
            //{
                Fill(255, 255, 150);
                TextFont(new Font("OCR A Extended", 20, FontStyle.Regular));
                Text("Press the reel to continue", 0, 580);
            //}





        }
    }
}
