const apiothers = 'https://prokast-axgwbmd6cnezbmet.polandcentral-01.azurewebsites.net/api/others';
const apiparams = 'https://prokast-axgwbmd6cnezbmet.polandcentral-01.azurewebsites.net/api/dictionary/Region/';
const apiname = 'https://prokast-axgwbmd6cnezbmet.polandcentral-01.azurewebsites.net/api/dictionary/Name/';

// Funkcja do pobierania listy regionów i wypełnienia listy rozwijanej
async function loadRegions() {
    try {
        const response = await fetch(apiothers, { method: 'GET' });
        if (!response.ok) throw new Error(`Błąd HTTP: ${response.status}`);
        
        const data = await response.json();
        console.log("Odpowiedź z API (loadRegions):", data);

        if (data && data.model && Array.isArray(data.model)) {
            const selectRegion = document.getElementById('region');
            selectRegion.innerHTML = ''; 

            // Dodajemy opcje domyślną
            const defaultOption = document.createElement('option');
            defaultOption.value = '';
            defaultOption.textContent = '-- Wybierz --';
            selectRegion.appendChild(defaultOption);

            // Iterujemy przez listę regionów
            data.model.forEach(region => {
                const option = document.createElement('option');
                option.value = region.id;
                option.textContent = region.name;
                selectRegion.appendChild(option);
            });

            // Dodajemy listener, aby załadować parametry po zmianie regionu
            selectRegion.addEventListener('change', load_params);
        } else {
            console.error('Brak poprawnych danych w odpowiedzi API (model lub lista regionów nie istnieje)');
        }
    } catch (error) {
        console.error('Wystąpił błąd podczas pobierania regionów:', error);
    }
}

// Funkcja do pobierania parametrów na podstawie ID regionu
async function load_params() {
    const paramSelect = document.getElementById('region');
    const paramId = paramSelect.value;

    // Resetujemy listę parametrów i wartości
    const selectParam = document.getElementById('param');
    const selectName = document.getElementById('name');
    
    selectParam.innerHTML = ''; // Czyścimy listę parametrów
    selectName.innerHTML = ''; // Czyścimy listę wartości

    // Ustawiamy domyślną opcję w liście parametrów
    const defaultParamOption = document.createElement('option');
    defaultParamOption.value = '';
    defaultParamOption.textContent = '-- Wybierz --';
    selectParam.appendChild(defaultParamOption);

    // Ustawiamy domyślną opcję w liście wartości
    const defaultNameOption = document.createElement('option');
    defaultNameOption.value = '';
    defaultNameOption.textContent = '-- Wybierz --';
    selectName.appendChild(defaultNameOption);

    if (!paramId) {
        console.log('Region nie został wybrany.');
        return;
    }

    const apiDictionary = `${apiparams}${paramId}`;

    try {
        const response = await fetch(apiDictionary, { method: 'GET' });
        if (!response.ok) throw new Error(`Błąd HTTP: ${response.status}`);
        
        const data = await response.json();
        console.log(`Odpowiedź z API dla regionu ${paramId}:`, data);

        if (data && data.model && Array.isArray(data.model)) {
            data.model.forEach(param => {
                const option = document.createElement('option');
                option.value = param;
                option.textContent = param;
                selectParam.appendChild(option);
            });

            // Dodajemy event listener, aby załadować wartości dla parametru
            selectParam.addEventListener('change', loadNames);
        } else {
            console.error('Brak poprawnych danych w odpowiedzi API (pole model jest nieprawidłowe)');
        }
    } catch (error) {
        console.error('Wystąpił błąd podczas pobierania parametrów:', error);
    }
}

// Funkcja do pobierania nazw na podstawie ID parametru
async function loadNames() {
    const nameSelect = document.getElementById('param');
    const nameId = nameSelect.value;

    if (!nameId) {
        console.log('Nazwa nie została wybrana.');
        return;
    }

    const apiDictionaryName = `${apiname}${nameId}`;

    try {
        const response = await fetch(apiDictionaryName, { method: 'GET' });
        if (!response.ok) throw new Error(`Błąd HTTP: ${response.status}`);
        
        const data = await response.json();
        console.log(`Odpowiedź z API dla wartości ${nameId}:`, data);

        const selectName = document.getElementById('name');
        selectName.innerHTML = ''; // Czyścimy listę

        // Dodajemy opcję domyślną
        const defaultOption = document.createElement('option');
        defaultOption.value = '';
        defaultOption.textContent = '-- Wybierz --';
        selectName.appendChild(defaultOption);

        // Sprawdzamy, czy odpowiedź zawiera pole model
        if (data && data.model && Array.isArray(data.model)) {
            // Iterujemy przez dane w polu model
            data.model.forEach(param => {
                const option = document.createElement('option');
                option.value = param; 
                option.textContent = param;
                selectName.appendChild(option);
            });
        } else {
            console.error('Brak poprawnych danych w odpowiedzi API (pole model jest nieprawidłowe)');
        }
    } catch (error) {
        console.error('Wystąpił błąd podczas pobierania parametrów:', error);
    }
}

// Wywołujemy funkcję podczas ładowania strony
document.addEventListener('DOMContentLoaded', loadRegions);
