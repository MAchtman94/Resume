package chocan;

import java.io.PrintWriter;
import java.time.LocalDateTime;
import java.time.temporal.WeekFields;
import java.util.ArrayList;
import java.util.Locale;

/**
 * Stores all information relating to a single member
 *
 * @author Hristo Bonev
 */
public class Member {

    private String memberName;
    private String memberIDnumber;   //not an int because it can have leading 0s
    private String memberStatus;
    private String streetAddress;
    private String city;
    private String state;
    private String zipCode;          //not an int because it can have leading 0s
    private ArrayList<Service> servicesReceived;

    Member() {
        memberName = "";
        memberIDnumber = "";
        memberStatus = "";
        streetAddress = "";
        city = "";
        state = "";
        zipCode = "";
        servicesReceived = new ArrayList<>();
    }//end default c-tor

    Member(String memberName, String memberIDnumber, String memberStatus,
            String streetAddress, String city, String state, String zipCode,
            ArrayList<Service> servicesReceived) {
        this.memberName = memberName;
        this.memberIDnumber = memberIDnumber;
        this.memberStatus = memberStatus;
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
        this.servicesReceived = servicesReceived;
    }//end c-tor

    public void setMemberName(String memberName) {
        this.memberName = memberName;
    }//end setMemberName()

    public void setMemberIDNumber(String memberIDnumber) {
        this.memberIDnumber = memberIDnumber;
    }//end setMemberIDNumber()

    public void setMemberStatus(String memberStatus) {
        this.memberStatus = memberStatus;
    }//end setMemberStatus()

    public void setStreetAddress(String streetAddress) {
        this.streetAddress = streetAddress;
    }//end setStreetAddress()

    public void setCity(String city) {
        this.city = city;
    }//end setCity()

    public void setState(String state) {
        this.state = state;
    }//end setState()

    public void setZipCode(String zipCode) {
        this.zipCode = zipCode;
    }//end setZipCode()

    public String getMemberName() {
        return memberName;
    }//end getMemberName()

    public String getMemberIDNumber() {
        return memberIDnumber;
    }//end getMemberIDNumber()

    public String getMemberStatus() {
        return memberStatus;
    }//end getMemberStatus()

    public String getStreetAddress() {
        return streetAddress;
    }//end getStreetAddress()

    public String getCity() {
        return city;
    }//end getCity()

    public String getState() {
        return state;
    }//end getState()

    public String getZipCode() {
        return zipCode;
    }//end getZipCode()

    public void addServicesReceived(Service service) {
        this.servicesReceived.add(service);
    }//end addServicesReceived()

    public ArrayList<Service> getServicesRecieved() {
        return servicesReceived;
    }//end getServicesRecieved

    public static int generateCurrentWeek() {
        LocalDateTime currDateTime = LocalDateTime.now();
        WeekFields weekFields;

        weekFields = WeekFields.of(Locale.getDefault());
        int week = currDateTime.get(weekFields.weekOfWeekBasedYear());

        return week;
    }

    public void generateMemberServices(PrintWriter printWr, int currWeek) {


        printWr.println("MEMBER SERVICE SUMMARY FOR WEEK " + currWeek);

        for (int i = 0; i < servicesReceived.size(); i++) {
            if (currWeek == servicesReceived.get(i).getWeek()) {
                printWr.println("");
                printWr.println("Date service was provided: " + servicesReceived.get(i).getDateServiceProvided());
                printWr.println("Provider name: " + servicesReceived.get(i).getProviderName());
                printWr.println("Service Name: " + servicesReceived.get(i).getSession().getSessionName());

            } // end if
        }//end for
        printWr.println("");
    
    }

    @Override
    public String toString() {
        return memberName + "," + memberIDnumber + "," + memberStatus + ","
                + streetAddress + "," + city + "," + state + "," + zipCode;
    }//end toString()

}//end Member Class
