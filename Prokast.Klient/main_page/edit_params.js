const apiUrl = 'https://prokast-axgwbmd6cnezbmet.polandcentral-01.azurewebsites.net/api/params';

let currentParameterName = ''; // Przechowuje nazwę wybranego parametru

// Funkcja ładowania parametrów do listy rozwijanej
async function loadParameters() {
    try {
        const response = await fetch(apiUrl, { method: 'GET' });
        if (!response.ok) throw new Error(`Błąd HTTP: ${response.status}`);
        const data = await response.json();
        console.log("Odpowiedź z API (loadParameters):", data);

        if (Array.isArray(data.model)) {
            const parameters = data.model;
            const select = document.getElementById("parameter-select");
            select.innerHTML = '';

            parameters.forEach(parameter => {
                const option = document.createElement("option");
                option.value = parameter.id;
                option.textContent = parameter.name;
                select.appendChild(option);
            });

            if (parameters.length > 0) {
                select.value = parameters[0].id;
                await loadParameterData();
            }
        } else {
            console.error("Odpowiedź z API nie zawiera tablicy w polu 'model'.");
        }
    } catch (error) {
        console.error("Błąd podczas ładowania parametrów:", error);
    }
}

async function loadParameterData() {
    const select = document.getElementById("parameter-select");
    const selectedId = select.value;

    if (selectedId) {
        try {
            // Pobierz dane parametru z API
            const response = await fetch(`${apiUrl}/${selectedId}`, { method: 'GET' });
            if (!response.ok) throw new Error(`Błąd HTTP: ${response.status}`);
            const parameter = await response.json();

            console.log("Dane wybranego parametru (loadParameterData):", parameter);

            // Pobierz dane modelu z odpowiedzi API
            const modelData = parameter.model?.[0]; // Zakładamy, że model to tablica, bierzemy pierwszy element

            if (modelData) {
                // Pobierz nazwę parametru z wybranej opcji w select
                currentParameterName = select.options[select.selectedIndex].textContent || '';

                // Wypełnij pola formularza danymi z serwera
                document.getElementById("type").value = modelData.type || ''; // Wczytaj rodzaj
                document.getElementById("value").value = modelData.value || ''; // Wczytaj wartość

                console.log("Wartość currentParameterName z select:", currentParameterName);
                console.log("Wartość type z modelu:", modelData.type);
                console.log("Wartość value z modelu:", modelData.value);
            } else {
                console.error("Model danych jest pusty lub brak danych w odpowiedzi.");
            }
        } catch (error) {
            console.error("Błąd podczas ładowania danych parametru:", error);
        }
    }
}

async function saveParameterData() {
    const select = document.getElementById("parameter-select");
    const selectedId = select.value;

    if (selectedId) {
        const type = document.getElementById("type").value;
        const value = document.getElementById("value").value;

        console.log("Wartość name:", currentParameterName); // Debugowanie
        console.log("Wartość type:", type); // Debugowanie
        console.log("Wartość value:", value); // Debugowanie

        // Sprawdź, czy wszystkie wymagane pola są wypełnione
        if (
            typeof currentParameterName !== 'string' || currentParameterName.trim() === '' ||
            typeof type !== 'string' || type.trim() === '' ||
            typeof value !== 'string' || value.trim() === ''
        ) {
            alert("Wszystkie pola muszą być wypełnione.");
            return;
        }

        const parameterData = { 
            name: currentParameterName, // Dodaj nazwę parametru
            type, 
            value 
        };

        console.log("Wysyłane dane:", parameterData); // Debugowanie danych

        try {
            const response = await fetch(`${apiUrl}/${selectedId}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(parameterData)
            });

            if (response.ok) {
                alert("Parametr został zaktualizowany!");
            } else {
                const errorText = await response.text();
                console.error("Szczegóły błędu:", errorText); // Debugowanie błędu
                alert(`Błąd: ${errorText}`);
            }
        } catch (error) {
            console.error("Błąd podczas zapisywania danych parametru:", error);
        }
    }
}

// Funkcja usuwająca wybrany parametr
async function deleteParameter() {
    const select = document.getElementById("parameter-select");
    const selectedId = select.value;

    if (selectedId) {
        const confirmDelete = confirm("Czy na pewno chcesz usunąć wybrany parametr?");
        if (confirmDelete) {
            try {
                const response = await fetch(`${apiUrl}/${selectedId}`, {
                    method: 'DELETE'
                });

                if (response.ok) {
                    alert("Parametr został usunięty!");
                    loadParameters(); // Odśwież listę parametrów
                    // Wyczyść formularz
                    document.getElementById("type").value = '';
                    document.getElementById("value").value = '';
                } else if (response.status === 404) {
                    alert("Parametr nie istnieje.");
                } else {
                    const errorText = await response.text();
                    alert(`Błąd podczas usuwania: ${errorText}`);
                }
            } catch (error) {
                console.error("Błąd podczas usuwania parametru:", error);
            }
        }
    }
}

document.getElementById("parameter-select").addEventListener("change", loadParameterData);
document.getElementById("save-button").addEventListener("click", saveParameterData);
document.getElementById("delete-button").addEventListener("click", deleteParameter);

window.onload = loadParameters;
