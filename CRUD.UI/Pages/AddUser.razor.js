export function DeleteUser(id) {
    window.location.reload();
}

export function GetUserName(id) {
    let res = document.getElementById(id).value;
    return res
}

export function GetFamilyName(id) {
    let res = document.getElementById(id).value;
    return res
}

export function ValidationError() {
    alert("User name or family name should not be null or empty");
}

export function Faild() {
    alert("Faild. please try again");
}
