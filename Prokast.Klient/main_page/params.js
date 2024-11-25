async function params() {
    const name = document.getElementById("name").value;
    const type = document.getElementById("type").value;
    const value = document.getElementById("value").value;
    
    
    const paramsData = {
        Name : name,
        Type : type,
        Value : value
    };

    try {
        const response = await fetch('https://prokast-axgwbmd6cnezbmet.polandcentral-01.azurewebsites.net/api/params',{
            method:  'POST',
            headers: {
                'Content-Type' : 'application/json'
            },
            body: JSON.stringify(paramsData)
        });

        console.log("Otrzymano odpowiedź z API");

        if (response.ok) {
            alert('Dodanie parametru powiodło się!');
            window.location.href = 'params.html'; 
        } else {
            const errorText = await response.text();
            console.error('Błąd wprowadzenia parametru:', errorText);
            alert(`Błąd wprowadzania danych: ${response.status}`);
        }
        
    } catch (error){
        console.error('Błąd połączenia z serwerem', error);
        alert('Błąd połączenia z serwerem');

    }


}