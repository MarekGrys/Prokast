const apiUrl = 'https://prokast-axgwbmd6cnezbmet.polandcentral-01.azurewebsites.net/api/params';

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

// Funkcja wczytująca dane wybranego parametru do formularza
async function loadParameterData() {
    const select = document.getElementById("parameter-select");
    const selectedId = select.value;

    if (selectedId) {
        try {
            const response = await fetch(`${apiUrl}/${selectedId}`, { method: 'GET' });
            if (!response.ok) throw new Error(`Błąd HTTP: ${response.status}`);
            const parameter = await response.json();
            console.log("Dane wybranego parametru (loadParameterData):", parameter);

            document.getElementById("name").value = parameter.name || '';
            document.getElementById("type").value = parameter.type || '';
            document.getElementById("value").value = parameter.value || '';
        } catch (error) {
            console.error("Błąd podczas ładowania danych parametru:", error);
        }
    }
}

// Funkcja zapisania zmian w danych parametru
async function saveParameterData() {
    const select = document.getElementById("parameter-select");
    const selectedId = select.value;

    if (selectedId) {
        const name = document.getElementById("name").value;
        const type = document.getElementById("type").value;
        const value = document.getElementById("value").value;

        const parameterData = { name, type, value };

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
                    method: 'DELETE',
                });

                if (response.ok) {
                    alert("Parametr został usunięty!");
                    location.reload(true); // Odśwież listę parametrów
                     // Wyczyść formularz
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
