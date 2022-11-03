import React, {useState} from 'react'
import '../App.css';
import { useNavigate } from 'react-router-dom';

const Form = (props) => {

    const [selection, setSelection] = useState("people");
    const [id, setId] = useState();
    const navigate = useNavigate()

    const submitHandler = (e) => {
        e.preventDefault();

        navigate(`/${selection}/${id}`)
    }

    return (
        <div>
            <form onSubmit={submitHandler}>
                Search for: 
                <select onChange={ (e) => {
                    setSelection(e.target.value)
                }} value={selection}>
                    <option value="people">People</option>
                    <option value="planet">Planet</option>
                </select>
                ID: 
                <input type="number" onChange={(e) => {
                    setId(e.target.value)
                }} value={id}/>
                <button>Search</button>
            </form>
            <hr />
        </div>
    )
}

export default Form