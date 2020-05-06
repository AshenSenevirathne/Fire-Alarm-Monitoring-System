package com.rmiclient.components;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.rmi.RemoteException;

import javax.jws.soap.SOAPBinding.Use;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPasswordField;
import javax.swing.JTextField;

import com.google.gson.Gson;
import com.rmiserver.model.user.User;
import com.rmiserver.service.ISensorServices;
import com.rmiserver.service.IUserServices;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Class Name		:	LoginUI
 *	@Description	:	Handle the Login function
 * 
*/

public class LoginUI {
	
	// Attributes of LoginUI
	private ISensorServices sensorService;
	private IUserServices userService;
	
	// Constructor
	public LoginUI(ISensorServices sensorService, IUserServices userService) {
		
		this.sensorService = sensorService;
		this.userService = userService;

		JFrame frame = new JFrame("Fire Alaram Monitoring");
		
		JLabel lblUserEmail = new JLabel("Enter User Email");
		lblUserEmail.setBounds(12, 15, 358, 16);
		
		JTextField txtUserEmail = new JTextField(40);
		txtUserEmail.setBounds(12, 44, 358, 30);
		
		JLabel lblUserPassword = new JLabel("Enter User Password");
		lblUserPassword.setBounds(12, 87, 358, 16);
		
		JPasswordField txtUserPassword = new JPasswordField(40);
		txtUserPassword.setBounds(12, 116, 358, 30);
		
		JButton login  = new JButton("Login");
		login.setBounds(114, 159, 150, 30);
		
		frame.setSize(400,250);
		frame.getContentPane().add(lblUserEmail);
		frame.getContentPane().add(txtUserEmail);
		frame.getContentPane().add(lblUserPassword);
		frame.getContentPane().add(txtUserPassword);
		frame.getContentPane().add(login);
		frame.getContentPane().setLayout(null);
		frame.setLocationRelativeTo(null);
		frame.setVisible(true); 
		
		login.addActionListener(new ActionListener() {
			
			@SuppressWarnings("deprecation")
			@Override
			public void actionPerformed(ActionEvent e) {
				if(txtUserEmail.getText().length() == 0 || txtUserPassword.getText().length() == 0) {
					JOptionPane.showConfirmDialog(null, 
			                "Please enter valid user email and password!", "Error Message", JOptionPane.DEFAULT_OPTION, JOptionPane.ERROR_MESSAGE);
				}
				else {

					try {
						String apiResult = userService.SignIn(txtUserEmail.getText().trim(), txtUserPassword.getText().trim());
						User loginUser = new Gson().fromJson(apiResult, User.class);
						if(loginUser != null) {
							frame.setVisible(false);
							new Dashboard(sensorService, loginUser);
						}
						else {
							JOptionPane.showConfirmDialog(null, 
					                "Please enter valid user email and password!", "Error Message", JOptionPane.DEFAULT_OPTION, JOptionPane.ERROR_MESSAGE);
						}
					} catch (RemoteException e1) {
						e1.printStackTrace();
					}
					
				}
			}
		});
	}
	
}
