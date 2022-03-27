using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalk : PhysicsObject
{
    [Header ("Reference")]
    [SerializeField] private GameObject graphic;

    [Header ("Properties")]
    [SerializeField] private LayerMask layerMask; //What can the Walker actually touch?
    public enum NPCMode {follow, stand};
    public NPCMode mode = NPCMode.follow;
    public float attentionRange;
    public float changeDirectionEase = 1; //How slowly should we change directions? A higher number is slower!
    [System.NonSerialized] public float direction = 1;
    private Vector2 distanceFromPlayer; //How far is this enemy from the player?
    [System.NonSerialized] public float directionSmooth = 1; //The float value that lerps to the direction integer.
    [SerializeField] public bool followPlayer;
    [SerializeField] private bool flipWhenTurning = false; //Should the graphic flip along localScale.x?
    private RaycastHit2D ground;
    public float maxSpeed = 7;
    [System.NonSerialized] public float launch = 1; //The float added to x and y moveSpeed. This is set with hurtLaunchPower, and is always brought back to zero
    [SerializeField] private float maxSpeedDeviation; //How much should we randomly deviate from maxSpeed? Ensures enemies don't move at exact same speed, thus syncing up.
    [SerializeField] private bool neverStopFollowing = false; //Once the player is seen by an enemy, it will forever follow the player.
    private Vector3 origScale;
    [SerializeField] private bool sitStillWhenNotFollowing = false; //Controls the sitStillMultiplier
    private float sitStillMultiplier = 1; //If 1, the enemy will move normally. But, if it is set to 0, the enemy will stop completely. 
    public bool frozen = false;

    void Start()
    {
        graphic = this.gameObject;
        origScale = transform.localScale;
        // rayCastSizeOrig = rayCastSize;
        maxSpeed -= Random.Range(0, maxSpeedDeviation);
        StartCoroutine(FreezeEffect(2.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!frozen)
        {
            ComputeVelocity();
        }
    }

    public IEnumerator FreezeEffect(float length)
    {
        frozen = true;
        yield return new WaitForSeconds(length);
        frozen = false;
    }

    void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        if (mode ==NPCMode.follow)
        {
            distanceFromPlayer = new Vector2 (NewPlayer.Instance.gameObject.transform.position.x - transform.position.x, NewPlayer.Instance.gameObject.transform.position.y - transform.position.y);
            directionSmooth += ((direction * sitStillMultiplier) - directionSmooth) * Time.deltaTime * changeDirectionEase;
            move.x = (1 * directionSmooth) + launch;
            launch += (0 - launch) * Time.deltaTime;
            
            if (move.x < 0)
            {
                transform.localScale = new Vector3(-origScale.x, origScale.y, origScale.z);
            }
            else
            {
                transform.localScale = new Vector3(origScale.x, origScale.y, origScale.z);
            }

            //Flip the graphic depending on the speed
            if (move.x > 0.01f)
            {
                if (graphic.transform.localScale.x == -1)
                {
                    graphic.transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                }
            }
            else if (move.x < -0.01f)
            {
                if (graphic.transform.localScale.x == 1)
                {
                    graphic.transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                }
            }

            //Check floor type
            ground = Physics2D.Raycast(transform.position, -Vector2.up);
            Debug.DrawRay(transform.position, -Vector2.up, Color.green);

            if (sitStillWhenNotFollowing)
            {
                sitStillMultiplier = 0;
            }
            else
            {
                sitStillMultiplier = 1;
            }

            if (followPlayer)
            {
                if (distanceFromPlayer.x < -1)
                {
                    direction = -1;
                }
                else if (distanceFromPlayer.x > 1)
                {
                    direction = 1;
                }
                else
                {
                    move.x = 0;
                }
            }
        }

        targetVelocity = move * maxSpeed;
    }


}
