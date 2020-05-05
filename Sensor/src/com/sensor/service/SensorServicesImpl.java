package com.sensor.service;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import javax.json.JsonObject;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Entity;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import com.google.gson.Gson;
import com.sensor.configuration.ApiConstant;
import com.sensor.model.Sensor;
import com.sensor.model.SensorState;

/*
 * 	@Author 		:	Anjani Welagedara
 *	@Class Name		:	SensorServicesImpl
 *	@Description	:	Implement the methods of ISensorServices
 * 
*/

public class SensorServicesImpl implements ISensorServices{

	@Override
	public List<Sensor> GetSensorDetails() {
		
		// Create a List object to store the sensors
		List<Sensor> sensorList = new ArrayList<Sensor>();
		
		// Create a client object to send request to API
		Client client = ClientBuilder.newClient();
		
		// Call the API and get response
		Response response = client
				.target(ApiConstant.API_SERVER) 			// Server URL
				.path(ApiConstant.GET_SENSOR_DETAILS_PATH)	// Endpoint path
				.request(MediaType.APPLICATION_JSON)		// Request Media Type
				.get();										// Request method type
		
		// Check response status which equals to 200
		// If it is 200 that means status is OK. If not that means that something went wrong.
		if(response.getStatus() == 200) {
			// Get a json object from response
			JsonObject jsonResponse = response.readEntity(JsonObject.class);
			// Then check the json object status
			// In the API every response have two attributes. One is "status" and one is "data".
			// "status" is the boolean value. If it's true that means API return valid response and "data" contains the Sensor objects
			// If "status" is false data attribute contains the error message.
			if(jsonResponse.getBoolean("status")) {
				// Using Gson library get sensor object array from json response variable
				Sensor list[] = new Gson().fromJson(jsonResponse.get("data").toString(), Sensor[].class);
				// Array store in the list
				sensorList = Arrays.asList(list);
				return sensorList;
			}
			// If "status" is false return null value
			return null;
		}
		// If status not equals to 200 return null value
		return null;
	}

	@Override
	public boolean SetSensorState(SensorState sensorState) {
		
		// Create List object to store the sensors
		Client client = ClientBuilder.newClient();
		
		// Call the API and get response
		Response response = client
				.target(ApiConstant.API_SERVER)									// Server URL
				.path(ApiConstant.SET_SENSOR_STATE_PATH)						// Endpoint path
				.request(MediaType.APPLICATION_JSON)							// Request Media Type
				.post(Entity.entity(sensorState, MediaType.APPLICATION_JSON));	// Request method type and pass object
		

		// Check response status equals to 200
		// If it is 200 that mean status is OK. If not that means that something went wrong.
		if(response.getStatus() == 200) {
			// Get a json object from response
			JsonObject jsonResponse = response.readEntity(JsonObject.class);
			// Then check the json object status
			// In the API every response have two attributes. One is "status" and one is "data".
			// "status" is a boolean value. If it's true that means that API returns valid response and "data" contains the updated sensor Id
			// If "status" is false data attribute contains the error message.
			if(jsonResponse.getBoolean("status")) {
				// If "status" is true that means sensor state updates. Then returns true.
				return true;
			}
			// If "status" is false  return false 
			return false;
		}
		// If "status" is not equal to 200 return false 
		return false;
	}

}
