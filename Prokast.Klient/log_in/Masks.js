// Funkcja inicjująca maski dla różnych pól
function initializeMasks() {
    // Maskowanie numeru telefonu (np. 123-456-789)
    const phoneElement = document.getElementById('Phone_Number');
    if (phoneElement) {
        IMask(phoneElement, { mask: '000-000-000' });
    }

    // Maskowanie kodu pocztowego (np. 12-345)
    const postalCodeElement = document.getElementById('Postal_Code');
    if (postalCodeElement) {
        IMask(postalCodeElement, { mask: '00-000' });
    }

}

// Inicjalizacja masek po załadowaniu dokumentu
document.addEventListener('DOMContentLoaded', initializeMasks);
