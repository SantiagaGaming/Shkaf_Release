using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testanim : MonoBehaviour
{
    public Button btnVent1;
    public Button btnVent2;
    
    public GameObject vent01;

    public void button1Click()
    {

        Animator test1 = vent01.GetComponent<Animator>();
        
        /*
        foreach (AnimationState anim11 in test1)
        {
            Debug.Log(anim11.name);
        }
        */
        
        //test1.

        Debug.Log(test1);
        
        test1.Play("vent01_rotate");

        //vent01.GetComponent<Animation>().
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
