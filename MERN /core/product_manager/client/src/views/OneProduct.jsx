import React, {useEffect, useState} from 'react'
import { useParams } from 'react-router-dom'
import axios from 'axios'
import {useNavigate} from 'react-router-dom';


export const OneProduct = (props) => {

    //Grab the URL variable :id
    const {id} = useParams();

    const navigate = useNavigate();

    const [thisProduct, setThisProduct] = useState({})

    useEffect(() => {
        axios.get(`http://localhost:8000/api/products/${id}`)
            .then(res => {
                console.log("One Product Data: ", res.data)
                setThisProduct(res.data)
            })
            .catch(err => {
                console.log("Error: ", err)
            })
    }, [id])


    const handleDelete = (productId) => {
        axios.delete(`http://localhost:8000/api/products/${id}`)
            .then(res => {
                console.log("Delete Product Data: ", res.data)
                navigate('/products')
            })
            .catch(err => console.error(err));
    }

    return (
        <div className='text-center'>
            <h3>{thisProduct.title}</h3>
            <p>${thisProduct.price}</p>
            <p>{thisProduct.description}</p>
            <button className='btn btn-danger btn-sm mb-2' onClick={(e) => {
                                handleDelete(thisProduct._id)
                            }} >Delete</button>
        </div>
    )
}

