package com.rmiserver.service;

import com.rmiserver.configuration.AlertConstant;
import com.twilio.Twilio;
import com.twilio.rest.api.v2010.account.Message;
import com.twilio.type.PhoneNumber;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Class Name		:	SmsService
 *	@Description	:	This class used to send the SMS for the users
 * 
*/

public class SmsService {

	public static void SendSms(String MobList, String Smsmessage) {
		
		// Initialize twilio object and pass SID and Auth Token to verify user
		Twilio.init(AlertConstant.SMS_ACCOUNT_SID, AlertConstant.SMS_AUTH_TOKEN);
		
		// Store mobile number list in array
		String[] recipientList = MobList.split(",");
		
		/*
		 * For send the SMS to the user we used the Twilio service.
		 * Using Twilio we can create a free trial account and get free mobile no for the testing purposes.
		 * There is some limitation in the free trial. One of the limitation is using free trial mobile no we can only send messages for the verified numbers.
		 * So that in this example we already registered the those users numbers in Twilio. Otherwise SMS will not send for the unverified numbers.
		 * 
		*/
		
		// Send sms for the Users
		for(int i = 0; i < recipientList.length; i++) {
			//Message smsMessage = Message.creator(new PhoneNumber(recipientList[i]), 
			//new PhoneNumber(AlertConstant.SMS_MY_NUMBER), AlertConstant.EMAIL_MESSAGE + Smsmessage).create();
			//System.out.println(smsMessage.getSid());
		}

	}
	
}
