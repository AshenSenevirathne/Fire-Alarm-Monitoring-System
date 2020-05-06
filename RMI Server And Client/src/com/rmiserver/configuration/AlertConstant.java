package com.rmiserver.configuration;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Class Name		:	AlertConstant
 *	@Description	:	This class store information used in send email and SMS
 * 
*/

public class AlertConstant {

	// Email Configuration and Information
	// Define email host
	public static String EMAIL_HOST = "smtp.gmail.com";
	// Define email port
	public static String EMAIL_PORT = "465";
	// Define ssl verification
	public static String EMAIL_SSL = "true";
	// Define email authentications
	public static String EMAIL_AUTH = "true";	
	// Set sender email address
	public static String EMAIL_SENDER = "hotelbluedragon@gmail.com";
	// Set sender email address password
	public static String EMAIL_SENDER_PWD = "mad@2019";
	
	// Set email subject
	public static String EMAIL_SUBJECT = "Fire Alert - Fire Alaram Monitoring System";
	// Set email message body
	public static String EMAIL_MESSAGE = "Fire Alarm alert !\nFollowing location are detected. \n";
	
	// SMS Configuration and Information
	// Set twilio account SID
	public static final String SMS_ACCOUNT_SID = "AC7a1e0939de604287ae78feb05fac1f3e";
	// Set twilio account Authentication token
	public static final String SMS_AUTH_TOKEN = "6eb39265c35acce4f189ffeabe0e28c0";
	// Set sender phone number
	public static final String SMS_MY_NUMBER = "+12057360906";
}
