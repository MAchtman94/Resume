package chocan;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Random;
import java.util.Scanner;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.time.temporal.WeekFields;
import java.util.Locale;

/**
 * So far it only reads data from all 3 input files and stores it locally.
 *
 * @author Hristo Bonev
 */
public class ChocAn {

    private static final String PROVIDER_DIR_INPUT_FILE_NAME = "providerDir.txt";
    private static final String MEMBERS_INPUT_FILE_NAME = "membersDataCenter.txt";
    private static final String PROVIDERS_INPUT_FILE_NAME = "providersDataCenter.txt";
    private static final String TOTAL_SERVICES_OUTPUT = "servicesForWeek.txt";
    private static final String MEMBER_REPORT = "memberReport.txt";
    private static final String PROVIDER_REPORT = "providerReport.txt";

    /*The provider directory input file is stored in this data structure. 
      Each line of the input file is stored at a separate index.*/
    private static ArrayList<Session> providerDirectory = new ArrayList<>();

    /*The provider input file is stored in this data structure.
      Each provider and his info are stored at a separate index.*/
    private static ArrayList<Provider> providerRecords = new ArrayList<>();

    /*The member input file is stored in this data structure.
      Each member and his info are stored at a separate index.*/
    private static ArrayList<Member> memberRecords = new ArrayList<>();

    /* Services provided    */
    private static ArrayList<Service> serviceTotal = new ArrayList<>();

    private static Scanner scan;        //to read input file(s)

    public static void readProviderDirectoryInputFile() {
        try {
            scan = new Scanner(new File(PROVIDER_DIR_INPUT_FILE_NAME));

            while (scan.hasNext()) {
                //tempLine = a single line from the provider dir input file
                String tempLine = scan.nextLine();

                /*Splits the line into tokens:
                  tokenizedLine[0] = session name
                  tokenizedLine[1] = service code
                  tokenizedLine[2] = fee */
                String[] tokenizedLine = tempLine.split(",");

                //creating a temporary Session object 
                Session tempSession = new Session();

                //initializes all data fields of the temp object
                tempSession.setSessionName(tokenizedLine[0]);
                tempSession.setServiceCode(tokenizedLine[1]);
                tempSession.setFee(Double.parseDouble(tokenizedLine[2]));

                providerDirectory.add(tempSession); //add session to ArrayList
            }
        }//end try
        catch (FileNotFoundException e) {
            //maybe a label within the GUI saying: ("Error: Input file " + MEMBERS_INPUT_FILE_NAME + " not found.")
        }
    }//end readProviderDirectoryInputFile()

    public static void readProvidersInputFile() {
        try {
            scan = new Scanner(new File(PROVIDERS_INPUT_FILE_NAME));

            while (scan.hasNext()) {
                //tempLine = a single line from the member's input file
                String tempLine = scan.nextLine();

                /*Splits the line into tokens:
                  tokenizedLine[0] = provider name
                  tokenizedLine[1] = provider ID number
                  tokenizedLine[2] = street address
                  ...
                  tokenizedLine[5] = zip code */
                String[] tokenizedLine = tempLine.split(",");

                //creating a temp Provider object
                Provider tempRecord = new Provider();

                //initializes all data fields of the tempRecord object
                tempRecord.setProviderName(tokenizedLine[0]);
                tempRecord.setProviderIDnumber(tokenizedLine[1]);
                tempRecord.setStreetAddress(tokenizedLine[2]);
                tempRecord.setCity(tokenizedLine[3]);
                tempRecord.setState(tokenizedLine[4]);
                tempRecord.setZipCode(tokenizedLine[5]);

                providerRecords.add(tempRecord); //add given member record
            }
        } catch (FileNotFoundException e) {
            //maybe a label within the GUI saying: ("Error: Input file " + MEMBERS_INPUT_FILE_NAME + " not found.")
        }
    }//end readProvidersInputFile()

    /**
     * Reads input file containing members' info and stores all data locally.
     */
    public static void readMembersInputFile() {
        try {
            scan = new Scanner(new File(MEMBERS_INPUT_FILE_NAME));

            while (scan.hasNext()) {
                //tempLine = a single line from the member's input file
                String tempLine = scan.nextLine();

                /*Splits the line into tokens:
                  tokenizedLine[0] = member name
                  tokenizedLine[1] = member ID number
                  tokenizedLine[2] = member status
                  ...
                  tokenizedLine[6] = member's zip code*/
                String[] tokenizedLine = tempLine.split(",");

                //creating a temp Member object
                Member tempRecord = new Member();

                //initializes all data fields of the tempRecord object
                tempRecord.setMemberName(tokenizedLine[0]);
                tempRecord.setMemberIDNumber(tokenizedLine[1]);
                tempRecord.setMemberStatus(tokenizedLine[2]);
                tempRecord.setStreetAddress(tokenizedLine[3]);
                tempRecord.setCity(tokenizedLine[4]);
                tempRecord.setState(tokenizedLine[5]);
                tempRecord.setZipCode(tokenizedLine[6]);

                memberRecords.add(tempRecord); //add given member record
            }
        } catch (FileNotFoundException e) {
            //maybe a label within the GUI saying: ("Error: Input file " + MEMBERS_INPUT_FILE_NAME + " not found.")
        }
    }//end readMembersInputFile()

    /**
     * Checks the status associated with a given member ID number.
     *
     * @param memberIDnumber a members ID number that needs to be validated.
     * @return a String: "Validated" if member ID number is valid "Member
     * suspended" if member has been suspended or an error message if entered ID
     * was not in the proper format.
     */
    public static String verifyMemberIDNumber(String memberIDnumber) {
        String status = "Invalid number";
        String regex = "\\d+";

        //checking if entered ID is 9 characters long. 
        if (memberIDnumber.length() != 9) {
            status = "Error! ID should be 9 integers long!";
        }

        //checking if entered ID is composed of numbers only. 
        if (!memberIDnumber.matches(regex)) {
            status = "Error! Entered ID can consist of numbers only [1-9].";
        }
        //traversing through memberRecords to find if there's a matching ID
        for (int i = 0; i < memberRecords.size(); i++) {
            if (memberIDnumber.equals(memberRecords.get(i).getMemberIDNumber())) {
                status = memberRecords.get(i).getMemberStatus();
                break;
            }
        }//end for

        return status;
    }//end verifyMemberIDNumber()

    /**
     * Checks the status associated with a given member ID number.
     *
     * @param providerIDnumber a members ID number that needs to be validated.
     * @return a String: "Validated" if member ID number is valid "Member
     * suspended" if member has been suspended or an error message if entered ID
     * was not in the proper format.
     */
    public static String verifyProviderIDNumber(String providerIDnumber) {
        String status = "Invalid number";
        String regex = "\\d+";

        //checking if entered ID is 9 characters long. 
        if (providerIDnumber.length() != 9) {
            status = "Error! ID should be 9 integers long!";
        }

        if (!providerIDnumber.matches(regex)) {
            status = "Error! Entered ID can consist of numbers only [1-9].";

        }

        //traversing through memberRecords to find if there's a matching ID
        for (int i = 0; i < providerRecords.size(); i++) {
            if (providerIDnumber.equals(providerRecords.get(i).getProviderIDnumber())) {
                status = "valid";
                break;
            }
        }//end for

        return status;
    }//end verifyProviderIDNumber()    
    
    /**
     * returns name of session from code
     *
     * @param serviceCode a session's code
     * @return a String: name of session if valid or error message if not valid
     */
    public static String getSessionNameFromCode(String serviceCode) {
        String name = "Invalid";
        String regex = "\\d+";

        if (serviceCode.matches(regex)) {
            for (int i = 0; i < providerDirectory.size(); i++) {
                if (providerDirectory.get(i).getServiceCode().equals(serviceCode)) {
                    name = providerDirectory.get(i).getSessionName();
                    break;
                }//end if

            }//end for
        } //end if       

        return name;
    } //end getSessionNameFromCode

    /**
     * gets fee for code. No validation bc in theory is only used after getting
     * name
     *
     * @param serviceCode is code of session
     * @return fee double
     */
    public static String getSessionFeeFromCode(String serviceCode) {
        double fee = 0;
        String statementFee = "";

        for (int i = 0; i < providerDirectory.size(); i++) {
            if (providerDirectory.get(i).getServiceCode().equals(serviceCode)) {
                fee = providerDirectory.get(i).getFee();
                statementFee += fee;
                break;
            }//end if

        }//end for

        return statementFee;
    } //end getSessionFeeFromCode

    /**
     * This method generates a unique random ID number for a member / provider.
     *
     * @param m_p if character passed = 'p' it will generate an ID number for a
     * provider. if character passed = 'm' it will generate an ID number for a
     * member.
     * @return unique member/provider ID number
     */
    public static String generateIDnumber(char m_p) {
        String idNum = "";

        boolean match = false;

        while (true) {
            idNum = generateRandomID();
            System.out.println(idNum);
            if (m_p == 'm') {
                for (int i = 0; i < memberRecords.size(); i++) {
                    if (idNum.equals(memberRecords.get(i).getMemberIDNumber())) {
                        match = true;
                        break;
                    }
                }//end for
            }//end if
            else if (m_p == 'p') {
                for (int i = 0; i < providerRecords.size(); i++) {
                    if (idNum.equals(providerRecords.get(i).getProviderIDnumber())) {
                        match = true;
                        break;
                    }
                }//end for
            }//end else if

            //if no matching ID was found break away from the while loop
            if (!match) {
                break;
            }

        }//end while

        return idNum;
    }//end generateIDnumber()

    /**
     * This method is a helper method. It should NOT be called within our GUI.
     *
     * @return RANDOMLY generated ID (without checking if it already exists).
     */
    private static String generateRandomID() {
        String randomID = "";

        Random rand = new Random();

        for (int i = 0; i < 9; i++) {
            randomID += (char) (rand.nextInt(10) + '0');
        }

        return randomID;
    }//end generateRandomID()

    /**
     * Adds a member.
     *
     * @param conString A string that holds a member's information in the form:
     * "name,IDnumber,street,city,state,zip"
     * @return String indicating whether addition was successful.
     */
    public static String addMember(String concatString) throws IOException {
        String returnMssg = "";

        /*Splits the line into tokens:
            tokenizedLine[0] = member name
            tokenizedLine[1] = member ID number
            tokenizedLine[2] = street address
            ...
            tokenizedLine[5] = member's zip code*/
        String[] tokenizedLine = concatString.split(",");

        if (tokenizedLine[0].length() > 25) { //ensure name is 25 chars long
            returnMssg = "Error! Member name is too long!";
        } else {
            Member tempMember = new Member();

            tempMember.setMemberName(tokenizedLine[0]);
            tempMember.setMemberIDNumber(tokenizedLine[1]);
            tempMember.setMemberStatus("Validated");
            tempMember.setStreetAddress(tokenizedLine[2]);
            tempMember.setCity(tokenizedLine[3]);
            tempMember.setState(tokenizedLine[4]);
            tempMember.setZipCode(tokenizedLine[5]);

            memberRecords.add(tempMember);

            updateMembersInputFile();

            returnMssg = "Member added successfully!";
        }

        return returnMssg;
    }//end addMember()

    /**
     * Adds a provider.
     *
     * @param concatString A string that holds a provider's information in the
     * form: "name,IDnumber,street,city,state,zip"
     * @return String String indicating whether addition was successful.
     * @throws IOException
     */
    public static String addProvider(String concatString) throws IOException {
        String returnMssg = "";

        /*Splits the line into tokens:
            tokenizedLine[0] = provider name
            tokenizedLine[1] = provider ID number
            tokenizedLine[2] = street address
            ...
            tokenizedLine[5] = provider's zip code*/
        String[] tokenizedLine = concatString.split(",");

        if (tokenizedLine[0].length() > 25) { //ensure name is 25 chars long
            returnMssg = "Error! Provider name is too long!";
        } else {
            Provider tempProvider = new Provider();

            tempProvider.setProviderName(tokenizedLine[0]);
            tempProvider.setProviderIDnumber(tokenizedLine[1]);
            tempProvider.setStreetAddress(tokenizedLine[2]);
            tempProvider.setCity(tokenizedLine[3]);
            tempProvider.setState(tokenizedLine[4]);
            tempProvider.setZipCode(tokenizedLine[5]);

            providerRecords.add(tempProvider);

            updateProvidersInputFile();

            returnMssg = "Provider added successfully!";
        }

        return returnMssg;
    }//end addProvider()

    /**
     * Updates the information we have on file for a Member / Provider
     *
     * @param IDnumber The ID# of the member/provider whose info we're updating
     * @param concatString A comma-separated string containing updated info.
     * @param m_p Character indicating whether the ID# and info are associated
     * with a member ['m'] or a provider ['p']
     * @return String indicating whether update was successfull.
     * @throws IOException
     */
    public static String update_Member_Provider(String IDnumber, String concatString, char m_p) throws IOException {
        String status = "Error! Invalid data entered!";

        /*tokenizes the concatanated string such that:
          tokenized[0] = member/provider name
          tokenized[1] = member/provider ID#
          tokenized[2] = street address
          tokenized[3] = city 
          tokenized[4] = state
          tokenized[5] = zip*/
        String[] tokenized = concatString.split(",");

        if (m_p == 'm') { //if updating Member's info
            int i;
            for (i = 0; i < memberRecords.size(); i++) {
                if (IDnumber.equals(memberRecords.get(i).getMemberIDNumber())) {
                    memberRecords.get(i).setMemberName(tokenized[0]);
                    memberRecords.get(i).setMemberIDNumber(tokenized[1]);
                    memberRecords.get(i).setStreetAddress(tokenized[2]);
                    memberRecords.get(i).setCity(tokenized[3]);
                    memberRecords.get(i).setState(tokenized[4]);
                    memberRecords.get(i).setZipCode(tokenized[5]);

                    updateMembersInputFile();

                    status = "Member info was successfully updated.";
                }//end if
            }//end for
        }//end if
        else if (m_p == 'p') {//if updating Provider's info
            int i;
            for (i = 0; i < providerRecords.size(); i++) {
                if (IDnumber.equals(providerRecords.get(i).getProviderIDnumber())) {
                    providerRecords.get(i).setProviderName(tokenized[0]);
                    providerRecords.get(i).setProviderIDnumber(tokenized[1]);
                    providerRecords.get(i).setStreetAddress(tokenized[2]);
                    providerRecords.get(i).setCity(tokenized[3]);
                    providerRecords.get(i).setState(tokenized[4]);
                    providerRecords.get(i).setZipCode(tokenized[5]);

                    updateProvidersInputFile();

                    status = "Provider info was successfully updated.";
                }//end if
            }//end for 
        }//end else-if
        else {
            status = "Error! Invalid character entered!";
        }//end else

        return status;
    }//end update_Member_Provider()    
    
    /**
     * Deletes a member
     *
     * @param memberID the ID number of the member we're deleting
     * @return String indicating whether the deletion was successful.
     * @throws IOException
     */
    public static String deleteMember(String memberID) throws IOException {
        String returnMessage = "Member ID not found";

        boolean idFound = false;

        int i;

        for (i = 0; i < memberRecords.size(); i++) {
            if (memberID.equals(memberRecords.get(i).getMemberIDNumber())) {
                idFound = true;
                break;
            }
        }

        //removes the member located at index i of the ArrayList
        if (idFound) {
            memberRecords.remove(memberRecords.get(i));
            returnMessage = "Member removed successfully!";
        }

        updateMembersInputFile(); //delete member from .txt file

        return returnMessage;
    }//end deleteMember()
    
    /**
     * Deletes a provider
     *
     * @param providerID the ID number of the provider we're deleting
     * @return String indicating whether the deletion was successful.
     * @throws IOException
     */
    public static String deleteProvider(String providerID) throws IOException {
        String returnMessage = "Provider ID not found";

        boolean idFound = false;

        int i;

        for (i = 0; i < providerRecords.size(); i++) {
            if (providerID.equals(providerRecords.get(i).getProviderIDnumber())) {
                idFound = true;
                break;
            }
        }

        //removes the member located at index i of the ArrayList
        if (idFound) {
            providerRecords.remove(providerRecords.get(i));
            returnMessage = "Member removed successfully!";
        }

        updateProvidersInputFile(); //delete provider from .txt file

        return returnMessage;
    }//end deleteProvider()

    /**
     * This method rewrites the members input file to whatever data is stored
     * currently in the memberRecords ArrayList.
     *
     * @throws FileNotFoundException
     * @throws IOException
     */
    private static void updateMembersInputFile() throws FileNotFoundException, IOException {

        PrintWriter printWr = new PrintWriter(new File(MEMBERS_INPUT_FILE_NAME));

        //populates the new file with the new member data
        for (int i = 0; i < memberRecords.size(); i++) {
            printWr.println(memberRecords.get(i).toString());
        }

        printWr.close();

    }//end updateMembersInputFile()    

    /**
     * This method rewrites the providers input file to whatever data is stored
     * currently in the providerRecords ArrayList.
     *
     * @throws FileNotFoundException
     * @throws IOException
     */
    private static void updateProvidersInputFile() throws FileNotFoundException, IOException {

        PrintWriter printWr = new PrintWriter(new File(PROVIDERS_INPUT_FILE_NAME));

        //populates the new file with the new member data
        for (int i = 0; i < providerRecords.size(); i++) {
            printWr.println(providerRecords.get(i).toString());
        }

        printWr.close();

    }//end updateProvidersInputFile()

    /**
     * Returns a comma-separated string containing all info for a
     * member/provider.
     *
     * @param IDnumber the ID number that belongs to a member/provider
     * @param m_p character that indicates if ID# belongs to member or provider
     * @return Comma separated string that holds the current info we have
     */
    public static String getConcatStringFromID(String IDnumber, char m_p) {
        String concatString = "Error! ID# not found!";

        if (m_p == 'm') { //if ID number belongs to a member
            int i;

            //find which index that ID is located at
            for (i = 0; i < memberRecords.size(); i++) {
                if (IDnumber.equals(memberRecords.get(i).getMemberIDNumber())) {
                    concatString = memberRecords.get(i).toString();
                    break;
                }
            }
        }//end if
        else if (m_p == 'p') {//if ID number belongs to a provider
            int i;

            //find which index that ID is located at
            for (i = 0; i < providerRecords.size(); i++) {
                if (IDnumber.equals(providerRecords.get(i).getProviderIDnumber())) {
                    concatString = providerRecords.get(i).toString();
                    break;
                }
            }
        }//end else-if

        return concatString;
    }//end getConcatStringFromID()

    public static String getProviderNameFromCode(String providerID) {
        String name = "";
        for (int i = 0; i < providerRecords.size(); i++) {
            if (providerID.equals(providerRecords.get(i).getProviderIDnumber())) {
                name = providerRecords.get(i).getProviderName();
                break;
            }
        }

        return name;
    }//end getProviderNameFromCode

    public static String getMemberNameFromCode(String memberID) {
        String name = "";
        for (int i = 0; i < memberRecords.size(); i++) {
            if (memberID.equals(memberRecords.get(i).getMemberIDNumber())) {
                name = memberRecords.get(i).getMemberName();
                break;
            }
        }

        return name;
    }//end getMemberNameFromCode()

    /**
     * Adds to 3 service lists once the verification form is accepted *
     *
     * @param currentDateTime current time from gui
     * @param dateServiceProvided current time from gui
     * @param memberIDNumber id of member who received service
     * @param session service given
     * @param comments added by provider
     * @param providerID id of provider
     */
    public static void serviceInformation(String currentDateTime, String dateServiceProvided,
            String memberIDNumber, Session session, String comments, String providerID) {
        Service newAdd = new Service(currentDateTime, dateServiceProvided,
                memberIDNumber, session,
                comments, providerID, getMemberNameFromCode(memberIDNumber), getProviderNameFromCode(providerID));

        serviceTotal.add(newAdd);

        for (int i = 0; i < memberRecords.size(); i++) {
            if (memberIDNumber.equals(memberRecords.get(i).getMemberIDNumber())) {
                memberRecords.get(i).addServicesReceived(newAdd);
            }//end if
        }//end for 

        for (int i = 0; i < providerRecords.size(); i++) {
            if (providerID.equals(providerRecords.get(i).getProviderIDnumber())) {
                providerRecords.get(i).addServicesProvided(newAdd);
            }//end if
        }//end for 
    }//end serviceInformation()

    /**
     * When called, this will write the servicesTotal to a file.
     *
     * @throws java.io.FileNotFoundException
     */
    public static void generateAllServicesForWeek() throws FileNotFoundException {

        PrintWriter printWr = new PrintWriter(new File(TOTAL_SERVICES_OUTPUT));
        double servFeeTotal = 0;
        int currWeek = generateCurrentWeek();

        printWr.println("SEVICES DELIVERED DURING WEEK " + currWeek);

        for (int i = 0; i < serviceTotal.size(); i++) {
            if (currWeek == serviceTotal.get(i).getWeek()) {
                printWr.println("");
                printWr.println("Current date and time: " + serviceTotal.get(i).getCurrentDateTime());
                printWr.println("Date service was provided: " + serviceTotal.get(i).getDateServiceProvided());
                printWr.println("Provider number: " + serviceTotal.get(i).getProviderIDNumber());
                printWr.println("Member number: " + serviceTotal.get(i).getMemberIDNumber());
                printWr.println("Service Code: " + serviceTotal.get(i).getSession().getServiceCode());
                printWr.println("Comment: " + serviceTotal.get(i).getComments());
                servFeeTotal += serviceTotal.get(i).getSession().getFee();

            } // end if
        }//end for
        printWr.println("");
        printWr.println("Total Fee: " + servFeeTotal);

        printWr.close();

    }//end generateAllServicesForWeek()


    /*
    Get the current week to generate the report for
     */
    public static int generateCurrentWeek() {
        LocalDateTime currDateTime = LocalDateTime.now();
        WeekFields weekFields;

        weekFields = WeekFields.of(Locale.getDefault());
        int week = currDateTime.get(weekFields.weekOfWeekBasedYear());

        return week;
    }

    public static void generateMemberReport() throws FileNotFoundException {

        PrintWriter printWr = new PrintWriter(new File(MEMBER_REPORT));
        int currWeek = generateCurrentWeek();

        printWr.println("MEMBERS");

        for (int i = 0; i < memberRecords.size(); i++) {
            printWr.println("");

            printWr.println("Member Name: " + memberRecords.get(i).getMemberName());
            printWr.println("Member Number: " + memberRecords.get(i).getMemberIDNumber());
            printWr.println("Member Street Address: " + memberRecords.get(i).getStreetAddress());
            printWr.println("Member City: " + memberRecords.get(i).getCity());
            printWr.println("Member State: " + memberRecords.get(i).getState());
            printWr.println("Member ZIP Code: " + memberRecords.get(i).getZipCode());
            memberRecords.get(i).generateMemberServices(printWr, currWeek);
        }//end for
        printWr.println("");

        printWr.close();
    }//end generateMemberReport()

    public static void generateProviderReport() throws FileNotFoundException {

        PrintWriter printWr = new PrintWriter(new File(PROVIDER_REPORT));
        int currWeek = generateCurrentWeek();

        printWr.println("PROVIDERS");

        for (int i = 0; i < providerRecords.size(); i++) {
            printWr.println("");

            printWr.println("Provider Name: " + providerRecords.get(i).getProviderName());
            printWr.println("Provider Number: " + providerRecords.get(i).getProviderIDnumber());
            printWr.println("Provider Street Address: " + providerRecords.get(i).getStreetAddress());
            printWr.println("Provider City: " + providerRecords.get(i).getCity());
            printWr.println("Provider State: " + providerRecords.get(i).getState());
            printWr.println("Provider ZIP Code: " + providerRecords.get(i).getZipCode());
            providerRecords.get(i).generateProviderServices(printWr, currWeek);
        }//end for
        printWr.println("");

        printWr.close();
    }//end generateProviderReport()

    /**
     * Returns a COPY of the provider directory. NOT the actually directory itself. 
     * I.e. You cannot make changes to the real provider directory if you make changes 
     * to the instance this method returns. 
     * 
     * @return copy of the provider directory
     */
    public static ArrayList<Session> getProviderDirectory(){
        ArrayList<Session> copyOfProviderDir = new ArrayList<>();
        
        Session tempSession;
        
        for(int i = 0 ; i < providerDirectory.size() ; i++){
            tempSession = new Session();
            tempSession.setSessionName(providerDirectory.get(i).getSessionName());
            tempSession.setServiceCode(providerDirectory.get(i).getServiceCode());
            tempSession.setFee(providerDirectory.get(i).getFee());
            
            copyOfProviderDir.add(tempSession);
        }
  
        return copyOfProviderDir;
    }//end getProviderDirectory()

}//end ChocAn class