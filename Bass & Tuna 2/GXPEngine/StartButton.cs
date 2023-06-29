using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class StartButton : Sprite
{
    Sound startMusic;
    SoundChannel channel;
    public StartButton() : base("StartButton.png") 
    {
        startMusic = new Sound("MenuMusic.wav",true,false);
        channel = startMusic.Play();
        //x = game.width / 2 - 200;
        //y = game.height / 2 - 100;
    }
    public void deleteStartButton() 
    {
        channel.Stop();
        Destroy();
    }
}

