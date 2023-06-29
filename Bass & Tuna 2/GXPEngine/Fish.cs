using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
internal class Fish : AnimationSprite
{
    Sound trashSound;
    Sound commonSound;
    Sound uncommonSound;
    Sound rareSound;
    Sound luckySound;

    int counter = 0;
    int frame = 0;
    int percentage = 0;
    int chance;
    int score;
    int fish = 0;
    int maxFrame;
    int fishChance;
    int startTime;
    bool animationDone = false;
    bool animating = false;
    bool timerStart;

    public Fish() : base("Fish6.png", 24 , 15) 
    {
        trashSound = new Sound("trashRarityShort.wav", false, false);
        commonSound = new Sound("commonRarityShort.wav", false, false);
        uncommonSound = new Sound("uncommonRarityShort.wav", false, false);
        rareSound = new Sound("rareRarityShort.wav", false, false);
        luckySound = new Sound("luckyRarityShort.wav", false, false);




        x = 900; //fish6
        //x = 800;
        scale = 1.7f; //fish6
        //scale = 1.1f;

        MyGame myGame = (MyGame)game;
        percentage = myGame.GetPercent();
        chance = Utils.Random(1, 101);
        fishChance = Utils.Random(1, 4);

        typesOfFish();
    } 
    void Update() 
    {
        FishAnimator();
    }

    void typesOfFish() 
    {
        //setframe, 

        if (percentage == 0)
        {
            //lose hook
            if (Utils.Random(1, 3) == 1)
            {
                fish = 0;
            }
            else 
            {
                fish = 1;
            }
        }
        if (percentage >= 1 && percentage <= 24)
        {
            //90- trash, 10% small fish
            if (chance > 10)
            {
                //trash
                fish = 1;
            }
            else
            {
                //small
                fish = 2;
            }
        }
        if (percentage >= 25 && percentage <= 49)
        {
            //80-small fish, 17 - medium, 3 -large
            if (chance <= 3)
            {
                //large
                fish = 4;
            }
            else
            {
                if (chance <= 20)
                {
                    //medium
                    fish = 3;
                }
                else
                {
                    //small
                    fish = 2;
                }
            }
        }
        if (percentage >= 50 && percentage <= 74)
        {
            //5- small, 75 - medium, 20 - large 
            if (chance <= 5)
            {
                //small
                fish = 2;
            }
            else
            {
                if (chance <= 25)
                {
                    //large
                    fish = 4;
                }
                else
                {
                    //medium
                    fish = 3;
                }
            }
        }
        if (percentage >= 75 && percentage <= 99)
        {
            //15 - medium, 85 - large
            if (chance > 15)
            {
                //large
                fish = 4;
            }
            else
            {
                //medium
                fish = 3;
            }
        }
        if (percentage == 100)
        {
            //lucky fish
            fish = 5;
        }
        fishScore();
    }


    //trash - 1, small - 2, medium - 3 , big -4 , lucky 5;

    void fishScore() 
    {
        if(fish == 1) 
        {
            score = 250; //LOST HOOK

        }
        if(fish == 2)
        {
            score = 500; 
        }
        if (fish == 3)
        {
            score = 1000;
        }
        if (fish == 4)
        {
            score = 2000;
        }
        if (fish == 5)
        {
            score = 2500;
        }
    }

    void FishAnimator() 
    {
        //fish = 5;
        if (animating == false)
        {
            if (fish == 0) 
            {
                trashSound.Play();
                frame = _cols * 12;
                maxFrame = _cols * 13 - 1;
            }
            if (fish == 1)
            {
                trashSound.Play();
                if (fishChance == 1)
                {
                    frame = 0;
                    maxFrame = _cols * 1 - 1;
                }
                if (fishChance == 2)
                {
                    frame = _cols ;
                    maxFrame = _cols * 2 - 1;
                }
                if(fishChance == 3) 
                {
                    frame = _cols * 13 ;
                    maxFrame = _cols * 14 + 2;
                }
            }
            if (fish == 2) 
            {
                commonSound.Play();
                if (fishChance == 1)
                {
                    frame = _cols *2;
                    maxFrame = _cols * 3 - 1;
                }
                if (fishChance == 2)
                {
                    frame = _cols * 3;
                    maxFrame = _cols * 4 - 1;
                }
                if (fishChance == 3)
                {
                    frame = _cols * 4;
                    maxFrame = _cols * 5 -1 ;
                }
            }
            if (fish == 3) 
            {
                uncommonSound.Play();
                if (fishChance == 1)
                {
                    frame = _cols * 5;
                    maxFrame = _cols * 6 - 1;
                }
                if (fishChance == 2)
                {
                    frame = _cols * 6;
                    maxFrame = _cols * 7 - 1;
                }
                if (fishChance == 3)
                {
                    frame = _cols * 7;
                    maxFrame = _cols * 8 - 1;
                }
            }
            if (fish == 4) 
            {
                rareSound.Play();
                if (fishChance == 1)
                {
                    frame = _cols * 8;
                    maxFrame = _cols * 9 - 1;
                }
                if (fishChance == 2)
                {
                    frame = _cols * 9;
                    maxFrame = _cols * 10 - 1;
                }
                if (fishChance == 3)
                {
                    frame = _cols * 10;
                    maxFrame = _cols * 11 - 1;
                }
            }
            if (fish == 5) 
            {
                luckySound.Play();
                frame = _cols * 11;
                maxFrame = _cols * 12 - 1;

            }
            //animating = true;
            timerStart = true;
        }

        if (timerStart) 
        {
            startTime = Time.time;
            animating = true;
            timerStart = false;
        }

        if( animating && animationDone == false && Time.time- startTime > 2500) 
        {
            counter++;

            if (counter > 10) // animation
            {
                counter = 0;
                frame++;
                if (frame == maxFrame)
                {
                    animationDone = true;
                }
            }

            SetFrame(frame);
        }
        
    }
    public bool AnimationDone() 
    {
        return animationDone;
    }
    public int GetFishScore() 
    { 
        return score;
    }

    public int GetFish() 
    {
        return fish;
    }
}
