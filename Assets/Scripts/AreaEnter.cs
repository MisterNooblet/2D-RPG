using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnter : MonoBehaviour
{
    [SerializeField] string pointOfAppearance;
    // Start is called before the first frame update
    void Start()
    {
        if (pointOfAppearance == Player.instance.pointOfAppearance)
        {
            Player.instance.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
