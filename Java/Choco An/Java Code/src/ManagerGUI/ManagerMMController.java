package ManagerGUI;

import java.io.FileNotFoundException;
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
import javafx.stage.Stage;


public class ManagerMMController implements Initializable {

    @FXML
    private Label ManagerLabel;
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    
    @FXML
    private void MemberReportAction(ActionEvent event) {
        try {
            chocan.ChocAn.generateMemberReport();
            ManagerLabel.setText("Member Report Created");
        } catch (FileNotFoundException ex) {
            Logger.getLogger(ManagerMMController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    @FXML
    private void ProviderReportAction(ActionEvent event){
        try {
            chocan.ChocAn.generateProviderReport();
            ManagerLabel.setText("Provider Report Created");
        } catch (FileNotFoundException ex) {
            Logger.getLogger(ManagerMMController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    @FXML
    private void ManagerReportAction(ActionEvent event){
        try {
            chocan.ChocAn.generateAllServicesForWeek();
            ManagerLabel.setText("Manager Report Created");
        } catch (FileNotFoundException ex) {
            Logger.getLogger(ManagerMMController.class.getName()).log(Level.SEVERE, null, ex);
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
