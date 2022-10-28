import React, { Component } from 'react';
import classes from './MyNewComponent.css';

class PersonComponent extends Component {

    //declared constructor to override the default constructor so that we can initially set the state object

    constructor(props){
        //gives us all the functionality of the default constructor that comes with Component
        super(props);
        //creates state for this component
        this.state = {
            age: this.props.age
        }
    }

    increaseAge = () => {
        this.setState(
            {age: this.state.age + 1}
            , () => console.log(this.state.age))
    }


    render(){
        return(
            <div className={classes.card}>
                <fieldset>
                    <h1>{this.props.firstName}, {this.props.lastName}</h1>
                    <p>Age: {this.state.age}</p>
                    <p>Hair Color:{this.props.hairColor}</p>
                    <button onClick={() => this.increaseAge()}>Birthday Button for {this.props.firstName}</button>
                </fieldset>
            </div>
        )
    }
}

export default PersonComponent;