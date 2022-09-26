using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Player")
        {
            Destroy(gameObject);
            ScoreManager.instance.ChangeScore(1);
        }
    }
}
