import React, { Component } from 'react';
import classes from './MyNewComponent.css';

class PersonComponent extends Component {
    render(){
        return(
            <div className={classes.card}>
                <div className={classes.content}>
                    <h1>{this.props.firstName}, {this.props.lastName}</h1>
                    <p>Age: {this.props.age}</p>
                    <p>Hair Color:{this.props.hairColor}</p>
                </div>
            </div>
        )
    }
}

export default PersonComponent;