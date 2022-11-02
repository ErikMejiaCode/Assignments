import React, {useState} from 'react'

const Form = (props) => {

    //state for the input form field
    const [colorName, setColorName] = useState("");

    //form submission handler function
    const submitHandler = (e) => {
        e.preventDefault();
        props.addBoxColor({color: colorName});
    //clear whats in state
    setColorName("");
    }

    const customFunction = (e) => {
        setColorName(e.target.value);
    }

    return (
        <div>

            <form onSubmit={submitHandler}>

            Name: <input type="color" onChange={customFunction} value={colorName}/> <button>Add</button>
            </form>
            
            <p></p>
        </div>
    )
}

export default Form