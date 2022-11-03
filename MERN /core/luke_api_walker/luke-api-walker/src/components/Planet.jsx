import '../App.css';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { useNavigate } from "react-router-dom";
import axios from 'axios';

const Planet = (props) => {
    const [planet, setPlanet] = useState({});
    const { id } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        axios.get(`https://swapi.dev/api/planets/${id}`)
            .then((response) => {
                console.log(response.data)
                setPlanet(response.data);
            })
            .catch(error => console.log("ERROR!!", error))        
    }, [id])

    const goBack = () => {
        navigate(-1)
    }

    return (
        <div>
            
            <h1>{planet.name}</h1>
            <p>Climate: {planet.climate}</p>
            <p>Terrain: {planet.terrain}</p>
            <p>Surface Water: {planet.surface_water}</p>
            <p>Population: {planet.population}</p>
            <button onClick={goBack}>Go Back to Person</button>
        </div>
    )
}



export default Planet