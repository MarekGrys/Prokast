function initializeMasks() {
    
    const phoneElement = document.getElementById('Phone_Number');
    if (phoneElement) {
        IMask(phoneElement, { mask: '000-000-000' });
    }

    
    const postalCodeElement = document.getElementById('Postal_Code');
    if (postalCodeElement) {
        IMask(postalCodeElement, { mask: '00-000' });
    }

    const NIPElement = document.getElementById('NIP');
    if (NIPElement) {
        IMask(NIPElement, { mask: 'PL-00-000000-0' });
    }
    
}

document.addEventListener('DOMContentLoaded', initializeMasks);

