package cis376project;

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
import javafx.stage.Stage;

public class JavaMainMenuController implements Initializable {


    @Override
    public void initialize(URL url, ResourceBundle rb) {

    }   
    
  @FXML
  private void ProviderGUIAction(ActionEvent event) {
    try {
        Parent root = FXMLLoader.load(getClass().getResource("/ProviderGUI/ChocoMemberID.fxml"));
        Scene Login_scene = new Scene(root);
        Stage scene = (Stage) ((Node) event.getSource()).getScene().getWindow();
        scene.setScene(Login_scene);
        scene.setTitle("Provider Login");
        scene.show();
    }catch (IOException ex) {
        Logger.getLogger(ProviderGUI.ChocoMemberIDController.class.getName()).log(Level.SEVERE, null, ex);
    }
  }
  @FXML
  private void OperatorGUIAction(ActionEvent event) {
    try {
        Parent root = FXMLLoader.load(getClass().getResource("/OperatorGUI/OperatorMM.fxml"));
        Scene Login_scene = new Scene(root);
        Stage scene = (Stage) ((Node) event.getSource()).getScene().getWindow();
        scene.setScene(Login_scene);
        scene.setTitle("Operator Main Menu");
        scene.show();
    }catch (IOException ex) {
        Logger.getLogger(OperatorGUI.OperatorMMController.class.getName()).log(Level.SEVERE, null, ex);
    }
  }
  @FXML
  private void ManagerGUIAction(ActionEvent event) {
    try {
        Parent root = FXMLLoader.load(getClass().getResource("/ManagerGUI/ManagerMM.fxml"));
        Scene Login_scene = new Scene(root);
        Stage scene = (Stage) ((Node) event.getSource()).getScene().getWindow();
        scene.setScene(Login_scene);
        scene.setTitle("Manager Main Menu");
        scene.show();
    }catch (IOException ex) {
        Logger.getLogger(ManagerGUI.ManagerMMController.class.getName()).log(Level.SEVERE, null, ex);
    }
  }
}
