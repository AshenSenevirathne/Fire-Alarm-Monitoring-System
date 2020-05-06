package com.rmiclient.components;

import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.JTextField;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;
import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableCellRenderer;

import com.google.gson.Gson;
import com.google.gson.JsonSyntaxException;
import com.rmiclient.configurations.ClientConstants;
import com.rmiserver.model.sensor.Sensor;
import com.rmiserver.model.user.User;
import com.rmiserver.service.ISensorServices;

import javax.swing.JLabel;

import java.awt.Color;
import java.awt.Component;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.rmi.RemoteException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.Arrays;
import java.util.List;
import java.util.Timer;
import java.util.TimerTask;

import javax.swing.JButton;
import javax.swing.JComboBox;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Class Name		:	Dashboard
 *	@Description	:	
 * 
*/

public class Dashboard {

	private ISensorServices sensorService;
	private User loginUser;
	private List<Sensor> sensorList;
	DefaultTableModel model = new DefaultTableModel();
	DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("yyyy/MM/dd HH:mm:ss");
	
	public Dashboard(ISensorServices sensorService, User loginUser) {
		this.sensorService = sensorService;
		this.loginUser = loginUser;
		dashboard();
	}
	
	private List<Sensor> getAllSensors(){
		
		try {
			Sensor list[] = new Gson().fromJson(sensorService.GetAllSensors().toString(), Sensor[].class);
			showNotification(list);
			return Arrays.asList(list);
		} catch (JsonSyntaxException e) {
			e.printStackTrace();
		} catch (RemoteException e) {
			e.printStackTrace();
		}
		
		return null;
	}
	
	private void showNotification(Sensor list[]) {
		String head = "Fire Alarm alert !\nFollowing location are detected. \n";
		String fireLocation = "";
		for(Sensor sensor : list) {
			if(sensor.getCo2Level() > 5 && sensor.getSmokeLevel() > 5) {
				fireLocation +=  "Sensor " + sensor.getSensorId() + " = Room No : " + sensor.getRoomNo() + " Floor No : " + sensor.getFloorNo() + "\n";
			}
		}
		if(fireLocation != "") {
			JOptionPane.showConfirmDialog(null, 
	                head + fireLocation, "Alert Warning !", JOptionPane.DEFAULT_OPTION, JOptionPane.ERROR_MESSAGE);	
		}
	}
	
	private Sensor getSensorById(int sensorId) {
		for(Sensor sensor : sensorList) {
			if(sensor.getSensorId() == sensorId)
				return sensor;
		}
		return null;
	}
	
	private void fillTable() {
		sensorList = null;
		this.sensorList = getAllSensors();
		model.setRowCount(0);
		for(Sensor sensor : sensorList) {
			String sensorState = "N";
			if(sensor.getSmokeLevel() > 5 && sensor.getCo2Level() > 5)
				sensorState = "Y";
			model.addRow(new Object[] { sensor.getSensorId(), sensor.getSensorName(), sensor.getFloorNo(), sensor.getRoomNo(),
					sensor.getSmokeLevel(), sensor.getCo2Level(), sensorState});
			
		}
	}
	
	private void dashboard() {
		
		JFrame frame = new JFrame("Fire alarm Dashboard");
		JTable table = new JTable() {
			@Override
			public Component prepareRenderer(TableCellRenderer renderer,int row,int column) {
				Component comp = super.prepareRenderer(renderer,row, column);
				comp.setBackground(getBackground());
				int modelRow = convertRowIndexToModel(row);
				String type = (String)getModel().getValueAt(modelRow, 6);
				if ("Y".equals(type))
					comp.setBackground(Color.RED);
				return comp;
			}
		};
	
		frame.setBounds(430, 200, 533, 530);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.getContentPane().setLayout(null);
		
		Object[] colomns = { "Sensor Id", "Sensor Name", "Floor No", "Room No", "Smoke Level", "Co2 Level" , "Status"};
		
		model.setColumnIdentifiers(colomns);
		table.setModel(model);
		
		table.getColumnModel().getColumn(6).setMinWidth(0);
		table.getColumnModel().getColumn(6).setMaxWidth(0);
		
		JScrollPane scrollPane = new JScrollPane(table);
		scrollPane.setBounds(12, 98, 491, 348);
		frame.getContentPane().add(scrollPane);
		
		JLabel caption = new JLabel("Fire Alaram Monitoring System");
		caption.setFont(new Font("Tahoma", Font.BOLD, 20));
		caption.setBounds(94, 16, 319, 25);
		frame.getContentPane().add(caption);
		
				JLabel lblLastSync = new JLabel("Last Sync : ");
		lblLastSync.setFont(new Font("Tahoma", Font.BOLD, 12));
		lblLastSync.setBounds(15, 456, 215, 16);
		frame.getContentPane().add(lblLastSync);
		
		JLabel lblLoginUser = new JLabel("Login User : " + loginUser.getUserName());
		lblLoginUser.setFont(new Font("Tahoma", Font.BOLD, 12));
		lblLoginUser.setBounds(309, 456, 194, 16);
		frame.getContentPane().add(lblLoginUser);
		
		frame.setLocationRelativeTo(null);
		frame.setVisible(true);

		if(loginUser.getUserRole().equals("ADMIN")) {
			
			JButton btnAddNewSensor = new JButton("Add New Sensor");
			btnAddNewSensor.setBounds(94, 57, 146, 25);
			frame.getContentPane().add(btnAddNewSensor); 
			
			JButton btnEditDelete = new JButton("Edit/Delete Sensor");
			btnEditDelete.setBounds(265, 56, 146, 25);
			frame.getContentPane().add(btnEditDelete);
			
			btnAddNewSensor.addActionListener(new ActionListener() {
				
				@Override
				public void actionPerformed(ActionEvent e) {
					frame.setVisible(false);
					registerSensor(null);
				}
			});
			
			btnEditDelete.addActionListener(new ActionListener() {
				
				@Override
				public void actionPerformed(ActionEvent e) {
					frame.setVisible(false);
					editDeleteOption();
				}
			});
			
		}
		
		Timer timer = new Timer();
		
		timer.schedule(new TimerTask() {
			
			@Override
			public void run() {
				LocalDateTime now = LocalDateTime.now();
				lblLastSync.setText("Last Sync : " + dateFormat.format(now));
				fillTable();
			}
		}, ClientConstants.TIME_DELAY, ClientConstants.TIME_PERIOD);
		
	}
	
	private void editDeleteOption() {
		
		JFrame frame = new JFrame("Edit/Delete Sensor");

		JLabel lblSensorId = new JLabel("Sensor ID");
		lblSensorId.setBounds(12, 15, 106, 16);

		JComboBox<String> sensorLst = new JComboBox<String>();
		sensorLst.setBounds(12, 44, 358, 30);
		
		for(Sensor sensor : sensorList) {
			sensorLst.addItem(sensor.getSensorId() + " - " + sensor.getSensorName());
		}

		JButton edit  = new JButton("Edit");
		edit.setBounds(22, 99, 150, 30);
		JButton delete  = new JButton("Delete");
		delete.setBounds(192, 99, 150, 30);

		frame.setSize(400,187);
		frame.getContentPane().add(lblSensorId);
		frame.getContentPane().add(sensorLst);
		frame.getContentPane().add(edit);
		frame.getContentPane().add(delete);
		frame.getContentPane().setLayout(null);
		frame.setLocationRelativeTo(null);
		frame.setVisible(true); 
		
		edit.addActionListener(new ActionListener() {		
			@Override
			public void actionPerformed(ActionEvent e) {
				frame.setVisible(false);
				int selectedItem = Integer.parseInt(sensorLst.getSelectedItem().toString().substring(0, sensorLst.getSelectedItem().toString().indexOf('-')).trim());
				registerSensor(getSensorById(selectedItem));
			}
		});
		
		delete.addActionListener(new ActionListener() {			
			@Override
			public void actionPerformed(ActionEvent e) {
				JOptionPane.showMessageDialog(frame, "Sucessfully Deleted!");
				
				int selectedItem = Integer.parseInt(sensorLst.getSelectedItem().toString().substring(0, sensorLst.getSelectedItem().toString().indexOf('-')).trim());
				try {
					sensorService.DeleteSensor(selectedItem, loginUser.getToken());
					frame.setVisible(false);
					dashboard();
				} catch (RemoteException e1) {
					e1.printStackTrace();
				}
			}
		});
	}
	
	private void registerSensor(Sensor sensor) {
		
		String windowName = "New Sensor Register";
		String btnName = "Register Sensor";
		
		if(sensor != null) {
			windowName = "Edit Sensor";
			btnName = "Edit Sensor";
		}			
		
		JFrame frame = new JFrame(windowName);
		
		JLabel lblsensorName = new JLabel("Sensor Name");
		lblsensorName.setBounds(12, 13, 106, 16);
		
		JTextField txtsensorName = new JTextField(40);
		txtsensorName.setBounds(12, 38, 358, 30);
		
		JLabel lblfloorNo = new JLabel("Floor No");
		lblfloorNo.setBounds(12, 78, 106, 16);
		
		JTextField txtfloorNo = new JTextField(40);
		txtfloorNo.setBounds(12, 103, 358, 30);
		
		JLabel lblroomNo = new JLabel("Room No");
		lblroomNo.setBounds(12, 141, 106, 16);
		
		JTextField txtroomNo = new JTextField(40);
		txtroomNo.setBounds(12, 165, 358, 30);
		
		JLabel lblSensorStatus = new JLabel("Sensor Status");
		lblSensorStatus.setBounds(12, 200, 106, 16);
	
		JComboBox<String> sensorStatus = new JComboBox<String>();
		sensorStatus.setBounds(12, 225, 358, 30);
		
		sensorStatus.addItem("A");
		sensorStatus.addItem("D");
		
		JButton register  = new JButton(btnName);
		register.setBounds(12, 333, 358, 30);
		
		frame.setSize(400,430);
		frame.getContentPane().add(lblsensorName);
		frame.getContentPane().add(txtsensorName);
		frame.getContentPane().add(lblfloorNo);
		frame.getContentPane().add(txtfloorNo);
		frame.getContentPane().add(lblroomNo);
		frame.getContentPane().add(txtroomNo);
		frame.getContentPane().add(lblSensorStatus);
		frame.getContentPane().add(sensorStatus);;
		frame.getContentPane().add(register);
		
		frame.getContentPane().setLayout(null);
		frame.setLocationRelativeTo(null);
		frame.setVisible(true);
		
		if(sensor != null) {
			txtsensorName.setText(sensor.getSensorName());
			txtfloorNo.setText(sensor.getFloorNo());
			txtroomNo.setText(sensor.getRoomNo());
			sensorStatus.setSelectedItem(sensor.getSensorStatus());
		}
		
		register.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent arg0) {
				if(txtsensorName.getText().trim().length() > 0 &&  txtfloorNo.getText().trim().length() > 0 && 
						txtroomNo.getText().trim().length() > 0 ) {

					if(sensor != null) {
						try {
							sensorService.EditSensor(sensor.getSensorId(), txtsensorName.getText().trim(), txtfloorNo.getText().trim(), txtroomNo.getText().trim(), 
									sensorStatus.getSelectedItem().toString(), loginUser.getToken());
							frame.setVisible(false);
							dashboard();
						} catch (RemoteException e) {
							e.printStackTrace();
						}
					}
					else {
						try {
							sensorService.RegisterSensor(txtsensorName.getText().trim(), txtfloorNo.getText().trim(), txtroomNo.getText().trim(), 
									sensorStatus.getSelectedItem().toString(), loginUser.getToken());
							frame.setVisible(false);
							dashboard();
						} catch (RemoteException e) {
							e.printStackTrace();
						}
					}
					
				}
				else {
					JOptionPane.showConfirmDialog(null, 
			                "Please Fill All Fields !", "Error Message", JOptionPane.DEFAULT_OPTION, JOptionPane.ERROR_MESSAGE);
				}
			}
		});	
	}

}
