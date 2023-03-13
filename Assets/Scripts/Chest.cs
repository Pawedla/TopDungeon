using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectible
{

    public Sprite emtpyChest;
    public int pesosAmount = 5;
    protected override void OnCollect()
    {
        if(!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emtpyChest;
            GameManager.instance.ShowText("+"+pesosAmount + " pesos!", 25, Color.yellow, transform.position, Vector3.up*50, 3.0f);

        }
    }
}
