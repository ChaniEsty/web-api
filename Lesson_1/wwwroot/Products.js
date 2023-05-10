
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
    categories.map(category => {
        let tmp = document.querySelector("#temp-category");
        let clone = tmp.content.cloneNode(true);
        document.getElementById("categoryList").appendChild(clone);
        let span = clone.querySelector(".OptionName");
        console.log(category.name)
        //let input = document.body.getElementsByTagName("input")[0];
        span.textContent = category.name;
    })
}
const getProducts = async () => {
    const res = await fetch("api/products");
    if (res.ok) {
        const products =await res.json();
        console.log(products);
    }
}
const buildProduct = async (products) => {
    products.map(product => {

    })

    
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
    categories.forEach(category => { url += `&categories=${category}` });
    if (productName)
        url += `&productName = ${ productName }`
    if (minPrice)
        url += `&minPrice = ${minPrice}`
    if (maxPrice)
        url += `&maxPrice = ${maxPrice}`
    console.log(url + "888888888888888888")
    const res =await fetch(url);
    if (res.ok) {
        const products = await res.json();
        buildProduct(products);
    }
}

