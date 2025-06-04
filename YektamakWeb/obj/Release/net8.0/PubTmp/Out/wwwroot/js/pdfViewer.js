function showPdf(pdfData) {
        const iframe = document.getElementById('pdfViewer');
        if (iframe) {
            const blob = new Blob([new Uint8Array(pdfData)], { type: 'application/pdf' });
            const url = URL.createObjectURL(blob);
            iframe.src = url;
        } else {
            console.error("iframe bulunamadı!");
        }
    
}