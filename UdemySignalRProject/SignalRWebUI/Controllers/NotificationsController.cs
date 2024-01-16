using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.NotificationDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class NotificationsController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public NotificationsController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7026/api/Notification");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
				return View(values);
			}

			return View();
		}

		[HttpGet]
		public IActionResult CreateNotification()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createNotificationDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7026/api/Notification", stringContent);

			if (responseMessage.IsSuccessStatusCode)
				return RedirectToAction("Index", "Notifications");

			return View();
		}

		public async Task<IActionResult> DeleteNotification(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7026/api/Notification/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Notifications");
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateNotification(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7026/api/Notification/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);
				return View(values);
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateNotificationDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7026/api/Notification/", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Notifications");
			}

			return View();
		}

		public async Task<IActionResult> NotificationStatusChangeToTrue(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7026/api/Notification/NotificationStatusChangeToTrue/{id}");

			return RedirectToAction("Index", "Notifications");
		}

		public async Task<IActionResult> NotificationStatusChangeToFalse(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7026/api/Notification/NotificationStatusChangeToFalse/{id}");

			return RedirectToAction("Index", "Notifications");
		}
	}
}
