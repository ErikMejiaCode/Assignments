import React, { Component } from "react";
import classes from "./Main.module.css";

class Header extends Component {

    render() {
        return (
            <header className={classes.header}>
                <h2>Header</h2>
            </header>
        )
    }
}

export default Header;