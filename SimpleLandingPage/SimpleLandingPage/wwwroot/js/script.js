/**
 * script.js
 * Mengatur interaksi Landing Page: Smooth Scroll, Navbar Scroll, dan Form Submission.
 */

document.addEventListener('DOMContentLoaded', function () {

    // --- 1. SMOOTH SCROLL UNTUK LINK NAVIGASI ---
    // Mengatur agar scroll terasa halus saat menekan menu navigasi
    const anchorLinks = document.querySelectorAll('a[href^="#"]');

    anchorLinks.forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();

            const targetId = this.getAttribute('href');
            if (targetId === '#') return;

            const targetElement = document.querySelector(targetId);
            if (targetElement) {
                window.scrollTo({
                    // Offset -80 untuk menyesuaikan dengan tinggi navbar fixed
                    top: targetElement.offsetTop - 80,
                    behavior: 'smooth'
                });
            }
        });
    });

    // --- 2. NAVBAR BACKGROUND PADA SAAT SCROLL ---
    // Mengubah tampilan navbar (misal: menambah bayangan) saat halaman di-scroll
    const navbar = document.querySelector('.navbar');

    window.addEventListener('scroll', function () {
        if (window.scrollY > 100) {
            navbar.classList.add('navbar-scrolled');
        } else {
            navbar.classList.remove('navbar-scrolled');
        }
    });

    // --- 3. FEEDBACK PENGIRIMAN FORMULIR ---
    // Menangani interaksi tombol saat formulir kontak dikirim
    const contactForm = document.querySelector('.contact-form');

    if (contactForm) {
        contactForm.addEventListener('submit', function (e) {
            const submitButton = this.querySelector('button[type="submit"]');
            const originalText = submitButton.innerHTML;

            // Tampilkan status loading
            submitButton.innerHTML = '<i class="fas fa-spinner fa-spin me-2"></i>Mengirim...';
            submitButton.disabled = true;

            // Simulasi keterlambatan server (delay)
            setTimeout(() => {
                submitButton.innerHTML = originalText;
                submitButton.disabled = false;

                // Catatan: Form akan diproses oleh backend ASP.NET setelah ini
            }, 2000);
        });
    }

    // --- 4. INISIALISASI BOOTSTRAP TOOLTIPS ---
    // Mengaktifkan fitur tooltip Bootstrap di seluruh halaman
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });

});