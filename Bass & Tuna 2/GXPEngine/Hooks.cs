using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Hooks : AnimationSprite
{
    int currentHooks;
    public Hooks() : base("hooks.png",2,2) 
    {
        scale = 0.3f;
        x = 10;

        MyGame myGame = (MyGame)game;
        currentHooks = myGame.GetHooks();
        checkHook();
    }

    void Update() 
    {
        MyGame myGame = (MyGame)game;
        if (currentHooks != myGame.GetHooks()) 
        {
            currentHooks = myGame.GetHooks();
            checkHook();
            
        }
    }
    void checkHook() 
    {
        if (currentHooks == 3)
        {
            SetFrame(0);
        }
        if (currentHooks == 2)
        {
            SetFrame(1);
        }
        if (currentHooks == 1)
        {
            SetFrame(2);
        }
    }
}

