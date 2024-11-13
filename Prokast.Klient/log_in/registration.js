async function registration() {
    const Login = document.getElementById("Login").value;
    const FirstName = document.getElementById('First_Name').value;
    const lastName = document.getElementById('Last_Name').value;
    const businessName = document.getElementById('Buisness_Name').value;
    const nip = document.getElementById('NIP').value;
    const address = document.getElementById('Address').value;
    const phoneNumber = document.getElementById('Phone_Number').value;
    const postalCode = document.getElementById('Postal_Code').value;
    const city = document.getElementById('City').value;
    const country = document.getElementById('Country').value;


    const userData = {
        login: Login,
        firstName: FirstName,
        lastName: lastName,
        businessName: businessName,
        nip: nip,
        address: address,
        phoneNumber: phoneNumber,
        postalCode: postalCode,
        city: city,
        country: country
    };

    try {
        const response = await fetch('https://prokast-axgwbmd6cnezbmet.polandcentral-01.azurewebsites.net/api/client', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userData)
        });

        console.log("Otrzymano odpowiedź z API");

        if (response.ok) {
            alert('Rejestracja powiodła się!');
            window.location.href = 'login.html'; 
        } else {
            const errorText = await response.text();
            console.error('Błąd rejestracji:', errorText);
            alert(`Błąd rejestracji: ${response.status}`);
        }
    } catch (error) {
        console.error('Błąd połączenia z serwerem:', error);
        alert('Błąd połączenia z serwerem.');
    }
}
