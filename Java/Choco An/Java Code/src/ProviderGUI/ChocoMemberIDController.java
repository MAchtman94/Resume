/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ProviderGUI;

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
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

/**
 *
 * @author Fallenanimes
 */
public class ChocoMemberIDController implements Initializable {
    
    public static String SendProviderID = ""; 
    @FXML
    private Label label;
    @FXML 
    private TextField ProviderInformation;
    @FXML
    private void handleButtonAction(ActionEvent event) {
        
        label.setText(chocan.ChocAn.verifyProviderIDNumber(ProviderInformation.getText()));
        System.out.println(label.getText());

        SendProviderID=ProviderInformation.getText();
        
        if (label.getText()=="valid"){
            try {
                Parent root = FXMLLoader.load(getClass().getResource("ChocoProviderMM.fxml"));
                Scene Login_scene = new Scene(root);
                Stage scene = (Stage) ((Node) event.getSource()).getScene().getWindow();
                scene.setScene(Login_scene);
                scene.setTitle("Provider MainPage");
                scene.show();
            }catch (IOException ex) {
                Logger.getLogger(ProviderGUI.ChocoProviderMMController.class.getName()).log(Level.SEVERE, null, ex);
            }  
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
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
        
    }    
    
}
