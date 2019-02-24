using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveScript : MonoBehaviour
{
    public script Script;
    public float ex;
    // Start is called before the first frame update
    void Start()
    {
        script = GetComponent(Script);
        Script.enable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
