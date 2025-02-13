
function openWindow(url) {
    window.open(url, '_blank', 'width=800,height=600,resizable=yes,scrollbars=yes');
}
function dialogShow(dialogId) {
    const dialog = document.getElementById(dialogId);
    if (dialog) {
        dialog.showModal(); // Dialog'u modal olarak a�ar
    }
}

function dialogClose(dialogId) {
    const dialog = document.getElementById(dialogId);
    if (dialog) {
        dialog.close(); // Dialog'u kapat�r
    }
}
function openPdfBlob(base64Data) {
    const blob = new Blob([base64Data], { type: 'application/pdf' });
    const url = URL.createObjectURL(blob);
    window.open(url, '_blank');
}
window.getFileList = (inputElement) => {
    const files = [];
    const fileList = inputElement.files;
    for (let i = 0; i < fileList.length; i++) {
        files.push(fileList[i].webkitRelativePath); // Dosyan�n klas�r i�indeki g�receli yolu
    }
    return files;
};