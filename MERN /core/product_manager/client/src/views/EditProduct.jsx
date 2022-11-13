import {useState, useEffect} from 'react'
import { useParams, useNavigate } from 'react-router-dom';
import { updateProduct, getProductById } from '../services/internalApiServices';

export const EditProduct = (props) => {

    const { id } = useParams();

    const [formData, setFormData] = useState({})

    const [errors, setErrors] = useState(null)

    const navigate = useNavigate()

    useEffect(() => {
        getProductById(id)
            .then((data) => {
                setFormData(data)
            })
            .catch((error) => {
                console.log(error)
            })
    }, [id])

    const handleFormSubmit = (e) => {
        e.preventDefault();
        for (const key in formData) {
            if (formData[key] === false) {
                delete formData[key]
            }
        }
        updateProduct(id, formData)
            .then((data) => {
                console.log('update product data:', data)
                navigate(`/products/${data._id}`)
            })
            .catch((error) => {
                console.log(error.response)
                setErrors(error.response?.data?.errors)
            })
    }

    const handleFormChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        })
    }

    if (formData === null) {
        return null;
    }


    return (
        <div className='w-75 p-4 rounded mx-auto shadow'>
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
                    <button className='btn btn-primary mt-3' >Update</button>
                </div>
            </form>
        </div>
    )
}

