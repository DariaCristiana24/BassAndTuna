using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
public class Background : AnimationSprite
{
    Sound gameMusic;
    SoundChannel channel;
    public Background() : base("BG-Ropes1.png", 5, 4) 
    {
        scale = 1.45f;
        gameMusic = new Sound("FishSound60.wav",true,false);
        channel = gameMusic.Play();
    }

    void Update() 
    {
        Animate(0.025f);
    }

    public void DeleteBG() 
    {
        channel.Stop();
        Destroy();
    }
}

