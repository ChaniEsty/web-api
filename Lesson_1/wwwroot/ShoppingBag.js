function loadShoppingBag()
{ 
    const orderItems = JSON.parse(sessionStorage.getItem("bag"));
    console.log("ssss", orderItems)
    drowOrderItems(orderItems)
}
function drowOrderItems(orderItems) {
    console.log("ss", orderItems)
    orderItems.forEach(orderItem => document.querySelector('#items').appendChild(designOrderItems(orderItem)))
        
}
function designOrderItems(orderItem)
{
    const template = document.querySelector('#orderItem');
    const OrderItem = template.content.cloneNode(true);
   // templateOrderItem.querySelector('#descriptionColumn')
    return OrderItem

}

//<template id="orderItem">
//    <tr class="item-row">
//        <td class="imageColumn"><a rel="lightbox" href="#"><div class="image"></div></a></td>
//        <td class="descriptionColumn"><div><h3 class="itemName"></h3><h6><p class="itemNumber"></p><a href="#">לפרטים נוספים</a></h6></div></td>
//        <td class="availabilityColumn"><div><h3 class="itemName">במלאי</h3></div></td>
//        <td class="totalColumn delete"><div class="expandoHeight" style="height: 99px;"><p class="price"></p><a href="#" title="לחצו כאן כדי להסיר את פריט זה" class="Hide DeleteButton showText">הסרת פריט</a></div></td>
//    </tr>
//</template>
