
const loadData = async () => {
    await getCategories();
    await getProducts();
}
window.addEventListener("load", loadData)
const getCategories = async () => {
    const res = await fetch("https://localhost:44351/api/categories");
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
const buildProduct = async (products) => {
    products.forEach(product => {
        const tmp = document.querySelector("#temp-card");
        const clone = tmp.content.cloneNode(true);
        let div_img = clone.querySelector(".img-w img").src = `img/${product.image}`;
        const name = clone.querySelector("h1").innerText=product.name;
        let desc = clone.querySelector(".description");
        let price = clone.querySelector(".price");
        document.body.appendChild(clone);
        console.log(product.name)
        price.innerText = `${product.price}₪`;
        desc.innerText = product.description;
       //div_img.src = `img/${product.img}`;
    })
    const filter = () => {
        console.log("filter");
    }
}

