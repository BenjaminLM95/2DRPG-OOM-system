﻿using _2DRPG_OOM_system;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


public class Item
{
    public string name { get; set; }
    public string description { get; set; }

    public bool isPickUp;

    public bool isUsed;

    public int cropPosX;
    public int cropPosY;

    public Vector2 itemPosition; 
    public virtual void itemEffect() 
    {

    }

    public void DrawItem(SpriteBatch _spriteBatch) 
    {
        _spriteBatch.Draw(Game1.mapTexture, new Rectangle((int)itemPosition.X * Game1.tileSize * 2, ((int)itemPosition.Y + 5) * Game1.tileSize * 2, Game1.tileSize * 2, Game1.tileSize * 2), new Rectangle(cropPosX * Game1.tileSize, cropPosY * Game1.tileSize, Game1.tileSize, Game1.tileSize), Color.White); 
    }

}

