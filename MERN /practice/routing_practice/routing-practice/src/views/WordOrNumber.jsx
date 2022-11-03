import React from "react";
import { useParams } from "react-router-dom";

export const WordOrNumber = (props) => {
    const {num} = useParams();
        
    return(
        <div className="text-center">
        {
            isNaN(num) ?
            <h1>The word is: {num}</h1> :
            <h1>The number is: {num}</h1>
        }
        </div>
    )
}