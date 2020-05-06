package com.rmiserver.model.sensor;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Class Name		:	EditSensor
 *	@Description	:	This class store information about Edit sensor object.
 *						This class extends from the RegisterSensor class
 * 
*/

public class EditSensor extends RegisterSensor{

	// Edit sensor object properties
	private int sensorId;

	// Constructors
	public EditSensor() { }
	
	public EditSensor(int sensorId,String sensorName, String floorNo, String roomNo, String sensorStatus) {
		super(sensorName,floorNo,roomNo,sensorStatus);
		this.sensorId = sensorId;
	}

	// Getters and Setters
	public int getSensorId() {
		return sensorId;
	}

	public void setSensorId(int sensorId) {
		this.sensorId = sensorId;
	}
	
}
