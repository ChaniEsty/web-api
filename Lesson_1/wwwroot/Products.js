
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
        let tmp = document.querySelector("#temp-category");
        let clone = tmp.content.cloneNode(true);
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
        let tmp = document.querySelector("#temp-card");
        let clone = tmp.content.cloneNode(true);
        let div_img = clone.querySelector(".img-w");
        let desc = clone.querySelector(".description");
        let price = clone.querySelector(".price");
        document.body.appendChild(clone);
        console.log(product.name)
        price.innerText = product.price;
        desc.innerText = product.description;
        //img.innerText=
    })
}

