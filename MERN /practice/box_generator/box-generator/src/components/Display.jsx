import React from 'react'

const Display = ({ boxes }) => {
    return (
        <div>
            {boxes.map((color, index) => {
                return <div style={{ backgroundColor: color, width: "150px", height: "150px", display: "inline-block", marginLeft: "15px" }} key={index}>{color}</div>

            })}
        </div>
    )
}

export default Display