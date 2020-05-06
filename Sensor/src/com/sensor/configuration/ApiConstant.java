package com.sensor.configuration;

/*
 * 	@Author 		:	Anjani Welagedara
 *	@Class Name		:	ApiConstant
 *	@Description	:	This class stores the constant values of the program.
 * 
*/

public class ApiConstant {

	// FireAlaram API server URL
	public static String API_SERVER = "http://localhost:44332/api/sensor/";
	
	// API endpoint for get available sensor details
	public static String GET_SENSOR_DETAILS_PATH = "GetSensorDetails";
	// API endpoint for set sensor state
	public static String SET_SENSOR_STATE_PATH = "SetSensorState";
	// Time interval for update sensor state
	public static int TIME_PERIOD = 10000;
	// Time delay
	public static int TIME_DELAY = 0;
}
