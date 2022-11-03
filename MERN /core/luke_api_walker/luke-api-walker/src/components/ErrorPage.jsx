import React from 'react'

const divStyle = {
    borderRadius: "25px",
    // border: "1px solid grey",
    width: "70%",
    // marginTop: "30px",
    margin: "0 auto",
}

const ErrorPage = (props) => {
    return (
        <div>
            <img style={divStyle} src="https://i.kym-cdn.com/editorials/icons/mobile/000/004/391/Hello_there.jpg" width="400px" alt="no idea" />
            <h1>These aren't the droids you're looking for!</h1>
        </div>
    )
}

export default ErrorPage