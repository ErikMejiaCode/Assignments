import React, { useState } from 'react'
// import { useNavigate } from 'react-router-dom'
import { AllProducts } from './AllProducts'

import { createProduct } from '../services/internalApiServices'

export const NewProduct = (props) => {

    const [formData, setFormData] = useState({
        title: "",
        price: "",
        description: "",
    })

    const [errors, setErrors] = useState([])


    const handleFormSubmit = (e) => {
        e.preventDefault()
        createProduct(formData)
            .then((data) => {
                console.log("New Product Data: ", data)
                // navigate('/products')
                setFormData({
                    title: "",
                    price: "",
                    description: "",
                })
            })
            .catch((error) => {
                console.log("Error: ", error)
                setErrors(error.response?.data?.errors)
            })
    }


    const handleFormChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        })
    }


    return (
        <div className="w-75 p-4 rounded mx-auto shadow">
            <form
                onSubmit={(e) => {
                    handleFormSubmit(e)
                }}>
                <div className='form-group'>
                    <label className='h6'>Title</label>
                    <input
                        onChange={handleFormChange}
                        type="text"
                        name='title'
                        value={formData.title}
                        className="form-control"
                        placeholder='Product name...'
                    />
                    {
                        errors?.title && (
                            <span className="text-danger">{errors.title?.message}</span>
                        )
                    }
                </div>
                <div className='form-group'>
                    <label className='h6 mt-3'>Price</label>
                    <input
                        onChange={handleFormChange}
                        type="text"
                        name='price'
                        value={formData.price}
                        className="form-control"
                        placeholder='Product price...'
                    />
                    {
                        errors?.price && (
                            <span className="text-danger">{errors.price?.message}</span>
                        )
                    }
                </div>
                <div className='form-group'>
                    <label className='h6 mt-3'>Description</label>
                    <textarea
                        onChange={handleFormChange}
                        type="text"
                        name='description'
                        value={formData.description}
                        className="form-control"
                        placeholder='Product description...'
                    />
                    {
                        errors?.description && (
                            <span className="text-danger">{errors.description?.message}</span>
                        )
                    }
                </div>
                <div className='text-center'>
                    <button className='btn btn-primary mt-3' >Create</button>
                </div>
            </form>
            <hr />
            <AllProducts />
        </div>
    )
}

