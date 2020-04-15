package chocan;

import java.io.PrintWriter;
import java.time.LocalDateTime;
import java.time.temporal.WeekFields;
import java.util.ArrayList;
import java.util.Locale;

/**
 * Stores all information relating to providers
 *
 * @author Hristo Bonev
 */
public class Provider {

    private String providerName;
    private String providerIDnumber; //not an int because it can have leading 0s
    private String streetAddress;
    private String city;
    private String state;
    private String zipCode;          //not an int because it can have leading 0s
    private ArrayList<Service> servicesProvided;

    Provider() {
        this.providerName = "";
        this.providerIDnumber = "";
        this.streetAddress = "";
        this.city = "";
        this.state = "";
        this.zipCode = "";
        this.servicesProvided = new ArrayList<>();
    }//end default c-tor

    Provider(String providerName, String providerIDnumber, String streetAddress,
            String city, String state, String zipCode, ArrayList<Service> servicesProvided) {
        this.providerName = providerName;
        this.providerIDnumber = providerIDnumber;
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
        this.servicesProvided = servicesProvided;
    }//end c-tor

    public void setProviderName(String providerName) {
        this.providerName = providerName;
    }//end setProviderName()

    public String getProviderName() {
        return providerName;
    }//end getProviderName()

    public void setProviderIDnumber(String providerIDnumber) {
        this.providerIDnumber = providerIDnumber;
    }//end setProviderIDnumber()

    public String getProviderIDnumber() {
        return providerIDnumber;
    }//end getProviderIDnumber()

    public void setStreetAddress(String streetAddress) {
        this.streetAddress = streetAddress;
    }//end setStreetAddress()

    public String getStreetAddress() {
        return streetAddress;
    }//end getStreetAddress()

    public void setCity(String city) {
        this.city = city;
    }//end setCity()

    public String getCity() {
        return city;
    }//end getCity()

    public void setState(String state) {
        this.state = state;
    }//end setState()

    public String getState() {
        return state;
    }//end getState()

    public void setZipCode(String zipCode) {
        this.zipCode = zipCode;
    }//end setZipCode()

    public String getZipCode() {
        return zipCode;
    }//end getZipCode()

    public String getTotalNumConsultations() {
        int consultationsTotal = 0;

        consultationsTotal = this.servicesProvided.size();
        
        String numberAsString = String.format("%03d", consultationsTotal);             

        return numberAsString;
    }//end getTotalNumConsultations()

    public void generateProviderServices(PrintWriter printWr, int currWeek) {

        printWr.println("PROVIDER SERVICE SUMMARY FOR WEEK " + currWeek);
        double servFeeTotal = 0;
        for (int i = 0; i < servicesProvided.size(); i++) {
            if (currWeek == servicesProvided.get(i).getWeek()) {
                printWr.println("");
                printWr.println("Date of service: " + servicesProvided.get(i).getDateServiceProvided());
                printWr.println("Recieved by Computer: " + servicesProvided.get(i).getCurrentDateTime());
                printWr.println("Member name: " + servicesProvided.get(i).getMemberName());
                printWr.println("Member number: " + servicesProvided.get(i).getMemberIDNumber());
                printWr.println("Service Code: " + servicesProvided.get(i).getSession().getServiceCode());
                printWr.println("Fee to be paid: " + servicesProvided.get(i).getSession().getFee());
                servFeeTotal += servicesProvided.get(i).getSession().getFee();
            } // end if
        }//end for
        printWr.println("Total consultations: " + getTotalNumConsultations());
        printWr.println("Total fee for week: " + servFeeTotal);
        

        printWr.println("");


    }

    public void addServicesProvided(Service service) {
        this.servicesProvided.add(service);
    }//end addServicesReceived()

    public ArrayList<Service> getServicesProvided() {
        return servicesProvided;
    }//end getServicesRecieved

    @Override
    public String toString() {
        return providerName + "," + providerIDnumber + "," + streetAddress
                + "," + city + "," + state + "," + zipCode;
    }

}//end Provider
