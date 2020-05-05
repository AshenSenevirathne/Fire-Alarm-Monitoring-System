package com.sensor.service;

import java.util.List;

import com.sensor.model.Sensor;
import com.sensor.model.SensorState;

/*
 * 	@Author 			:	Anjani Welagedara
 *	@Interface Name		:	ISensorServices
 *	@Description		:	This interface represent the functions of sensor object.
 * 
*/

public interface ISensorServices {

	// Get all sensors objects
	public List<Sensor> GetSensorDetails();
	
	// Set sensor state
	public boolean SetSensorState(SensorState sensorState);
	
}
