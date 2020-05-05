package com.sensor.model;

/*
 * 	@Author 		:	Anjani Welagedara
 *	@Class Name		:	Sensor
 *	@Description	:	This class represents the sensor state object.
 * 
*/

public class SensorState {

	// Attributes of the sensor object
	private int sensorId;
    private int smokeLevel;
    private int coLevel;
    
    // Constructors
    public SensorState() { }

	public SensorState(int sensorId, int smokeLevel, int coLevel) {
		super();
		this.sensorId = sensorId;
		this.smokeLevel = smokeLevel;
		this.coLevel = coLevel;
	}
	
	// Getters and Setters
	public int getSensorId() {
		return sensorId;
	}

	public void setSensorId(int sensorId) {
		this.sensorId = sensorId;
	}

	public int getSmokeLevel() {
		return smokeLevel;
	}

	public void setSmokeLevel(int smokeLevel) {
		this.smokeLevel = smokeLevel;
	}

	public int getCoLevel() {
		return coLevel;
	}

	public void setCoLevel(int coLevel) {
		this.coLevel = coLevel;
	}
	
}
