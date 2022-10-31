import React, {useState} from "react";
import style from "./NewFormComponent.module.css";

const NewFormComponent = props => {

    const [formData, setFormData] = useState({
        firstName: "",
        lastName: "",
        email: "",
        password: "",
        confirmPassword: ""
    })

    const [formDataErrors, setFormDataErrors] = useState({
        firstNameErrors: "",
        lastNameErrors: "",
        emailErrors: "",
        passwordErrors: "",
        confirmPasswordErrors: ""
    });


    return (
        <>
            <fieldset>
                <legend>Form</legend>
                <form action="" className={style.form}>
                    <div className={style.formItem}>
                        <label>First Name:</label>
                        <input type="text" placeholder="search" name="firstName" onChange={(e) => {
                            if (e.target.value.length < 2 && e.target.value.length !== 0) {
                                setFormDataErrors({
                                    ...formDataErrors,
                                    firstNameErrors : "First name must be at least 2 characters"
                                })
                            }else {
                                setFormDataErrors({
                                    ...formDataErrors,
                                    firstNameErrors : ""
                                })
                            }
                        }}/>
                        <p>{formDataErrors.firstNameErrors}</p>
                    </div>
                    <div className={style.formItem}>
                        <label>Last Name:</label>
                        <input type="text" placeholder="search" name="lastName" onChange={(e) => {
                            if (e.target.value.length < 2 && e.target.value.length !== 0) {
                                setFormDataErrors({
                                    ...formDataErrors,
                                    lastNameErrors : "Last name must be at least 2 characters"
                                })
                            }else {
                                setFormDataErrors({
                                    ...formDataErrors,
                                    lastNameErrors : ""
                                })
                            }
                        }}/>
                        <p>{formDataErrors.lastNameErrors}</p>
                    </div>
                    <div className={style.formItem}>
                        <label>Email:</label>
                        <input type="text" placeholder="search" name="email" onChange={(e) => {
                            if (e.target.value.length < 5) {
                                setFormDataErrors({
                                    ...formDataErrors,
                                    emailErrors : "Email must be at least 5 characters"
                                })
                            } else {
                                    setFormDataErrors({
                                        ...formDataErrors,
                                        emailErrors : ""
                                    })
                                }    
                        }}/>
                        <p>{formDataErrors.emailErrors}</p>
                    </div>
                    <div className={style.formItem}>
                        <label>Password:</label>
                        <input type="password" placeholder="search" name="password" onChange={(e) => {
                            if (e.target.value.length < 8) {
                                setFormDataErrors({
                                    ...formDataErrors,
                                    passwordErrors : "Password must be at least 8 characters"
                                })
                            }
                            else {
                                setFormDataErrors({
                                    ...formDataErrors,
                                    passwordErrors : ""
                                })
                            }
                        }}/>
                        <p>{formDataErrors.passwordErrors}</p>
                    </div>
                    <div className={style.formItem}>
                        <label>Confirm Password:</label>
                        <input type="password" placeholder="search" name="confirmPassword" onChange={(e) => {
                            if (e.target.value.length < 8) {
                                setFormDataErrors({
                                    ...formDataErrors,
                                    confirmPasswordErrors : "Confirm password must be at least 8 characters"
                                })
                            }
                            else {
                                setFormDataErrors({
                                    ...formDataErrors,
                                    confirmPasswordErrors : ""
                                })
                            }
                        }}/>
                    </div>
                    <p>{formDataErrors.confirmPasswordErrors}</p>
                    <div>
                        {
                            (formData.password !== formData.confirmPassword) ? <p>Passwords must match</p> : ""
                        }
                    </div>
                    <button>Submit</button>
                </form>
            </fieldset>
        </>
    )
}

export default NewFormComponent;
