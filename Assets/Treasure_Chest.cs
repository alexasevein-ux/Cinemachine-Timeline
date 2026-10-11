using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Treasure_Chest : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private GameObject _item;
    [SerializeField] private GameObject _spawnLocation;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _director.Play();
            Invoke("InstantiateSword", 0.5f);
        }
    }

    private void InstantiateSword()
    {
        Instantiate(_item, _spawnLocation.transform.position, Quaternion.identity);
    }
}