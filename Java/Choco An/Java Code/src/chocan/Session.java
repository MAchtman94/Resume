package chocan;

/**
 * This class represents a single line in the Provider Directory input file.
 *
 * @author Hristo Bonev
 */
public class Session {

    private String sessionName;
    private String serviceCode;//not an int because it can have leading 0s
    private double fee;

    public Session() {
        sessionName = "";
        serviceCode = "";
        fee = 0.0;
    }

    public Session(String sessionName, String serviceCode, double fee) {
        this.sessionName = sessionName;
        this.serviceCode = serviceCode;
        this.fee = fee;
    }

    public void setSessionName(String sessionName) {
        this.sessionName = sessionName;
    }

    public void setServiceCode(String serviceCode) {
        this.serviceCode = serviceCode;
    }
    
    public void setFee(double fee) {
        this.fee = fee;
    }
    
    public String getSessionName() {
        return sessionName;
    }

    public String getServiceCode() {
        return serviceCode;
    }

    public double getFee() {
        return fee;
    }

}//end Session Class