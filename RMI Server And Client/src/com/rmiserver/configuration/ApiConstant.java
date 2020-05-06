package com.rmiserver.configuration;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Class Name		:	ApiConstant
 *	@Description	:	This class store endpoints path of API
 * 
*/

public class ApiConstant {

	// FireAlaram API server URL
	public static String API_SERVER = "http://localhost:44332/api/";
	
	// API endpoint for SignIn
	public static String SIGNIN_METHOD = "user/SignIn";
	// API endpoint for Get user emails and mobile numbers
	public static String GET_USER_EMAIL_MOBILE = "user/GetUserEmailMobile";
	
	// API endpoint for get sensor details
	public static String GET_SENSOR_DETAILS_PATH = "sensor/GetSensorDetails";
	// API endpoint for register new sesor
	public static String REGISTER_NEW_SENSOR = "sensor/RegisterSensor";
	// API endpoint for edit sensor
	public static String EDIT_SENSOR = "sensor/EditSensor";
	// API endpoint for delete sensor
	public static String DELETE_SENSOR = "sensor/DeleteSensor";
	
}
