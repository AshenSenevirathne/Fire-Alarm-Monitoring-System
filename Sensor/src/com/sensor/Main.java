package com.sensor;

import java.util.List;

import com.sensor.model.Sensor;
import com.sensor.service.ISensorServices;
import com.sensor.service.SensorServicesImpl;

/*
 * 	@Author 		:	Anjani Welagedara
 *	@Class Name		:	Main
 *	@Description	:	Handles sensor object and returns view for sensor object
 * 
*/

public class Main {

	public static void main(String[] args) {
		
		// Create instance of sensor service object
		ISensorServices iSensorServices = new SensorServicesImpl();
		// Get sensor objects list from API.
		List<Sensor> sensorList = iSensorServices.GetSensorDetails();
		
		// Check sensorList to confirm it is not null
		if(sensorList != null) {
			for(Sensor sensor : sensorList) {
				// Return view for every sensor object
				new SensorUI(sensor);
			}		
		}
	}

}
