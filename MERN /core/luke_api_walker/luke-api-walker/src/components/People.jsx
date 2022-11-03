import '../App.css';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import { Link } from 'react-router-dom'

const People = (props) => {

    const [person, setPerson] = useState({});
    const [homeworld, setHomeworld] = useState({});
    const { id, } = useParams();

    useEffect(() => {
        axios.get(`https://swapi.dev/api/people/${id}`)
            .then((response) => {
                console.log(response.data)
                setPerson(response.data);
            })
            .catch(error => console.log("ERROR!!", error))        
    }, [id])

    useEffect (() => {
        axios.get(`https://swapi.dev/api/planets/${id}/`)
            .then((response) => {
                console.log(response.data)
                setHomeworld(response.data);
            })
            .catch(error => console.log("ERROR!!", error))
        }, [id])

    return (
        
        <div>
            <h1>{person.name}</h1>
            <p>Height: {person.height}</p>
            <p>Mass: {person.mass}</p>
            <p>Hair Color: {person.hair_color}</p>
            <p>Skin Color: {person.skin_color}</p>
            <p>Homeworld: <Link to={`/planet/${id}`}>{homeworld.name}</Link></p>
            
        </div>
    )
}

export default People;