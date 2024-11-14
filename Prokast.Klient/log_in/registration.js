async function registration() {
    const Login = document.getElementById("Login").value;
    const Password = document.getElementById("Password").value;
    const FirstName = document.getElementById('FirstName').value;
    const LastName = document.getElementById('LastName').value;
    const BusinessName = document.getElementById('BusinessName').value;
    const NIP = document.getElementById('NIP').value;
    const Address = document.getElementById('Address').value;
    const PhoneNumber = document.getElementById('PhoneNumber').value;
    const PostalCode = document.getElementById('PostalCode').value;
    const City = document.getElementById('City').value;
    const Country = document.getElementById('Country').value;
    


    const userData = {
        login: Login,
        password: Password,
        firstName: FirstName,
        lastName: LastName,
        businessName: BusinessName,
        nip: NIP,
        address: Address,
        phoneNumber: PhoneNumber,
        postalCode: PostalCode,
        city: City,
        country: Country
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
