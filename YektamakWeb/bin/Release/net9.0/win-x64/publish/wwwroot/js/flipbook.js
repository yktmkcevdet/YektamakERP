// wwwroot/js/flipbook.js
window.flipBook = {
    init: async function (pdfUrl, elementId, opts) {
        try {
            const pdfjsLib = window['pdfjs-dist/build/pdf'];
            if (!pdfjsLib) {
                console.error("PDF.js bulunamadı. PDF.js script'inin yüklü olduğundan emin ol.");
                return;
            }
            pdfjsLib.GlobalWorkerOptions.workerSrc =
                'https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.16.105/pdf.worker.min.js';

            const container = document.getElementById(elementId);
            if (!container) {
                console.error("Container element bulunamadı:", elementId);
                return;
            }

            // PageFlip sınıfını tespit et (script-tag: St.PageFlip, module: PageFlip)
            const PageFlipClass = window.St?.PageFlip ?? window.PageFlip ?? window.PageFlip;
            if (!PageFlipClass) {
                console.error("PageFlip kütüphanesi bulunamadı. page-flip JS dosyasını flipbook.js'den önce yükleyin.");
                return;
            }

            const config = Object.assign({
                width: 600,
                height: 850,
                size: "stretch",
                minWidth: 315,
                maxWidth: 600,
                maxHeight: 850,
                showCover: true,
                mobileScrollSupport: false,
            }, opts || {});

            const pageFlip = new PageFlipClass(container, config);
            console.log("PageFlip instance created:", pageFlip);

            // PDF yükle & tüm sayfaları render edip image array topla
            const pdf = await pdfjsLib.getDocument(pdfUrl).promise;
            const totalPages = pdf.numPages;
            const images = [];

            for (let i = 1; i <= totalPages; i++) {
                const page = await pdf.getPage(i);
                const viewport = page.getViewport({ scale: 1.5 });
                const canvas = document.createElement("canvas");
                const ctx = canvas.getContext("2d");
                canvas.width = viewport.width;
                canvas.height = viewport.height;

                await page.render({ canvasContext: ctx, viewport }).promise;
                images.push(canvas.toDataURL("image/png"));
            }

            // ÖNEMLİ: bütün image URL'lerini tek seferde yükle
            pageFlip.loadFromImages(images);

            // render/güncelleme çağrıları (varsa)
            if (typeof pageFlip.update === 'function') pageFlip.update();
            if (typeof pageFlip.flip === 'function') pageFlip.flip(0); // ilk sayfaya animasyonlu geçiş
            console.log("Flipbook hazır. Sayfa sayısı:", images.length);
        } catch (err) {
            console.error("flipBook.init hata:", err);
        }
    }
};
