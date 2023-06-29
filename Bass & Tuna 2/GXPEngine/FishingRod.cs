using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GXPEngine;

public class FishingRod : AnimationSprite    
{
        Sound tickingSound;
        SoundChannel channel;

    int counter = 0;
    int frame = 0;

    bool soundStarted = false;
    bool soundPlayed = false;
    public FishingRod() : base("FishingRod.png", 7, 6) 
    {
        tickingSound = new Sound("ClockTicking.wav",false,false);
        
        x = 300;
    }
        
    void Update() 
    {
        counter++;

        if (counter > 10) // animation
        {
              counter = 0;
                frame++;
             if (frame == frameCount - 3)
             {
                    frame = 5;
 
             }
        }

            SetFrame(frame);

        MyGame myGame = (MyGame)game;
        if (myGame.GetTickSound() == true && soundStarted ==false) 
        {
            soundStarted = true;
            channel = tickingSound.Play();
            soundPlayed = true;
        }

        if(myGame.GetTickSound() == false && soundStarted == true) 
        {
            channel.Stop();
            
        }

    }

    public void DeleteRod() 
    {
        if (soundPlayed)
        {
            Console.Write("da");
            channel.Stop();
           // channel.IsPaused = true;
           
        }
        Destroy();
    }
}

