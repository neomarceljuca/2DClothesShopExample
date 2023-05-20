using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public CustomAnimator baseCharacterAnimator;
    public CustomAnimator[] clothesAnimators;
    private AnimationState currentAnimationState;
    [SerializeField] float frameRate = 16f; // Frames per second
    private float timer = 0f;
    private int currentIndex = 0;



    // Dictionary that has Enum PlayerDirection as keys, and returns which frames should play for that direction
    private Dictionary<AnimationState, int[]> directionFrames = new Dictionary<AnimationState, int[]>();
    private void Awake()
    {  
        //Assign respective frames for each direction and state; They are the same for every spritesheet.
        directionFrames.Add(AnimationState.IdleUp, new int[] { 0 });
        directionFrames.Add(AnimationState.IdleLeft, new int[] { 9 });
        directionFrames.Add(AnimationState.IdleDown, new int[] { 18 });
        directionFrames.Add(AnimationState.IdleRight, new int[] { 27 });
        directionFrames.Add(AnimationState.MoveUp, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        directionFrames.Add(AnimationState.MoveLeft, new int[] { 10, 11, 12, 13, 14, 15, 16, 17 });
        directionFrames.Add(AnimationState.MoveDown, new int[] { 19, 20, 21, 22, 23, 24, 25, 26 });
        directionFrames.Add(AnimationState.MoveRight, new int[] { 28, 29, 30, 31, 32, 33, 34, 35 });
    }

    public void Update()
    {
        HandleAnimations();
    }

    public void HandleAnimations() 
    {
        //TO DO: Set each current equipment animation according to currentAnimationState. Already works for player base animation

        // Calculate the time interval for each frame
        float frameInterval = 1f / frameRate;

        // Update the timer
        timer += Time.deltaTime;

        // Check if it's time to change the sprite
        if (timer >= frameInterval)
        {
            // Reset the timer
            timer = 0f;

            // Set the sprite based on the current frame index + safety check
            if (currentIndex < directionFrames[currentAnimationState].Length)
                baseCharacterAnimator.SetSpriteByFrame(directionFrames[currentAnimationState][currentIndex]);

            currentIndex++;

            // Check if we reached the end of the frame list
            if (currentIndex >= directionFrames[currentAnimationState].Length)
            {
                // Reset the frame index
                currentIndex = 0;
            }
        }

    }


    /// <summary>
    /// determine which animation is supposed to play according to input player movement, storing the result on currentAnimationState
    /// </summary>
    /// <param name="movement"></param>
    public void SetAnimationState(Vector2 movement) 
    {
        if(movement == Vector2.zero) 
        {
            //assign idle position based on the last moving direction
            if (currentAnimationState == AnimationState.MoveUp) currentAnimationState = AnimationState.IdleUp;
            else if (currentAnimationState == AnimationState.MoveDown) currentAnimationState = AnimationState.IdleDown;
            else if (currentAnimationState == AnimationState.MoveRight) currentAnimationState = AnimationState.IdleRight;
            else if (currentAnimationState == AnimationState.MoveLeft) currentAnimationState = AnimationState.IdleLeft;
            else currentAnimationState = AnimationState.IdleDown; //default case
        }
        else //reproduce blend tree behavior when character is on movement
        {
            //Calculate the absolute values of x and y
            float absX = Mathf.Abs(movement.x);
            float absY = Mathf.Abs(movement.y);

            // Check which direction has the largest absolute value
            if (absX > absY)
            {
                //left or right based on the sign of x
                if (movement.x < 0)
                    currentAnimationState = AnimationState.MoveLeft;
                else
                    currentAnimationState = AnimationState.MoveRight;
            }
            else
            {
                //up or down based on the sign of y
                if (movement.y < 0)
                    currentAnimationState = AnimationState.MoveDown;
                else
                    currentAnimationState = AnimationState.MoveUp;
            }
        }
    }
}

public enum AnimationState
{
    IdleUp,IdleDown,IdleLeft,IdleRight,
    MoveUp,MoveDown,MoveLeft,MoveRight
}
