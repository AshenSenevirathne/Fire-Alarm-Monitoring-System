import React,{Component} from "react";
import Sensor from "./Sensor/Sensor";
import './Style/LoginStyle.css';
import './Style/StyleH.css';

export default class Home extends Component{
    constructor(props) {
        super(props);
        this.state = {
            content: []     //use for get data from API
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
        const response = await fetch('http://localhost:44332/api/sensor/GetSensorDetails', config)  //send token in the url header and get the response from API
        const content = await response.json()   //response convert in to json object

        this.setState({
            content: content.data
        });
        //console.log(this.state.content);
    }
    render() {
        const { content } = this.state;
        console.log(content);
        return (
            <div id="Body">
                <div className="header jumbotron">
                    <h1 >Fire Alarm Application</h1>
                    <h5>It is not death, it is dying that alarms me.</h5>
                </div>
                <div className="row m-5" id="Sensor">
                    {content.map((item, index) => {
                        return <Sensor key = {index}
                                       sensorName = {item.sensorName}
                                       co2Level = {item.co2Level}
                                       smokeLevel = {item.smokeLevel}
                                       floorNo = {item.floorNo}
                                       roomNo = {item.roomNo}
                                       sensorStatus = {item.sensorStatus}
                        />;
                    })}
                </div>
            </div>
        );
    }
}