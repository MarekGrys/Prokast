function initializeMasks() {
    
    const phoneElement = document.getElementById('PhoneNumber');
    if (phoneElement) {
        IMask(phoneElement, { mask: '000-000-000' });
    }

    
    const postalCodeElement = document.getElementById('PostalCode');
    if (postalCodeElement) {
        IMask(postalCodeElement, { mask: '00-000' });
    }

    const NIPElement = document.getElementById('NIP');
    if (NIPElement) {
        IMask(NIPElement, { mask: 'PL-000-000000-0' });
    }
    
}

document.addEventListener('DOMContentLoaded', initializeMasks);

