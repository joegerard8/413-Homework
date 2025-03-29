import { useNavigate } from "react-router-dom";
// import './Cart.css';
import { CartItem } from "../types/CartItem";
import { useCart } from "../context/CartContext"; // importing the cart context to be able to add things to cart

// the cart page, shows all the items you have added to your cart and the quantity
function Cart() {
    const navigate = useNavigate();
    const { cart, removeFromCart, clearCart } = useCart(); // use cart object essentially, now we are importing aspects of it to be used
    return (
        <div>
            <h1>Your Cart</h1>
            <div>
                {/** says your cart is empty if there is nothing added, otherwise it maps out all the items in your cart and then calculates the total price and displays the quantity for each item */}
                {cart.length === 0 ? (
                    <p>Your cart is empty</p> 
                ) : (
                    <ul>
                        {cart.map((item: CartItem) => (
                            <li key={item.bookId}>
                                {item.title} - Quantity: {item.quantity}  Total Price: $({item.price * item.quantity})
                                <button className="btn btn-danger"onClick={() => removeFromCart(item.bookId)}>Remove</button>
                            </li>
                        ))}
                    </ul>
                )}
            </div>
            {/**cart items will be displayed here likely using a map function */}
            <button className="btn btn-danger" onClick={() => clearCart()}>Clear Cart</button>
            <button className="btn btn-success">Checkout</button>
            <button className="btn" onClick={() => navigate('/')}>Continue Shopping</button>

        </div>
    );
}

export default Cart;