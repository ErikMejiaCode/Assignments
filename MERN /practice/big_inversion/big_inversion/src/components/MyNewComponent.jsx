// import React, { Component } from 'react';
import React from 'react';
import classes from './MyNewComponent.module.css';

//Functional Component
const PersonComponent = props => {
    return (
        <div className={classes.card}>
            <div className={classes.content}>
                <h1>{props.firstName}, {props.lastName}</h1>
                <p>Age: {props.age}</p>
                <p>Hair Color:{props.hairColor}</p>
            </div>
        </div>
    )
}

//class based component
// class PersonComponent extends Component {
//     render(){
//         return(
//             <div className={classes.card}>
//                 <div className={classes.content}>
//                     <h1>{this.props.firstName}, {this.props.lastName}</h1>
//                     <p>Age: {this.props.age}</p>
//                     <p>Hair Color:{this.props.hairColor}</p>
//                 </div>
//             </div>
//         )
//     }
// }


export default PersonComponent;