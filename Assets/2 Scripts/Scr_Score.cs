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

    private void Start()
    {
        CalculateScore();
    }

    public float CalculateScore()
    {
        Scr_Trap[] traps = FindObjectsOfType<Scr_Trap>();

        int trapsGood = 0;
        foreach (var trap in traps)
        {
            if (trap.armed) trapsGood++;
        }

        float trapScore = traps.Length - trapsGood;
        Mathf.Clamp(trapScore, 0, 1);

        return 0;

    }
    
    
    
    
}
