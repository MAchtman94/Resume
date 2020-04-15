/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package OperatorGUI;

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
import javafx.scene.control.CheckBox;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.stage.Stage;
import static OperatorGUI.OperatorMMController.MorPUser;

/**
 * FXML Controller class
 *
 * @author Fallenanimes
 */
public class AddMemberGUIController implements Initializable {

    @FXML
    private TextField NameText;
    @FXML
    private TextField IDText;
    @FXML
    private TextField StreetText;
    @FXML
    private TextField CityText;
    @FXML
    private TextField StateText;
    @FXML
    private TextField ZipText;
    @FXML
    private CheckBox VerifyBox;
    @FXML
    private Label VerifyLabel;

    String ConString;
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        if(MorPUser=="Member"){
            IDText.setText(chocan.ChocAn.generateIDnumber('m'));
        }else{
          IDText.setText(chocan.ChocAn.generateIDnumber('p')); 
          VerifyBox.setText("Bank Information");

        }
    }    
    
    @FXML
    private void handleBackAction(ActionEvent event){
        try{
            Parent  root = FXMLLoader.load(getClass().getResource("OperatorMM.fxml"));
            Scene Forgot_scene = new Scene(root);
            Stage scene = (Stage) ((Node) event.getSource()).getScene().getWindow();
            scene.setScene(Forgot_scene);
            scene.setTitle("Main Menu");
            scene.show();
        }
        catch (IOException ex) {
            Logger.getLogger(OperatorMMController.class.getName()).log(Level.SEVERE, null, ex);
        }  
    }   
    
    @FXML 
    private void handleCreateAction(ActionEvent event){
        if(VerifyBox.isSelected()){
            ConString=NameText.getText()+","+IDText.getText()+","+StreetText.getText()+","+CityText.getText()+","+StateText.getText()+","+ZipText.getText();
            if(MorPUser.equals("Member")){
                try {
                    chocan.ChocAn.addMember(ConString);
                } catch (IOException ex) {
                    Logger.getLogger(AddMemberGUIController.class.getName()).log(Level.SEVERE, null, ex);
                } 
            }else{
                 try {
                    chocan.ChocAn.addProvider(ConString);
                } catch (IOException ex) {
                    Logger.getLogger(AddMemberGUIController.class.getName()).log(Level.SEVERE, null, ex);
                }                
            }
            try{
                Parent  root = FXMLLoader.load(getClass().getResource("OperatorMM.fxml"));
                Scene Forgot_scene = new Scene(root);
                Stage scene = (Stage) ((Node) event.getSource()).getScene().getWindow();
                scene.setScene(Forgot_scene);
                scene.setTitle("Main Menu");
                scene.show();
            }
            catch (IOException ex) {
                Logger.getLogger(OperatorMMController.class.getName()).log(Level.SEVERE, null, ex);
            }     
        }else{
            VerifyLabel.setText("Box not checked");
        }
    }
}
