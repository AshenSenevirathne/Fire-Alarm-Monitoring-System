package com.rmiserver.model.user;

/*
 * 	@Author 		:	Ashen Senevirathne
 *	@Class Name		:	User
 *	@Description	:	This class represent the User object.
 * 
*/

public class User {

	// Attributes of the User object
	private String userId;
	private String userName;
	private String token;
	private String userMobile;
	private String userEmail;
	private String userRole;
	
	// Constructors
	public User() { }

	public User(String userId, String userName, String token, String userMobile, String userEmail, String userRole) {
		super();
		this.userId = userId;
		this.userName = userName;
		this.token = token;
		this.userMobile = userMobile;
		this.userEmail = userEmail;
		this.userRole = userRole;
	}

	// Getters and Setters
	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

	public String getUserName() {
		return userName;
	}

	public void setUserName(String userName) {
		this.userName = userName;
	}

	public String getToken() {
		return token;
	}

	public void setToken(String token) {
		this.token = token;
	}

	public String getUserMobile() {
		return userMobile;
	}

	public void setUserMobile(String userMobile) {
		this.userMobile = userMobile;
	}

	public String getUserEmail() {
		return userEmail;
	}

	public void setUserEmail(String userEmail) {
		this.userEmail = userEmail;
	}

	public String getUserRole() {
		return userRole;
	}

	public void setUserRole(String userRole) {
		this.userRole = userRole;
	}

}
