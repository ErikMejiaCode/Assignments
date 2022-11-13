import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import axios from 'axios'
// import {useNavigate} from 'react-router-dom';
import { deleteProduct } from '../services/internalApiServices';

export const AllProducts = (props) => {

    // const navigate = useNavigate();

    const [products, setProducts] = useState([])

    useEffect(() => {
        axios.get('http://localhost:8000/api/products')
            .then(res => {
                console.log("All Products Data: ", res.data)
                setProducts(res.data)
            })
            .catch(error => {
                console.log("Error: ", error)
            })
    }, [])

    const handleDelete = (deleteId) => {
        deleteProduct(deleteId)
            .then((data) => {
                const filteredProducts = products.filter((product) => {
                    return product._id !== deleteId;
                })
                setProducts(filteredProducts)
            })
            .catch((error) => {
                console.log(error)
            })
    }

    return (
        <div className="w-75 mx-auto text-center">
            <h2 className='text-center'>All Products:</h2>
            {
                products.map((oneProduct, i) => {
                    return (
                        <div key={i} className='shadow mb-4 rounded border'>
                            <Link to={`/products/${oneProduct._id}`}>
                            <h4 className='text-center'>{oneProduct.title}</h4>
                            </Link>
                            <p className='text-center'>Price: ${oneProduct.price}</p>
                            <p className='text-center'>Description: {oneProduct.description}</p>
                            <Link 
                            to={`/products/edit/${oneProduct._id}`}
                            className='btn btn-primary btn-sm mb-2'
                            >Edit</Link> &nbsp;
                            <button className='btn btn-danger btn-sm mb-2' onClick={(e) => {
                                handleDelete(oneProduct._id)
                            }} >Delete</button>
                        </div>
                    )
                })
            }
        </div>
    )
}

