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
        if (collision.gameObject.GetComponent<Attack>()!=null)
        {
            Attack attack = collision.gameObject.GetComponent<Attack>();
            hitPoints -= attack.OnHit();
            Debug.Log("Has taken damage, current hp: "+hitPoints);
            if (hitPoints <= 0)
                Destroy(gameObject.transform.parent.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
