package com.rmiserver.model.sensor;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Class Name		:	RegisterSensor
 *	@Description	:	This class store information about Register sensor object.
 * 
*/

public class RegisterSensor {

	// Register sensor object properties
	private String sensorName;
	private String floorNo;
	private String roomNo;
	private String sensorStatus;
	
	// Constructors
	public RegisterSensor() { }

	public RegisterSensor(String sensorName, String floorNo, String roomNo, String sensorStatus) {
		super();
		this.sensorName = sensorName;
		this.floorNo = floorNo;
		this.roomNo = roomNo;
		this.sensorStatus = sensorStatus;
	}

	// Getters and Setters
	public String getSensorName() {
		return sensorName;
	}

	public void setSensorName(String sensorName) {
		this.sensorName = sensorName;
	}

	public String getFloorNo() {
		return floorNo;
	}

	public void setFloorNo(String floorNo) {
		this.floorNo = floorNo;
	}

	public String getRoomNo() {
		return roomNo;
	}

	public void setRoomNo(String roomNo) {
		this.roomNo = roomNo;
	}

	public String getSensorStatus() {
		return sensorStatus;
	}

	public void setSensorStatus(String sensorStatus) {
		this.sensorStatus = sensorStatus;
	}
	
}
