package OperatorGUI;

import ProviderGUI.VerificationFormGUIController;
import java.io.IOException;
import java.net.URL;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.stage.Stage;

public class OperatorMMController implements Initializable {
    public static String MorPUser="";
    
    @FXML 
    private Button AddMemberBut;
    @FXML
    private Button DeleteMemberBut;
        @FXML
    private Button UpdateMemberBut;
    @Override
    public void initialize(URL url, ResourceBundle rb) {

    }    
    
    @FXML
    private void handleAddAction(ActionEvent event){
        if(event.getSource().equals(AddMemberBut)){
            MorPUser="Member";
        }
        else{
            MorPUser="Provider";
        }
        try{
            Parent root = FXMLLoader.load(getClass().getResource("AddMemberGUI.fxml"));
            Scene Forgot_scene = new Scene(root);
            Stage scene = (Stage) ((Node) event.getSource()).getScene().getWindow();
            scene.setScene(Forgot_scene);
            scene.setTitle("Add "+MorPUser);
            scene.show();
        }
        catch (IOException ex) {
            Logger.getLogger(AddMemberGUIController.class.getName()).log(Level.SEVERE, null, ex);
        }  
    } 
    
    @FXML
    private void handleDeleteAction(ActionEvent event){
        if(event.getSource().equals(DeleteMemberBut)){
            MorPUser="Member";
        }
        else{
            MorPUser="Provider";
        }
        try{
            Parent root = FXMLLoader.load(getClass().getResource("DeleteOperatorGUI.fxml"));
            Scene Forgot_scene = new Scene(root);
            Stage scene = (Stage) ((Node) event.getSource()).getScene().getWindow();
            scene.setScene(Forgot_scene);
            scene.setTitle("Remove "+MorPUser);
            scene.show();
        }
        catch (IOException ex) {
            Logger.getLogger(DeleteOperatorGUIController.class.getName()).log(Level.SEVERE, null, ex);
        } 
    }
     @FXML
    private void handleUpdateAction(ActionEvent event){
        if(event.getSource().equals(UpdateMemberBut)){
            MorPUser="Member";
        }
        else{
            MorPUser="Provider";
        }
        try{
            Parent root = FXMLLoader.load(getClass().getResource("UpdateOperatorGUI.fxml"));
            Scene Forgot_scene = new Scene(root);
            Stage scene = (Stage) ((Node) event.getSource()).getScene().getWindow();
            scene.setScene(Forgot_scene);
            scene.setTitle("Update "+MorPUser);
            scene.show();
        }
        catch (IOException ex) {
            Logger.getLogger(DeleteOperatorGUIController.class.getName()).log(Level.SEVERE, null, ex);
        } 
    }
    @FXML
    private  void BackToMainMenu(ActionEvent event){
        try {
            Parent root = FXMLLoader.load(getClass().getResource("/cis376project/JavaMainMenu.fxml"));
            Scene Login_scene = new Scene(root);
            Stage scene = (Stage) ((Node) event.getSource()).getScene().getWindow();
            scene.setScene(Login_scene);
            scene.setTitle("Main Menu");
            scene.show();
        }catch (IOException ex) {
            Logger.getLogger(cis376project.JavaMainMenuController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
