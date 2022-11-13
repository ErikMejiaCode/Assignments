const mongoose = require("mongoose");

const ProductSchema = new mongoose.Schema(
    {
        title: {
            type: String,
            required: [true, "{PATH} is required"],
            minlength: [3, "{PATH} must be at least {MINLENGTH} characters long"]
        },
        price: {
            type: Number,
            required: [true, "{PATH} is required"],
            minlength: [1, "{PATH} must be at least {MINLENGTH} character long"]
        },
        description: {
            type: String,
            required: [true, "{PATH} is required"],
            minlength: [3, "{PATH} must be at least {MINLENGTH} characters long"]
        }
    }, {timestamps: true}
);



/*
Register schema with mongoose and provide a string to name the collection. 
This also returns a reference to our model that we can use for DB operations.
*/
const Product = mongoose.model("Product", ProductSchema);

module.exports = {Product : Product}