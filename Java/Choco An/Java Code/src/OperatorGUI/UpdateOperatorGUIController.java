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
import javafx.scene.control.Button;
import javafx.scene.control.CheckBox;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

/**
 * FXML Controller class
 *
 * @author Fallenanimes
 */
public class UpdateOperatorGUIController implements Initializable {

    @FXML
    private TextField NumberIDText;
    @FXML
    private Label IDLabel;
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
    @FXML
    private Button VerifyButton;
    
    String ConName;
    String ConString;
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        if(MorPUser.equals("Provider")){
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
    private void GetInfoAction(ActionEvent event){
        if(MorPUser.equals("Member")){
            IDLabel.setText(chocan.ChocAn.verifyMemberIDNumber(NumberIDText.getText()));
            if(IDLabel.getText().equals("Validated")||IDLabel.getText().equals("Member suspended")){
               ConName=chocan.ChocAn.getConcatStringFromID(NumberIDText.getText(), 'm');
                System.out.println(ConName);
                
            String[] tokenizedLine = ConName.split(",");
            NameText.setText(tokenizedLine[0]);
            IDText.setText(tokenizedLine[1]);
            StreetText.setText(tokenizedLine[3]);
            CityText.setText(tokenizedLine[4]);
            StateText.setText(tokenizedLine[5]);
            ZipText.setText(tokenizedLine[6]);
            
            NameText.setDisable(false);
            IDText.setDisable(false);
            StreetText.setDisable(false);
            CityText.setDisable(false);
            StateText.setDisable(false);
            ZipText.setDisable(false);
            VerifyBox.setDisable(false);
            VerifyButton.setDisable(false);
            } 

        }else{    
            IDLabel.setText(chocan.ChocAn.verifyProviderIDNumber(NumberIDText.getText()));   
            if(IDLabel.getText().equals("valid")){
               IDLabel.setText("Validated");
               ConName=chocan.ChocAn.getConcatStringFromID(NumberIDText.getText(), 'p');
                System.out.println(ConName);
                
            String[] tokenizedLine = ConName.split(",");
            NameText.setText(tokenizedLine[0]);
            IDText.setText(tokenizedLine[1]);
            StreetText.setText(tokenizedLine[2]);
            CityText.setText(tokenizedLine[3]);
            StateText.setText(tokenizedLine[4]);
            ZipText.setText(tokenizedLine[5]);
            
            NameText.setDisable(false);
            IDText.setDisable(false);
            StreetText.setDisable(false);
            CityText.setDisable(false);
            StateText.setDisable(false);
            ZipText.setDisable(false);
            VerifyBox.setDisable(false);
            VerifyButton.setDisable(false);
            } 
 
        }
    }
    @FXML   
    private void handleUpdateAction(ActionEvent event){
        ConString=NameText.getText()+","+IDText.getText()+","+StreetText.getText()+","+CityText.getText()+","+StateText.getText()+","+ZipText.getText();
        if(VerifyBox.isSelected()){
            if(MorPUser.equals("Member")){
                try { 
                    chocan.ChocAn.update_Member_Provider(IDText.getText(),ConString, 'm');
                } catch (IOException ex) {
                    Logger.getLogger(UpdateOperatorGUIController.class.getName()).log(Level.SEVERE, null, ex);
                }
            }else{
                try { 
                    chocan.ChocAn.update_Member_Provider(IDText.getText(),ConString, 'p');
                } catch (IOException ex) {
                    Logger.getLogger(UpdateOperatorGUIController.class.getName()).log(Level.SEVERE, null, ex);
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
