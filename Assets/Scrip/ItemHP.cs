using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHP : MonoBehaviour
{
    [SerializeField]int hp = 50;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.Instance.OnBuffHP();
            Player.Instance.Healing(hp);
            Destroy(gameObject);
        }
    }
}
