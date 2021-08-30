using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangePlanets : MonoBehaviour
{
    public ArrangeTest[] planetCarts;

    
    public void StartArrage()
    {
        foreach(ArrangeTest objects in planetCarts)
        {
            objects.Testbutton();
        }
    }
    public void StartInitPos()
    {
        foreach (ArrangeTest objects in planetCarts)
        {
            objects.SetInitialPos();
        }
    }
}
