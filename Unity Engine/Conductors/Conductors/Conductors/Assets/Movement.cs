using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOne : MonoBehaviour
{   
    public GameObject otherCube; //holds a reference to the Squaresome (the second cube on the level)
    private float movementAmount = 2.31f; //the amount of pixels a cube will move on the x,y axis.
	private static int rows = 3;
	private static int columns = 5;

    [SerializeField] private string newLevel = "Level2";

	private Tile[,] board = new Tile[rows,columns];
	
	class Tile {
		private bool left = true;
		private bool right = true;
		private bool up = true;
		private bool down = true;

        private bool openCircuit = false;
		
		private bool isSquaresomeOn = false;
		private bool isCubyOn = false;

		public Tile(bool up, bool right, bool down,bool left, bool openCircuit,bool isCubyOn, bool isSquaresomeOn) {
			this.up = up;
			this.right = right;
            this.down = down;
            this.left = left;
            this.openCircuit = openCircuit;

            this.isCubyOn = isCubyOn;
            this.isSquaresomeOn = isSquaresomeOn;

		}
        /*public void setTile(bool up, bool right, bool down, bool left, bool openCircuit) {
            this.up = up;
            this.right = right;
            this.down = down;
            this.left = left;
            this.openCircuit = openCircuit;
        }*/

        public bool isUpAvailable(){
            return up;
        }

        public bool isRightAvailable(){
            return right;
        }

        public bool isDownAvailable(){
            return down;
        }

        public bool isLeftAvailable(){
            return left;
        }

        public bool isOpenCircuit(){
            return openCircuit;
        }

        public void setIsSquaresomeOn(bool isSquaresomeOn){
            this.isSquaresomeOn = isSquaresomeOn;
        }

        public bool getIsSquaresomeOn(){
            return isSquaresomeOn;
        }

        public void setIsCubyOn(bool isCubyOn){
            this.isCubyOn = isCubyOn;
        }
        public bool getIsCubyOn(){
            return isCubyOn;
        }

	}//end Tile Class

    void Start() {
        initializeBoard();
    }

    void Update() {
        CubesMovement();
        isLevelComplete();
    }//end Update()

    void initializeBoard(){
        board[0,0] = new Tile(false,true,true,false,false,true,false);
        board[0,1] = new Tile(false,false,true,true,false,false,false);
        board[0,2] = new Tile(false,false,false,false,false,false,false);
        board[0,3] = new Tile(false,true,true,false,false,false,false);
        board[0,4] = new Tile(false,false,true,true,true,false,false);
        board[1,0] = new Tile(true,true,true,false,false,false,false);
        board[1,1] = new Tile(true,true,true,true,false,false,false);
        board[1,2] = new Tile(false,true,true,true,false,false,false);
        board[1,3] = new Tile(true,true,false,true,false,false,false);
        board[1,4] = new Tile(true,false,false,true,false,false,false);
        board[2,0] = new Tile(true,true,false,false,false,false,true);
        board[2,1] = new Tile(true,true,false,true,false,false,false);
        board[2,2] = new Tile(true,true,false,true,false,false,false);
        board[2,3] = new Tile(false,true,false,true,false,false,false);
        board[2,4] = new Tile(false,false,false,true,true,false,false);
    }//end initializeBoard() 

    void CubesMovement(){
        int i, j = 0;

        if (Input.GetKeyDown("down")){
            
            //Cuby's DOWN Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    if(board[i,j].getIsCubyOn() && board[i,j].isDownAvailable()){
                        
                        //check if the other cube is NOT located next to you
                        if(!board[i+1,j].getIsSquaresomeOn()){
                            transform.Translate (0,-movementAmount,0);

                            //update character position in the 2D array
                            board[i,j].setIsCubyOn(false);
                            board[i+1,j].setIsCubyOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        }
                        /*if the other cube is located next to you, check if it can move to upwards
                          so that you can as well.*/
                        else{                    
                            if(board[i+1,j].isDownAvailable()){
                                transform.Translate (0,-movementAmount,0);

                                //update character position in the 2D array
                                board[i,j].setIsCubyOn(false);
                                board[i+1,j].setIsCubyOn(true);

                                //stop inner and outter loop from executing
                                i = rows;
                                j = columns;
                            }    
                        } 
                    }    
                }
            }

            //Squaresome's DOWN Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    if(board[i,j].getIsSquaresomeOn() && board[i,j].isDownAvailable()){

                        //check if the other cube is NOT located next to you
                        if(!board[i+1,j].getIsCubyOn()){
                            otherCube.transform.Translate (0,-movementAmount,0);

                            //update character position in the 2D array
                            board[i,j].setIsSquaresomeOn(false);
                            board[i+1,j].setIsSquaresomeOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        }
                        /*if the other cube is located next to you, check if it can move to upwards
                          so that you can as well.*/
                        else {
                            if(board[i+1,j].isDownAvailable()){
                                otherCube.transform.Translate (0,-movementAmount,0);

                                //update character position in the 2D array
                                board[i,j].setIsSquaresomeOn(false);
                                board[i+1,j].setIsSquaresomeOn(true);

                                //stop inner and outter loop from executing
                                i = rows;
                                j = columns;
                            }
                        }
                    }   
                }
            }
        }//end DOWN

        if (Input.GetKeyDown("up")){

            //Cuby's UP Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    if(board[i,j].getIsCubyOn() && board[i,j].isUpAvailable()){
                        
                        //check if the other cube is NOT located next to you
                        if(!board[i-1,j].getIsSquaresomeOn()){
                            transform.Translate (0,movementAmount,0);

                            //update character position in the 2D array
                            board[i,j].setIsCubyOn(false);
                            board[i-1,j].setIsCubyOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        }
                        /*if the other cube is located next to you, check if it can move to upwards
                          so that you can as well.*/
                        else {
                            if(board[i-1,j].isUpAvailable()){
                                transform.Translate (0,movementAmount,0);

                                //update character position in the 2D array
                                board[i,j].setIsCubyOn(false);
                                board[i-1,j].setIsCubyOn(true);

                                //stop inner and outter loop from executing
                                i = rows;
                                j = columns;
                            }
                        }
                    }   
                }
            }

            //Squaresome's UP Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    if(board[i,j].getIsSquaresomeOn() && board[i,j].isUpAvailable()){
          
                        //check if the other cube is NOT located next to you
                        if(!board[i-1,j].getIsCubyOn()){
                            otherCube.transform.Translate (0,movementAmount,0);

                            //update character position in the 2D array
                            board[i,j].setIsSquaresomeOn(false);
                            board[i-1,j].setIsSquaresomeOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        }
                        /*if the other cube is located next to you, check if it can move to upwards
                          so that you can as well.*/
                        else {
                            if(board[i-1,j].isUpAvailable()){
                                otherCube.transform.Translate (0,movementAmount,0);

                                //update character position in the 2D array
                                board[i,j].setIsSquaresomeOn(false);
                                board[i-1,j].setIsSquaresomeOn(true);

                                //stop inner and outter loop from executing
                                i = rows;
                                j = columns;
                            }
                        }
                    }
                }
            }
        }//end UP

        if (Input.GetKeyDown("left")){

            //Cuby's Left Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    if(board[i,j].getIsCubyOn() && board[i,j].isLeftAvailable()){

                        //check if the other cube is NOT located next to you
                        if(!board[i,j-1].getIsSquaresomeOn()){
                            transform.Translate (-movementAmount,0,0);

                            //update character position in the 2D array
                            board[i,j].setIsCubyOn(false);
                            board[i,j-1].setIsCubyOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        }
                        /*if the other cube is located next to you, check if it can move to the left
                          so that you can as well.*/
                        else {
                            if(board[i,j-1].isLeftAvailable()){
                                transform.Translate (-movementAmount,0,0);

                                //update character position in the 2D array
                                board[i,j].setIsCubyOn(false);
                                board[i,j-1].setIsCubyOn(true);

                                //stop inner and outter loop from executing
                                i = rows;
                                j = columns;
                            }
                        } 
                    }
                }
            }

            //Squaresome's Left Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    if(board[i,j].getIsSquaresomeOn() && board[i,j].isLeftAvailable()){

                        //check if the other cube is NOT located next to you
                        if(!board[i,j-1].getIsCubyOn()){
                            otherCube.transform.Translate (-movementAmount,0,0);

                            //update character position in the 2D array
                            board[i,j].setIsSquaresomeOn(false);
                            board[i,j-1].setIsSquaresomeOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        }
                        /*if the other cube is located next to you, check if it can move to the left
                          so that you can as well.*/
                        else {
                            if(board[i,j-1].isLeftAvailable()){

                                otherCube.transform.Translate (-movementAmount,0,0);

                                //update character position in the 2D array
                                board[i,j].setIsSquaresomeOn(false);
                                board[i,j-1].setIsSquaresomeOn(true);

                                //stop inner and outter loop from executing
                                i = rows;
                                j = columns;
                            }    
                        }    
                    }   
                }
            }
        }//end LEFT 

        if (Input.GetKeyDown("right")){
            
            //Cuby's Right Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    if(board[i,j].getIsCubyOn() && board[i,j].isRightAvailable()){
                        
                        //check if the other cube is NOT located next to you
                        if(!board[i,j+1].getIsSquaresomeOn()){
                            transform.Translate (movementAmount,0,0);

                            //update character position in the 2D array
                            board[i,j].setIsCubyOn(false);
                            board[i,j+1].setIsCubyOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        }
                        /*if the other cube is located next to you, check if it can move to the right
                          so that you can as well.*/
                        else {
                            if(board[i,j+1].isRightAvailable()){
                                transform.Translate (movementAmount,0,0);

                                //update character position in the 2D array
                                board[i,j].setIsCubyOn(false);
                                board[i,j+1].setIsCubyOn(true);

                                //stop inner and outter loop from executing
                                i = rows;
                                j = columns;
                            }
                        }  
                    }  
                }
            }

            //Squaresome's Right Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    if(board[i,j].getIsSquaresomeOn() && board[i,j].isRightAvailable()){
                        //otherCube.transform.Translate (movementAmount,0,0);

                        //check if the other cube is NOT located next to you
                        if(!board[i,j+1].getIsCubyOn()){
                            otherCube.transform.Translate (movementAmount,0,0);

                            //update character position in the 2D array
                            board[i,j].setIsSquaresomeOn(false);
                            board[i,j+1].setIsSquaresomeOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        }
                        /*if the other cube is located next to you, check if it can move to the right
                          so that you can as well.*/
                        else {
                            if(board[i,j+1].isRightAvailable()){
                                otherCube.transform.Translate (movementAmount,0,0);

                                //update character position in the 2D array
                                board[i,j].setIsSquaresomeOn(false);
                                board[i,j+1].setIsSquaresomeOn(true);

                                //stop inner and outter loop from executing
                                i = rows;
                                j = columns;
                            }                  
                        }
                    }   
                }
            }
        }//end RIGHT

    }//end CubesMovement()

    void isLevelComplete(){
        
        //checks if Cube OR Squaresome are located in either one of the open circuit locations. 
        if((board[0,4].getIsCubyOn() || board[0,4].getIsSquaresomeOn()) && (board[2,4].getIsCubyOn() || board[2,4].getIsSquaresomeOn()) ){
            SceneManager.LoadScene(newLevel);
        }
    }//end isLevelComplete
	
}//end class LevelOne
