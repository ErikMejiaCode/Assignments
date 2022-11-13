const {
    createProduct,
    getAllProducts,
    getProductById,
    deleteProductById,
    getProductByIdAndUpdate
} = require('../services/product.service')

//Create Product 
const handleCreateProduct = async (req, res) => {
    console.log('controller: handleCreateProduct, req.body:', req.body);
    try{
        const product = await createProduct(req.body);
        return res.json(product)
    } catch(error) {
        return res.status(400).json(error)
    }
}

//Get all Products 
const handleGetAllProducts = async (req, res) => {
    console.log('controller: handleGetAllProducts');
    try{
        const products = await getAllProducts();
        return res.json(products)
    } catch(error) {
        return res.status(400).json(error)
    }
}

//Get Product by ID 
const handleGetProductById = async (req, res) => {
    console.log('controller: handleGetProductById, req.params: ', req.params.id);
    try{
        const product = await getProductById(req.params.id);
        return res.json(product)
    } catch(error) {
        return res.status(400).json(error)
    }
}

//Delete Product by ID 
const handleDeleteProductByID = async (req, res) => {
    console.log('controller: handleDeleteProductByID, req.params: ', req.params.id);
    try{
        const product = await deleteProductById(req.params.id);
        return res.json(product)
    } catch(error) {
        return res.status(400).json(error)
    }
}

//Update Product by ID 
const handleUpdateProductById = async (req, res) => {
    console.log('controller: handleUpdateProductById, req.params: ', req.params.id, "\n req.body: ", req.body);
    try{
        const product = await getProductByIdAndUpdate(req.params.id, req.body);
        return res.json(product)
    } catch(error) {
        return res.status(400).json(error)
    }
}


module.exports = {
    handleCreateProduct,
    handleGetAllProducts,
    handleGetProductById,
    handleDeleteProductByID,
    handleUpdateProductById
}