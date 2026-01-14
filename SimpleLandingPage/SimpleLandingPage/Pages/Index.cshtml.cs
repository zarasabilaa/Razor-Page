using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Diperlukan untuk validasi form
using System.Collections.Generic; // Diperlukan untuk List<>

namespace SimpleLandingPage.Pages
{
    public class IndexModel : PageModel
    {
        // Properti untuk data
        public string WelcomeMessage { get; set; } = "Selamat Datang!";
        public string Tagline { get; set; } = "Kami membuat website yang luar biasa";

        // Data untuk services
        public List<Service> Services { get; set; }

        // Data untuk portfolio
        public List<PortfolioItem> PortfolioItems { get; set; }

        // Model untuk contact form
        [BindProperty]
        public ContactForm Contact { get; set; }

        public bool IsSubmitted { get; set; } = false;

        public void OnGet()
        {
            // Inisialisasi data saat page load
            InitializeData();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                InitializeData();
                return Page();
            }

            // Simulasi: Simpan data kontak
            // Di aplikasi nyata, simpan ke database
            IsSubmitted = true;

            // Reset form setelah submit
            Contact = new ContactForm();
            ModelState.Clear();

            InitializeData();
            return Page();
        }

        private void InitializeData()
        {
            // Data untuk services
            Services = new List<Service>
            {
                new Service
                {
                    Icon = "fas fa-laptop-code",
                    Title = "Web Development",
                    Description = "Kami membuat website responsif dan modern dengan teknologi terbaru."
                },
                new Service
                {
                    Icon = "fas fa-mobile-alt",
                    Title = "Mobile Apps",
                    Description = "Pengembangan aplikasi mobile untuk iOS dan Android."
                },
                new Service
                {
                    Icon = "fas fa-chart-line",
                    Title = "Digital Marketing",
                    Description = "Strategi pemasaran digital untuk meningkatkan penjualan."
                },
                new Service
                {
                    Icon = "fas fa-paint-brush",
                    Title = "UI/UX Design",
                    Description = "Desain antarmuka yang menarik dan mudah digunakan."
                }
            };

            // Data untuk portfolio
            PortfolioItems = new List<PortfolioItem>
            {
                new PortfolioItem
                {
                    Title = "E-commerce Website",
                    Category = "Web Development",
                    ImageUrl = "https://via.placeholder.com/400x300"
                },
                new PortfolioItem
                {
                    Title = "Mobile Banking App",
                    Category = "Mobile Apps",
                    ImageUrl = "https://via.placeholder.com/400x300"
                },
                new PortfolioItem
                {
                    Title = "Corporate Website",
                    Category = "Web Development",
                    ImageUrl = "https://via.placeholder.com/400x300"
                }
            };
        }
    }

    // --- Definisi Model ---

    // Model untuk Service
    public class Service
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    // Model untuk Portfolio
    public class PortfolioItem
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
    }

    // Model untuk Contact Form dengan Validasi
    public class ContactForm
    {
        [Required(ErrorMessage = "Nama wajib diisi")]
        [Display(Name = "Nama Lengkap")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email wajib diisi")]
        [EmailAddress(ErrorMessage = "Format email tidak valid")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pesan wajib diisi")]
        [Display(Name = "Pesan")]
        [StringLength(500, ErrorMessage = "Maksimal 500 karakter")]
        public string Message { get; set; }
    }
}