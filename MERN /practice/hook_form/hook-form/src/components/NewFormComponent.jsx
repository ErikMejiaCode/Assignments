import React, {useState} from "react";
import style from "./NewFormComponent.module.css";

const NewFormComponent = props => {

    const [firstName, setFirstName] = useState("");
    const [lastName, setLastName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [password2, setPassword2] = useState("");
    
    const handleChange = (e) => {
        e.preventDefault();
        const newUser = { firstName, lastName, email, password };
        console.log("Welcome", newUser);
    } 



    return (
        <>
            <fieldset>
                <legend>Form</legend>
                <form onSubmit={ handleChange } className={style.form}>
                    <div className={style.formItem}>
                        <label>First Name:</label>
                        <input type="text" name="first" onChange={(e) => {
                            setFirstName(e.target.value);
                        }}/>
                    </div>
                    <div className={style.formItem}>
                        <label>Last Name:</label>
                        <input type="text" name="last" onChange={(e) => {
                            setLastName(e.target.value);
                        }}/>
                    </div>
                    <div className={style.formItem}>
                        <label>Email:</label>
                        <input type="text" name="email" onChange={(e) => {
                            setEmail(e.target.value);
                        }}/>
                    </div>
                    <div className={style.formItem}>
                        <label>Password:</label>
                        <input type="password" name="password" onChange={(e) => {
                            setPassword(e.target.value);
                        }}/>
                    </div>
                    <div className={style.formItem}>
                        <label>Confirm Password:</label>
                        <input type="password" name="password2" onChange={(e) => {
                            setPassword2(e.target.value);
                        }}/>
                    </div>
                    <button>Submit</button>
                </form>
            </fieldset>
            <fieldset>
                <legend>User Form Data</legend>
                <form className={style.form}>
                    <div>
                        <p>First Name: {firstName}</p>
                    </div>
                    <div>
                        <p>Last Name: {lastName}</p>
                    </div>
                    <div>
                        <p>Email: {email}</p>
                    </div>
                    <div>
                        <p>Password: {password}</p>
                    </div>
                    <div>
                        <p>Confirm Password: {password2}</p>
                    </div>
                </form>
            </fieldset>
        </>
    )
}

export default NewFormComponent;
