package com.rmiserver.service;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

import javax.json.JsonObject;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Entity;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import com.rmiserver.model.user.LoginUser;
import com.rmiserver.model.user.User;
import com.google.gson.Gson;
import com.rmiserver.configuration.ApiConstant;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Class Name		:	SensorSeUserServicesImplrvicesImpl
 *	@Description	:	Implementation of all methods in UserServicesImpl
 * 
*/

public class UserServicesImpl extends UnicastRemoteObject implements IUserServices{

	public UserServicesImpl() throws RemoteException {
		super();
	}

	@Override
	public String SignIn(String userEmail, String userPassword) throws RemoteException {

		// Create client object to send request to API
		Client client = ClientBuilder.newClient();
		
		// Create object of LoginUser using passed parameters
		LoginUser loginUser = new LoginUser(userEmail, userPassword);
		
		// Call the API and get response
		Response response = client 
				.target(ApiConstant.API_SERVER)									// Server URL
				.path(ApiConstant.SIGNIN_METHOD)								// Endpoint path
				.request(MediaType.APPLICATION_JSON)							// Request Media Type
				.post(Entity.entity(loginUser, MediaType.APPLICATION_JSON));	// Request method type
		

		// Check response status equals to 200
		// If it is 200 that mean status is OK. If not that mean some error happen.
		if(response.getStatus() == 200) {
			// Get a json object from response
			JsonObject jsonResponse = response.readEntity(JsonObject.class);
			// Then check the json object status
			if(jsonResponse.getBoolean("status")) {
				// return information of login user
				return jsonResponse.get("data").toString();
			}
			return null;
		}
		
		return null;
		
	}

}
