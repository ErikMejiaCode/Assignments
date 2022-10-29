import React, { Component } from "react";
import classes from "./Main.module.css";

class Main extends Component {

    render() {
        return (
            <main className={classes.main}>
                <div className="mainContent">
                {this.props.children}
                </div>
            </main>
        )
    }
}

export default Main;