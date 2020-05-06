package com.rmiserver.model.sensor;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Class Name		:	Sensor
 *	@Description	:	This class represent the sensor object.
 * 
*/

public class Sensor {
	
	// Attributes of the sensor object
    private int sensorId;
    private String sensorName;
    private String floorNo;
    private String roomNo;
    private String sensorStatus;
    private int smokeLevel;
    private int co2Level;
    
    // Constructors
    public Sensor() { }
    
	public Sensor(int sensorId, String sensorName, String floorNo, String roomNo, String sensorStatus, int smokeLevel,
			int co2Level) {
		super();
		this.sensorId = sensorId;
		this.sensorName = sensorName;
		this.floorNo = floorNo;
		this.roomNo = roomNo;
		this.sensorStatus = sensorStatus;
		this.smokeLevel = smokeLevel;
		this.co2Level = co2Level;
	}

	// Getters and Setters
	public int getSensorId() {
		return sensorId;
	}

	public void setSensorId(int sensorId) {
		this.sensorId = sensorId;
	}

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

	public int getSmokeLevel() {
		return smokeLevel;
	}

	public void setSmokeLevel(int smokeLevel) {
		this.smokeLevel = smokeLevel;
	}

	public int getCo2Level() {
		return co2Level;
	}

	public void setCo2Level(int co2Level) {
		this.co2Level = co2Level;
	}
    
}
