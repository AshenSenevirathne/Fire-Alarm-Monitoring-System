package com.rmiclient;

import java.rmi.Naming;

import com.rmiclient.components.LoginUI;
import com.rmiserver.service.ISensorServices;
import com.rmiserver.service.IUserServices;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Class Name		:	Main
 *	@Description		:	Main class is used to get services from RMI server
 * 
*/

public class Main {

	public static void main(String[] args) {

		// Set the policy file as the system security policy
		System.setProperty("java.security.policy", "file:allowall.policy");
	
		// Define remote interfaces
		ISensorServices sensorService = null;
		IUserServices userService = null;
		
		try {
			// Initialize the remote interface from RMI server
			sensorService = (ISensorServices) Naming.lookup("//localhost/SensorService");
			userService = (IUserServices) Naming.lookup("//localhost/UserService");
			
			// If remote interfaces not null return the login UI
			if(sensorService != null && userService != null) {
				new LoginUI(sensorService,userService);
			}
			
		} catch (Exception ex) {
			System.out.println("Error : " + ex.getMessage());
		}
	}

}
