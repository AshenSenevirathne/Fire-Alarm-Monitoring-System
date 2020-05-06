package com.rmiserver.service;

import java.rmi.Remote;
import java.rmi.RemoteException;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Interface Name	:	ISensorServices
 *	@Description	:	Define the all remote methods related to the sensors
 * 
*/

public interface ISensorServices extends Remote{
	
	// Get all sensors from API
	public String GetAllSensors() throws RemoteException;
	// Register new sensor
	public boolean RegisterSensor(String sensorName, String floorNo, String roomNo, String sensorStatus, String token) throws RemoteException;
	// Edit Sensor
	public boolean EditSensor(int sensorId, String sensorName, String floorNo, String roomNo, String sensorStatus, String token) throws RemoteException;
	// Delete sensor
	public boolean DeleteSensor(int sensorId, String token) throws RemoteException;
}
