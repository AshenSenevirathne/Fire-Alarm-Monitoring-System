package com.rmiserver.service;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Class Name		:	EmailService
 *	@Description	:	This class used to send the emails for the users
 * 
*/

import java.util.Properties;
import javax.mail.*; 
import javax.mail.internet.*;

import com.rmiserver.configuration.AlertConstant;

import javax.mail.Session; 
import javax.mail.Transport; 

public class EmailService {

	public static void SendEmail(String emailList, String Emailmessage) {
		
		// Initialize the properties
		Properties properties = System.getProperties(); 
		
		// Set properties details
	    properties.put("mail.smtp.host", AlertConstant.EMAIL_HOST);
	    properties.put("mail.smtp.port", AlertConstant.EMAIL_PORT);
	    properties.put("mail.smtp.ssl.enable", AlertConstant.EMAIL_SSL);
	    properties.put("mail.smtp.auth", AlertConstant.EMAIL_AUTH);
	    
	    // Start the session and pass the sender authentication attributes
	    Session session = Session.getDefaultInstance(properties, new Authenticator() {
	    	protected PasswordAuthentication getPasswordAuthentication() {
				return new PasswordAuthentication(AlertConstant.EMAIL_SENDER, AlertConstant.EMAIL_SENDER_PWD);
	    	}
		});
	    
	    // Get the emails list
	    String[] recipientList = emailList.split(",");
	    // Initialize the InternetAddress to store the emails
	    InternetAddress[] recipientAddress = new InternetAddress[recipientList.length];
	    
	    try {
			// Add email to the InternetAddress object
		    for(int i = 0; i < recipientList.length; i++) {
		    	recipientAddress[i] = new InternetAddress(recipientList[i].trim());
		    }
	    	
		    // Initialize MimeMessage object
	    	MimeMessage message = new MimeMessage(session);
	    	// Set Sender Email address
	    	message.setFrom(new InternetAddress(AlertConstant.EMAIL_SENDER)); 
	    	// Set recipient list
	    	message.addRecipients(Message.RecipientType.TO, recipientAddress);
	    	// Set email subject
	    	message.setSubject(AlertConstant.EMAIL_SUBJECT); 
	    	// Set email message
	    	message.setText(AlertConstant.EMAIL_MESSAGE + Emailmessage); 
	    	// Send email
	    	Transport.send(message); 
	    	System.out.println("Email Send!");
	    	
		} catch (Exception ex) {
			System.out.println(ex);
		}
	}
	
}
