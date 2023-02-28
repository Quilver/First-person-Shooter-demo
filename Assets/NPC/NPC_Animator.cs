using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC_Animator : MonoBehaviour
{
    Transform player;
    [SerializeField]
    private List<Sprite> sprites = new List<Sprite>();
    [SerializeField]
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerMovement.player;
    }

    // Update is called once per frame
    void Update()
    {
        facingPlayer();
        selectAnimationDirection();
    }
    private void facingPlayer()
    {
        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
    }
    void selectAnimationDirection()
    {
        if (sprites.Count == 0) return;
        float angle = getAngle();
        int index = GetFacing(getAngle());
        //Debug.Log(index + " of " + sprites.Count);
        var sprite = sprites[index];
        renderer.sprite=sprite;
        if(index > 4) renderer.flipX = false;
        else renderer.flipX = true;
        if(index ==2 || index == 6) renderer.flipX = !renderer.flipX;
    }
    int GetFacing(float angle)
    {
        //front
        if (angle > -22.5 && angle <= 22.5) return 0;
        if (angle > -67.5 && angle <= -22.5) return 1;
        if (angle > -112.5 && angle <= -67.5) return 2;
        if (angle > -157.5 && angle <= -112.5) return 3;
        if (angle > 112.5 && angle <= 157.5) return 5;
        if (angle > 67.5 && angle <= 112.5) return 6;
        if (angle > 22.5 && angle <= 67.5) return 7;
        else return 4;
    }
    float getAngle()
    {
        Vector3 targetDirection = player.position - transform.parent.position;
        float angle = Vector3.SignedAngle(targetDirection, transform.parent.forward, Vector3.up);
        return angle;
    }
}
