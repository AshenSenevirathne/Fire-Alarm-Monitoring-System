import React,{Component, useState, useEffect} from "react";
import './Login/Style.scss';
import './StyleH.css';
import axios from 'axios'

export default class Home extends Component{

    constructor(props) {
        super(props);
        this.state = {
            content: []
        };

        this.fetchData = this.fetchData.bind(this);  //bind function
    }

     componentWillMount() {
         this.fetchData();
         setInterval(this.fetchData, 40000); //Refresh every 40 seconds.
     }

     //This function is use to get sensor details from API
     async fetchData(){
        const {token} = this.props;

        const config = {
            headers: { Authorization: `Bearer ${token}` }
        };

        if (typeof fetch == 'undefined') return
        const response = await fetch('http://localhost:44332/api/sensor/GetSensorDetails', config)  //get request with token
        const content = await response.json()   //response convert in to json object

        this.setState({
            content: content.data
        });
        //console.log(this.state.content);

    }

    render() {

        const { content } = this.state;

        return (
            <div id="Body">
                <div className="header jumbotron">
                    <h1 >Fire Alarm Application</h1>
                    <h5>It is not death, it is dying that alarms me.</h5>
                </div>
                <div className="row m-5" id="Sensor">
                    {content.map((item, index) => (
                        <div className="col-md-4" key={index}>
                            <div className="m-5" >
                                <div className=
                                         {(item.co2Level > 5 || item.smokeLevel > 5) ? "card text-white bg-danger mb-3" : "card text-white bg-success mb-3"}>
                                    <div className={(item.co2Level > 5 || item.smokeLevel > 5) ?"card-header border-danger": "card-header border-success"}  id="cardHeader"><h4 className="card-title">{item.sensorName}</h4></div>
                                    <div className="card-body " id="cardBody">
                                        <p className="card-text">Floor No : {item.floorNo}</p>
                                        <p className="card-text">Room No : {item.roomNo}</p>
                                        <p className="card-text">Smoke Level : {item.smokeLevel}</p>
                                        <p className="card-text">CO2 level : {item.co2Level}</p>
                                    </div>
                                    <div className={(item.co2Level > 5 || item.smokeLevel > 5) ? "card-footer border-danger": "card-footer border-success"} id="footer">
                                        <span>{(item.sensorStatus == "A") ? "Status : Active":"Status : Inactive"}</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ))}

                </div>

            </div>
        );
    }
}