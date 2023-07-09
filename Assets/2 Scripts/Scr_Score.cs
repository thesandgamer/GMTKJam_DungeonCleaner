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

    public float score = 0;

    [SerializeField] private Scr_Timer Timer;
    
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        bloodNumber = FindObjectsOfType<Scr_Dirt>().Length;


        // float score = CalculateScore();
        // Debug.Log("Score: "+CalculateScore());

    }

    public void CalculateScore()
    {
        Debug.Log("SCORE CALCULATING");
        //---Boss in final room
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
        float bloodScore = 1;
        int numberOfBlood = FindObjectsOfType<Scr_Dirt>().Length;
        if (numberOfBlood == 0)
        {
            bloodScore = 0;
        }
        bloodScore = bloodNumber / numberOfBlood;
        //bloodScore /= bloodNumber;
        
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


        float maxScore = 5;

        float currenScore = maxScore - (doorScore + furnitureScore + chestScore + trapScore + bloodScore);

        score = currenScore;

    }


    private void OnEnable()
    {
        Timer.timerFinished += CalculateScore;
    }
}
