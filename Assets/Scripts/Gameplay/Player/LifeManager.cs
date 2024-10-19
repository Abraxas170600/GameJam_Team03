using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    private int lifes = 2;
    public LifeUI lifeUI;

    public void UpdateLife(bool state)
    {
        if(lifes >= 0)
        {
            lifeUI.UpdateLife(lifes, state);
            lifes--;
        }
        
    } 

}