using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using UnityEngine.Networking;

public class ZombieMovementAI : NetworkBehaviour
{
    #pragma warning disable IDE0044 // Add readonly modifier
    [SerializeField, Range(0.01f, 0.05f)] private float movementSmoothing = 0.05f;
    #pragma warning restore IDE0044 // Add readonly modifier
    //Which layer the rigidbody can collide with.
    [SerializeField] private LayerMask collisionObjectsLayer;
    //The velocity for the rigidbody.
    [SerializeField] private int movementSpeed;

    private Rigidbody2D _rigidbody2D;
    private Vector3 velocityForRef = Vector3.zero;
    private const float radius = 0.2f;
    private bool movingAround;

    // Use this for initialization
    void Start()
    {

        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Instantiate a Random class in order to generate a random number.
        Random random = new Random();
        //Checks if the rigidbody of the model is colliding with a specific layer.
        if (!_rigidbody2D.IsTouchingLayers(collisionObjectsLayer))
        {
            //If the body is not colliding it continues to move down.
            //Creates a new vector with the target movement velocity, vector is three-dimensional in order to apply smoothing.
            Vector3 targetVelocity = new Vector2(0f, -movementSpeed * 0.10f);
            //The created vector is applied to the rigidbody along with smoothing.
            _rigidbody2D.velocity = Vector3.SmoothDamp(_rigidbody2D.velocity, targetVelocity, ref velocityForRef, movementSmoothing);
            Debug.Log(String.Format("{0} moving down.", gameObject.name));
            //Sets the "moving around objects" boolean to false.
            movingAround = false;
        }

        else if (_rigidbody2D.IsTouchingLayers(collisionObjectsLayer))
        {
            //Checks to see if the rigidbody is already moving around an obstacle
            if (!movingAround)
            {
                //If not, a new vector is created, three dimensional in order to apply smoothing later.
                Vector3 targetVelocity;

                //A random direction between left and right is chosen from the previously instantiated Random class.
                //The if check equates the result to 0 in the range of 0 and 1.
                if (random.Next(0, 2) == 0)
                {
                    //If the randomly generated number is 0, then the rigidbody's velocity is directed right.
                    targetVelocity = new Vector2(movementSpeed * 0.10f, 0);
                    //The velocity is applied with smoothing.
                    _rigidbody2D.velocity = Vector3.SmoothDamp(_rigidbody2D.velocity, targetVelocity, ref velocityForRef, movementSmoothing);
                    Debug.Log(String.Format("{0} moving right.", gameObject.name));
                    //Moving around boolean is set to true to avoid repeated left right movement when colliding with an obstacle.
                    movingAround = true;
                    //Flip method to ensure body is facing correct direction.
                    Flip(false);
                }
                else if (random.Next(0, 2) == 1)
                {
                    //If the randomly generated number is 1, then the rigidbody's velocity is directed left.
                    targetVelocity = new Vector2(-movementSpeed * 0.10f, 0);
                    //The velocity is applied with smoothing.
                    _rigidbody2D.velocity = Vector3.SmoothDamp(_rigidbody2D.velocity, targetVelocity, ref velocityForRef, movementSmoothing);
                    Debug.Log(String.Format("{0} moving left.", gameObject.name));
                    //Moving around boolean is set to true to avoid repeated left right movement when colliding with an obstacle.
                    movingAround = true;
                    //Flip method to ensure body is facing correct direction.
                    Flip(true);
                }

                
            }
        }

    }

    private void Flip(bool direction)
    {
        //Stores the current local scale of the transform.
        Vector3 tempLocalScaleStore = transform.localScale;

        //Checks the current orientation of the model and flips it accordingly.
        if(direction)
        {
            tempLocalScaleStore.x = -1;
        }
        //
        else if (!direction)
        {
            tempLocalScaleStore.x = 1;
        }
        //Applies the inverted axis to the game object local scale.
        transform.localScale = tempLocalScaleStore;
    }
}
