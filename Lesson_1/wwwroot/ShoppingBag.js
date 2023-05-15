const loadShoppingBag=()=>
{ 
    const orderItems = JSON.parse(sessionStorage.getItem("basket"));
    console.log("ssss", orderItems)
    totalSumOrders(orderItems);
    buildOrderItems(orderItems);
}
const addToCart = (product) => {
    product.quantity = 1;
    basket = JSON.parse(sessionStorage.getItem('basket') || '[]');
    const bagFiltered = basket.filter(p => p.id == product.id);
    if (bagFiltered.length == 0) {
        product.quantity = 1;
        basket.push(product);
    }
    else {
        bagFiltered[0].quantity++;
    }
    totalSumOrders(basket);
    sessionStorage.setItem("basket", JSON.stringify(basket));
    removeProducts();
    loadShoppingBag();
}
const removeFromCart = (product) => {
    basket = JSON.parse(sessionStorage.getItem('basket') || '[]');
    const bagFiltered = basket.filter(p => p.id == product.id);
    if (bagFiltered[0].quantity==1) {
        basket = basket.filter(p => p.id != product.id)
    }
    else {
        bagFiltered[0].quantity--;
    }
    totalSumOrders(basket);
    sessionStorage.setItem("basket", JSON.stringify(basket));
    removeProducts();
    loadShoppingBag();
}

const totalSumOrders=(basket)=> {
    let totalSumOrders = 0
    basket.forEach(p => totalSumOrders += p.quantity * p.price);
    document.querySelector('#totalAmount').innerHTML = totalSumOrders;
}
const removeProducts = () => {
    document.querySelectorAll('.item-row').forEach(item => document.querySelector('#items').removeChild(item));
}
const buildOrderItems=(orderItems) =>{
    orderItems.forEach(orderItem => {
        const template = document.querySelector('#orderItem');
        const OrderItem = template.content.cloneNode(true);
        const desc = OrderItem.querySelector('.descriptionColumn');
        console.log(orderItem);
        desc.querySelector('h3').innerText = orderItem.name;
        OrderItem.querySelector('.img').src = `img/${orderItem.image}`
        OrderItem.querySelector('.description').innerText = orderItem.description;
        OrderItem.querySelector('.quantity').innerText = orderItem.quantity;
        OrderItem.querySelector('.price').innerText = `${orderItem.price * orderItem.quantity}₪`;
        OrderItem.querySelector('.add').addEventListener('click', () => addToCart(orderItem));
        OrderItem.querySelector('.remove').addEventListener('click', () => removeFromCart(orderItem));
        document.querySelector('#items').appendChild(OrderItem);
    });

}

const placeOrder = () => {
    const basket = JSON.parse(sessionStorage.getItem('basket')||'[]');
    const orderItems = basket.map(p => {
        return {
            productId:p.id,
            quantity:p.quantity
        }
    })
    console.log(orderItems);
    //const sum = document.querySelector('#totalAmount').innerHTML;
    //const user = JSON.parse(sessionStorage.getItem('user'));
    const order = {
        userId: user.id,
        orderSum: sum,
        orderItems:orderItems
    }
    const res=fetch('api/Orders', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(order)
        })
}  