import React from 'react'

const Box = (props) => {
    return (
        <div style={{ backgroundColor: props.boxObj.color, width: "150px", height: "150px", display: "inline-block", marginLeft: "15px", marginTop: "10px" }}>{props.boxObj.color}</div>
    )
}

export default Box