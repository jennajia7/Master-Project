using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalk : PhysicsObject
{
    [Header ("Properties")]
    [SerializeField] private LayerMask layerMask; //What can the Walker actually touch?
    public float attentionRange;
    public float changeDirectionEase = 1; //How slowly should we change directions? A higher number is slower!
    [System.NonSerialized] public float direction = 1;
    private Vector2 distanceFromPlayer; //How far is this enemy from the player?
    [System.NonSerialized] public float directionSmooth = 1; //The float value that lerps to the direction integer.
    [SerializeField] private bool followPlayer;
    [SerializeField] private bool flipWhenTurning = false; //Should the graphic flip along localScale.x?
    public float maxSpeed = 7;
    [SerializeField] private float maxSpeedDeviation; //How much should we randomly deviate from maxSpeed? Ensures enemies don't move at exact same speed, thus syncing up.
    [SerializeField] private bool neverStopFollowing = false; //Once the player is seen by an enemy, it will forever follow the player.
    private Vector3 origScale;

    void Start()
    {
        origScale = transform.localScale;
        // rayCastSizeOrig = rayCastSize;
        maxSpeed -= Random.Range(0, maxSpeedDeviation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
