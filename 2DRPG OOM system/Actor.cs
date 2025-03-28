﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;



public class Actor 
{
    // This is the X position of the actor
    private int Tilemap_PosX;    
   
    public int tilemap_PosX 
    {
        get { return Tilemap_PosX; }
        set { Tilemap_PosX = Math.Max(0, Math.Min(29, value)); }
    }

    // This is the Y position of the actor
    private int Tilemap_PosY;

    public int tilemap_PosY 
    {
        get { return Tilemap_PosY; }
        set { Tilemap_PosY = Math.Max(0, Math.Min(10, value)); }
    }

    public HealthSystem _healthSystem = new HealthSystem();

    // This will check if the actor is alive in the game
    public bool active;

    // This is the actor turn
    public bool turn;
    public float waitingTime = 0;
    public bool hasMoved = false;

    public int cropPositionX;
    public int cropPositionY; 


    // Movement
    public Vector2 moveDir;
    public Vector2 facingDir; 



    // This check if two objects are colliding, is will ask two position (x,y)
    public bool CheckForObjCollision(int Xo, int Yo, int Xt, int Yt) 
    {
        return Xo == Xt && Yo == Yt; 
    }

   // This moves the actor
    public void Movement(int mvX, int mvY)
    {
        tilemap_PosX += mvX;
        tilemap_PosY += mvY;
    }

    // This check for collision, is accesing the tilemap to check if the actor will be in a certain char position
    public bool checkingForCollision(Tilemap _tilemap, char _char, Actor _actor, int x, int y) 
    {
        return _tilemap.MapToChar(_tilemap.multidimensionalMap, _actor.tilemap_PosX + x, _actor.tilemap_PosY + y) == _char;
    }

    // this check if the actor will collide with another actor which will trigger an attack
    public bool enemyCollision(Actor _attacker, Actor _attacked) 
    {
        return _attacker.tilemap_PosX == _attacked.tilemap_PosX && _attacker.tilemap_PosY == _attacked.tilemap_PosY;
    }

    public virtual void TurnUpdate(GameTime gameTime) 
    {

    }

    public virtual void DrawStats(SpriteBatch _spriteBatch, int num, int posY) 
    {
        
    }

}




