using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Score : MonoBehaviour
{
    //Récupère toutes les portes
    //Récupère tous les pièges
    //Récupère tout les taches de sang
    //Récupère tout les coffres
    //Récupère tout les objest cassés
    //Joueur dans la salle du boss

    private int bloodNumber = 0;
    
    private void Start()
    {
        bloodNumber = FindObjectsOfType<Scr_Trap>().Length;
        
       // float score = CalculateScore();
       Debug.Log("Score: "+CalculateScore());

    }

    public float CalculateScore()
    {
        ///----------Trap Score
        Scr_Trap[] traps = FindObjectsOfType<Scr_Trap>();
        int trapsGood = 0;
        foreach (var trap in traps)
        {
            if (trap.armed) trapsGood++;
        }
        float trapScore = traps.Length - trapsGood;
        trapScore /= traps.Length;
        
        ///----------Chest Score
        Scr_Chest[] chests = FindObjectsOfType<Scr_Chest>();
        int chestsGood = 0;
        foreach (var chest in chests)
        {
            if (!chest.closed) chestsGood++;
        }
        float chestScore = chests.Length - chestsGood;
        chestScore /= chests.Length;
        
        ///----------Blood Score
        float bloodScore = bloodNumber - FindObjectsOfType<Scr_Trap>().Length;
        bloodScore /= bloodNumber;
        
        ///----------Broken Score
        Scr_BrokenObject[] furnitures = FindObjectsOfType<Scr_BrokenObject>();
        int furnitureGood = 0;
        foreach (var furniture in furnitures)
        {
            if (!furniture.broken) furnitureGood++;
        }
        float furnitureScore = furnitures.Length - furnitureGood;
        furnitureScore /= furnitures.Length;
        
        ///----------Door Score
        Scr_Door[] doors = FindObjectsOfType<Scr_Door>();
        int doorsGood = 0;
        foreach (var door in doors)
        {
            if (!door.isOpen) doorsGood++;
        }
        float doorScore = doors.Length - doorsGood;
        doorScore /= doors.Length;
        

        return doorScore +furnitureScore + chestScore +trapScore + bloodScore ;

    }
    
    
    
    
}
