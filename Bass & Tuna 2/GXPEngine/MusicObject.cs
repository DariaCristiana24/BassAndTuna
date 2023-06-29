using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;


public class MusicObject : AnimationSprite
{
   // public int pos = Utils.Random(1, 5);
    public int pos = Utils.Random(1,6);
    public MusicObject() : base("Arrows.png", 2,3) 
    {
        //scale = 2;
        //SetFrame(pos);
        if(pos == 1) 
        {
            SetFrame(3);
            //SetFrame(4);
        }
        if(pos == 2) 
        {
            SetFrame(2);
            //SetFrame(2);
        }
        if(pos == 3)    
        {
            SetFrame(4);
            //SetFrame(0);
        }
        if(pos == 4)    
        {
            SetFrame(0);
            //SetFrame(1);
        }
        if(pos == 5) 
        {
            SetFrame(1);
            //SetFrame(5);
        }
        x = pos * 100 + 100;
        //Console.WriteLine(pos + "pos x" + x);
    }
    
    public void Movement() 
    {
        y += 100;
    }
}
