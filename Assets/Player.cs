using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    
    public float speed = 6;
    
    // Use this for initialization
    void Start()
    {
                
    }
    
    // Update is called once per frame
    void Update()
    {
        rigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Animator>().SetTrigger("JUMP");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            GetComponent<Animator>().SetTrigger("SLIDE");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        var stateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
                
        if (TakesDamage(stateInfo, collider))
        {
            GetComponent<Animator>().SetTrigger("DAMAGED");
            speed = 0;
        }
    }

    private bool TakesDamage(AnimatorStateInfo state, Collider collider)
    {
        bool collidesHigh = collider.CompareTag("High");
        bool collidesLow = collider.CompareTag("Low");

        bool isRun = state.IsName("Base Layer.RUN00_F");
        bool isJump = state.IsName("Base Layer.JUMP00");
        bool isSlide = state.IsName("Base Layer.SLIDE00");

        if (isRun && (collidesHigh || collidesLow))
        {
            return true;
        }

        if (isJump && collidesHigh)
        {
            return true;
        }

        if (isSlide && collidesLow)
        {
            return true;
        }

        return false;

    }

}
