import React from "react"
import { useParams } from "react-router-dom"

export const Color = () => {
    const {num, color, background} = useParams();

    return(
        <div className="text-center" style = {{height: "100px", color: color, backgroundColor: background}}>   
            <h1>The word is: {num}</h1>
        </div>
    )
}