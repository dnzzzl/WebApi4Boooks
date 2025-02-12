using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebApi4Boooks.Models;
using BoooksUI.Models;
using System.Diagnostics;

namespace BoooksUI.Controllers
{
    public class BoooksController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<BoooksController> _logger;
        private readonly string _apiBaseUrl = "http://localhost:5044/api/Boooks"; // Adjust the port as needed

        public BoooksController(HttpClient httpClient, ILogger<BoooksController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        // GET: BoooksController
        public async Task<ActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiBaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var books = JsonSerializer.Deserialize<IEnumerable<Boook>>(content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(books);
                }

                _logger.LogWarning("API returned status code: {StatusCode}", response.StatusCode);
                return View("Error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving books list");
                return View("Error", new ErrorViewModel()
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                });
            }
        }

        // GET: BoooksController/Detalle/5
        public async Task<ActionResult> Detalle(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var book = JsonSerializer.Deserialize<Boook>(content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(book);
                }

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return NotFound();
                }

                return View("Error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving book details for ID: {Id}", id);
                return View("Error",new ErrorViewModel()
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                });
            }
        }

        // GET: BoooksController/Create
        public ActionResult Create()
        {
            return View(new Boook());
        }

        // POST: BoooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Boook book)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(book);
                }

                var json = JsonSerializer.Serialize(book);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(_apiBaseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "Failed to create book. Please try again.");
                return View(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new book");
                return View("Error", new ErrorViewModel()
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                });
            }
        }

        // GET: BoooksController/Edit/5
        public async Task<ActionResult> Editar(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var book = JsonSerializer.Deserialize<Boook>(content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return View(book);
                }

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return NotFound();
                }

                return View("Error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving book for edit, ID: {Id}", id);
                return View("Error", new ErrorViewModel()
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                });
            }
        }

        // POST: BoooksController/Edit
        [HttpPost]
        public ActionResult Editar([FromBody]Boook book)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var json = JsonSerializer.Serialize(book);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = _httpClient.PutAsync($"{_apiBaseUrl}/{book.Id}", content).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }

                ModelState.AddModelError("", "Failed to update book. Please try again.");
                return View(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating book ID: {Id}", book.Id);
                return View("Error", new ErrorViewModel()
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                });
            }
        }

        // POST: BoooksController/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_apiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }

                ModelState.AddModelError("", "Failed to delete book. Please try again.");
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting book ID: {Id}", id);
                return View(new ErrorViewModel()
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                });
            }
        }
    }
}