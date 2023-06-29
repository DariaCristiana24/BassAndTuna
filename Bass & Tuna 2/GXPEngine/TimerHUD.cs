using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GXPEngine
{
    internal class TimerHUD : EasyDraw
    {
        private int seconds;
        public TimerHUD() : base(300, 50)
        {
                TextFont(new Font("OCR A Extended", 30, FontStyle.Regular));
                TextAlign(CenterMode.Min, CenterMode.Min);
                Fill(255, 255, 255);
                MyGame myGame = (MyGame)game;
                Text("Time: " + myGame.GetSeconds() , 0, 0); // the timer is visible when the game starts
                seconds = myGame.GetSeconds();
                //Console.WriteLine(seconds);
            }
            void Update()  //this gets called only when the level updates
            {
                MyGame myGame = (MyGame)game;
                if (seconds != myGame.GetSeconds())
                {
                    Clear(0, 0, 0, 0);
                    Text("Time: " + myGame.GetSeconds(), 0, 0);
                    seconds = myGame.GetSeconds();
                }

            }
        } 
    }

