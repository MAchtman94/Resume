/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package OperatorGUI;

import static OperatorGUI.OperatorMMController.MorPUser;
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


public class DeleteOperatorGUIController implements Initializable {

    @FXML
    private Label VerifyBoxLabel;
    @FXML
    private Label IDLabel;
    @FXML
    private TextField IDNumberText;
    @FXML
    private CheckBox VerifyBox;
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
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
    private void DeleteIDNumber(ActionEvent event){
        if(VerifyBox.isSelected()){
            VerifyBoxLabel.setText("");
            if(MorPUser.equals("Member")){
                try {
                    IDLabel.setText(chocan.ChocAn.verifyMemberIDNumber(IDNumberText.getText()));
                    if(IDLabel.getText().equals("Validated") || IDLabel.getText().equals("Member suspended")){
                        chocan.ChocAn.deleteMember(IDNumberText.getText());
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
                } catch (IOException ex) {
                Logger.getLogger(DeleteOperatorGUIController.class.getName()).log(Level.SEVERE, null, ex);
                }
            }else if(MorPUser.equals("Provider")){
                IDLabel.setText(chocan.ChocAn.verifyProviderIDNumber(IDNumberText.getText()));
                if(IDLabel.getText().equals("valid")){
                     IDLabel.setText("Validated");
                    try {
                        chocan.ChocAn.deleteProvider(IDNumberText.getText());
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
                    } catch (IOException ex) {
                        Logger.getLogger(DeleteOperatorGUIController.class.getName()).log(Level.SEVERE, null, ex);
                    }
                }
            }
        }else{
            VerifyBoxLabel.setText("Box not checked");
        }
    }
}
