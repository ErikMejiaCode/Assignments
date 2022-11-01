import React, { useReducer } from "react";
import styles from "./ReducerComponent.module.css";

const initialState = {
    firstName: {
        value: '',
        error: null
    },
    lastName: {
        value: '',
        error: null
    },
    email: {
        value: '',
        error: null
    }
};


const reducer = (state, action) => {
    return {
        ...state,
        [action.type]: action.payload,
    }
}

const Form = () => {
    const [state, dispatch] = useReducer(reducer, initialState);

    function handleChange(e) {
        const { name, value } = e.target;
        dispatch({
            type: name,
            payload: value
        });
    }

    return (
        <div className={styles.container}>
            <form className={styles.form}>
                <label>First Name</label>
                <input
                    type="text"
                    name="firstName"
                    value={state.firstName.value}
                    onChange={handleChange}
                />
                <label>Last Name</label>
                <input
                    type="text"
                    name="lastName"
                    value={state.lastName.value}
                    onChange={handleChange}
                />
                <label>Email</label>
                <input
                    type="email"
                    name="email"
                    value={state.email.value}
                    onChange={handleChange}
                />
                <button>Send</button>
            </form>
        </div>
    );
};

export default Form;