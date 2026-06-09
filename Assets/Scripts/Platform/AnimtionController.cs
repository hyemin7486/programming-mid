using UnityEngine;
using KinematicCharacterController;
using KinematicCharacterController.Examples;

public class AnimtionController : MonoBehaviour
{
    public ExampleCharacterController character;

    public Animator animator;

    [SerializeField] private float animationSmoothTime = 0.1f;
    private float _animationBlend;

    private void Update()
    {
        Vector3 characterVelocity = character.Motor.Velocity;

        if (character.Motor.AttachedRigidbody != null)
        {
            characterVelocity -= character.Motor.AttachedRigidbody.linearVelocity;
        }

        float speed = new Vector3(
            characterVelocity.x,
            0f,
            characterVelocity.z
        ).magnitude;

        float maxSpeed = 5.335f;
        float normalizedSpeed = Mathf.Clamp01(speed / maxSpeed);

        _animationBlend = Mathf.Lerp(
            _animationBlend,
            normalizedSpeed,
            Time.deltaTime / animationSmoothTime
        );

        animator.SetFloat("Speed", _animationBlend);

        // Ãß°¡
        bool grounded = character.Motor.GroundingStatus.IsStableOnGround;
        animator.SetBool("Grounded", grounded);

        float verticalSpeed = character.Motor.Velocity.y;
        bool freeFall = !grounded && verticalSpeed < -2f;

        animator.SetBool("FreeFall", freeFall);
    }
}