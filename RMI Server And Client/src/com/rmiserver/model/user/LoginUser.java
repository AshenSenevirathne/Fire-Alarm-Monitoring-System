package com.rmiserver.model.user;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Class Name		:	LoginUser
 *	@Description	:	This class represent the LoginUser object.
 * 
*/

public class LoginUser {

	// Attributes of the LoginUser object
	private String userEmail;
	private String userPassword;
	
	 // Constructors
	public LoginUser() {}

	public LoginUser(String userEmail, String userPassword) {
		super();
		this.userEmail = userEmail;
		this.userPassword = userPassword;
	}

	// Getters and Setters
	public String getUserEmail() {
		return userEmail;
	}

	public void setUserEmail(String userEmail) {
		this.userEmail = userEmail;
	}

	public String getUserPassword() {
		return userPassword;
	}

	public void setUserPassword(String userPassword) {
		this.userPassword = userPassword;
	}	
	
}
