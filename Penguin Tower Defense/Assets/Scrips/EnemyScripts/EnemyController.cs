using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public void DealDamage()                                                                //Deals damage to the player, and checks if EndGame should be called
    {
        int damageAmount;
        damageAmount = gameObject.GetComponent<EnemyModel>().enemyStats.Dmg;                //Gets the Damage variable in EnemyModel
        if (PlayerStats.PlayerLives < damageAmount)                                         //Prevents getting negative health
        {
            PlayerStats.PlayerLives = 0;
        }
        else
        {
            PlayerStats.PlayerLives = PlayerStats.PlayerLives - damageAmount;               //Otherwise, deals the amount of damage in EnemyModel.Damage
        }
        Debug.Log("PlayerLives is now: " + PlayerStats.PlayerLives);
        if (PlayerStats.PlayerLives == 0)
        {
            FindObjectOfType<LevelLoader>().LoadSelectedLevel(3); //Game over
            //GameOver gameOver = FindObjectOfType<GameOver>();                               //Finds the GameOver class in GameMaster
            //gameOver.EndGame();                                                             //Calls the "EndGame" function, ending the game (not yet)
        }
    }
}
