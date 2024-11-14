async function login() {
    console.log("Funkcja login została wywołana"); // Sprawdzenie, czy funkcja działa

    const login = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    if (!login || !password) {
        alert('Proszę wypełnić wszystkie pola.');
        return;
    }

    try {
        const response = await fetch('https://prokast-axgwbmd6cnezbmet.polandcentral-01.azurewebsites.net/api/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ login, password })
        });

        console.log("Otrzymano odpowiedź z API"); 

        // Sprawdzenie odpowiedzi z serwera
        if (response.ok) {
            
            const text = await response.text(); 
            const data = text ? JSON.parse(text) : {}; 
            
            window.location.href = '/Prokast.Klient/main_page/main.html';
            console.log("Zalogowano pomyślnie", data); 
            localStorage.setItem('authToken', data.token);
            alert('Zalogowano pomyślnie');

            
        } 
        else {
            console.log("Nieudane logowanie, status:", response.status);
            alert('Błąd logowania! Sprawdź dane logowania.');
        }
    } 
    catch (error) {
        console.error('Wystąpił błąd:', error); 
        alert('Wystąpił błąd: ' + error.message);
    }
}
