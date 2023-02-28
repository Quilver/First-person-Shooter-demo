using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AI : MonoBehaviour
{
    Transform player;
    [SerializeField]
    float speed;
    [SerializeField]
    float attackFrequency;
    [SerializeField]
    GameObject fireball;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerMovement.player;
        InvokeRepeating("MakeAttack", 2, attackFrequency);
        InvokeRepeating("MoveToPlayer", 1, 5);
    }
    Vector3 target;
    // Update is called once per frame
    void Update()
    {
        var lookPos = target - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);

        transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
    }
    
    void MoveToPlayer(){
        target=player.position;
        target.y=transform.position.y;
    }
    void MakeAttack()
    {
        var f = Instantiate(fireball, transform.position + transform.forward*0.2f, Quaternion.identity);
        f.GetComponent<FireBall>().direction= transform.forward;
    }
}
