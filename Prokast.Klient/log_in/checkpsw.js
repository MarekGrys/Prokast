const passwordInput = document.getElementById("Password");
const confirmPasswordInput = document.getElementById("Password2");
const message = document.getElementById("passwordMessage"); 


function checkPasswords() {
    const password = passwordInput.value;
    const confirmPassword = confirmPasswordInput.value;

    if (password === confirmPassword && password.length > 0) {
        message.textContent = "Hasła są zgodne!";
        message.className = "message success";
        return true;
    } else if (confirmPassword.length > 0) {
        message.textContent = "Hasła się różnią!";
        message.className = "message error";
        return false;
    } else {
        message.textContent = ""; 
        return false;
    }
}


function validateAndRegister() {
    if (checkPasswords()) {
        registration();
    }
}

// Nasłuchiwanie na zmiany w polach "Hasło" i "Powtórz hasło"
passwordInput.addEventListener("input", checkPasswords);
confirmPasswordInput.addEventListener("input", checkPasswords);
