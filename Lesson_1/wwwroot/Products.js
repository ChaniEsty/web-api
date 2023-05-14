
const loadData = async () => {
    await getCategories();
    await getProducts();
}
window.addEventListener("load", loadData)
const getCategories = async () => {
    const res = await fetch("api/categories");
    if (res.ok) {
        const categories =await res.json();
        buildCategory(categories);
        console.log(categories);
    }

}
const buildCategory = async (categories) => {
    categories.forEach(category => {
        const tmp = document.querySelector("#temp-category");
        const clone = tmp.content.cloneNode(true);
        clone.querySelector(".OptionName").innerText = category.name;
        clone.querySelector(".opt").id = category.id;
        document.getElementById("categoryList").appendChild(clone);
        console.log(category.name)

    })
}
const getProducts = async () => {
    const res = await fetch("api/products");
    if (res.ok) {
        const products =await res.json();
        console.log(products);
        buildProduct(products)
    }
}
const removeProducts = () => {
    productsToRemove = document.querySelectorAll(".card");
    productsToRemove.forEach(product => document.querySelector("#PoductList").removeChild(product));
}
const buildProduct = async (products) => {
    removeProducts();
    products.forEach(product => {
        const tmp = document.querySelector("#temp-card");
        const clone = tmp.content.cloneNode(true);
        let div_img = clone.querySelector(".img-w img").src = `img/${product.image}`;
        const name = clone.querySelector("h1").innerText = product.name;
        let desc = clone.querySelector(".description");
        let price = clone.querySelector(".price");
        clone.querySelector('button').addEventListener('click', () => { addToCart(product) });
        document.querySelector("#PoductList").appendChild(clone);
        price.innerText = `${product.price}₪`;
        desc.innerText = product.description;

    })

}
const addToCart = (product) => {
    basket = JSON.parse(sessionStorage.getItem('basket') || '[]');
    basket.push(product);
    sessionStorage.setItem("basket", JSON.stringify(basket));
}

async function filterProducts() {
    const categories = [];
    const productName = document.getElementById("nameSearch").value;
    const minPrice = parseInt(document.querySelector("#minPrice").value);
    const maxPrice = parseInt(document.querySelector("#maxPrice").value);
    console.log("nnnnnnnnnnnnnnnnnn",productName, minPrice, maxPrice);
    const checkbox = document.querySelectorAll(".checkBox");
    checkbox.forEach(c => { if (c.querySelector("input").checked) categories.push(parseInt(c.querySelector("input").id)); })
    console.log(categories);
    let url = "api/Products?";
    categories.forEach(category => { url.endsWith("?") ?url += `categories=${category}`:url += `&categories=${category}` });
    if (productName)
        url.endsWith("?") ? url += `productName=${productName}` : url += `&productName=${productName}` 
    if (minPrice)
        url.endsWith("?") ? url += `minPrice=${minPrice}` : url += `&minPrice=${minPrice}` 
    if (maxPrice)
        url.endsWith("?") ? url += `maxPrice=${maxPrice}` : url += `&maxPrice=${maxPrice}` 
    console.log(url + "888888888888888888")
    const res =await fetch(url);
    if (res.ok) {
        const products = await res.json();
        buildProduct(products);
    }
}

