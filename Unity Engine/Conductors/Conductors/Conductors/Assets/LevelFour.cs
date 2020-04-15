using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFour : MonoBehaviour
{
    public GameObject squaresome;  //holds a reference to the Squaresome (the second cube on the level)
    public GameObject rectahelper; //holds a reference to the Rectahelper (the third cube on the level)
    public GameObject nervangle;   //holds a reference to the Nervangle (the forth cube on the level)

    private float movementAmount = 1.35f; //the amount of pixels a cube will move on the x,y axis.
	private static int rows = 7;
	private static int columns = 7;

    [SerializeField] private string endScreen = "Endscreen";

	private Tile[,] board = new Tile[rows,columns];
	
	class Tile {
		private bool left = true;
		private bool right = true;
		private bool up = true;
		private bool down = true;

        private bool openCircuit = false;
		
		private bool isSquaresomeOn = false;
		private bool isCubyOn = false;
        private bool isRectahelperOn = false;
        private bool isNervangleOn = false;

		public Tile(bool up, bool right, bool down,bool left, bool openCircuit,bool isCubyOn, bool isSquaresomeOn, bool isRectahelperOn, bool isNervangleOn) {
			this.up = up;
			this.right = right;
            this.down = down;
            this.left = left;

            this.openCircuit = openCircuit;

            this.isCubyOn = isCubyOn;
            this.isSquaresomeOn = isSquaresomeOn;
            this.isRectahelperOn = isRectahelperOn;
            this.isNervangleOn = isNervangleOn;
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

        public void setIsRectahelperOn(bool isRectahelperOn){
            this.isRectahelperOn = isRectahelperOn;
        }
        public bool getIsRectahelperOn(){
            return isRectahelperOn;
        }

        public void setIsNervangleOn(bool isNervangleOn){
            this.isNervangleOn = isNervangleOn;
        }
        public bool getIsNervangleOn(){
            return isNervangleOn;
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
                            //up right down left circuit cuby squaresome rectahelper nervangle
        board[0,0] = new Tile(false,false,false,false,false,false,false,false,false);
        board[0,1] = new Tile(false,false,false,false,false,false,false,false,false);
        board[0,2] = new Tile(false,false,false,false,false,false,false,false,false);
        board[0,3] = new Tile(false,false,true,false,false,true,false,false,false);
        board[0,4] = new Tile(false,false,false,false,false,false,false,false,false);
        board[0,5] = new Tile(false,false,false,false,false,false,false,false,false);
        board[0,6] = new Tile(false,false,false,false,false,false,false,false,false);
        board[1,0] = new Tile(false,false,false,false,false,false,false,false,false);
        board[1,1] = new Tile(false,false,false,false,false,false,false,false,false);
        board[1,2] = new Tile(false,false,false,false,false,false,false,false,false);
        board[1,3] = new Tile(true,false,true,false,false,false,false,false,false);
        board[1,4] = new Tile(false,false,false,false,false,false,false,false,false);
        board[1,5] = new Tile(false,false,false,false,false,false,false,false,false);
        board[1,6] = new Tile(false,false,false,false,false,false,false,false,false);
        board[2,0] = new Tile(false,false,false,false,false,false,false,false,false);
        board[2,1] = new Tile(false,false,false,false,false,false,false,false,false);
        board[2,2] = new Tile(false,true,true,false,false,false,false,false,false);
        board[2,3] = new Tile(true,true,true,true,true,false,false,false,false);
        board[2,4] = new Tile(false,false,true,true,false,false,false,false,false);
        board[2,5] = new Tile(false,false,false,false,false,false,false,false,false);
        board[2,6] = new Tile(false,false,false,false,false,false,false,false,false);
        board[3,0] = new Tile(false,true,false,false,false,false,false,true,false);
        board[3,1] = new Tile(false,true,false,true,false,false,false,false,false);
        board[3,2] = new Tile(true,true,true,true,true,false,false,false,false);
        board[3,3] = new Tile(true,true,true,true,false,false,false,false,false);
        board[3,4] = new Tile(true,true,true,true,true,false,false,false,false);
        board[3,5] = new Tile(false,true,false,true,false,false,false,false,false);
        board[3,6] = new Tile(false,false,false,true,false,false,true,false,false);
        board[4,0] = new Tile(false,false,false,false,false,false,false,false,false);
        board[4,1] = new Tile(false,false,false,false,false,false,false,false,false);
        board[4,2] = new Tile(true,true,false,false,false,false,false,false,false);
        board[4,3] = new Tile(true,true,true,true,true,false,false,false,false);
        board[4,4] = new Tile(true,false,false,true,false,false,false,false,false);
        board[4,5] = new Tile(false,false,false,false,false,false,false,false,false);
        board[4,6] = new Tile(false,false,false,false,false,false,false,false,false);
        board[5,0] = new Tile(false,false,false,false,false,false,false,false,false);
        board[5,1] = new Tile(false,false,false,false,false,false,false,false,false);
        board[5,2] = new Tile(false,false,false,false,false,false,false,false,false);
        board[5,3] = new Tile(true,false,true,false,false,false,false,false,false);
        board[5,4] = new Tile(false,false,false,false,false,false,false,false,false);
        board[5,5] = new Tile(false,false,false,false,false,false,false,false,false);
        board[5,6] = new Tile(false,false,false,false,false,false,false,false,false);
        board[6,0] = new Tile(false,false,false,false,false,false,false,false,false);
        board[6,1] = new Tile(false,false,false,false,false,false,false,false,false);
        board[6,2] = new Tile(false,false,false,false,false,false,false,false,false);
        board[6,3] = new Tile(true,false,false,false,false,false,false,false,true);
        board[6,4] = new Tile(false,false,false,false,false,false,false,false,false);
        board[6,5] = new Tile(false,false,false,false,false,false,false,false,false);
        board[6,6] = new Tile(false,false,false,false,false,false,false,false,false);
    }//end initializeBoard() 

    void CubesMovement(){
        int i, j = 0;
        bool executeMove = false;

        //**************************************************************** DOWN MOVEMENT FOR ALL CUBES ********************************************************************
        if (Input.GetKeyDown("down")){

            //Cuby's DOWN Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsCubyOn() && board[i,j].isDownAvailable()){
                        
                        //check if none of the cubes are below you, if so execute the movement
                        if(!board[i+1,j].getIsSquaresomeOn() && !board[i+1,j].getIsRectahelperOn() && !board[i+1,j].getIsNervangleOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move downwards
                          so that you can as well.*/
                        else{                    
                            if(board[i+1,j].isDownAvailable()){ //checks if there is a tile below the one we're interested in moving to
                                //if there are no cubes one tile below the one we're interested in moving to execute the movement
                                if(!board[i+2,j].getIsSquaresomeOn() && !board[i+2,j].getIsRectahelperOn() && !board[i+2,j].getIsNervangleOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i+2,j].isDownAvailable()){ //checks if there is a tile, two tiles below the one we're interested in moving to
                                        //if there are no cubes two tiles below the one we're interested in moving to execute the movement
                                        if(!board[i+3,j].getIsSquaresomeOn() && !board[i+3,j].getIsRectahelperOn() && !board[i+3,j].getIsNervangleOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            transform.Translate (0,-movementAmount,0);

                            //update character position in the 2D array
                            board[i,j].setIsCubyOn(false);
                            board[i+1,j].setIsCubyOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop 

            //Squaresome's DOWN Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsSquaresomeOn() && board[i,j].isDownAvailable()){
                        
                        //check if none of the cubes are below you, if so execute the movement
                        if(!board[i+1,j].getIsRectahelperOn() && !board[i+1,j].getIsCubyOn() && !board[i+1,j].getIsNervangleOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move downwards
                          so that you can as well.*/
                        else{                    
                            if(board[i+1,j].isDownAvailable()){ //checks if there is a tile below the one we're interested in moving to
                                //if there are no cubes one tile below the one we're interested in moving to execute the movement
                                if(!board[i+2,j].getIsRectahelperOn() && !board[i+2,j].getIsCubyOn() && !board[i+2,j].getIsNervangleOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i+2,j].isDownAvailable()){ //checks if there is a tile, two tiles below the one we're interested in moving to
                                        //if there are no cubes two tiles below the one we're interested in moving to execute the movement
                                        if(!board[i+3,j].getIsRectahelperOn() && !board[i+3,j].getIsCubyOn() && !board[i+3,j].getIsNervangleOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            squaresome.transform.Translate (0,-movementAmount,0);

                            //update character position in the 2D array
                            board[i,j].setIsSquaresomeOn(false);
                            board[i+1,j].setIsSquaresomeOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop
            
            //Rectahelper's DOWN Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsRectahelperOn() && board[i,j].isDownAvailable()){
                        
                        //check if none of the cubes are below you, if so execute the movement
                        if(!board[i+1,j].getIsSquaresomeOn() && !board[i+1,j].getIsCubyOn() && !board[i+1,j].getIsNervangleOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move downwards
                          so that you can as well.*/
                        else{                    
                            if(board[i+1,j].isDownAvailable()){ //checks if there is a tile below the one we're interested in moving to
                                //if there are no cubes one tile below the one we're interested in moving to execute the movement
                                if(!board[i+2,j].getIsSquaresomeOn() && !board[i+2,j].getIsCubyOn() && !board[i+2,j].getIsNervangleOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i+2,j].isDownAvailable()){ //checks if there is a tile, two tiles below the one we're interested in moving to
                                        //if there are no cubes two tiles below the one we're interested in moving to execute the movement
                                        if(!board[i+3,j].getIsSquaresomeOn() && !board[i+3,j].getIsCubyOn() && !board[i+3,j].getIsNervangleOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            rectahelper.transform.Translate (0,-movementAmount,0);

                            //update character position in the 2D array
                            board[i,j].setIsRectahelperOn(false);
                            board[i+1,j].setIsRectahelperOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop
            
        //Nerveangle's DOWN Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsNervangleOn() && board[i,j].isDownAvailable()){
                        
                        //check if none of the cubes are below you, if so execute the movement
                        if(!board[i+1,j].getIsSquaresomeOn() && !board[i+1,j].getIsCubyOn() && !board[i+1,j].getIsRectahelperOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move downwards
                          so that you can as well.*/
                        else{                    
                            if(board[i+1,j].isDownAvailable()){ //checks if there is a tile below the one we're interested in moving to
                                //if there are no cubes one tile below the one we're interested in moving to execute the movement
                                if(!board[i+2,j].getIsSquaresomeOn() && !board[i+2,j].getIsCubyOn() && !board[i+2,j].getIsRectahelperOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i+2,j].isDownAvailable()){ //checks if there is a tile, two tiles below the one we're interested in moving to
                                        //if there are no cubes two tiles below the one we're interested in moving to execute the movement
                                        if(!board[i+3,j].getIsSquaresomeOn() && !board[i+3,j].getIsCubyOn() && !board[i+3,j].getIsRectahelperOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            nervangle.transform.Translate (0,-movementAmount,0);

                            //update character position in the 2D array
                            board[i,j].setIsNervangleOn(false);
                            board[i+1,j].setIsNervangleOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop

        }//**************************************************************** END DOWN MOVEMENT FOR ALL CUBES ********************************************************************



        //**************************************************************** UP MOVEMENT FOR ALL CUBES ********************************************************************
        if (Input.GetKeyDown("up")){

            //Cuby's UP Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsCubyOn() && board[i,j].isUpAvailable()){
                        
                        //check if none of the cubes are above you, if so execute the movement
                        if(!board[i-1,j].getIsSquaresomeOn() && !board[i-1,j].getIsRectahelperOn() && !board[i-1,j].getIsNervangleOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move upwards
                          so that you can as well.*/
                        else{                    
                            if(board[i-1,j].isUpAvailable()){ //checks if there is a tile above the one we're interested in moving to
                                //if there are no cubes one tile above the one we're interested in moving to execute the movement
                                if(!board[i-2,j].getIsSquaresomeOn() && !board[i-2,j].getIsRectahelperOn() && !board[i-2,j].getIsNervangleOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i-2,j].isUpAvailable()){ //checks if there is a tile, two tiles above the one we're interested in moving to
                                        //if there are no cubes, two tiles above the one we're interested in moving to, execute the movement
                                        if(!board[i-3,j].getIsSquaresomeOn() && !board[i-3,j].getIsRectahelperOn() && !board[i-3,j].getIsNervangleOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            transform.Translate (0,movementAmount,0);

                            //update character position in the 2D array
                            board[i,j].setIsCubyOn(false);
                            board[i-1,j].setIsCubyOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop 

            //Squaresome's UP Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsSquaresomeOn() && board[i,j].isUpAvailable()){
                        
                        //check if none of the cubes are above you, if so execute the movement
                        if(!board[i-1,j].getIsCubyOn() && !board[i-1,j].getIsRectahelperOn() && !board[i-1,j].getIsNervangleOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move upwards
                          so that you can as well.*/
                        else{                    
                            if(board[i-1,j].isUpAvailable()){ //checks if there is a tile above the one we're interested in moving to
                                //if there are no cubes one tile above the one we're interested in moving to execute the movement
                                if(!board[i-2,j].getIsCubyOn() && !board[i-2,j].getIsRectahelperOn() && !board[i-2,j].getIsNervangleOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i-2,j].isUpAvailable()){ //checks if there is a tile, two tiles above the one we're interested in moving to
                                        //if there are no cubes, two tiles above the one we're interested in moving to, execute the movement
                                        if(!board[i-3,j].getIsCubyOn() && !board[i-3,j].getIsRectahelperOn() && !board[i-3,j].getIsNervangleOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            squaresome.transform.Translate (0,movementAmount,0);

                            //update character position in the 2D array
                            board[i,j].setIsSquaresomeOn(false);
                            board[i-1,j].setIsSquaresomeOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop

        //Rectahelper's UP Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsRectahelperOn() && board[i,j].isUpAvailable()){
                        
                        //check if none of the cubes are above you, if so execute the movement
                        if(!board[i-1,j].getIsCubyOn() && !board[i-1,j].getIsSquaresomeOn() && !board[i-1,j].getIsNervangleOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move upwards
                          so that you can as well.*/
                        else{                    
                            if(board[i-1,j].isUpAvailable()){ //checks if there is a tile above the one we're interested in moving to
                                //if there are no cubes one tile above the one we're interested in moving to execute the movement
                                if(!board[i-2,j].getIsCubyOn() && !board[i-2,j].getIsSquaresomeOn() && !board[i-2,j].getIsNervangleOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i-2,j].isUpAvailable()){ //checks if there is a tile, two tiles above the one we're interested in moving to
                                        //if there are no cubes, two tiles above the one we're interested in moving to, execute the movement
                                        if(!board[i-3,j].getIsCubyOn() && !board[i-3,j].getIsSquaresomeOn() && !board[i-3,j].getIsNervangleOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            rectahelper.transform.Translate (0,movementAmount,0);

                            //update character position in the 2D array
                            board[i,j].setIsRectahelperOn(false);
                            board[i-1,j].setIsRectahelperOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop

        //Nervangle's UP Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsNervangleOn() && board[i,j].isUpAvailable()){
                        
                        //check if none of the cubes are above you, if so execute the movement
                        if(!board[i-1,j].getIsCubyOn() && !board[i-1,j].getIsSquaresomeOn() && !board[i-1,j].getIsRectahelperOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move upwards
                          so that you can as well.*/
                        else{                    
                            if(board[i-1,j].isUpAvailable()){ //checks if there is a tile above the one we're interested in moving to
                                //if there are no cubes one tile above the one we're interested in moving to execute the movement
                                if(!board[i-2,j].getIsCubyOn() && !board[i-2,j].getIsSquaresomeOn() && !board[i-2,j].getIsRectahelperOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i-2,j].isUpAvailable()){ //checks if there is a tile, two tiles above the one we're interested in moving to
                                        //if there are no cubes, two tiles above the one we're interested in moving to, execute the movement
                                        if(!board[i-3,j].getIsCubyOn() && !board[i-3,j].getIsSquaresomeOn() && !board[i-3,j].getIsRectahelperOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            nervangle.transform.Translate (0,movementAmount,0);

                            //update character position in the 2D array
                            board[i,j].setIsNervangleOn(false);
                            board[i-1,j].setIsNervangleOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop

        }//**************************************************************** END UP MOVEMENT FOR ALL CUBES ********************************************************************


        //**************************************************************** LEFT MOVEMENT FOR ALL CUBES ********************************************************************
        if (Input.GetKeyDown("left")){

            //Cuby's LEFT Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsCubyOn() && board[i,j].isLeftAvailable()){
                        
                        //check if none of the cubes are above you, if so execute the movement
                        if(!board[i,j-1].getIsSquaresomeOn() && !board[i,j-1].getIsRectahelperOn() && !board[i,j-1].getIsNervangleOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move upwards
                          so that you can as well.*/
                        else{                    
                            if(board[i,j-1].isLeftAvailable()){ //checks if there is a tile above the one we're interested in moving to
                                //if there are no cubes one tile above the one we're interested in moving to execute the movement
                                if(!board[i,j-2].getIsSquaresomeOn() && !board[i,j-2].getIsRectahelperOn() && !board[i,j-2].getIsNervangleOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i,j-2].isLeftAvailable()){ //checks if there is a tile, two tiles above the one we're interested in moving to
                                        //if there are no cubes, two tiles above the one we're interested in moving to, execute the movement
                                        if(!board[i,j-3].getIsSquaresomeOn() && !board[i,j-3].getIsRectahelperOn() && !board[i,j-3].getIsNervangleOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            transform.Translate (-movementAmount,0,0);

                            //update character position in the 2D array
                            board[i,j].setIsCubyOn(false);
                            board[i,j-1].setIsCubyOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop 

            //Squaresome's Left Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsSquaresomeOn() && board[i,j].isLeftAvailable()){
                        
                        //check if none of the cubes are above you, if so execute the movement
                        if(!board[i,j-1].getIsCubyOn() && !board[i,j-1].getIsRectahelperOn() && !board[i,j-1].getIsNervangleOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move upwards
                          so that you can as well.*/
                        else{                    
                            if(board[i,j-1].isLeftAvailable()){ //checks if there is a tile above the one we're interested in moving to
                                //if there are no cubes one tile above the one we're interested in moving to execute the movement
                                if(!board[i,j-2].getIsCubyOn() && !board[i,j-2].getIsRectahelperOn() && !board[i,j-2].getIsNervangleOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i,j-2].isLeftAvailable()){ //checks if there is a tile, two tiles above the one we're interested in moving to
                                        //if there are no cubes, two tiles above the one we're interested in moving to, execute the movement
                                        if(!board[i,j-3].getIsCubyOn() && !board[i,j-3].getIsRectahelperOn() && !board[i,j-3].getIsNervangleOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            squaresome.transform.Translate (-movementAmount,0,0);

                            //update character position in the 2D array
                            board[i,j].setIsSquaresomeOn(false);
                            board[i,j-1].setIsSquaresomeOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop

            //Rectahelper's Left Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsRectahelperOn() && board[i,j].isLeftAvailable()){
                        
                        //check if none of the cubes are above you, if so execute the movement
                        if(!board[i,j-1].getIsCubyOn() && !board[i,j-1].getIsSquaresomeOn() && !board[i,j-1].getIsNervangleOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move upwards
                          so that you can as well.*/
                        else{                    
                            if(board[i,j-1].isLeftAvailable()){ //checks if there is a tile above the one we're interested in moving to
                                //if there are no cubes one tile above the one we're interested in moving to execute the movement
                                if(!board[i,j-2].getIsCubyOn() && !board[i,j-2].getIsSquaresomeOn() && !board[i,j-2].getIsNervangleOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i,j-2].isLeftAvailable()){ //checks if there is a tile, two tiles above the one we're interested in moving to
                                        //if there are no cubes, two tiles above the one we're interested in moving to, execute the movement
                                        if(!board[i,j-3].getIsCubyOn() && !board[i,j-3].getIsSquaresomeOn() && !board[i,j-3].getIsNervangleOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            rectahelper.transform.Translate (-movementAmount,0,0);

                            //update character position in the 2D array
                            board[i,j].setIsRectahelperOn(false);
                            board[i,j-1].setIsRectahelperOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop

            //Nervangle's Left Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsNervangleOn() && board[i,j].isLeftAvailable()){
                        
                        //check if none of the cubes are above you, if so execute the movement
                        if(!board[i,j-1].getIsCubyOn() && !board[i,j-1].getIsSquaresomeOn() && !board[i,j-1].getIsRectahelperOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move upwards
                          so that you can as well.*/
                        else{                    
                            if(board[i,j-1].isLeftAvailable()){ //checks if there is a tile above the one we're interested in moving to
                                //if there are no cubes one tile above the one we're interested in moving to execute the movement
                                if(!board[i,j-2].getIsCubyOn() && !board[i,j-2].getIsSquaresomeOn() && !board[i,j-2].getIsRectahelperOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i,j-2].isLeftAvailable()){ //checks if there is a tile, two tiles above the one we're interested in moving to
                                        //if there are no cubes, two tiles above the one we're interested in moving to, execute the movement
                                        if(!board[i,j-3].getIsCubyOn() && !board[i,j-3].getIsSquaresomeOn() && !board[i,j-3].getIsRectahelperOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            nervangle.transform.Translate (-movementAmount,0,0);

                            //update character position in the 2D array
                            board[i,j].setIsNervangleOn(false);
                            board[i,j-1].setIsNervangleOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop

        }//**************************************************************** END LEFT MOVEMENT FOR ALL CUBES ******************************************************************** 


        //**************************************************************** RIGHT MOVEMENT FOR ALL CUBES ********************************************************************
        if (Input.GetKeyDown("right")){
            
            //Cuby's Right Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsCubyOn() && board[i,j].isRightAvailable()){
                        
                        //check if none of the cubes are to the right of you, if so execute the movement
                        if(!board[i,j+1].getIsSquaresomeOn() && !board[i,j+1].getIsRectahelperOn() && !board[i,j+1].getIsNervangleOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move to the right
                          so that you can as well.*/
                        else{                    
                            if(board[i,j+1].isRightAvailable()){ //checks if there is a tile to the right of the one we're interested in moving to
                                //if there are no cubes one tile above the one we're interested in moving to execute the movement
                                if(!board[i,j+2].getIsSquaresomeOn() && !board[i,j+2].getIsRectahelperOn() && !board[i,j+2].getIsNervangleOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i,j+2].isRightAvailable()){ //checks if there is a tile, two tiles to the right of the one we're interested in moving to
                                        //if there are no cubes, two tiles above the one we're interested in moving to, execute the movement
                                        if(!board[i,j+3].getIsSquaresomeOn() && !board[i,j+3].getIsRectahelperOn() && !board[i,j+3].getIsNervangleOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            transform.Translate (movementAmount,0,0);

                            //update character position in the 2D array
                            board[i,j].setIsCubyOn(false);
                            board[i,j+1].setIsCubyOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop 

            //Squaresome's Right Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsSquaresomeOn() && board[i,j].isRightAvailable()){
                        
                        //check if none of the cubes are to the right of you, if so execute the movement
                        if(!board[i,j+1].getIsCubyOn() && !board[i,j+1].getIsRectahelperOn() && !board[i,j+1].getIsNervangleOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move to the right
                          so that you can as well.*/
                        else{                    
                            if(board[i,j+1].isRightAvailable()){ //checks if there is a tile to the right of the one we're interested in moving to
                                //if there are no cubes one tile above the one we're interested in moving to execute the movement
                                if(!board[i,j+2].getIsCubyOn() && !board[i,j+2].getIsRectahelperOn() && !board[i,j+2].getIsNervangleOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i,j+2].isRightAvailable()){ //checks if there is a tile, two tiles to the right of the one we're interested in moving to
                                        //if there are no cubes, two tiles above the one we're interested in moving to, execute the movement
                                        if(!board[i,j+3].getIsCubyOn() && !board[i,j+3].getIsRectahelperOn() && !board[i,j+3].getIsNervangleOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            squaresome.transform.Translate (movementAmount,0,0);

                            //update character position in the 2D array
                            board[i,j].setIsSquaresomeOn(false);
                            board[i,j+1].setIsSquaresomeOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop

            //Rectahelper's Right Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsRectahelperOn() && board[i,j].isRightAvailable()){
                        
                        //check if none of the cubes are to the right of you, if so execute the movement
                        if(!board[i,j+1].getIsCubyOn() && !board[i,j+1].getIsSquaresomeOn() && !board[i,j+1].getIsNervangleOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move to the right
                          so that you can as well.*/
                        else{                    
                            if(board[i,j+1].isRightAvailable()){ //checks if there is a tile to the right of the one we're interested in moving to
                                //if there are no cubes one tile above the one we're interested in moving to execute the movement
                                if(!board[i,j+2].getIsCubyOn() && !board[i,j+2].getIsSquaresomeOn() && !board[i,j+2].getIsNervangleOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i,j+2].isRightAvailable()){ //checks if there is a tile, two tiles to the right of the one we're interested in moving to
                                        //if there are no cubes, two tiles above the one we're interested in moving to, execute the movement
                                        if(!board[i,j+3].getIsCubyOn() && !board[i,j+3].getIsSquaresomeOn() && !board[i,j+3].getIsNervangleOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            rectahelper.transform.Translate (movementAmount,0,0);

                            //update character position in the 2D array
                            board[i,j].setIsRectahelperOn(false);
                            board[i,j+1].setIsRectahelperOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop

            //Nervangle's Right Movement
            for (i = 0 ; i < rows ; i++){
                for (j = 0 ; j < columns ; j++){
                    executeMove = false;

                    if(board[i,j].getIsNervangleOn() && board[i,j].isRightAvailable()){
                        
                        //check if none of the cubes are to the right of you, if so execute the movement
                        if(!board[i,j+1].getIsCubyOn() && !board[i,j+1].getIsSquaresomeOn() && !board[i,j+1].getIsRectahelperOn() ){
                            executeMove = true;
                        }
                        /*if the other cube is located next to you, check if it can move to the right
                          so that you can as well.*/
                        else{                    
                            if(board[i,j+1].isRightAvailable()){ //checks if there is a tile to the right of the one we're interested in moving to
                                //if there are no cubes one tile above the one we're interested in moving to execute the movement
                                if(!board[i,j+2].getIsCubyOn() && !board[i,j+2].getIsSquaresomeOn() && !board[i,j+2].getIsRectahelperOn() ){
                                    executeMove = true;
                                }
                                else {
                                    if(board[i,j+2].isRightAvailable()){ //checks if there is a tile, two tiles to the right of the one we're interested in moving to
                                        //if there are no cubes, two tiles above the one we're interested in moving to, execute the movement
                                        if(!board[i,j+3].getIsCubyOn() && !board[i,j+3].getIsSquaresomeOn() && !board[i,j+3].getIsRectahelperOn() ){
                                            executeMove = true;
                                        }
                                    }
                                }    
                            }    
                        }

                        if(executeMove){
                            nervangle.transform.Translate (movementAmount,0,0);

                            //update character position in the 2D array
                            board[i,j].setIsNervangleOn(false);
                            board[i,j+1].setIsNervangleOn(true);

                            //stop inner and outter loop from executing
                            i = rows;
                            j = columns;
                        } 
                    }    
                }//end inner for loop
            }//end outter for loop
            

        }//**************************************************************** END RIGHT MOVEMENT FOR ALL CUBES ******************************************************************** 

    }//end CubesMovement()

    void isLevelComplete(){
        
        //checks if Cube OR Squaresome are located in either one of the open circuit locations. 
        if((board[2,3].getIsCubyOn() || board[2,3].getIsSquaresomeOn() || board[2,3].getIsRectahelperOn() || board[2,3].getIsNervangleOn()) && 
           (board[3,2].getIsCubyOn() || board[3,2].getIsSquaresomeOn() || board[3,2].getIsRectahelperOn() || board[3,2].getIsNervangleOn()) &&
           (board[3,4].getIsCubyOn() || board[3,4].getIsSquaresomeOn() || board[3,4].getIsRectahelperOn() || board[3,4].getIsNervangleOn()) &&
           (board[4,3].getIsCubyOn() || board[4,3].getIsSquaresomeOn() || board[4,3].getIsRectahelperOn() || board[4,3].getIsNervangleOn()) )
            {
                SceneManager.LoadScene(endScreen);
            }
    }//end isLevelComplete
}
