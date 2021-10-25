using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOnenable : MonoBehaviour
{
    public GameObject character;

    private void OnEnable()
    {
        character.SetActive(true);
    }
    private void OnDisable()
    {
        character.SetActive(false);
    }
}
