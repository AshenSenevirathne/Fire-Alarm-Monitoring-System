package com.rmiserver;

import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

import com.rmiserver.service.SensorServicesImpl;
import com.rmiserver.service.UserServicesImpl;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Class Name		:	Service
 *	@Description	:	Service class used to run the RMI server and bind the remote interfaces
 * 
*/

public class Service {

	public static void main(String[] args) {

		// Set the policy file as the system security policy
		System.setProperty("java.security.policy", "file:allowall.policy");
		
		try {
			// Define remote interfaces
			UserServicesImpl userServices = new UserServicesImpl();
			SensorServicesImpl sensorService = new SensorServicesImpl();
			
			// Create object of Registry
			Registry registry = LocateRegistry.getRegistry();
			// Bind the interfaces with Registry
			registry.bind("UserService", userServices);
			registry.bind("SensorService", sensorService);
			
			System.out.println("FireAlaram Service Started!");
			
		} catch (Exception ex) {
			System.out.println("Error : " + ex.getMessage());
		}
		
	}

}
