﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2DRPG_OOM_system;
using Microsoft.Xna.Framework;


public class DarkMage : Enemy
{
    public DarkMage(int hp, int atk, int shld, int iPosX, int iPosY) 
    {
        _healthSystem.health = hp;
        _healthSystem.power = atk;
        _healthSystem.shield = shld;
        _healthSystem.life = 1;
        tilemap_PosX = iPosX;
        tilemap_PosY = iPosY;
        _healthSystem.setMaxHP(hp);
        _healthSystem.setMaxShield(shld);
        _healthSystem.isStunned = false;
        active = true;
        turn = true;
        ismyTurn = false;
        _healthSystem.status = "Normal";
        cropPositionX = 3;
        cropPositionY = 9;
        AColor = Color.White;
        shot = false; 
    }

    private int mvX;
    private int mvY;
    private bool shot;
    public Projectile miasmaFire = null; 

    public override void TurnUpdate(GameTime gameTime)
    {


        if (turn && !hasMoved)
        {
            // Checks if the enemy is still alive
            if (active && !_healthSystem.isStunned && !shot)
            {
                ismyTurn = true; 
                AColor = Color.White;
                mvX = 0;
                mvY = 0; 

                // this checks for the player position, based on that this will tell if the dark mage should go right or left
                if (Game1.characters[0].tilemap_PosX - tilemap_PosX > 0)
                    mvX = 1;
                else if (Game1.characters[0].tilemap_PosX - tilemap_PosX < 0)
                    mvX = -1;
                else
                {
                    if (Game1.characters[0].tilemap_PosY - tilemap_PosY > 0) 
                    {
                        // to the dark mage to shot, check if he hasn't shot already in the current turn and if there is no miasma ball already 
                        if (!shot && miasmaFire == null)
                        {
                            miasmaFire = new FireBall(new Vector2(tilemap_PosX, tilemap_PosY + 1), new Vector2(0, 1), Color.Purple);
                            mvX = 0;
                            mvY = 0;
                            shot = true; 
                        }
                        
                    }
                    else if(Game1.characters[0].tilemap_PosY - tilemap_PosY < 0) 
                    {
                        // to the dark mage to shot, check if he hasn't shot already in the current turn and if there is no miasma ball already 
                        if (!shot && miasmaFire == null )
                        {
                            miasmaFire = new FireBall(new Vector2(tilemap_PosX, tilemap_PosY - 1), new Vector2(0, -1), Color.Purple);
                            mvX = 0;
                            mvY = 0;
                            shot = true;
                        }
                    }
                }
                    

                // this checks for the player position, based on that this will tell if the Dark mage should go up or down
                if (Game1.characters[0].tilemap_PosY - tilemap_PosY > 0)
                    mvY = 1;
                else if (Game1.characters[0].tilemap_PosY - tilemap_PosY < 0)
                    mvY = -1;
                else 
                {
                    // if the Dark mage is in the same Y as the player, check if the player is right or left. Based on that will determine
                    // the direction of the miasma ball
                    if(Game1.characters[0].tilemap_PosX - tilemap_PosX > 0) 
                    {
                        // to the dark mage to shot, check if he hasn't shot already in the current turn and if there is no miasma ball already 
                        if (!shot && miasmaFire == null)                                          
                        {                            
                            miasmaFire = new FireBall(new Vector2(tilemap_PosX + 1, tilemap_PosY), new Vector2(1, 0), Color.Purple);
                            mvX = 0;
                            mvY = 0;
                            shot = true;
                        }
                    }
                    else if(Game1.characters[0].tilemap_PosX - tilemap_PosX < 0) 
                    {
                        // to the dark mage to shot, check if he hasn't shot already in the current turn and if there is no miasma ball already 
                        if (!shot && miasmaFire == null)
                        {
                            miasmaFire = new FireBall(new Vector2(tilemap_PosX - 1, tilemap_PosY), new Vector2(-1, 0), Color.Purple);
                            mvX = 0;
                            mvX = 0;
                            shot = true;
                        }
                    }
                }
                   

                // This disable the Dark Mage for moving diagonally 
                if (Math.Abs(mvX) == 1 && Math.Abs(mvY) == 1) 
                {
                    // Check if is going to collide with a wall in each direaction
                    if (checkingForCollision(Game1.tileMap, '#', this, mvX, 0) || checkingForCollision(Game1.tileMap, '$', this, mvX, 0))
                    {
                        mvX = 0;
                    }
                    else if (checkingForCollision(Game1.tileMap, '#', this, 0, mvY) || checkingForCollision(Game1.tileMap, '$', this, 0, mvY))
                    {
                        mvY = 0;
                    }
                    else 
                    {
                        mvX = 0; 
                    }
                }
                                                 

                if(checkingForCollision(Game1.tileMap, '#', this, mvX, mvY) || checkingForCollision(Game1.tileMap, '$', this, mvX, mvY)) 
                {
                    mvX = 0;
                    mvY = 0; 
                }

                if(!(mvX == 0 && mvY == 0) && !shot)
                {
                    Movement(mvX, mvY);
                    FinishTurn();
                }               
                
                
            }
            else if (_healthSystem.isStunned)
            {
                //When the enemy is stunned, enemy's turn is skipped and make the enemy unstunned
                AColor = Color.Yellow;
                _healthSystem.makeUnstunned();
                FinishTurn();

            }

            if (shot) 
            {
                if (miasmaFire.hit) 
                {
                    shot = false;
                    miasmaFire = null; 
                    FinishTurn(); 
                }
            }
            
        }

        if (waitingPhase)
        {
            waitingTurnToFinish(1f, gameTime);
        }

        

    }

}

