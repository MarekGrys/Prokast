async function login() {
    console.log("Funkcja login została wywołana"); // Sprawdzenie, czy funkcja działa

    const login = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    // Sprawdzenie, czy pola nie są puste
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
            credentials: 'include', 
            body: JSON.stringify({ login, password })
        });

        console.log("Otrzymano odpowiedź z API"); // Sprawdzenie, czy odpowiedź została odebrana

        // Sprawdzenie odpowiedzi z serwera
        if (response.ok) {
            const data = await response.json();
            console.log("Zalogowano pomyślnie", data); // Potwierdzenie poprawnego logowania
            alert('Zalogowano pomyślnie');
            localStorage.setItem('authToken', data.token);

            
            window.location.href = '/strona-glowna.html';
        } 
        
        else {
            console.log("Nieudane logowanie, status:", response.status); //  Błędu logowania
            alert('Błąd logowania! Sprawdź dane logowania.');
        }
    } 
    catch (error) {
        console.error('Wystąpił błąd:', error); 
        alert('Nie umiesz to nie rób');
    }
}
