using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateAnimations : MonoBehaviour
{
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _anim.SetTrigger("Death");
        }
    
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _anim.SetBool("AIM", true);
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _anim.SetBool("AIM", false);
        }
    }
}
