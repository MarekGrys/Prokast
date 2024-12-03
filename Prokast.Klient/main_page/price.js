// Elementy modalne
const modal = document.getElementById("modal");
const openButton = document.getElementById("button");
const closeButton = document.getElementById("closeModal");

// Funkcja otwierająca modal
openButton.addEventListener("click", () => {
    modal.style.display = "block";
});

// Funkcja zamykająca modal
closeButton.addEventListener("click", () => {
    modal.style.display = "none";
});

// Zamknięcie modalu po kliknięciu poza jego obszarem
window.addEventListener("click", (event) => {
    if (event.target === modal) {
        modal.style.display = "none";
    }
});


const apiPriceList = 'https://prokast-axgwbmd6cnezbmet.polandcentral-01.azurewebsites.net/api/priceLists?clientID=1';

async function PriceListNamePOST() {
    const name = document.getElementById("name").value;
    
    const PriceListData = {
        Name: name
    };
    
    try{
        const response = await fetch(apiPriceList, {
            method:'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(PriceListData)
            });

            console.log("Otrzymano odpowiedź z API");

            if (response.ok) {
                alert('Cennik został zapisany');
                window.location.href = 'price.html'; 
            } else {
                const errorText = await response.text();
                console.error('Błąd wprowadzenia danych:', errorText);
                alert(`Wystąpił błąd: ${response.status}`);
            }
        } catch (error) {
            console.error('Błąd połączenia z serwerem:', error);
            alert('Błąd połączenia z serwerem.');
        }
}

async function PriceListNameGET() {
    try{
        const response = await fetch(apiPriceList,{method: 'GET'});
        if (!response.ok) throw new Error (`Błąd HTTP; ${response.status}`);
        
        const data = await response.json();
        console.log("Odpowiedź z APi (PriceListNameGet):", data);
        if (data && data.model && Array.isArray(data.model)) {
            const selectRegion = document.getElementById('data-display');
            selectRegion.innerHTML = ''; 


            data.model.forEach(name => {
                const option = document.createElement('option');
                option.value = name.id;
                option.textContent = name.name;
                selectRegion.appendChild(option);
            });

        } else {
            console.error('Brak poprawnych danych w odpowiedzi API ');
        }
    }catch (error) {
        console.error('Wystąpił błąd podczas pobierania cenników:', error);
    }
    
}

document.addEventListener('DOMContentLoaded', PriceListNameGET);
