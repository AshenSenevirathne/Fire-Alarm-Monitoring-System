package com.rmiserver.service;

import java.rmi.Remote;
import java.rmi.RemoteException;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Interface Name	:	IUserServices
 *	@Description	:	Define the all remote methods related to the users
 * 
*/

public interface IUserServices extends Remote{

	// Sign in method
	public String SignIn(String userEmail, String userPassword) throws RemoteException;
	
}
