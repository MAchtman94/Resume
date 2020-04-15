using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubyMovement : MonoBehaviour
{
    private float movementAmount = 2.32f; //the amount of pixels a cube will move on the x,y axis.
    
	private static int rows = 3;
	private static int columns = 5;

	private Tile[,] board = new Tile[rows,columns];
	
	
	class Tile {
		private bool left = true;
		private bool right = true;
		private bool up = true;
		private bool down = true;

        private bool openCircuit = false;
		
		private bool isSquaresomeOn = false;
		private bool isCubyOn = false;

		Tile(bool left, bool right, bool up,bool down, bool openCircuit,bool isSquaresomeOn, bool isCubyOn) {
			this.left = left;
			this.right = right;
			this.up = up;
            this.down = down;

            this.openCircuit = openCircuit;

            this.isSquaresomeOn = isSquaresomeOn;
            this.isCubyOn = isCubyOn;
		}
	}//end Tile Class

    void Update() {

        if (Input.GetKeyDown("down")){
            transform.Translate (0,-movementAmount,0);
        }

        if (Input.GetKeyDown("up")){
            transform.Translate (0,movementAmount,0);
        }

        if (Input.GetKeyDown("left")){
            transform.Translate (-movementAmount,0,0);
        }

        if (Input.GetKeyDown("right")){
            transform.Translate(movementAmount,0,0);
        }

    }//end Update()




	
	
	/********* You were using this before trying the 2D array approach **************
	public float moveSpeed = 5f;
	
	public Rigidbody2D rb;
	
	Vector2 movement;
	
   // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
    }
	
	void FixedUpdate() 
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
		
	}

    /********************************************************************************** 
 



/*     private float moveSpeed = 6f;
    private float gridSize = 2.3f;
    private enum Orientation {
       Horizontal,
       Vertical
    };
    private Orientation gridOrientation = Orientation.Horizontal;
    private bool allowDiagonals = false;
    private bool correctDiagonalSpeed = true;
    private Vector2 input;
    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float t;
    private float factor;
 
    public void Update() {
        if (!isMoving) {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (!allowDiagonals) {
                if (Mathf.Abs(input.x) > Mathf.Abs(input.y)) {
                    input.y = 0;
               } else {
                   input.x = 0;
               }
            }

            if (input != Vector2.zero) {
                StartCoroutine(move(transform));
           }
        }
   }

    public IEnumerator move(Transform transform) {
      isMoving = true;
       startPosition = transform.position;
      t = 0;

       if(gridOrientation == Orientation.Horizontal) {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
        } else {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
       }

        if(allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0) {
            factor = 0.7071f;
        } else {
            factor = 1f;
        }
 
        while (t < 1f) {
            t += Time.deltaTime * (moveSpeed/gridSize) * factor;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
       }
 
        isMoving = false;
        yield return 0;
    } */





/* 	public Transform startPos, endPos;
    public bool repeatable = false;
    public float speed = 1.0f;
    public float duration = 3.0f;

    float startTime, totalDistance;

	// Use this for initialization
	IEnumerator Start () {
        startTime = Time.time;
        totalDistance = Vector3.Distance(startPos.position, endPos.position);
        while(repeatable) {
            yield return RepeatLerp(startPos.position, endPos.position, duration);
            yield return RepeatLerp(endPos.position, startPos.position, duration);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(!repeatable) {
            float currentDuration = (Time.time - startTime) * speed;
            float journeyFraction = currentDuration / totalDistance;
            this.transform.position = Vector3.Lerp(startPos.position, endPos.position, journeyFraction);
        }
	}

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time) {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f) {
            i += Time.deltaTime * rate;
            this.transform.position = Vector3.Lerp(a, b, i);
            yield return null;
        }
    } */
	
}
