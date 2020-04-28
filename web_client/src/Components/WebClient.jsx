import React,{Component} from "react";
import Swal from "sweetalert2";
import Login from "./Login/Login";
import Home from "./Home";
import 'sweetalert2/src/sweetalert2.scss'
const axios = require('axios').default;

export default class extends Component{

    state = {
        email : '',
        password: '',
        showHome: false,
        loading: true,
        error: "",
        data: null,
        token: null
    };

    //handle change event for email
    onChangeHandlerEmail = (e) => {
        e.preventDefault();
        //const {name, value} = e.target;
        this.setState({
            email:e.target.value
        })
    };
    //handle change event for password
    onChangeHandlerPwd = (e) => {
        e.preventDefault();
        //const {name, value} = e.target;
        this.setState({
            password:e.target.value
        })
    };
    //handle click submit button
    onSubmitHandler = (e) =>{
        e.preventDefault();

        // Send a POST request
        axios
            .post("http://localhost:44332/api/user/SignIn", {
                userEmail: this.state.email.toString(),
                userPassword: this.state.password.toString()
            })
            .then(result => {
                console.log(result);
                this.setState({
                    data: result.data,
                    loading: false,
                    error: false,
                    token: result.data.data.token
                });
                if(this.state.loading == true){
                    return(
                        <div>
                            Loading...
                        </div>
                    )
                }
                if (this.state.data.status){    //check whether response status is true, then login success
                    this.setState({
                        showHome:true
                    })
                }
                else{
                    Swal.fire({     //when email or password was incorrect
                        icon: 'error',
                        title: 'Oops...',
                        text: 'There is no user related to the user credentials',
                    })
                };
            })
            .catch(err => console.error(err));
    };


    render() {

        return (
            <div>
                {this.state.showHome ?
                    <Home
                        token={this.state.token}
                    /> :
                    <Login
                        email={this.state.email}
                        password={this.state.password}
                        onChangeHandlerEmail={this.onChangeHandlerEmail}
                        onChangeHandlerPwd={this.onChangeHandlerPwd}
                        onSubmitHandler={this.onSubmitHandler}
                    />
                }

            </div>
        );
    }
}