const express = require('express');
const cookieParser = require('cookie-parser');

const app = express();
const products = require('./product-test-data');

// Middleware
app.use(cookieParser());
app.use(express.json());

// Endpoints

// Load all site's products
app.get('/api/products', (req, res) => {
    // Send all products as JSON data
    res.json(products);
});

// Add product to user's cart
app.post('/api/cart', (req, res) => {
    const productId = req.body.id;

    if (!productId) {
        return res.status(400).send('Product ID is required');
    }

    // Retrieve the current cart from cookies or initialize an empty array
    let cart = req.cookies.cart ? JSON.parse(req.cookies.cart) : [];

    // Add the product ID to the cart
    cart.push(productId);

    // Update the cart in the cookies
    res.cookie('cart', JSON.stringify(cart), { httpOnly: true });

    res.status(200).send('Product added to cart');
});

// Load list of products in user's cart
app.get('/api/cart', (req, res) => {
    // Retrieve the current cart from cookies or initialize an empty array
    const cart = req.cookies.cart ? JSON.parse(req.cookies.cart) : [];

    // Map cart IDs to their corresponding product details
    const cartProducts = cart.map(productId => {
        return products.find(product => product.id === productId);
    }).filter(product => product); // Filter out any invalid product IDs

    // Send the list of products in the cart as JSON
    res.json(cartProducts);
});

// Start the server
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
});
