using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EggCollector : MonoBehaviour
{
    BasketStorage storage;
    EggSpawner spawner;


    // Start is called before the first frame update
    void Start()
    {
        storage= GetComponentInParent<BasketStorage>();
        spawner= FindAnyObjectByType<EggSpawner>();

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Egg"))
        {
            GameManager.Instance.AddScore(1);
            storage.AddEgg();
            spawner.EggCollected();
            Destroy(other.gameObject);
        }
    }
}
