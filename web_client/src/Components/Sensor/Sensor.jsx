import React,{Component} from "react";
import '../Style/StyleH.css';

export default class Sensor extends Component{

    render() {
        const {sensorName, co2Level, smokeLevel, floorNo, roomNo, sensorStatus} = this.props;
        let color = '';
        ( co2Level > 5 || smokeLevel > 5) ? color = "danger": color = "success";    //Check whether co2level or smokeLevel grater 5

        return (
            <div className="col-md-4">
                <div className="m-5" >
                    <div className={ `card text-white bg-${color} mb-3`}>
                        <div className={`card-header border-${color}`}  id="cardHeader"><h4 className="card-title">{sensorName}</h4></div>
                        <div className="card-body " id="cardBody">
                            <p className="card-text">Floor No : {floorNo}</p>
                            <p className="card-text">Room No : {roomNo}</p>
                            <p className="card-text">Smoke Level : {smokeLevel}</p>
                            <p className="card-text">CO2 level : {co2Level}</p>
                        </div>
                        <div className={`card-footer border-${color}`} id="footer">
                            <span>{(sensorStatus == "A") ? "Status : Active":"Status : Inactive"}</span>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}