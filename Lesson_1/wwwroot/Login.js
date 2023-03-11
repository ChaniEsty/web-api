const signUp = async () => {
    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    let firstName = document.getElementById("firstName").value;
    let lastName = document.getElementById("lastName").value;
   let user = JSON.stringify({email, password,  firstName,  lastName })
   // let user = { email: email, password: password, firstName: firstName, lastName: lastName }
    const res = await fetch("api/Users",
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: user
        })
    if (res.status == 200) {
        alert("user addded");
           }
    else
        alert("error in details");

}
const newUser = () => {

    document.getElementById("register").style.visibility = "visible"

}


const signIn = async () => {

    let email = document.getElementById("userNameLogIn").value;
    let password = document.getElementById("userPasswordLogIn").value;


    let User =JSON.stringify({  email,  password, });
    const res = await fetch("api/Users/signIn",
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: User
        })
    alert("just checking")
    if (res.ok) {
        const user = await res.json();
        sessionStorage.setItem('user', JSON.stringify(user));
        alert("loged in");
        document.location = "/UserDetails.html";
    }
}


const load = async () => {

    const user = await JSON.parse(sessionStorage.getItem('user'));
    document.getElementById('email').setAttribute('value', user.email);
    document.getElementById('password').setAttribute('value', user.password);
    document.getElementById('firstName').setAttribute('value', user.firstName);
    document.getElementById('lastName').setAttribute('value', user.lastName);
}
const update = async () => {

    let email = document.getElementById("email").value;
    let password = document.getElementById("password").value;
    let firstName = document.getElementById("firstName").value;
    let lastName = document.getElementById("lastName").value;
    let id = await JSON.parse(sessionStorage.getItem('user')).userId
    let userId=id
    let user = JSON.stringify({ userId,email, password, firstName, lastName})
    

    const response = await fetch(`api/users/${id}`,
        {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: user
        })



}



