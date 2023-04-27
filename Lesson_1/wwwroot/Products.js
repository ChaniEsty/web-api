
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
        let tmp = document.querySelector(template);
        let clone = tmp.content.cloneNode(true);
        clone.getElementsByTagName("input")
        document.body.appendChild(clone);
        document.body.getElementsByTagName
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