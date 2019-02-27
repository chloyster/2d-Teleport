using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gabiTestAdjust : MonoBehaviour
{
    public void AddHealth()
    {
        GameController.control.health += 10;
    }
}
