package com.rmiserver.service;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.Arrays;
import java.util.List;

import javax.json.JsonObject;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Entity;
import javax.ws.rs.core.HttpHeaders;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.json.JsonArray;
import com.rmiserver.model.sensor.RegisterSensor;
import com.rmiserver.model.sensor.Sensor;
import com.google.gson.Gson;

import com.rmiserver.configuration.ApiConstant;
import com.rmiserver.model.sensor.EditSensor;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Class Name		:	SensorServicesImpl
 *	@Description	:	Implementation of all methods in ISensorServices
 * 
*/

public class SensorServicesImpl extends UnicastRemoteObject implements ISensorServices{

	// Constructors
	public SensorServicesImpl() throws RemoteException {
		super();
	}

	@Override
	public String GetAllSensors() throws RemoteException {

		// Create client object to send request to API
		Client client = ClientBuilder.newClient();
		
		// Call the API and get response
		Response response = client
				.target(ApiConstant.API_SERVER) 			// Server URL		
				.path(ApiConstant.GET_SENSOR_DETAILS_PATH)	// Endpoint path	
				.request(MediaType.APPLICATION_JSON)		// Request Media Type
				.get();										// Request method type

		// Check response status equals to 200
		// If it is 200 that mean status is OK. If not that mean some error happen.
		if(response.getStatus() == 200) {
			// Get a json object from response
			JsonObject jsonResponse = response.readEntity(JsonObject.class);
			// Then check the json object status
			// In the API every response have a two attribute. One is "status" and another one is "data".
			// "status" is boolean value. If it's true that mean API return valid response and "data" contains the Sensor objects
			// If "status" is false data attribute contains the error message.
			if(jsonResponse.getBoolean("status")) {
				// Initialize the tread and call SendEmailsAndSms function to send emails and SMS for the users
				Thread newThread = new Thread(() -> {
			        for(double i=0; i<5; i++){
			        	// Call SendEmailsAndSms method with passing sensor details
			        	//SendEmailsAndSms(jsonResponse);
			        }
				});
				newThread.start();
				// Return data
				return jsonResponse.get("data").toString();
			}
		}
		
		// return null if status code not 200
		return null;
		
	}
	
	private void SendEmailsAndSms(JsonObject jsonResponse) {
		
		// Get sensor details into sensor array
		Sensor list[] = new Gson().fromJson(jsonResponse.get("data").toString(), Sensor[].class);
		// Create List object suing array
		List<Sensor> sensorList = Arrays.asList(list);
		// Firealaram message
		String fireLocation = "";
		
		// Check every sensor to identify smoke and co2 value > 5
		for(Sensor sensor : sensorList) {
			if(sensor.getCo2Level() > 5 && sensor.getSmokeLevel() > 5) {
				// Set Firelocation message
				// Store the sensor id and location of the sensor to send the users
				fireLocation +=  "Sensor " + sensor.getSensorId() + " = Room No : " + sensor.getRoomNo() + " Floor No : " + sensor.getFloorNo() + "\n";
			}
		}
		
		// Check if fireLocation is not null. If it's not null means at least one of the sensor are detected the fire
		if(fireLocation != "") {
			
			// Create client object to send request to API
			Client client = ClientBuilder.newClient();
			
			// Call the API and get response
			Response response = client
					.target(ApiConstant.API_SERVER) 			// Server URL	
					.path(ApiConstant.GET_USER_EMAIL_MOBILE)	// Endpoint path
					.request(MediaType.APPLICATION_JSON)		// Request Media Type
					.get();										// Request method type
			
			// Check response status equals to 200
			// If it is 200 that mean status is OK. If not that mean some error happen.
			if(response.getStatus() == 200) {
				// Get a json object from response
				JsonObject apiRes = response.readEntity(JsonObject.class);
				// Check json object status
				if(apiRes.getBoolean("status")) {
					
					// Get data body from the json object
					JsonObject data = apiRes.getJsonObject("data");
					
					// Get email and mobile number lists as arrays
					JsonArray jsonEmailList = data.getJsonArray("email");
					JsonArray jsonMobileList = data.getJsonArray("mobile");
					
					// Set Email and Mobile No list to String
					String emailList = "";
					String mobileList = "";
					
					for(int i = 0; i < jsonEmailList.size(); i++) {
						emailList += jsonEmailList.getString(i) + ",";
						mobileList += jsonMobileList.getString(i) + ",";
					}
					
					// Finalize the email and mobile list
					emailList = emailList.substring(0, emailList.length() - 1);
					mobileList = mobileList.substring(0, mobileList.length() - 1);
					
					// Call the Email service method to send email
					EmailService.SendEmail(emailList, fireLocation.substring(0,fireLocation.length() - 1));
					// Call Sms service method to send sms
					//SmsService.SendSms(mobileList, fireLocation.substring(0,fireLocation.length() - 1));
				}
			}
			
		}
	}

	@Override
	public boolean RegisterSensor(String sensorName, String floorNo, String roomNo, String sensorStatus, String token)
			throws RemoteException {

		// Create client object to send request to API
		Client client = ClientBuilder.newClient();
		
		// Create a RegisterSensor object using pass parameters
		RegisterSensor registerSensor = new RegisterSensor(sensorName, floorNo, roomNo, sensorStatus);

		// Call the API and get response
		Response response = client 
				.target(ApiConstant.API_SERVER)										// Server URL
				.path(ApiConstant.REGISTER_NEW_SENSOR)								// Endpoint path
				.request(MediaType.APPLICATION_JSON)								// Request Media Type
				.header(HttpHeaders.AUTHORIZATION, token)							// Set AUTHORIZATION header
				.post(Entity.entity(registerSensor, MediaType.APPLICATION_JSON));	// Request method type
		
		// Check response status equals to 200
		// If it is 200 that mean status is OK. If not that mean some error happen.
		if(response.getStatus() == 200) {
			// Get a json object from response
			JsonObject jsonResponse = response.readEntity(JsonObject.class);
			// Then check the json object status
			if(jsonResponse.getBoolean("status")) {
				return true;
			}
		}
		
		// return null if status code not 200
		return false;
	}

	@Override
	public boolean EditSensor(int sensorId, String sensorName, String floorNo, String roomNo, String sensorStatus, String token) 
			throws RemoteException {

		// Create client object to send request to API
		Client client = ClientBuilder.newClient();
		
		// Create a EditSensor object using pass parameters
		RegisterSensor editSensor = new EditSensor(sensorId, sensorName, floorNo, roomNo, sensorStatus);
		
		// Call the API and get response
		Response response = client 
				.target(ApiConstant.API_SERVER)									// Server URL
				.path(ApiConstant.EDIT_SENSOR)									// Endpoint path
				.request(MediaType.APPLICATION_JSON)							// Request Media Type
				.header(HttpHeaders.AUTHORIZATION, token)						// Set AUTHORIZATION header
				.put(Entity.entity(editSensor, MediaType.APPLICATION_JSON));	// Request method type
		
		
		// Check response status equals to 200
		// If it is 200 that mean status is OK. If not that mean some error happen.
		if(response.getStatus() == 200) {
			// Get a json object from response
			JsonObject jsonResponse = response.readEntity(JsonObject.class);
			// Then check the json object status
			if(jsonResponse.getBoolean("status")) {
				return true;
			}
		}
		// return null if status code not 200
		return false;
	}

	@Override
	public boolean DeleteSensor(int sensorId, String token) throws RemoteException {

		Client client = ClientBuilder.newClient();
		
		Response response = client 
				.target(ApiConstant.API_SERVER)				// Server URL
				.path(ApiConstant.DELETE_SENSOR)			// Endpoint path
				.path(String.valueOf(sensorId))				// Request Media Type
				.request(MediaType.APPLICATION_JSON)		// Set AUTHORIZATION header
				.header(HttpHeaders.AUTHORIZATION, token)	// Request method type
				.delete();
		
		// Check response status equals to 200
		// If it is 200 that mean status is OK. If not that mean some error happen.
		if(response.getStatus() == 200) {
			// Get a json object from response
			JsonObject jsonResponse = response.readEntity(JsonObject.class);
			// Then check the json object status
			if(jsonResponse.getBoolean("status")) {
				return true;
			}
		}
		
		// return null if status code not 200
		return false;
	}

}
