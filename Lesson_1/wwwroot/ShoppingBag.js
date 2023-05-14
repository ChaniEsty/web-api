function loadShoppingBag()
{ 
    const orderItems = JSON.parse(sessionStorage.getItem("basket"));
    console.log("ssss", orderItems)
    buildOrderItems(orderItems);
}

function buildOrderItems(orderItems) {
    orderItems.forEach(orderItem => {
        const template = document.querySelector('#orderItem');
        const OrderItem = template.content.cloneNode(true);
        const desc = OrderItem.querySelector('.descriptionColumn');
        console.log(orderItem);
        desc.querySelector('h3').innerText = orderItem.name;
        OrderItem.querySelector('.image img').src=`img/${orderItem.image}`
        document.querySelector('#items').appendChild(OrderItem);
    });

}

//<template id="orderItem">
//    <tr class="item-row">
//        <td class="imageColumn"><a rel="lightbox" href="#"><div class="image"></div></a></td>
//        <td class="descriptionColumn"><div><h3 class="itemName"></h3><h6><p class="itemNumber"></p><a href="#">לפרטים נוספים</a></h6></div></td>
//        <td class="availabilityColumn"><div><h3 class="itemName">במלאי</h3></div></td>
//        <td class="totalColumn delete"><div class="expandoHeight" style="height: 99px;"><p class="price"></p><a href="#" title="לחצו כאן כדי להסיר את פריט זה" class="Hide DeleteButton showText">הסרת פריט</a></div></td>
//    </tr>
//</template>
