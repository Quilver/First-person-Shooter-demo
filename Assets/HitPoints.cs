using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    [SerializeField]
    int hitPoints = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="Player")
        {
            Debug.Log("Has taken damage");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
