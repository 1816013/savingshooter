﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            gameObject.GetComponent<PlayerStatas>().AddPlayerEnergy(50);
            other.gameObject.SetActive(false);
        }
    }
}
