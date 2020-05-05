package com.sensor;

import javax.swing.JFrame;
import javax.swing.JLabel;

import com.sensor.configuration.ApiConstant;
import com.sensor.model.Sensor;
import com.sensor.model.SensorState;
import com.sensor.service.ISensorServices;
import com.sensor.service.SensorServicesImpl;

import java.awt.Font;
import java.util.Timer;
import java.util.TimerTask;
import java.util.concurrent.ThreadLocalRandom;

/*
 * 	@Author 		:	Anjani Welagedara
 *	@Class Name		:	SensorUI
 *	@Description	:	Handle user interface for sensorobject
 * 
*/

public class SensorUI {
	
	// Attributes 
	private Sensor sensor;
	private ISensorServices iSensorServices;
	
	// Constructor
	public SensorUI(Sensor sensor) {
		this.sensor = sensor;
		this.iSensorServices = new SensorServicesImpl();
		InitiUI();
	}
	
	// return UI
	private void InitiUI() {
		
		// Initialize Frame
		JFrame frame = new JFrame(sensor.getSensorName());
		
		// Display sensor id
		JLabel lblSensorId = new JLabel("Sensor Id : ");
		lblSensorId.setBounds(12, 15, 90, 16);
		
		// Display sensor name
		JLabel lblSensorName = new JLabel("Sensor Name : ");
		lblSensorName.setBounds(12, 45, 90, 16);	
		
		// Display floor no
		JLabel lblFloorNo = new JLabel("Floor No : ");
		lblFloorNo.setBounds(12, 75, 90, 16);	
		
		// Display room no
		JLabel lblRoomNo = new JLabel("Room No : ");
		lblRoomNo.setBounds(12, 105, 90, 16);		
		
		// Display value of sensor id
		JLabel lblSensorIdVal = new JLabel(sensor.getSensorId() + "");
		lblSensorIdVal.setBounds(168, 15, 56, 16);
		
		// Display value of sensor name
		JLabel lblSensorNameVal = new JLabel(sensor.getSensorName());
		lblSensorNameVal.setBounds(168, 45, 90, 16);	
		
		// Display value of floor no
		JLabel lblFloorNoVal = new JLabel(sensor.getFloorNo());
		lblFloorNoVal.setBounds(168, 75, 56, 16);
		
		// Display value of room no
		JLabel lblRoomNoVal = new JLabel(sensor.getRoomNo());
		lblRoomNoVal.setBounds(168, 105, 56, 16);	
		
		// Display smoke level
		JLabel lblSmokeLevel = new JLabel("Smoke Level : ");
		lblSmokeLevel.setBounds(48, 152, 90, 16);
		
		// Display co2 level
		JLabel lblCo2 = new JLabel("Co2 Level : ");
		lblCo2.setBounds(200, 152, 90, 16);
		
		// Display value of smoke level
		JLabel lblSmokeLevelVal = new JLabel(sensor.getSmokeLevel() + "");
		lblSmokeLevelVal.setFont(new Font("Tahoma", Font.BOLD, 20));
		lblSmokeLevelVal.setBounds(74, 176, 40, 16);
		
		// Display value of co2 level
		JLabel lblCo2Val = new JLabel(sensor.getCo2Level() + "");
		lblCo2Val.setFont(new Font("Tahoma", Font.BOLD, 20));
		lblCo2Val.setBounds(213, 176, 40, 16);
		
		// Add UI components to frame
		frame.getContentPane().add(lblSensorId);
		frame.getContentPane().add(lblSensorName);
		frame.getContentPane().add(lblFloorNo);
		frame.getContentPane().add(lblRoomNo);
		
		frame.getContentPane().add(lblSensorIdVal);
		frame.getContentPane().add(lblSensorNameVal);
		frame.getContentPane().add(lblRoomNoVal);
		frame.getContentPane().add(lblFloorNoVal);		

		frame.getContentPane().add(lblSmokeLevel);
		frame.getContentPane().add(lblCo2);

		frame.getContentPane().add(lblSmokeLevelVal);
		frame.getContentPane().add(lblCo2Val);
		
		// Set frame size
		frame.setSize(350,260);
		// Set frame layout
		frame.getContentPane().setLayout(null);
		frame.setLocationRelativeTo(null);
		// Set frame visible
		frame.setVisible(true); 
		
		// Initialize the timer object
		Timer timer = new Timer();
		// Define scheduled method using timer object
		timer.schedule(new TimerTask() {
			
			@Override
			public void run() {
				// Get random value set to the view
				lblSmokeLevelVal.setText(getRandomIntValue() + "");
				lblCo2Val.setText(getRandomIntValue() + "");

				// Call the changeSensorState
				changeSensorState(new SensorState(
						sensor.getSensorId(),							// Pass sensor Id
						Integer.parseInt(lblSmokeLevelVal.getText()),	// Pass smoke level
						Integer.parseInt(lblCo2Val.getText())			// Pass co2 level
						));
			}
		}, ApiConstant.TIME_DELAY, ApiConstant.TIME_PERIOD); 			// Define delay and time interval
		
	}
	
	// Handle the sensor state change
	// Call the method of iSensorServices to send updated data to API
	private void changeSensorState(SensorState sensorState) {
		iSensorServices.SetSensorState(sensorState);
	}
	
	// Return random int value with in 0 - 10
	private int getRandomIntValue() {
		return ThreadLocalRandom.current().nextInt(0, 10);
	}
}


