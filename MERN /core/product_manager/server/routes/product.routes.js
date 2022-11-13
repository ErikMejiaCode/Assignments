const express = require('express')

const {
    handleCreateProduct,
    handleGetAllProducts,
    handleGetProductById,
    handleDeleteProductByID,
    handleUpdateProductById
} = require ('../controllers/product.controller')

const router = express.Router();

router.get('/', handleGetAllProducts)
router.get('/:id', handleGetProductById)
router.post('/', handleCreateProduct)
router.put('/:id', handleUpdateProductById)
router.delete('/:id', handleDeleteProductByID)

module.exports = {productRouter : router}