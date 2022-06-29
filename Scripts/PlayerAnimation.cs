
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    public UltimateJoystick joystick;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float horizontalMove = UltimateJoystick.GetHorizontalAxis("Movement");
        float verticalMove = UltimateJoystick.GetVerticalAxis("Movement");

        if (horizontalMove > .1f || horizontalMove < -.1f)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if (verticalMove >= .5f)
        {
            anim.SetTrigger("Jump");
        }
    }
}
