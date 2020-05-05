import React, {Component} from "react";
import '../Style/LoginStyle.css';

export default class Login extends Component{

    render() {
        const {email, password, onChangeHandlerEmail, onChangeHandlerPwd, onSubmitHandler} = this.props;

        return(
            <div className="wrapper fadeInDown" style={{marginTop: "8%"}}>
                <div id="formContent">

                    <h2> Sign In </h2><br/><br/>
                    <p className="login-text">
                            <span className="fa-stack fa-lg">
                              <i className="fa fa-circle fa-stack-2x"></i>
                              <i className="fa fa-lock fa-stack-1x"></i>
                            </span>
                    </p><br/><br/>
                    <form onSubmit={onSubmitHandler}>
                        <input name="email" onChange={onChangeHandlerEmail} type="email" className="login-username" required={true}
                               placeholder="Email" value={email}/>
                        <input name="password" onChange={onChangeHandlerPwd} type="password" className="login-password" required={true}
                               placeholder="Password" value={password}/>

                        <input type="submit" name="Login" value="Login" className="login-submit" style={{marginTop: "10%"}}/>
                    </form>

                </div>
            </div>
        );
    }
}